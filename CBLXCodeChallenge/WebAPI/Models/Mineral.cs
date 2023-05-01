using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Mineral
    {
        #region Attributes

        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Tipo")]
        public string Tipo { get; set; }
        [Column("Caracteristica")]
        public string Caracteristica { get; set; }
        [Column("Preco")]
        public decimal PrecoPorKg { get; set; }

        #endregion
    }
}
