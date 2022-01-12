using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Post;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Domain.Services.Post
{
    public sealed class PostService : EntityService<_Post, long>, IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository) : base(postRepository) 
        {
            _postRepository = postRepository;
        }

        public async Task<IPost> GetPostAsync(long postId) 
        {
            return await _postRepository.GetPostAsync(postId);
        }

        public IEnumerable<IPost> GetAllPostsForThread(long threadId, int boardId)
        {
            return _postRepository.GetAllPostsForThread(threadId, boardId);
        }
    }
}