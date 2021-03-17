using System;
using System.Collections.Generic;

namespace DemoAcmeAp.Models
{
    public class Instalacao
    {
        public long Id { get; set; }

        public Cliente Cliente { get; set; }

        public Endereco EnderecoInstalacao { get; set; }

        public ICollection<Fatura> ListFatura { get; set; }

        public string Codigo { get; set; }

        public DateTime DataInstalacao { get; set; }
    }
}
