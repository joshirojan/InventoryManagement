﻿using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Dtos.StockDto
{
    public class CreateStockDto
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        [ValidateNever]
        public virtual Product? Product { get; set; }

        [Range(0, 1000)]
        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
