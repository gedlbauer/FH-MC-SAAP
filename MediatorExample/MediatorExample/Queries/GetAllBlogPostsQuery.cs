using MediatorExample.Domain;
using MediatR;

namespace MediatorExample.Queries
{
    public class GetAllBlogPostsQuery: IRequest<ICollection<BlogPost>>
    {
    }
}
