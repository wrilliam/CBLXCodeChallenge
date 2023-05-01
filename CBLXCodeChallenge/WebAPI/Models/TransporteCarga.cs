using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class TransporteCarga
    {
        #region Attributes

        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [ForeignKey("Cargueiro")]
        [Column("Tipo_Cargueiro")]
        public int CargueiroId { get; set; }
        public virtual Cargueiro Cargueiro { get; set; }
        [Column("Data_Hora_Saida")]
        public DateTime DataHoraSaida { get; set; }
        [Column("Data_Hora_Retorno")]
        public DateTime DataHoraRetorno { get; set; }
        [ForeignKey("Mineral")]
        [Column("Tipo_Mineral")]
        public int MineralId { get; set; }
        public virtual Mineral Mineral { get; set; }
        [Column("Quantidade_Minerais")]
        public int Quantidade { get; set; }
        [Column("Valor_Total")]
        public decimal ValorTotal { get; set; }

        #endregion
    }
}
