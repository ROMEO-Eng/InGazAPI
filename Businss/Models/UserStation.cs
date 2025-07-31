using InGazAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserStation
{
   

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // <- Prevent EF from generating a value for this key
    public int UserStationId { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    public int StationId { get; set; }
    [ForeignKey("StationId")]
    public virtual Station Station { get; set; }

}