using MediatorExample.Domain;
using MediatR;

namespace MediatorExample.Queries
{
    public class GetBlogPostByIdQuery : IRequest<BlogPost?>
    {
        public GetBlogPostByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
