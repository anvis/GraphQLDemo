
using GraphQL.Types;
using GraphQLAPIDemo.GraphQL.Mutations;

namespace GraphQLAPIDemo.GraphQL
{
    public class ArticleSchema : Schema
    {
        public ArticleSchema(IServiceProvider serviceProvider, ArticleQuery query, CategotyMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
