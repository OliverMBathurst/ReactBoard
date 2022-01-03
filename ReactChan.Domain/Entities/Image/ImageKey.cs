using System;

namespace ReactBoard.Domain.Entities.Image
{
    readonly public struct ImageKey : IImageKey, IEquatable<ImageKey>
    {
        public ImageKey(long? imageId)
        {
            ImageId = imageId;           
        }

        public long? ImageId { get; }

        public bool Equals(ImageKey other)
        {
            return other.ImageId != null && ImageId != null && other.ImageId == ImageId;
        }
    }
}
