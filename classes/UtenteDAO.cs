using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAppEventiCrociera.classes
{
    public class UtenteDAO
    {
        public void InsertUtente(Utente oUtente)
        {
            string query = "INSERT INTO UTENTI VALUES('" + oUtente.codUtente + "','" + oUtente.cognome + "','" + oUtente.nome + "','" + oUtente.telefono + "','" + oUtente.email + "','" + oUtente.password + "')";

            DBConnection oDBConnection = new DBConnection();
            oDBConnection.ExecuteNonQuery(query);
        }

        public List<Utente> GetAllUtenti()
        {
            List<Utente> listaUtenti = new List<Utente>();

            string sQuery = "SELECT * FROM UTENTI";
            DBConnection d = new DBConnection();
            DataTable dt = d.DoQuerySelect(sQuery);

            foreach (DataRow dr in dt.Rows)
            {
                Utente oUtente = new Utente();
                oUtente.codUtente = dr["CodUtente"].ToString();
                oUtente.nome = dr["Nome"].ToString();
                oUtente.cognome = dr["Cognome"].ToString();
                oUtente.telefono = dr["Telefono"].ToString();
                oUtente.email = dr["Email"].ToString();
                oUtente.password = dr["Password"].ToString();

                listaUtenti.Add(oUtente);
            }
            return listaUtenti;
        }


        public void DeleteUtente(string codUtente)
        {
            string sQuery = "DELETE FROM UTENTI WHERE CodUtente=" + codUtente + ";";
            DBConnection d = new DBConnection();
            d.ExecuteNonQuery(sQuery);
        }


        public void UpdateUtente(Utente oUtente)
        {
            string sQuery = @"UPDATE UTENTI SET Nome='" + oUtente.nome +
                "',Cognome='" + oUtente.cognome +
                "' WHERE CodUtente='" + oUtente.codUtente + "';";
            DBConnection d = new DBConnection();
            d.ExecuteNonQuery(sQuery);
        }

        public Utente GetUtenteById(string codUtente)
        {
            string sQuery = "SELECT * FROM UTENTI WHERE CodUtente=" + codUtente + ";";
            DBConnection d = new DBConnection();

            DataTable dt = d.DoQuerySelect(sQuery);
            Utente oUtente = new Utente();
            oUtente.codUtente = dt.Rows[0]["CodUtente"].ToString();
            oUtente.nome = dt.Rows[0]["Nome"].ToString();
            oUtente.cognome = dt.Rows[0]["Cognome"].ToString();
            oUtente.telefono = dt.Rows[0]["Telefono"].ToString();
            oUtente.email = dt.Rows[0]["Email"].ToString();
            oUtente.password = dt.Rows[0]["Password"].ToString();


            return oUtente;

        }
    }
}