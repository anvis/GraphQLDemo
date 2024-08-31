using Microsoft.EntityFrameworkCore;

namespace GraphQLAPIDemo
{
    public class ArticleRepository : IArticleRepository
    {
        //BlogDBContext blogDBContext = new BlogDBContext();

        //  private Category category;

        private BlogDBContext _blogDBContext;
        public ArticleRepository(BlogDBContext blogDBContext)
        {
            _blogDBContext = blogDBContext;
        }

        public void AddPost(Post post, Category category)
        {
            // category = new Category();
            _blogDBContext.Categories.Add(category);

            _blogDBContext.SaveChanges();


            _blogDBContext.Posts.Add(post);
            _blogDBContext.SaveChanges();
        }

        public Task<List<Category>> GetCategories()
        {
            throw new System.NotImplementedException();
        }


        public List<PostDTO> GetArticles()
        {
            var posts = _blogDBContext.Posts.Include(x => x.Category).ToList();
            List<PostDTO> postDTO = new List<PostDTO>();

            foreach (var post in posts)
            {
                postDTO.Add(new PostDTO()
                {
                    PostId = post.PostId,
                    Category = new CategoryDTO { Id = post.Category.Id, Name = post.Category.Name },
                    CategoryId = post.Category.Id,
                    CreatedDate = post.CreatedDate,
                    Description = post.Description,
                    Title = post.Title

                });
            }

            return postDTO;
        }

        //public Task UpdatePost(Post post)
        //{

        //    throw new System.NotImplementedException();
        //}
    }
}
