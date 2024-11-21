using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookWeb.Models
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Nombre")]
        [StringLength(30,ErrorMessage ="El nombre solo acepta 30 caracteres como máximo")]
        public string? nombre { get; set; }
        [DisplayName("Nro. Order")]
        [Range(1,100, ErrorMessage = "El rango es de min. 1 y max. 100")]
        public int order { get; set; }
        public DateTime fechaCreacion { get; set; } = DateTime.Now;
    }
}
