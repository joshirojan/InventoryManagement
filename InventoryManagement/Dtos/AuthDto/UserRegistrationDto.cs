﻿using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Dtos.AuthDto
{
    public class UserRegistrationDto
    {

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string PasswordHash { get; set; } = string.Empty;

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        [ValidateNever]
        public virtual Role? role { get; set; }
    }
}
