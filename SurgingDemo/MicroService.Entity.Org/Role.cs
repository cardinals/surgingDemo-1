using MicroService.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroService.Entity.Org
{
    public class Role : Entity<string>
    {

        [Required]
        [StringLength(64)]
        public string Name { set; get; }
    }
}
