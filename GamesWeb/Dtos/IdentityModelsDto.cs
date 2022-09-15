using GamesWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesWeb.Dtos
{
    public class IdentityModelsDto
    {
        public string Id { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[MembershipAnAdultRequirement]
        public Nullable<DateTime> Birthdate { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}