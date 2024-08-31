namespace GraphQLAPIDemo
{
    public  class Category
    {
        public Category()
        {
           // Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Slug { get; set; }

        //[NonSerialized]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
