using System;

namespace ReactChan.Domain.Entities.Post
{
    readonly public struct PostKey : IPostKey, IEquatable<PostKey>
    {
        public PostKey(long? postId, long threadId, int boardId) 
        {
            PostId = postId;
            ThreadId = threadId;
            BoardId = boardId;
        }

        public long? PostId { get; }

        public int BoardId { get; }

        public long ThreadId { get; }

        public bool Equals(PostKey other)
        {
            return other.PostId != null 
                && PostId != null 
                && other.PostId == PostId 
                && other.ThreadId == ThreadId 
                && other.BoardId == BoardId;
        }
    }
}