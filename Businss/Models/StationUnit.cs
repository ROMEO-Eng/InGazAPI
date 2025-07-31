using InGazAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StationUnit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // <- Prevent EF from generating a value for this key
    public int StationUnitId { get; set; }
    public int StationId { get; set; }
    [ForeignKey("StationId")]
    public virtual Station Station { get; set; }

    public int UnitId { get; set; }
    [ForeignKey("UnitId")]
    public virtual Unit Unit { get; set; }


    [Required]
    public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;

    [MaxLength(100)]
    public string ModifiedBy { get; set; } = string.Empty;
}