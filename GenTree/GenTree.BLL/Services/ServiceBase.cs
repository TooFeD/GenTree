using GenTree.DAL;

namespace GenTree.BLL.Services
{
    public class ServiceBase
    {
        protected UnitOfWork Uow { get; }

        public ServiceBase(UnitOfWork uow)
        {
            Uow = uow;
        }
    }
}