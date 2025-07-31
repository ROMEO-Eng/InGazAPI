using System;
using InGazAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InGazAPI.Models
{
    public class WorkingLine
    {
        [Key]
        public int WorkingLineId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        // ForeignKey to Unit
        public int UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }

        // Pressure and Temperature properties
        public decimal Pressure { get; set; }
        public decimal Temperature { get; set; }

        // One-to-many with Reading
        public virtual ICollection<Reading> Readings { get; set; } = new List<Reading>();
    }
}

