using MediatorExample.Dal;
using MediatorExample.Domain;
using MediatorExample.Queries;
using MediatR;

namespace MediatorExample.QueryHandlers
{
    public class GetAllBlogPostsQueryHandler : IRequestHandler<GetAllBlogPostsQuery, ICollection<BlogPost>>
    {
        private readonly IBlogDb db;
        public GetAllBlogPostsQueryHandler(IBlogDb db)
        {
            this.db = db;
        }
        public Task<ICollection<BlogPost>> Handle(GetAllBlogPostsQuery request, CancellationToken cancellationToken)
        {
            return db.GetPostsAsync();
        }
    }
}
