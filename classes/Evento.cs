using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEventiCrociera.classes
{
    public class Evento
    {

        public string codEvento { get; set; }
        public string codLocale { get; set; }
        public string nomeEvento { get; set; }
        public bool IsAnnullato { get; set; }

        public Evento()
        {

        }

        public Evento(string codEvento, string codLocale, string nomeEvento, bool annullato)
        {
            this.codEvento = codEvento;
            this.codLocale = codLocale;
            this.nomeEvento = nomeEvento;
            this.IsAnnullato = annullato;
        }
    }
}