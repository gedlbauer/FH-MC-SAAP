using MediatorExample.Domain;
using System.Collections.ObjectModel;

namespace MediatorExample.Dal
{
    public class MockBlogDb : IBlogDb
    {
        private ICollection<BlogPost> posts = new List<BlogPost>()
        {
            new BlogPost { Id = 0, Text = "Das ist mein erster Blog Post!", Title = "Hallo Welt" },
            new BlogPost { Id = 1, Text = "Das ist mein zweiter Blog Post!", Title = "Wow" },
            new BlogPost { Id = 2, Text = "Das ist mein dritter Blog Post! Versuche jetzt selbst, einen Post zu verfassen!", Title = "Post 3" }
        };

        public Task<BlogPost> AddPostAsync(BlogPost postToAdd)
        {
            postToAdd.Id = posts.Count;
            posts.Add(postToAdd);
            return Task.FromResult(postToAdd);
        }

        public Task<BlogPost?> GetPostAsync(int id)
        {
            return Task.FromResult(posts.SingleOrDefault(p => p.Id == id));
        }

        public Task<ICollection<BlogPost>> GetPostsAsync()
        {
            return Task.FromResult(posts);
        }
    }
}
