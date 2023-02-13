using System.ComponentModel.DataAnnotations;

namespace backend_api.Models
{
    public class Patrocinador
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "O nome precisa conter pelo menos 3 letras!")]
        [MaxLength(300, ErrorMessage = "O nome precisa conter no máximo 300 letras!")]
        public string? Nome { get; set; }
        [Required]
        public string? Resposta { get; set; }
        [Required]
        public string? FormaDeContato { get; set; }
        [Required]
        [Range(1,100000)]
        public decimal Valor { get; set; }
        [Required]
        public string? Status { get; set; }
        [MaxLength(1000)]
        public string? Observacoes { get; set; }
        [Required]
        public string? Responsavel { get; set; }
    }
}