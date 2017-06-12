using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenTree.DAL;

namespace GenTree.BLL.Services
{
    class UserService:ServiceBase
    {
        public UserService(UnitOfWork uow) : base(uow)
        {
           
        }
    }
}
