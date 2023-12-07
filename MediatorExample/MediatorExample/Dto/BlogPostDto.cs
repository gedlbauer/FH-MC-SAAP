using MediatorExample.Domain;

namespace MediatorExample.Dto
{
    public class BlogPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public BlogPostDto(BlogPost from)
        {
            Id = from.Id;
            Title = from.Title;
            Text = from.Text;
        }
    }
}
