using System;
using System.Diagnostics.CodeAnalysis;

namespace ReactBoard.Domain.Entities.Board
{
    public readonly struct BoardAdminMappingKey : IBoardAdminMappingKey, IEquatable<BoardAdminMappingKey>
    {
        public BoardAdminMappingKey(int userId, int boardId) 
        {
            UserId = userId;
            BoardId = boardId;
        }

        public int UserId { get; }

        public int BoardId { get; }

        public bool Equals([AllowNull] BoardAdminMappingKey other)
        {
            return other.UserId == UserId && other.BoardId == BoardId;
        }
    }
}
