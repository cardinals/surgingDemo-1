using MicroService.IRespository.Order;
using MicroService.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Respository.Order
{
    public class PersonRespository : RespositoryBase<MicroService.Entitiy.Order.Person>, IPersonRespository
    {




        public PersonRespository(IUnitOfWorkDbContext dbDbContext) : base(dbDbContext)
        {

        }
    }
}
