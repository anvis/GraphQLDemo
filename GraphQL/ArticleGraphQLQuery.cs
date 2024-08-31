using GraphQL;
using GraphQL.Types;

namespace GraphQLAPIDemo.GraphQL
{
    public class ArticleGraphQLQuery : ObjectGraphType<object>
    {
        public ArticleGraphQLQuery(IArticleRepository ArticleRepository)
        {
            Name = "PostGrapghQLQuery";

            //Field<PosttGraphQLType>(
            //    "event",
            //    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "eventId" }),
            //    resolve: context => ArticleRepository.GetArticles()
            //);

            Field<ListGraphType<ArticleGraphQLType>>(
                "posts",
                resolve: context => ArticleRepository.GetArticles()
            );

            Field<ListGraphType<ArticleGraphQLType>>(
                "staticposts",
                resolve: context => new List<PostDTO>
                { new PostDTO {PostId = 1, CategoryId = 2, Title = "abc", Description = "Desciption"}}
            );
        }
    }
}
