using ReactBoard.API.Models.Post;
using ReactBoard.Domain.Entities.Thread;
using System.Linq;

namespace ReactBoard.API.Models.Thread
{
    public sealed class FeaturedThreadDto
    {
        public FeaturedThreadDto(IThread thread)
        {
            ThreadId = thread.Id;
            OriginalPost = new PostDto(thread.Posts.OrderByDescending(x => x.Time).First());
        }

        public long ThreadId { get; set; }

        public string BoardName { get; set; }

        public string BoardUrlName { get; set; }

        public PostDto OriginalPost { get; set; }
    }
}
