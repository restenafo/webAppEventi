using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEventiCrociera.classes
{
    public class Utente
    {
        public string codUtente { get; set; }
        public string cognome { get; set; }
        public string nome { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public Utente()
        {

        }

        public Utente(string codUtente, string cognome, string nome, string telefono, string email, string password)
        {
            this.codUtente = codUtente;
            this.cognome = cognome;
            this.nome = nome;
            this.telefono = telefono;
            this.email = email;
            this.password = password;
        }
    }
}