using MicroService.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroService.Entity.Order
{
    public class Person : Entity<string>
    {
        
     //   public  string Id { set; get; }


        public string RoleId { set; get; }

        [Required]
        [StringLength(64)]
        public string Name { set; get; }


        [StringLength(16)]
        public string PhoneCode { set; get; }
         

    //    public int IsDelete { set; get; }

     //   public DateTime CreateDate { set; get; }

      
    }
}
