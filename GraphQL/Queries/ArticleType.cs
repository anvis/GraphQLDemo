using GraphQL.Types;

namespace GraphQLAPIDemo.GraphQL
{
    public class ArticleType : ObjectGraphType<PostDTO>
    {
        public ArticleType()
        {
            Field(x => x.PostId).Description("Postid");
            Field(x => x.Title).Description("Title");
            Field(x => x.Description).Description("Description");
            Field(x => x.CreatedDate).Description("CreatedDate");
            Field<CategoryDTOType>("Category").Description("Gets Category");
        }
    }
}
