
using GraphQL.Types;

namespace GraphQLAPIDemo.GraphQL.Mutations
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(x => x.Id).Description("Id");
            Field(x => x.Name).Description("Name");
        }
    }
}
