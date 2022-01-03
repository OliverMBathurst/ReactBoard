using System;

namespace ReactBoard.Domain.Entities.Thread
{
    readonly public struct ThreadKey : IThreadKey, IEquatable<ThreadKey>
    {
        public ThreadKey(long? threadId, int boardId)
        {
            ThreadId = threadId;
            BoardId = boardId;
        }

        public long? ThreadId { get; }

        public int BoardId { get; }

        public bool Equals(ThreadKey other)
        {
            return other.BoardId == BoardId 
                && ThreadId != null 
                && other.ThreadId != null 
                && other.ThreadId == ThreadId;
        }
    }
}