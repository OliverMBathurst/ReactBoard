using System;

namespace ReactChan.Domain.Entities.Thread
{
    readonly public struct ThreadKey : IThreadKey, IEquatable<ThreadKey>
    {
        public ThreadKey(int boardId)
        {
            BoardId = boardId;
        }

        public int BoardId { get; }

        public bool Equals(ThreadKey other)
        {
            throw new NotImplementedException();
        }
    }
}
