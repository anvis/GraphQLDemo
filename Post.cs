namespace GraphQLAPIDemo
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Category? Category { get; set; }
        //  public object Id { get; internal set; }
        //  public string CategoryName { get; internal set; }
    }
}
