﻿using ReactChan.Domain.Entities.Board;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;

namespace ReactChan.Infrastructure.Repositories.Board
{
    public class BoardRepository : EntityRepository<IBoard, Guid>, IBoardRepository
    {
        public BoardRepository(ApplicationDbContext context) : base(context) { }
    }
}