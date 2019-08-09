using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppEventiCrociera.classes;

namespace WebAppEventiCrociera
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTNlogin_Click(object sender, EventArgs e)
        {
            List<Utente> listaUtenti = new List<Utente>();
            bool isValid = false;

            if (TXTemail.Text!=""&&TXTpassword.Text!="")
            {
                UtenteDAO oUtenteDAO = new UtenteDAO();
                listaUtenti=oUtenteDAO.GetAllUtenti();
                foreach (Utente u in listaUtenti)
                {
                    if (TXTemail.Text==u.email&&TXTpassword.Text == u.password) {
                        isValid = true;
                        Session.Add("codUtente", u.codUtente);
                        Response.Redirect("prenotazioneEventi.aspx");
                    }

                }
                if (!isValid)
                {
                    LBLrisposta.Text = "UTENTE NON REGISTRATO";
                }
                
               
            }
        }

        protected void BTNreset_Click(object sender, EventArgs e)
        {
            TXTemail.Text = "";
            TXTpassword.Text = "";
        }
    }
}