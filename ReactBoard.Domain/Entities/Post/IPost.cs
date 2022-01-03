using ReactBoard.Domain.Entities.Image;
using ReactBoard.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ReactBoard.Domain.Entities.Post
{
    public interface IPost : IEntity<PostKey>
    {
        DateTime Time { get; set; }

        IImage Image { get; set; }

        string Text { get; set; }

        IEnumerable<IPost> Replies { get; set; }
    }
}
