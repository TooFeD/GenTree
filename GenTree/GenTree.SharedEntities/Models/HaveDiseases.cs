namespace GenTree.SharedEntities.Models
{
    public class HaveDiseases
    {
        public int Id { get; set; }

        public int  MemberId { get; set; }
        public virtual Member Member { get; set; }

        public int  GenDiseasesId { get; set; }
        public virtual GenDiseases GenDiseases { get; set; }
        public bool Dominant { get; set; }
    }
}