using GraphQL.Types;

namespace GraphQLAPIDemo.GraphQL
{
    public class ArticleType : ObjectGraphType<ArticleDTO>
    {
        public ArticleType()
        {
            Field(x => x.ArticleId).Description("ArticleId");
            Field(x => x.Title).Description("Title");
            Field(x => x.Description).Description("Description");
            Field(x => x.CreatedDate).Description("CreatedDate");
            Field<CategoryDTOType>("Category").Description("Gets Category");
        }
    }
}
