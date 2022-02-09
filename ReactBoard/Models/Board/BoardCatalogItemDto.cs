using ReactBoard.Domain.Entities.Post;

namespace ReactBoard.API.Models.Board
{
    public sealed class BoardCatalogItemDto
    {
        public int TotalReplies { get; set; }

        public int TotalImages { get; set; }

        public IPost OriginalPost { get; set; }
    }
}
