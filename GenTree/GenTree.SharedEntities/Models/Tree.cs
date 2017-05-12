namespace GenTree.SharedEntities.Models
{
    public class Tree
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}