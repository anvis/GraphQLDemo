namespace GraphQLAPIDemo
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual CategoryDTO? Category { get; set; }
    }

    public class CategoryDTO
    {
       
        public int Id { get; set; }
        public string? Name { get; set; }
       // public string? Slug { get; set; }
    }


}
