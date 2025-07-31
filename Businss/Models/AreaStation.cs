using InGazAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AreaStation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // <- Prevent EF from generating a value for this key
    public int AreaStationId { get; set; }
    [Column(Order = 0)]
    [ForeignKey(nameof(Area))]  // <- Foreign Key declaration
    public int AreaId { get; set; }


    [Column(Order = 1)]
    [ForeignKey(nameof(Station))]  // <- Foreign Key declaration
    public int StationId { get; set; }

    public virtual Area Area { get; set; } = new Area(); // Initialize to a new Area instance
    public virtual Station Station { get; set; }

}