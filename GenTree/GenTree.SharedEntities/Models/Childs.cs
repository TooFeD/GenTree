namespace GenTree.SharedEntities.Models
{
    public class Childs
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public virtual Member Member { get; set; }

        public int ChildId { get; set; }
        public virtual Member Child { get; set; }
    }
}