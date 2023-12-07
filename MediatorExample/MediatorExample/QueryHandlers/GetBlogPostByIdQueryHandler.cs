using MediatorExample.Dal;
using MediatorExample.Domain;
using MediatorExample.Queries;
using MediatR;

namespace MediatorExample.QueryHandlers
{
    public class GetBlogPostByIdQueryHandler : IRequestHandler<GetBlogPostByIdQuery, BlogPost?>
    {
        private readonly IBlogDb db;
        public GetBlogPostByIdQueryHandler(IBlogDb db)
        {
            this.db = db;
        }
        public Task<BlogPost?> Handle(GetBlogPostByIdQuery request, CancellationToken cancellationToken)
        {
            return db.GetPostAsync(request.Id);
        }
    }
}
