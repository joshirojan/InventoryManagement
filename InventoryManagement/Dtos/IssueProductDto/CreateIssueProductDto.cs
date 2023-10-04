using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Dtos.IssueProductDto
{
    public class CreateIssueProductDto
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual User? User { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        [ValidateNever]
        public virtual Product? Product { get; set; }

        [Range(1, 1000)]
        public int Quantity { get; set; }

    }
}
