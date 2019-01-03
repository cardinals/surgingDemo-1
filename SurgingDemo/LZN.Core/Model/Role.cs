using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LZN.Core.Model
{
    public class Role : Entity<string>
    {
        [Key]
        public string Id { set;get; }

        [Required]
        [StringLength(64)]
        public string Name { set; get; }

        public int IsDelete { set; get; }

        public DateTime CreateDate { set; get; }
    }
}
