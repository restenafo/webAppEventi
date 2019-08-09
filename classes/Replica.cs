using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEventiCrociera.classes
{
    public class Replica
    {
        public string codReplica { get; set; }
        public string codEvento { get; set; }
        public DateTime dataEOra { get; set; }
        public string codLocale { get; set; }
        public string nomeEvento { get; set; }
        public string nomeLocale { get; set; }
        public string luogo { get; set; }
        public int posti { get; set; }

        public Replica()
        {

        }

        public Replica(string codReplica, string codEvento, DateTime dataEOra)
        {
            this.codReplica = codReplica;
            this.codEvento = codEvento;
            this.dataEOra = dataEOra;
        }

    }
}