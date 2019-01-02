using LZN.Core.Data;
using LZN.Core.IRespository;
using LZN.Core.Model;
using LZN.EntityFramwork.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZN.EntityFramwork.Respository
{
    public class PersonRespository : RespositoryBase<Person>, IPersonRespository
    {
       
              


        public PersonRespository(IUnitOfWorkDbContext dbDbContext) : base(dbDbContext)
        {
           
        }
    }
}
