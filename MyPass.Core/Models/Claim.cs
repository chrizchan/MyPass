using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPass.Core.Models
{
    public class Claim
    {
        private User _user;

        #region Scalar Properties
        public int ClaimId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
        #endregion

        #region Navigation Properties
        public virtual User User
        {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _user = value;
                UserId = value.Id;
            }
        }
        #endregion
    }
}
