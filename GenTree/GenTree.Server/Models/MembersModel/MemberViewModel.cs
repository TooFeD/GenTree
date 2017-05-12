using System;
using System.Collections.Generic;
using GenTree.SharedEntities.Models;

namespace GenTree.Server.Models
{
    public class AllMembersViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeth { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public string OtherInfo { get; set; }
        public List<ParentsViewModel> Parents { get; set; }
        public List<ChildsViewModel> Childs { get; set; }
        public List<MarriageViewModel> Marriages { get; set; }
        public List<HaveDiseaseViewModel> Diseaseses { get; set; }
    }

    public class ParentsViewModel
    {
        public int ParentId { get; set; }
    }

    public class ChildsViewModel
    {
        public int ChieldId { get; set; }
    }

    public class MarriageViewModel
    {
        public int MarriageId { get; set; }
        public bool IsMarriade { get; set; }
    }

    public class HaveDiseaseViewModel
    {
        public int DiseaseId;
        public string NameDisease { get; set; }
        public bool WomenInherited { get; set; }
        public bool MenInherited { get; set; }
        public string About { get; set; }
              
        public bool Dominante;
    }

}