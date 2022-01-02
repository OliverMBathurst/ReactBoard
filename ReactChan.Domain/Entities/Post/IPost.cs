using ReactChan.Domain.Entities.Image;
using ReactChan.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ReactChan.Domain.Entities.Post
{
    public interface IPost : IEntity<PostKey>
    {
        DateTime Time { get; set; }

        IImage Image { get; set; }

        string Text { get; set; }

        IEnumerable<IPost> Replies { get; set; }
    }
}
