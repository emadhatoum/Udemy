using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price")]
        public double ListPrice { get; set; }
        [Range(1, 10000)]
        [Required]
        [Display(Name = "Price for 1-49")]
        public double Price { get; set; }
        [Range(1, 10000)]
        [Required]
        [Display(Name = "Price for 50-100 ")]
        public double ListPrice50 { get; set; }
        [Range(1, 10000)]
        [Required]
        [Display(Name = "Price for100+")]
        public double ListPrice100 { get; set; }
        [ValidateNever]
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }// this comand and the one below is to create foreign key
        [ValidateNever]
        [ForeignKey("CategoryId")]
        
        public Category Category { get; set; }
        [Required]
        [Display(Name ="Cover Type")]
        public int CoverTypeId { get; set; }// this comand and the one below is to create foreign key
        [ValidateNever]
        public CoverType CoverType { get; set; }


    }
}
