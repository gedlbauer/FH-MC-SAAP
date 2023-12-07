using MediatorExample.Domain;

namespace MediatorExample.Dal
{
    public interface IBlogDb
    {
        Task<BlogPost> AddPostAsync(BlogPost postToAdd);
        Task<BlogPost?> GetPostAsync(int id);
        Task<ICollection<BlogPost>> GetPostsAsync();
    }
}
