using InGazAPI.Businss;
using Microsoft.Azure.Documents;
using System.ComponentModel.DataAnnotations;
namespace InGazAPI.Models
{

    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        [Required]
        [MaxLength(100)]
        public string AreaName { get; set; } = string.Empty;
        public List<Station> Stations { get; set; } = new();
        public List<User> Users { get; set; } = new();
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;

        // Many-to-many with Station
        public virtual ICollection<AreaStation> AreaStation { get; set; } = new List<AreaStation>();


        public virtual ICollection<UserArea> UserAreas { get; set; } = new List<UserArea>();
    }


}
