using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicService.Data;

[Table("Consultations")]
public class Consultation
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ConsultationId { get; set; }

    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }

    [ForeignKey(nameof(Pet))]
    public int PetId { get; set; }

    [Column]
    public DateTime ConsultationDate { get; set; }

    [Column]
    public string Description { get; set; } = string.Empty;
    public virtual Client Client { get; set; } = default!;

    public virtual Pet Pet { get; set; } = default!;
}
