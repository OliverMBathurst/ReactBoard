﻿namespace ReactBoard.Domain.Common
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}