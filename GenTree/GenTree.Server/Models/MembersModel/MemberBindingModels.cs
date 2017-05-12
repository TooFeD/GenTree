using System;

namespace GenTree.Server.Models
{
    public class AddMemberBindingModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeth { get; set; }
        public string Address { get; set; }

        public byte[] Photo { get; set; }

        public string OtherInfo { get; set; }

    }

   
}