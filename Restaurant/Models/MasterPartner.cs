using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterPartner : BaseEntity
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
    }
}
