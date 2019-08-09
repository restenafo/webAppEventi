using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppEventiCrociera.classes;

namespace WebAppEventiCrociera
{
    public partial class booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GeneraTabella();
        }

        protected void GeneraTabella()
        {
            List<Reservation> listaReservations = new List<Reservation>();
            PrenotazioneDAO oPrenotazioneDAO = new PrenotazioneDAO();
            listaReservations = oPrenotazioneDAO.GetAllPrenotazioni();

            foreach (Reservation r in listaReservations)
            {
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                TableCell tc5 = new TableCell();
                TableCell tc6 = new TableCell();
                TableCell tc7 = new TableCell();
                TableCell tc8 = new TableCell();
                TableCell tc9 = new TableCell();
                TableCell tc10 = new TableCell();



                tc1.Text = r.codPrenotazione;
                tc2.Text = r.codReplica;
                tc3.Text = (r.dataEOra).ToString();
                tc4.Text = r.codUtente;
                tc5.Text = r.cognomeUtente;
                tc6.Text = r.nomeUtente;
                tc7.Text = r.telefonoUtente;
                tc8.Text = r.emailUtente;
                tc9.Text = r.quantita.ToString();
                tc10.Text = r.nomeEvento;

                TableRow tr = new TableRow();
                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);
                tr.Cells.Add(tc5);
                tr.Cells.Add(tc6);
                tr.Cells.Add(tc7);
                tr.Cells.Add(tc8);
                tr.Cells.Add(tc9);
                tr.Cells.Add(tc10);

                TBLprenotazioni.Rows.Add(tr);
            }
        }

    }
}