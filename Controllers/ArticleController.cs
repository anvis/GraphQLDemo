using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticleRepository _ArticleRepository { get; set; }
        public ArticleController(IArticleRepository ArticleRepository)
        {
            _ArticleRepository = ArticleRepository;
        }


        [HttpGet(Name = "GetArticles")]
        public  List<PostDTO> Get()
        {
            return  _ArticleRepository.GetArticles();
        }
    }
}
