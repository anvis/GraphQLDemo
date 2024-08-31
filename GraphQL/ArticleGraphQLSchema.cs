
using GraphQL.Types;

namespace GraphQLAPIDemo.GraphQL
{
    public class ArticleGraphQLSchema : Schema
    {
        public ArticleGraphQLSchema(IServiceProvider serviceProvider, ArticleGraphQLQuery query)
        {
              Query = query;
            //Query = serviceProvider.GetRequiredService<ArticleGraphQLQuery>();
        }
    }
}
