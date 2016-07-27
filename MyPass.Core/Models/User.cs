using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MyPass.Core.Models
{
    public class User
    {

        public User()
        {
            //Entries = new Collection<Entry>();
            //Categories = new Collection<Category>();
        }

        #region Fields
            private ICollection<Claim> _claims;
            private ICollection<ExternalLogin> _externalLogins;
            private ICollection<Role> _roles;
        #endregion

        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string UserName  { get; set; }

        [EmailAddress]
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string SecurityStamp { get; set; }

        [Required]
        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public bool PhoneNumberConfirmed { get; set; }

        [Required]
        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public int AccessFailedCount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public ICollection<Category> Categories { get; set; }
        //public ICollection<Entry> Entries { get; set; }


        #region Navigation Properties
            public virtual ICollection<Claim> Claims
            {
                get { return _claims ?? (_claims = new List<Claim>()); }
                set { _claims = value; }
            }

            public virtual ICollection<ExternalLogin> Logins
            {
                get
                {
                    return _externalLogins ??
                        (_externalLogins = new List<ExternalLogin>());
                }
                set { _externalLogins = value; }
            }

            public virtual ICollection<Role> Roles
            {
                get { return _roles ?? (_roles = new List<Role>()); }
                set { _roles = value; }
            }
        #endregion

    }
}
