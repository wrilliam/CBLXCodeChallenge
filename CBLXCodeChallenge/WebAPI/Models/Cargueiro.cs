using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Cargueiro
    {
        #region Attributes

        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Quantidade")]
        public int Quantidade { get; set; }
        [Column("Classe")]
        public string Classe { get; set; }
        [Column("Capacidade")]
        public decimal CapacidadeEmToneladas { get; set; }
        [ForeignKey("Mineral")]
        [Column("Tipo_Mineral")]
        public int MineralId { get; set; }
        public virtual Mineral Mineral { get; set; }

        #endregion
    }
}
