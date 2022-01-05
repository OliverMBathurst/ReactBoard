using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Post;
using System.Collections.Generic;
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

        public IEnumerable<IPost> GetAllPostsForThread(int boardId, int threadId)
        {
            return _postRepository.GetAllPostsForThread(boardId, threadId);
        }
    }
}