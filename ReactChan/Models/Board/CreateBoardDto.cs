﻿using System;
using _Board = ReactChan.Domain.Entities.Board.Board;

namespace ReactChan.Models.Board
{
    public sealed class CreateBoardDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Suffix { get; set; }

        public bool IsWorkSafe { get; set; }

        public int MaxThreads { get; set; }

        public static implicit operator _Board(CreateBoardDto dto) 
        {
            return new _Board(Guid.NewGuid())
            {
                Name = dto.Name,
                Description = dto.Description,
                Suffix = dto.Suffix,
                IsWorkSafe = dto.IsWorkSafe,
                MaxThreads = dto.MaxThreads
            };
        }
    }
}