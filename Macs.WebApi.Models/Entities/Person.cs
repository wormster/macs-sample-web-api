using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Macs.WebApi.Models.Entities
{
    public class Person : BaseEntity
    {
        public Person()
        {
            Addresses = new List<Address>();
            Contacts = new List<Contact>();
        }

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }


        public string Title { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [IgnoreDataMember]
        public IList<Address> Addresses { get; set; }


        [IgnoreDataMember]
        public IList<Contact> Contacts { get; set; }

    }
}