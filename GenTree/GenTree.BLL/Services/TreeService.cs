using GenTree.DAL;
using GenTree.SharedEntities.Models;

namespace GenTree.BLL.Services
{
    public class TreeService:ServiceBase
    {
        public TreeService(UnitOfWork uow) : base(uow)
        {
            
        }

        public void CreateTree(string userId)
        {
            Tree tree = new Tree() {ApplicationUserId = userId};
            Uow.TreeRepository.Add(tree);
        }
    }
}