﻿using System.ComponentModel.DataAnnotations;

namespace Event_Mangement_System_Front_End.Models
{
    public class Login
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
