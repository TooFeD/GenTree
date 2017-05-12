using System.Data.Entity;
using GenTree.SharedEntities.Models;

namespace GenTree.DAL.Repository
{
    public class GenDiseasesRepository:BaseRepository<GenDiseases>
    {
        public GenDiseasesRepository(DbContext dataContext) : base(dataContext)
        {

        }
    }
}