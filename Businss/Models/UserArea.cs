using InGazAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserArea
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // <- Prevent EF from generating a value for this key
    public int UserAreaId { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    public int AreaId { get; set; }
    [ForeignKey("AreaId")]
    public virtual Area Area { get; set; }
}