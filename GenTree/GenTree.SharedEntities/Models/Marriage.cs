namespace GenTree.SharedEntities.Models
{
    public class Marriage
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public virtual Member Member { get; set; }

        public int MarriagId { get; set; }
        public virtual Member Marriag { get; set; }

        public bool IsMarriade { get; set; }
    }
}