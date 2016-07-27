using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPass.Core.Models
{
    public class Role
    {
        #region Fields
            private ICollection<User> _users;
        #endregion

        #region Scalar Properties

            [Required]
            public Guid RoleId { get; set; }

            [Required]
            public string Name { get; set; }

        #endregion

        #region Navigation Properties
            public ICollection<User> Users
            {
                get { return _users ?? (_users = new List<User>()); }
                set { _users = value; }
            }
        #endregion
    }
}