using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAcmeAp.Models
{
    public class Fatura
    {
        public long Id { get; set; }

        public Instalacao Instalacao { get; set; }

        public string Codigo { get; set; }

        public DateTime DataLeitura { get; set; }

        public DateTime DataVencimento { get; set; }

        public int NumeroLeitura { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorConta { get; set; }
    }
}
