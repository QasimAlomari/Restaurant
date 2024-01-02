using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterCategoryMenu : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterCategoryMenuId { get; set; }
        [MaxLength(250)]
        [MinLength(2)]
        [Required(ErrorMessage = "Name Is Required")]
        [DisplayName("Name")]
        public string MasterCategoryMenuName { get; set; }
    }
}
