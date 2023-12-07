using MediatorExample.Commands;
using MediatorExample.Dal;
using MediatorExample.Domain;
using MediatR;

namespace MediatorExample.CommandHandlers
{
    public class AddBlogPostCommandHandler : IRequestHandler<AddBlogPostCommand, BlogPost>
    {
        private readonly IBlogDb db;
        public AddBlogPostCommandHandler(IBlogDb db)
        {
            this.db = db;
        }

        public Task<BlogPost> Handle(AddBlogPostCommand request, CancellationToken cancellationToken)
        {
            return db.AddPostAsync(new BlogPost { Title = request.Title, Text = request.Text });
        }
    }
}
