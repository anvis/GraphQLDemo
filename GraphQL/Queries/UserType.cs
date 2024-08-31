using GraphQL.Types;

namespace GraphQLAPIDemo.GraphQL
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.Id).Description("Id");
            Field(x => x.Title).Description("Title");
            Field(x => x.UserId).Description("UserId");
        }
    }
}
