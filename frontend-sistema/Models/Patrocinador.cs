using System.ComponentModel.DataAnnotations;

namespace frontend_sistema.Models
{
    public class Patrocinador
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o nome.")]
        [MinLength(3, ErrorMessage = "O nome precisa conter pelo menos 3 letras!")]
        [MaxLength(300, ErrorMessage = "O nome precisa conter no máximo 300 letras!")]
        public string? Nome { get; set; }
        [Required]
        public string? Resposta { get; set; }
        [Required]
        [Display(Name = "Forma de contato")]
        public string? FormaDeContato { get; set; }
        [Required(ErrorMessage = "É o brigatório informar o valor.")]
        [Range(0,100000, ErrorMessage = "O valor precisa ser positivo.")]
        [DataType(DataType.Currency, ErrorMessage = "O tipo do valor está inválido.")]
        public decimal Valor { get; set; }
        [Required]
        public string? Status { get; set; }
        [MaxLength(1000)]
        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }
        [Required]
        [Display(Name = "Responsável")]
        public string? Responsavel { get; set; }

        public string GetStatusClassColor()
        {
            switch(Status)
            {
                case "NAO":
                    return "bg-danger";
                case "PENDENTE":
                    return "bg-warning";
                case "COM RESPOSÁVEL":
                    return "bg-primary";
                case "PAGO":
                    return "bg-success";
                default:
                    return "bg-primary";
            }
        }

        public string GetRespostaClassColor()
        {
            switch (Resposta)
            {
                case "SIM":
                    return "bg-success";
                case "NAO":
                    return "bg-danger";
                case "PENDENTE":
                    return "bg-warning";
                default:
                    return "bg-primary";
            }
        }
    }
}