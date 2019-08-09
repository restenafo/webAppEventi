using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppEventiCrociera.classes;


namespace WebAppEventiCrociera
{
    public partial class elencoRepliche : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string cod1 = "";
            string cod2 = "";
            string cod3 = "";

            cod1 = Request.QueryString["cod1"];
            cod2 = Request.QueryString["cod2"];
            cod3 = Request.QueryString["cod3"];
            GeneraTabella(cod1,cod2,cod3);
            string linkToPreviousPage = Request.UrlReferrer.ToString();
            Session.Add("collegamentoBack", linkToPreviousPage);
        }
        protected void GeneraTabella(string c1, string c2, string c3)
        {
            List<Replica> listaRepliche = new List<Replica>();
            ReplicaDAO oReplicaDAO = new ReplicaDAO();
            if (c2!=""&&c3!="" &&c1!="")
            {
                listaRepliche = oReplicaDAO.GetReplicheByIdEvento(c1,c2,c3);
            }
            else if (c3=="")
                {
                listaRepliche = oReplicaDAO.GetReplicheByIdEvento(c1,c2);
            }
            else
            {
                listaRepliche = oReplicaDAO.GetReplicheByIdEvento(c1);

            }

            foreach (Replica r in listaRepliche)
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


                Button bt1 = new Button();

                bt1.Text = "PRENOTA";
                bt1.CssClass = "btn btn-primary";

                bt1.ID = r.codReplica;
                bt1.Click += new EventHandler(prenotaReplica);


                tc1.Text = r.codReplica;
                tc2.Text = r.codEvento;
                tc3.Text = (r.dataEOra).ToString();
                tc4.Text = r.codLocale;
                tc5.Text = r.nomeEvento;
                tc6.Text = r.nomeLocale;
                tc7.Text = r.luogo;
                tc8.Text = (r.posti).ToString();
                tc9.Controls.Add(bt1);

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
                TBLListaRepliche.Rows.Add(tr);
            }
        }
        public void prenotaReplica(object sender, EventArgs e)
        {
            Button regeneratedbutton = (Button)sender;
            string id = regeneratedbutton.ID;
            ReplicaDAO oReplicaDAO = new ReplicaDAO();
            Response.Redirect("reservation.aspx?idReplica=" + id);

        }
    }
}