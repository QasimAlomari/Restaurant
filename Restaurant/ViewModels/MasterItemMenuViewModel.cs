using Restaurant.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Restaurant.ViewModels
{
    public class MasterItemMenuViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterItemMenuId { get; set; }
        [DisplayName("Category Id")]
        public int? MasterCategoryMenuId { get; set; }
        [Required(ErrorMessage = "Title Is Required")]
        [DisplayName("Title")]
        public string MasterItemMenuTitle { get; set; }
        [Required(ErrorMessage = "Breif Is Required")]
        [DisplayName("Breif")]
        public string MasterItemMenuBreif { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        [DisplayName("Description")]
        public string MasterItemMenuDesc { get; set; }
        [DisplayName("Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MasterItemMenuPrice { get; set; }
        [DisplayName("Image")]
        public string MasterItemMenuImageUrl { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.DateTime)]
        [DisplayName("Date")]
        public DateTime? MasterItemMenuDate { get; set; }
        public virtual MasterCategoryMenu MasterCategoryMenu { get; set; }
        [DisplayName("Upload Image")]
        public IFormFile UploadImage { get; set; }
    }
}
