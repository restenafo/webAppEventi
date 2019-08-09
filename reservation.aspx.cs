using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppEventiCrociera.classes;

namespace WebAppEventiCrociera
{
    public partial class reservation : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string codiceReplica = Request.QueryString["idReplica"];
            PresentaEventoSelezionato(codiceReplica);
            string linkAllaPaginaPrecedente = (string)Session["collegamentoBack"];
            BTNIndietro.PostBackUrl = linkAllaPaginaPrecedente;
            BTNAvanti.Click+= new EventHandler(effettuaPrenotazione);

        }

        protected void PresentaEventoSelezionato(string codice)
        {
            Replica oReplica = new Replica();
            ReplicaDAO oReplicaDAO = new ReplicaDAO();
            oReplica = oReplicaDAO.GetReplicaById(codice);


            TableCell tc1 = new TableCell();
            TableCell tc2 = new TableCell();
            TableCell tc3 = new TableCell();
            TableCell tc4 = new TableCell();
            TableCell tc5 = new TableCell();
            TableCell tc6 = new TableCell();
            TableCell tc7 = new TableCell();
            TableCell tc8 = new TableCell();
            TableCell tc9 = new TableCell();


            //Button bt1 = new Button();

            //bt1.Text = "PRENOTA";
            //bt1.CssClass = "btn btn-primary";

            //bt1.ID = oReplica.codReplica;
            //bt1.Click += new EventHandler(prenotaReplica);


            tc1.Text = oReplica.codReplica;
            tc2.Text = oReplica.codEvento;
            tc3.Text = (oReplica.dataEOra).ToString();
            tc4.Text = oReplica.codLocale;
            tc5.Text = oReplica.nomeEvento;
            tc6.Text = oReplica.nomeLocale;
            tc7.Text = oReplica.luogo;
            tc8.Text = (oReplica.posti).ToString();
            //tc9.Controls.Add(bt1);

            TableRow tr = new TableRow();
            tr.Cells.Add(tc1);
            tr.Cells.Add(tc2);
            tr.Cells.Add(tc3);
            tr.Cells.Add(tc4);
            tr.Cells.Add(tc5);
            tr.Cells.Add(tc6);
            tr.Cells.Add(tc7);
            tr.Cells.Add(tc8);
            //tr.Cells.Add(tc9);
            TBLEvento.Rows.Add(tr);
        }
        public void effettuaPrenotazione (object sender, EventArgs e)
        {
            //Button regeneratedbutton = (Button)sender;
            //string id = regeneratedbutton.ID;
            //ReplicaDAO oReplicaDAO = new ReplicaDAO();
            //Response.Redirect("reservation.aspx?idReplica=" + id);
            string codiceReplica = Request.QueryString["idReplica"];
            PrenotazioneDAO oPrenotazioneDAO = new PrenotazioneDAO();
            int postiGiaPrenotati = oPrenotazioneDAO.PostiPrenotatiPerReplica(codiceReplica);
            ReplicaDAO oReplicaDAO = new ReplicaDAO();
            int postiDisponibiliPerReplica = oReplicaDAO.PostiDisponibiliPerReplica(codiceReplica);
            int postiLiberi = postiDisponibiliPerReplica - postiGiaPrenotati;
            int postiRichiestiPerPrenotazione = Convert.ToInt32(TXTpostiDaRiservare.Text);
            Prenotazione oPrenotazione = new Prenotazione();
            oPrenotazione.codReplica = codiceReplica;
            oPrenotazione.codUtente = (string)Session["codUtente"];
            oPrenotazione.quantita = postiRichiestiPerPrenotazione;
            oPrenotazioneDAO.InsertPrenotazione(oPrenotazione);

        }
    }
}
