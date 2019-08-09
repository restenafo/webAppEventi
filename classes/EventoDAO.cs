using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAppEventiCrociera.classes
{
    public class EventoDAO
    {

        public void InsertEvento(Evento oEvento)
        {

            string query = "INSERT INTO EVENTI VALUES('" + oEvento.codEvento + "','" + oEvento.codLocale + "','" + oEvento.nomeEvento + "'," + false +"')";

            DBConnection oDBConnection = new DBConnection();
            oDBConnection.ExecuteNonQuery(query);
        }

        public List<Evento> GetAllEventi()
        {
            List<Evento> listaEventi = new List<Evento>();

            string sQuery = "SELECT * FROM EVENTI";
            DBConnection d = new DBConnection();
            DataTable dt = d.DoQuerySelect(sQuery);

            foreach (DataRow dr in dt.Rows)
            {
                Evento oEvento = new Evento();
                oEvento.codEvento = dr["CodEvento"].ToString();
                oEvento.codLocale = dr["CodLocale"].ToString();
                oEvento.nomeEvento = dr["NomeEvento"].ToString();
                oEvento.IsAnnullato = Convert.ToBoolean(dr["Annullato"]);

                listaEventi.Add(oEvento);
            }
            return listaEventi;
        }


        public void DeleteEvento(string codEvento)
        {
            string sQuery = "DELETE FROM EVENTI WHERE CodEvento=" + codEvento + ";";
            DBConnection d = new DBConnection();
            d.ExecuteNonQuery(sQuery);
        }


        //public void UpdateEvento(Evento oEvento)
        //{
        //    string sQuery = @"UPDATE EVENTI SET Nome='" + oEvento.nome +
        //        "',Cognome='" + oEvento.cognome +
        //        "' WHERE CodEvento='" + oEvento.codEvento + "';";
        //    DBConnection d = new DBConnection();
        //    d.ExecuteNonQuery(sQuery);
        //}

        public Evento GetEventoById(string codEvento)
        {
            string sQuery = "SELECT * FROM EVENTI WHERE CodEvento=" + codEvento + ";";
            DBConnection d = new DBConnection();

            DataTable dt = d.DoQuerySelect(sQuery);
            Evento oEvento = new Evento();
            oEvento.codEvento = dt.Rows[0]["CodEvento"].ToString();
            oEvento.codLocale = dt.Rows[0]["CodLocale"].ToString();
            oEvento.nomeEvento = dt.Rows[0]["NomeEvento"].ToString();
            oEvento.IsAnnullato = Convert.ToBoolean(dt.Rows[0]["Annullato"]);


            return oEvento;

        }

    }
}