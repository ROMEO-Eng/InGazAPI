using InGazAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InGazAPI.Models
{
    public class Station
    {
        [Key]
        public int StationId { get; set; }
        public string Name
        {
            get => StationName;
            set => StationName = value;
        }
        public string StationName { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; } = string.Empty;


        // Many-to-one with Area
        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }

        // Many-to-many with Unit
        public virtual ICollection<StationUnit> StationUnits { get; set; } = new List<StationUnit>();
    }




}



