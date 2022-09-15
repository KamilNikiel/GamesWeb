using GamesWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesWeb.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public int? Id { get; set; }

        [MaxLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [MaxLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd:0}", ApplyFormatInEditMode = true)]
        [MembershipAnAdultRequirement]
        public Nullable<DateTime> Birthdate { get; set; }
        [Required]
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Current e-mail")]
        public string Email { get; set; }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string NewEmail { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm E-mail")]
        [Compare("Email", ErrorMessage = "The e-mail and confirmation email do not match.")]
        public string ConfirmEmail { get; set; }

        [MaxLength(50)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Customer";
            }
        }
        public CustomerFormViewModel()
        {
            Id = 0;
        }
        public CustomerFormViewModel(IdentityModels customer)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            MembershipTypeId = customer.MembershipTypeId;
            Birthdate = customer.Birthdate;
            UserName = customer.UserName;
            PhoneNumber = customer.PhoneNumber;
            Email = customer.Email;
            NewEmail = customer.NewEmail;
        }
    }
}