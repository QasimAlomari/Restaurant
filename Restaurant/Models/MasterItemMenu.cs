using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterItemMenu : BaseEntity
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
    }
}
