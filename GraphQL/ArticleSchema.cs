
using GraphQL.Types;

namespace GraphQLAPIDemo.GraphQL
{
    public class ArticleSchema : Schema
    {
        public ArticleSchema(IServiceProvider serviceProvider, ArticleQuery query)
        {
              Query = query;
        }
    }
}
