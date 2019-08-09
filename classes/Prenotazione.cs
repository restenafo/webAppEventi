using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEventiCrociera.classes
{
    public class Prenotazione
    {

        public string codPrenotazione { get; set; }
        public string codUtente { get; set; }
        public string codReplica { get; set; }
        public int quantita { get; set; }
        public DateTime dataEOra { get; set; }

        public Prenotazione()
        {

        }

        public Prenotazione(string codPrenotazione, string codUtente, string codReplica, int quantita, DateTime dataEOra)
        {
            this.codPrenotazione = codPrenotazione;
            this.codUtente = codUtente;
            this.codReplica = codReplica;
            this.quantita = quantita;
            this.dataEOra = dataEOra;
        }


    }
}