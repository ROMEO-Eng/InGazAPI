using InGazAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// SOLUTION 1: Initialize with default values (Recommended for Entity Framework)
public class User
{
    [Key]
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty; // "Admin" or "Operator"
    public int? AreaId { get; set; } // For Admins (already nullable, no warning)
    public List<UserStation> UserStations { get; set; } = new List<UserStation>(); // For Operators
    public bool IsDeleted { get; set; } = false; // Soft delete flag
                                                 // Many-to-many with Area
    public virtual ICollection<UserArea> UserAreas { get; set; } = new List<UserArea>();
}






