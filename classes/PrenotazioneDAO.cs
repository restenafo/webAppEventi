using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAppEventiCrociera.classes
{
    public class PrenotazioneDAO
    {

        private string GeneraCodicePrenotazione()
        {
            Guid oGuid = Guid.NewGuid();
            string codice = oGuid.ToString();
            codice = codice.Substring(4, 4);
            return codice;
        }

        public void InsertPrenotazione(Prenotazione oPrenotazione)
        {
            bool codiceValido = false;
            bool codiceUsato = false;
            string codice = "";
            List<string> listaCodici = GetAllCodiciPrenotazioni();
            while (!codiceValido)
            {
                codice = GeneraCodicePrenotazione();
                foreach (string c in listaCodici)
                {
                    if (codice==c)
                    {
                        codiceUsato = true;
                    }
                }
                if (!codiceUsato)
                {
                    codiceValido = true;
                }
            }

            string query = "INSERT INTO PRENOTAZIONI VALUES('" + codice + "','" + oPrenotazione.codUtente + "','" + oPrenotazione.codReplica + "'," + oPrenotazione.quantita + ",GETDATE())";

            DBConnection oDBConnection = new DBConnection();
            oDBConnection.ExecuteNonQuery(query);
        }

        private List<string> GetAllCodiciPrenotazioni()
        {
            List<string> listaCodiciPrenotazioni = new List<string>();

            string sQuery = "SELECT CodPrenotazione FROM PRENOTAZIONI";
            DBConnection d = new DBConnection();
            DataTable dt = d.DoQuerySelect(sQuery);

            foreach (DataRow dr in dt.Rows)
            {
                string codicePrenotazione;
                codicePrenotazione = dr["CodPrenotazione"].ToString();

                listaCodiciPrenotazioni.Add(codicePrenotazione);
            }
            return listaCodiciPrenotazioni;
        }

        public List<Reservation> GetAllPrenotazioni()
        {
            List<Reservation> listaPrenotazioni = new List<Reservation>();

            //string sQuery = "SELECT * FROM PRENOTAZIONI";
            string sQuery = "SELECT p.CodPrenotazione, p.Quantita, r.CodReplica, R.CodEvento, R.DataEOra, u.Cognome,u.Nome,u.Telefono,u.Email,u.CodUtente , E.NomeEvento, E.Annullato, (L.Posti-totaliPrenotati) Posti FROM REPLICHE R INNER JOIN EVENTI E ON E.CodEvento = R.CodEvento INNER JOIN LOCALI L ON L.CodLocale = E.CodLocale inner join prenotazioni p on p.CodReplica=r.CodReplica inner join (Select CodReplica,sum(quantita) totaliPrenotati from PRENOTAZIONI p group by CodReplica) tabellaPrenotati on tabellaPrenotati.CodReplica=p.CodReplica inner join UTENTI u on p.CodUtente=u.CodUtente;";
            DBConnection d = new DBConnection();
            DataTable dt = d.DoQuerySelect(sQuery);

            foreach (DataRow dr in dt.Rows)
            {
                Reservation oPrenotazione = new Reservation();
                oPrenotazione.codPrenotazione = dr["CodPrenotazione"].ToString();
                oPrenotazione.codReplica = dr["CodReplica"].ToString();
                oPrenotazione.codUtente = dr["CodUtente"].ToString();
                oPrenotazione.quantita = Convert.ToInt32(dr["Quantita"]);
                oPrenotazione.dataEOra = Convert.ToDateTime(dr["DataEOra"]);
                oPrenotazione.emailUtente = dr["Email"].ToString();
                oPrenotazione.cognomeUtente = dr["Cognome"].ToString();
                oPrenotazione.nomeEvento = dr["NomeEvento"].ToString();
                oPrenotazione.nomeUtente = dr["Nome"].ToString();
                oPrenotazione.telefonoUtente = dr["Telefono"].ToString();

                listaPrenotazioni.Add(oPrenotazione);
            }
            return listaPrenotazioni;
        }


        public void DeletePrenotazione(string codPrenotazione)
        {
            string sQuery = "DELETE FROM PRENOTAZIONI WHERE CodPrenotazione=" + codPrenotazione + ";";
            DBConnection d = new DBConnection();
            d.ExecuteNonQuery(sQuery);
        }


        //public void UpdatePrenotazione(Prenotazione oPrenotazione)
        //{
        //    string sQuery = @"UPDATE PRENOTAZIONI SET Nome='" + oPrenotazione.nome +
        //        "',Cognome='" + oPrenotazione.cognome +
        //        "' WHERE CodPrenotazione='" + oPrenotazione.codPrenotazione + "';";
        //    DBConnection d = new DBConnection();
        //    d.ExecuteNonQuery(sQuery);
        //}

        public Prenotazione GetPrenotazioneById(string codPrenotazione)
        {
            string sQuery = "SELECT * FROM PRENOTAZIONI WHERE CodPrenotazione=" + codPrenotazione + ";";
            DBConnection d = new DBConnection();

            DataTable dt = d.DoQuerySelect(sQuery);
            Prenotazione oPrenotazione = new Prenotazione();
            oPrenotazione.codPrenotazione = dt.Rows[0]["CodPrenotazione"].ToString();
            oPrenotazione.codReplica = dt.Rows[0]["CodReplica"].ToString();
            oPrenotazione.codUtente = dt.Rows[0]["CodUtente"].ToString();
            oPrenotazione.quantita = Convert.ToInt32(dt.Rows[0]["Quantita"]);
            oPrenotazione.dataEOra = Convert.ToDateTime(dt.Rows[0]["DataEOra"]);


            return oPrenotazione;

        }

        public int PostiPrenotatiPerReplica(string codiceReplica)
        {
            int postiPernotati = 0; ;

            string sQuery = "SELECT SUM(Quantita) Quantita FROM PRENOTAZIONI WHERE CodReplica = '" + codiceReplica + "';";
            DBConnection d = new DBConnection();
            DataTable dt = d.DoQuerySelect(sQuery);

            if ((dt.Rows[0]["Quantita"])!=null)
            {
                try
                {
                    postiPernotati = Convert.ToInt32(dt.Rows[0]["Quantita"]);

                }
                catch (Exception)
                {

                    postiPernotati = 0;
                }
            }                                                                              
            return postiPernotati;
        }

    }
}