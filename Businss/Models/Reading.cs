//using InGazAPI.Businss.Models;
using InGazAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Reading
{
    [Key]
    public int ReadingId { get; set; }  // Changed from ReadingId to Id
    [Required]
    [StringLength(100)]
    public string ReadingName { get; set; } = string.Empty;
    public decimal Value { get; set; }  // Added missing property
    public string Unit { get; set; } = string.Empty;  // Added missing property
    public List<Station> Stations { get; set; } = new List<Station>();
    public DateTime ModifiedOn { get; set; }
    public string ModifiedBy { get; set; } = string.Empty;
    // ForeignKey to WorkingLine
    public int WorkingLineId { get; set; }
    [ForeignKey("WorkingLineId")]
    public virtual WorkingLine WorkingLine { get; set; }
}