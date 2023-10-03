﻿using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
