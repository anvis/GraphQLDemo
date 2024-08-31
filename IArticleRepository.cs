namespace GraphQLAPIDemo
{
    public interface IArticleRepository
    {
        Task<List<Category>> GetCategories();

        List<PostDTO> GetArticles();

        void AddPost(Post post, Category category);

      //  Task UpdatePost(Post post);
    }
}
