
using GraphQL.Types;
namespace GraphQLAPIDemo.GraphQL.Mutations
{
    public class CategoryInputType : InputObjectGraphType
    {
        public CategoryInputType()
        {
            Name = "CategoryInput";
            Field<NonNullGraphType<StringGraphType>>("Name");
        }

    }
}
