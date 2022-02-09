using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactBoard.ImageAPI.Domain.Common
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public TId Id { get; set; }
    }
}
