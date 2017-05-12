namespace GenTree.SharedEntities.Models
{
    public class Parents
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public virtual Member Member { get; set; }

        public int ParentId { get; set; }
        public virtual Member Parent { get; set; }
       
    }
}