using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterCategoryMenuViewModel : BaseEntity
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
