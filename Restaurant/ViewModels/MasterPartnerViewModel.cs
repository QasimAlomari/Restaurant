using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Restaurant.ViewModels
{
    public class MasterPartnerViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterPartnerId { get; set; }
        [Required(ErrorMessage = "Partner Name Is Required")]
        [DisplayName("Name")]
        public string MasterPartnerName { get; set; }
        [DisplayName("Logo")]
        public string MasterPartnerLogoImageUrl { get; set; }
        [Required(ErrorMessage = "Website Url Is Required")]
        [DisplayName("Website Url")]
        public string MasterPartnerWebsiteUrl { get; set; }
        [DisplayName("Upload Logo")]
        public IFormFile UploadLogo { get; set; }
    }
}
