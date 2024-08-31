
using GraphQL.Types;
using GraphQL;

namespace GraphQLAPIDemo.GraphQL.Mutations
{
    public class CategotyMutation : ObjectGraphType
    {
        public CategotyMutation(IArticleRepository articleRepository)
        {
            Field<CategoryType>("CreateCategory")
                .Arguments(new QueryArguments(new QueryArgument<CategoryInputType> { Name = "Category" }))
                .Resolve(context =>
                {
                    var category = context.GetArgument<Category>("Category");
                    return articleRepository.AddCategory(category);
                });
                
        }
    }
}
