using GraphQL.Types;

namespace GraphQLAPIDemo.GraphQL
{
    public class CategoryDTOType : ObjectGraphType<CategoryDTO>
    {
        public CategoryDTOType()
        {
            Field(x => x.Id).Description("Id");
            Field(x => x.Name).Description("Name");
        }

    }
}
