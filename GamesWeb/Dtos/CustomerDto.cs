using GamesWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesWeb.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        //[MembershipAnAdultRequirement]
        public Nullable<DateTime> Birthdate { get; set; }
    }
}