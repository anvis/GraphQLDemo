using GraphQL.Types;

namespace GraphQLAPIDemo.GraphQL
{
    public class ArticleGraphQLType : ObjectGraphType<PostDTO>
    {
        public ArticleGraphQLType()
        {
            Field(x => x.PostId).Description("Postid");
            Field(x => x.Title).Description("Title");
            Field(x => x.Description).Description("Description");
            Field(x => x.CreatedDate).Description("CreatedDate");

            //Field<ListGraphType<ParticipantType>>(
            //    "participants",
            //    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "postId" }),
            //    resolve: context => repository.GetParticipantInfoByEventId(context.Source.PostId)
            //);
        }
    }
}
