using System.ComponentModel.DataAnnotations;

namespace CRUDlabSODRE.Models
{
    public class SodreModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Escolha o cargo do funcionario!!!")]
        public int IdCargo { get; set; }


        [Required(ErrorMessage = "Didite o Nome do funcionario!!!")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Digite o salário do funcionario!!!")]
        public float Salario { get; set; }

        public int Quantidade { get; set; } = 0;
    }
}
