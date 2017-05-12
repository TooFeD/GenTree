using System.Collections.Generic;
using GenTree.DAL;
using GenTree.SharedEntities.Models;

namespace GenTree.BLL.Services
{
    public class GenDiseaseService:ServiceBase
    {
        public GenDiseaseService(UnitOfWork uow) : base(uow)
        {

        }

        public void AddNewDisease(GenDiseases disease)
        {
            Uow.GenDiseasesRepository.Add(disease);
        }

        public List<GenDiseases> GetAllGenDiseaseses()
        {
            return Uow.GenDiseasesRepository.GetAll();
        }

        public GenDiseases GetGenDiseasesById(int id)
        {
            return Uow.GenDiseasesRepository.GetById(id);
        }

        public void CheangeDisease(GenDiseases newDisease)
        {
            var currentDisease = Uow.GenDiseasesRepository.GetById(newDisease.Id);
            currentDisease.About = newDisease.About;
            currentDisease.MenInherited = newDisease.MenInherited;
            currentDisease.WomenInherited = newDisease.WomenInherited;
            currentDisease.Name = newDisease.Name;
        }
    }
}