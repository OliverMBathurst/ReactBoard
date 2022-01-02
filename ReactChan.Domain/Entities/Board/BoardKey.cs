using System;
using System.Diagnostics.CodeAnalysis;

namespace ReactChan.Domain.Entities.Board
{
    public readonly struct BoardKey : IBoardKey, IEquatable<BoardKey>
    {
        public BoardKey(int? boardId) 
        {
            BoardId = boardId;
        }

        public int? BoardId { get; }

        public bool Equals([AllowNull] BoardKey other)
        {
            return other.BoardId != null && BoardId != null && BoardId == other.BoardId;
        }
    }
}
