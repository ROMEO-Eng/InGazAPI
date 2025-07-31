using System.ComponentModel.DataAnnotations;

namespace InGazAPI.Businss.DTOs
{
    public class CreateStationDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int AreaId { get; set; }
    }
}