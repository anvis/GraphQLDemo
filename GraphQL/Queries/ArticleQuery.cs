using GraphQL;
using GraphQL.Types;

namespace GraphQLAPIDemo.GraphQL
{
    public class ArticleQuery : ObjectGraphType<object>
    {
        public ArticleQuery(IArticleRepository ArticleRepository)
        {
            Name = "PostGrapghQLQuery";

            Field<ListGraphType<ArticleType>>(
                "articles").Description("Gets all Articles from Database").Resolve( context => ArticleRepository.GetArticles()
            );

            Field<ListGraphType<ArticleType>>(
                "staticposts").Resolve(context => new List<PostDTO>
                { new PostDTO {PostId = 1, CategoryId = 2, Title = "abc", Description = "Desciption"}}
            );

            Field<ListGraphType<UserType>>("Users").Resolve(context => ArticleRepository.GetUsers().Result);

            Field<ListGraphType<ArticleType>>(
                "articlesById").Description("Gets all Articles by Idfrom Database")
                .Resolve(context =>
                {
                    var filter = context.GetArgument<int>("article_Id");
                    var articles = ArticleRepository.GetArticles();
                    if (filter > 0)
                    {
                        articles = articles.Where(x => x.PostId == filter).ToList();
                    }
                    return articles;

                }
                )
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "article_Id", Description = "articles by article_Id" }));

        }
    }
}
