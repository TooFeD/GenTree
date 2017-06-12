using System.Data.Entity;
using GenTree.DAL.Repository;
using GenTree.SharedEntities.Models;

namespace GenTree.DAL
{
    public class UnitOfWork
    {
        protected DbContext DbContext { get; }
        public TreeRepository TreeRepository;
        public FriendshipRepository FriendshipRepository;
        public GenDiseasesRepository GenDiseasesRepository;
        public HaveDiseaseRepository HaveDiseaseRepository;
        public MemberRepository MemberRepository;
        public ParentsRepository ParentsRepository;
        public ChildsRepository ChildsRepository;
        public MarriageRepository MarriageRepository;
      
       // public ApplicationUserRepository ApplicationUserRepository;
      
     
      
        //public ProductKeyRepository ProductKeyRepository;


        public UnitOfWork(DbContext dataContext)
        {
            DbContext = dataContext;
            TreeRepository = new TreeRepository(dataContext);
            FriendshipRepository = new FriendshipRepository(dataContext);
            GenDiseasesRepository = new GenDiseasesRepository(dataContext);
            HaveDiseaseRepository = new HaveDiseaseRepository(dataContext);
            MemberRepository = new MemberRepository(dataContext);
            ParentsRepository = new ParentsRepository(dataContext);
            ChildsRepository = new ChildsRepository(dataContext);
            MarriageRepository = new MarriageRepository(dataContext);
        
        //    ApplicationUserRepository = new ApplicationUserRepository(dataContext);
            //ProductKeyRepository = new ProductKeyRepository(dataContext);
           
        }

      

        public void Commit()
        {
            DbContext?.SaveChanges();
        }
    }
}