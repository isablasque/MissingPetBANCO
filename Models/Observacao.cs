using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MissingPet.Models
{
    [Table("Observacao")]
    public class Observacao
    {
        [Column("ObservacaoId")]
        [Display(Name = "Código")]
        public int ObservacaoId { get; set; }

        [Column("ObservacaoDescricao")]
        [Display(Name = "Descricao")]
        public string ObservacaoDescricao { get; set; } = string.Empty;

        [Column("ObservacaoLocal")]
        [Display(Name = "Local")]
        public string ObservacaoLocal { get; set; } = string.Empty;

        [Column("ObservacaoData")]
        [Display(Name = "Data")]
        public DateTime ObservacaoData { get; set; }

        [ForeignKey("AnimalId")]
        [Display(Name = "Código do Animal")]
        public int AnimalId { get; set; }

        public Animal? Animal { get; set; }

        [ForeignKey("UsuarioId")]
        [Display(Name = "Código do Usuario")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
