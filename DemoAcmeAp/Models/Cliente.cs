using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoAcmeAp.Models
{
    public class Cliente
    {
        [Key]
        public long Id { get; set; }

        public Endereco EnderecoCobranca { get; set; }

        public ICollection<Instalacao> ListaInstalacao { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(11)]
        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
