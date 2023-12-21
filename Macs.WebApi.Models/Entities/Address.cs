
using System.ComponentModel.DataAnnotations;

namespace Macs.WebApi.Models.Entities
{
    public class Address : BaseEntity
    {
        [Required]
        public Guid PersonId { get; set; }
        [Required]
        public AddressType Type { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }
        public string PostCode { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

     public bool Preffered { get; set; }
     public bool IsActive { get; set; }
    }
}
