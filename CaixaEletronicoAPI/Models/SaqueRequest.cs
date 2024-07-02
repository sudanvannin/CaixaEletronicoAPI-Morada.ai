using System.ComponentModel.DataAnnotations;

namespace CaixaEletronicoAPI.Models
{
    public class SaqueRequest
    {
        [Required(ErrorMessage = "O valor de saque é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor de saque deve ser um número inteiro positivo.")]
        public int Valor { get; set; }
    }
}

