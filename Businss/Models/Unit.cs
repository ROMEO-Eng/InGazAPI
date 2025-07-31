using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InGazAPI.Models
{
    // SOLUTION 1: Quick fix - just initialize the properties
    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]     //Maximum length for the name
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }


        // One-to-many with WorkingLine
        public virtual ICollection<WorkingLine> WorkingLines { get; set; } = new List<WorkingLine>();
    }
    // Join table for Station-Unit many-to-many

}