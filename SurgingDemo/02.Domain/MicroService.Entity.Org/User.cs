using MicroService.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroService.Entity.Org
{
    public class User : Entity<string>
    {
        public string RoleId { set; get; }

        [Required]
        [StringLength(64)]
        public string Name { set; get; }

        [Required]
        [StringLength(128)]
        public string Password { set; get; }

        [StringLength(16)]
        public string PhoneCode { set; get; }

    }
}
