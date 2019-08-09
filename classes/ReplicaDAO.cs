using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAppEventiCrociera.classes
{
    public class ReplicaDAO
    {

        //public void InsertReplica(Replica oReplica)
        //{
        //    string query = "INSERT INTO REPLICHE VALUES('" + oReplica.codReplica + "','" + oReplica.codEvento + "','" + oReplica.dataEOra + "')";

        //    DBConnection oDBConnection = new DBConnection();
        //    oDBConnection.ExecuteNonQuery(query);
        //}

        public List<Replica> GetAllRepliche()
        {
            List<Replica> listaRepliche = new List<Replica>();

            string sQuery = "SELECT R.CodReplica, R.CodEvento, R.DataEOra, e.CodLocale, E.NomeEvento, E.Annullato, L.Nome, L.Luogo, L.Posti" +
                            " FROM REPLICHE R" +
                            " INNER JOIN EVENTI E ON E.CodEvento = R.CodEvento" +
                            " INNER JOIN LOCALI L ON L.CodLocale = E.CodLocale" +
                            " ORDER BY DataEOra; ";
            DBConnection d = new DBConnection();
            DataTable dt = d.DoQuerySelect(sQuery);

            foreach (DataRow dr in dt.Rows)
            {
                Replica oReplica = new Replica();
                oReplica.codReplica = dr["CodReplica"].ToString();
                oReplica.codEvento = dr["CodEvento"].ToString();
                oReplica.dataEOra = Convert.ToDateTime(dr["DataEOra"]);
                oReplica.codLocale = dr["CodLocale"].ToString();
                oReplica.nomeEvento = dr["NomeEvento"].ToString();
                oReplica.nomeLocale = dr["Nome"].ToString();
                oReplica.luogo = dr["Luogo"].ToString();
                oReplica.posti = Convert.ToInt32(dr["Posti"]);

                listaRepliche.Add(oReplica);
            }
            return listaRepliche;
        }

        public List<Replica> GetAllReplicheDisponibili()
        {
            List<Replica> listaReplicheDisponibili = new List<Replica>();

            string sQuery = "SELECT R.CodReplica, R.CodEvento, R.DataEOra, e.CodLocale, E.NomeEvento, E.Annullato, L.Nome, L.Luogo, L.Posti " +
                            " FROM REPLICHE R" +
                            " INNER JOIN EVENTI E ON E.CodEvento = R.CodEvento" +
                            " INNER JOIN LOCALI L ON L.CodLocale = E.CodLocale" +
                            " WHERE E.Annullato = 0" +
                            " ORDER BY DataEOra; ";
            DBConnection d = new DBConnection();
            DataTable dt = d.DoQuerySelect(sQuery);

            foreach (DataRow dr in dt.Rows)
            {
                Replica oReplica = new Replica();
                oReplica.codReplica = dr["CodReplica"].ToString();
                oReplica.codEvento = dr["CodEvento"].ToString();
                oReplica.dataEOra = Convert.ToDateTime(dr["DataEOra"]);
                oReplica.codLocale = dr["CodLocale"].ToString();
                oReplica.nomeEvento = dr["NomeEvento"].ToString();
                oReplica.nomeLocale = dr["Nome"].ToString();
                oReplica.luogo = dr["Luogo"].ToString();
                oReplica.posti = Convert.ToInt32(dr["Posti"]);

                listaReplicheDisponibili.Add(oReplica);
            }
            return listaReplicheDisponibili;
        }


        public void DeleteReplica(string codReplica)
        {
            string sQuery = "DELETE FROM REPLICHE WHERE CodReplica=" + codReplica + ";";
            DBConnection d = new DBConnection();
            d.ExecuteNonQuery(sQuery);
        }


        //public void UpdateReplica(Replica oReplica)
        //{
        //    string sQuery = @"UPDATE REPLICHE SET Nome='" + oReplica.nome +
        //        "',Cognome='" + oReplica.cognome +
        //        "' WHERE CodReplica='" + oReplica.codReplica + "';";
        //    DBConnection d = new DBConnection();
        //    d.ExecuteNonQuery(sQuery);
        //}

        public Replica GetReplicaById(string codReplica)
        {

            string sQuery = "SELECT DISTINCT R.CodReplica, R.CodEvento, R.DataEOra, e.CodLocale, E.NomeEvento, E.Annullato, L.Nome, L.Luogo,L.Posti Capienza, (L.Posti-totaliPrenotati) Posti"+
                            " FROM REPLICHE R "+
                            " INNER JOIN EVENTI E ON E.CodEvento = R.CodEvento"+
                            " INNER JOIN LOCALI L ON L.CodLocale = E.CodLocale" +
                            " left join prenotazioni p on p.CodReplica = r.CodReplica "+
                            " left join(Select CodReplica, sum(quantita) totaliPrenotati from PRENOTAZIONI p" +
                            " group by CodReplica) tabellaPrenotati on tabellaPrenotati.CodReplica = p.CodReplica" +
                            " WHERE R.CodReplica='" + codReplica + "';";
            DBConnection d = new DBConnection();

            DataTable dt = d.DoQuerySelect(sQuery);
            Replica oReplica = new Replica();
            oReplica.codReplica = dt.Rows[0]["CodReplica"].ToString();
            oReplica.codEvento = dt.Rows[0]["CodEvento"].ToString();
            oReplica.dataEOra = Convert.ToDateTime(dt.Rows[0]["DataEOra"]);
            oReplica.codLocale = dt.Rows[0]["CodLocale"].ToString();
            oReplica.nomeEvento = dt.Rows[0]["NomeEvento"].ToString();
            oReplica.nomeLocale = dt.Rows[0]["Nome"].ToString();
            oReplica.luogo = dt.Rows[0]["Luogo"].ToString();

            try
            {
                oReplica.posti = Convert.ToInt32(dt.Rows[0]["Posti"]);
            }
            catch (Exception)
            {

                oReplica.posti = Convert.ToInt32(dt.Rows[0]["Capienza"]);
            }
    


            return oReplica;

        }

        public List<Replica> GetReplicheByIdEvento(string codEvento)
        {

            List<Replica> listaReplichePerEvento = new List<Replica>();

            //string sQuery = "SELECT R.CodReplica, R.CodEvento, R.DataEOra, e.CodLocale, E.NomeEvento, E.Annullato, L.Nome, L.Luogo, L.Posti" +
            //                " FROM REPLICHE R" +
            //                " INNER JOIN EVENTI E ON E.CodEvento = R.CodEvento" +
            //                " INNER JOIN LOCALI L ON L.CodLocale = E.CodLocale" +
            //                " WHERE CodEvento='" + codEvento + "';";
            string sQuery = "SELECT DISTINCT R.CodReplica, R.CodEvento, R.DataEOra, e.CodLocale, E.NomeEvento, E.Annullato, L.Nome, L.Luogo, L.Posti Capienza, (L.Posti - totaliPrenotati) Posti" +
                            " FROM REPLICHE R" +
                            " INNER JOIN EVENTI E ON E.CodEvento = R.CodEvento" +
                            " INNER JOIN LOCALI L ON L.CodLocale = E.CodLocale" +
                            " left join prenotazioni p on p.CodReplica = r.CodReplica" +
                            " left join(Select CodReplica, sum(quantita) totaliPrenotati from PRENOTAZIONI p" +
                            " group by CodReplica) tabellaPrenotati on tabellaPrenotati.CodReplica = p.CodReplica" +
                            " where R.CodEvento = ('"+codEvento+"')"+
                            " ORDER BY DataEOra;";
            DBConnection d = new DBConnection();

            DataTable dt = d.DoQuerySelect(sQuery);

            foreach (DataRow dr in dt.Rows)
            {
                Replica oReplica = new Replica();
                oReplica.codReplica = dr["CodReplica"].ToString();
                oReplica.codEvento = dr["CodEvento"].ToString();
                oReplica.dataEOra = Convert.ToDateTime(dr["DataEOra"]);
                oReplica.codLocale = dr["CodLocale"].ToString();
                oReplica.nomeEvento = dr["NomeEvento"].ToString();
                oReplica.nomeLocale = dr["Nome"].ToString();
                oReplica.luogo = dr["Luogo"].ToString();
                try
                {
                    oReplica.posti = Convert.ToInt32(dr["Posti"]);
                }
                catch (Exception)
                {

                    oReplica.posti= Convert.ToInt32(dr["Capienza"]);
                }
                listaReplichePerEvento.Add(oReplica);

            }
            return listaReplichePerEvento;

        }
        public List<Replica> GetReplicheByIdEvento(string codEvento1, string codEvento2)
        {

            List<Replica> listaReplichePerEvento = new List<Replica>();

            //string sQuery = "SELECT R.CodReplica, R.CodEvento, R.DataEOra, e.CodLocale, E.NomeEvento, E.Annullato, L.Nome, L.Luogo, L.Posti" +
            //                " FROM REPLICHE R" +
            //                " INNER JOIN EVENTI E ON E.CodEvento = R.CodEvento" +
            //                " INNER JOIN LOCALI L ON L.CodLocale = E.CodLocale" +
            //                " WHERE E.CodEvento IN ('" + codEvento1 + "','" + codEvento2 + "');";
            string sQuery = "SELECT DISTINCT R.CodReplica, R.CodEvento, R.DataEOra, e.CodLocale, E.NomeEvento, E.Annullato, L.Nome, L.Luogo, L.Posti Capienza, (L.Posti - totaliPrenotati) Posti" +
                           " FROM REPLICHE R" +
                           " INNER JOIN EVENTI E ON E.CodEvento = R.CodEvento" +
                           " INNER JOIN LOCALI L ON L.CodLocale = E.CodLocale" +
                           " left join prenotazioni p on p.CodReplica = r.CodReplica" +
                           " left join(Select CodReplica, sum(quantita) totaliPrenotati from PRENOTAZIONI p" +
                           " group by CodReplica) tabellaPrenotati on tabellaPrenotati.CodReplica = p.CodReplica" +
                           " WHERE E.CodEvento IN ('" + codEvento1 + "','" + codEvento2 + "')" +
                           " ORDER BY DataEOra;";
            DBConnection d = new DBConnection();

            DataTable dt = d.DoQuerySelect(sQuery);

            foreach (DataRow dr in dt.Rows)
            {
                Replica oReplica = new Replica();
                oReplica.codReplica = dr["CodReplica"].ToString();
                oReplica.codEvento = dr["CodEvento"].ToString();
                oReplica.dataEOra = Convert.ToDateTime(dr["DataEOra"]);
                oReplica.codLocale = dr["CodLocale"].ToString();
                oReplica.nomeEvento = dr["NomeEvento"].ToString();
                oReplica.nomeLocale = dr["Nome"].ToString();
                oReplica.luogo = dr["Luogo"].ToString();
                try
                {
                    oReplica.posti = Convert.ToInt32(dr["Posti"]);
                }
                catch (Exception)
                {

                    oReplica.posti = Convert.ToInt32(dr["Capienza"]);
                }
                listaReplichePerEvento.Add(oReplica);

            }
            return listaReplichePerEvento;

        }

        public List<Replica> GetReplicheByIdEvento(string codEvento1, string codEvento2,string codEvento3)
        {

            List<Replica> listaReplichePerEvento = new List<Replica>();

            //string sQuery = "SELECT R.CodReplica, R.CodEvento, R.DataEOra, e.CodLocale, E.NomeEvento, E.Annullato, L.Nome, L.Luogo, L.Posti" +
            //                " FROM REPLICHE R" +
            //                " INNER JOIN EVENTI E ON E.CodEvento = R.CodEvento" +
            //                " INNER JOIN LOCALI L ON L.CodLocale = E.CodLocale" +
            //                " WHERE E.CodEvento IN ('" + codEvento1 + "','" + codEvento2 + "');";
            string sQuery = "SELECT DISTINCT R.CodReplica, R.CodEvento, R.DataEOra, e.CodLocale, E.NomeEvento, E.Annullato, L.Nome, L.Luogo, L.Posti Capienza, (L.Posti - totaliPrenotati) Posti" +
                           " FROM REPLICHE R" +
                           " INNER JOIN EVENTI E ON E.CodEvento = R.CodEvento" +
                           " INNER JOIN LOCALI L ON L.CodLocale = E.CodLocale" +
                           " left join prenotazioni p on p.CodReplica = r.CodReplica" +
                           " left join(Select CodReplica, sum(quantita) totaliPrenotati from PRENOTAZIONI p" +
                           " group by CodReplica) tabellaPrenotati on tabellaPrenotati.CodReplica = p.CodReplica" +
                           " WHERE E.CodEvento IN ('" + codEvento1 + "','" + codEvento2 + "','"+codEvento3+"')" +
                           " ORDER BY DataEOra;";
            DBConnection d = new DBConnection();

            DataTable dt = d.DoQuerySelect(sQuery);

            foreach (DataRow dr in dt.Rows)
            {
                Replica oReplica = new Replica();
                oReplica.codReplica = dr["CodReplica"].ToString();
                oReplica.codEvento = dr["CodEvento"].ToString();
                oReplica.dataEOra = Convert.ToDateTime(dr["DataEOra"]);
                oReplica.codLocale = dr["CodLocale"].ToString();
                oReplica.nomeEvento = dr["NomeEvento"].ToString();
                oReplica.nomeLocale = dr["Nome"].ToString();
                oReplica.luogo = dr["Luogo"].ToString();
                try
                {
                    oReplica.posti = Convert.ToInt32(dr["Posti"]);
                }
                catch (Exception)
                {

                    oReplica.posti = Convert.ToInt32(dr["Capienza"]);
                }
                listaReplichePerEvento.Add(oReplica);

            }
            return listaReplichePerEvento;

        }

        public int PostiDisponibiliPerReplica(string codReplica)
        {
            int postiLiberi;
            int postiPrenotati;
            ReplicaDAO oReplicaDAO = new ReplicaDAO();
            PrenotazioneDAO oPrenotazioneDAO = new PrenotazioneDAO();
            string sQuery = "SELECT SUM(Quantita) Quantita FROM PRENOTAZIONI WHERE CodReplica = '" + codReplica + "';";
            DBConnection d = new DBConnection();
            DataTable dt = d.DoQuerySelect(sQuery);

            try
            {
                postiPrenotati = Convert.ToInt32(dt.Rows[0]["Quantita"]);
            }
            catch (Exception)
            {

                postiPrenotati = 0;
            }

            sQuery = "SELECT R.CodReplica, L.Posti " +
                     "FROM REPLICHE R " +
                     "INNER JOIN EVENTI E ON E.CodEvento = R.CodEvento " +
                     "INNER JOIN LOCALI L ON L.CodLocale = E.CodLocale WHERE CodReplica = '" + codReplica + "';";
            d = new DBConnection();
            dt = d.DoQuerySelect(sQuery);

            int postiPerEvento = Convert.ToInt32(dt.Rows[0]["Posti"]);

            postiLiberi = postiPerEvento - postiPrenotati;

            return postiLiberi;
        }

    }
}