﻿using System.ComponentModel.DataAnnotations;

namespace ProductWebAPI2025.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Fname { get; set; }

        [Required]
        public string Sname{ get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
