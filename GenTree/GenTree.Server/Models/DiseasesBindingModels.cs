using System.ComponentModel.DataAnnotations;

namespace GenTree.Server.Models
{
    public class AddGenDiseasesBindingModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool WomenInherited { get; set; }
        [Required]
        public bool MenInherited { get; set; }
        public string About { get; set; }
    
    }

    public class HaveDiseaseBindingModel
    {
        public int MemberId { get; set; }

        public int CurrentDiseaseId { get; set; }
        public int DiseaseId { get; set; }
        public bool Dominante { get; set; }
    }

    
}