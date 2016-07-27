using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPass.Core.Models
{
    public class ExternalLogin
    {
        private User _user;

        #region Scalar Properties

        [Required]
        [MaxLength(128)]
        public string LoginProvider { get; set; }

        [MaxLength(128)]
        [Required]
        public string ProviderKey { get; set; }

        [Required]
        public Guid UserId { get; set; }
        #endregion

        #region Navigation Properties
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                UserId = value.Id;
            }
        }
        #endregion
    }
}
