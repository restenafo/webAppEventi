using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEventiCrociera.classes
{
    public class Reservation
    {
        public string codPrenotazione { get; set; }
        public string codUtente { get; set; }
        public string codReplica { get; set; }
        public int quantita { get; set; }
        public DateTime dataEOra { get; set; }

        public string nomeUtente { get; set; }
        public string cognomeUtente { get; set; }
        public string emailUtente { get; set; }
        public string telefonoUtente { get; set; }
        public string nomeEvento { get; set; }



    }
}