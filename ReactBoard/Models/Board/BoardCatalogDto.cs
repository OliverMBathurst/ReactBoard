using System.Collections.Generic;

namespace ReactBoard.API.Models.Board
{
    public sealed class BoardCatalogDto
    {
        public IEnumerable<BoardCatalogItemDto> Items { get; set; }
    }
}
