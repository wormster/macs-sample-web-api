
using System.ComponentModel.DataAnnotations;

namespace Macs.WebApi.Models.Entities
{
    public class Contact : BaseEntity
    {
        [Required]
        public Guid PersonId { get; set; }
        [Required]
        public ContactType Type { get; set; }
        [Required]
        public string Value { get; set; }
        public bool Preferred { get; set; }
        public bool IsActive { get; set; }
    }
}
