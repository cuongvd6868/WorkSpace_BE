﻿using System.ComponentModel.DataAnnotations;

namespace WorkSpace.DTOs.AccountDto
{
    public class LoginDto
    {
        [Required]
        public string? Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
