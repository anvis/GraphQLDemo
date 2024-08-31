using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        public void AddArticle(Article Article, Category category)
        {
            // category = new Category();
            _blogDBContext.Categories.Add(category);

            _blogDBContext.SaveChanges();


            _blogDBContext.Articles.Add(Article);
            _blogDBContext.SaveChanges();
        }

        public Task<List<Category>> GetCategories()
        {
            throw new System.NotImplementedException();
        }


        public List<ArticleDTO> GetArticles()
        {
            var Articles = _blogDBContext.Articles.Include(x => x.Category).ToList();
            List<ArticleDTO> ArticleDTO = new();

            foreach (var Article in Articles)
            {
                ArticleDTO.Add(new ArticleDTO()
                {
                    ArticleId = Article.ArticleId,
                    Category = new CategoryDTO { Id = Article.Category.Id, Name = Article.Category.Name },
                    CategoryId = Article.Category.Id,
                    CreatedDate = Article.CreatedDate,
                    Description = Article.Description,
                    Title = Article.Title

                });
            }

            return ArticleDTO;
        }

        public async  Task<List<User>> GetUsers()
        {
            List<User> users = new List<User>();
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/todos");
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                dynamic result = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<User>>(result);
            }

            return users;
        }


        public Category AddCategory(Category category)
        {
            // category = new Category();
            _blogDBContext.Categories.Add(category);

            _blogDBContext.SaveChanges();   

            return category;

        }

            //public Task UpdateArticle(Article Article)
            //{

            //    throw new System.NotImplementedException();
            //}
        }
    }
