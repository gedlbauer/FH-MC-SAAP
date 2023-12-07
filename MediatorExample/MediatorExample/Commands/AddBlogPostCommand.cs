using MediatorExample.Domain;
using MediatorExample.Dto;
using MediatR;

namespace MediatorExample.Commands
{
    public class AddBlogPostCommand : AddBlogPostDto, IRequest<BlogPost>
    {
        public AddBlogPostCommand(AddBlogPostDto dto)
        {
            Text = dto.Text;
            Title = dto.Title;
        }
    }
}
