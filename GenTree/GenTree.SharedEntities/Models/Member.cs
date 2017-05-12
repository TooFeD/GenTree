using System;
using System.Collections.Generic;

namespace GenTree.SharedEntities.Models
{
    public class Member
    {
        public int Id { get; set; }
        public int TreeId { get; set; }
        public virtual Tree Tree { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeth { get; set; }
        public string Address { get; set; }

        public byte[] Photo { get; set; }

        public string OtherInfo { get; set; }

        public virtual List<HaveDiseases> Diseaseses { get; set; }
        public virtual List<Parents> Parents { get; set; }
        public virtual List<Childs> Childs { get; set; }
        public virtual List<Marriage> Marriages { get; set; } 
        
   }
}