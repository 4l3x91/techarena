﻿using System.ComponentModel.DataAnnotations;

namespace API.Identity.Models
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
