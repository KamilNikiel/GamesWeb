using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using GamesWeb.Persistence.EntityConfigurations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GamesWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class IdentityModels : IdentityUser
    {
        [MaxLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [MaxLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date of Birth")]
        [MembershipAnAdultRequirement]
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        public Nullable<DateTime> Birthdate { get; set; }
        [MaxLength(50)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string NewEmail { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityModels> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}