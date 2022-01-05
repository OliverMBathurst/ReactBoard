using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactBoard.Domain.Common
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Key, Column(Order = 0)]
        public TId Id { get; set; }
    }
}
