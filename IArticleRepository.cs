namespace GraphQLAPIDemo
{
    public interface IArticleRepository
    {
        Task<List<Category>> GetCategories();

        List<ArticleDTO> GetArticles();

        Task<List<User>> GetUsers();

        void AddArticle(Article Article, Category category);

        Category AddCategory( Category category);

        //  Task UpdateArticle(Article Article);
    }
}
