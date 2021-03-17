using System.ComponentModel.DataAnnotations;

namespace DemoAcmeAp.Models
{
    public class Endereco
    {
        public long Id { get; set; }

        [StringLength(255)]
        public string Logradouro { get; set; }

        public long Numero { get; set; }

        [StringLength(255)]
        public string Bairro { get; set; }

        [StringLength(255)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Uf { get; set; }
    }
}
