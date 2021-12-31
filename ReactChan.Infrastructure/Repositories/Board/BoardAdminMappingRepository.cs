﻿using ReactChan.Domain.Entities.Board;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;

namespace ReactChan.Infrastructure.Repositories.Board
{
    public class BoardAdminMappingRepository : EntityRepository<BoardAdminMapping, Guid>, IBoardAdminMappingRepository
    {
        public BoardAdminMappingRepository(ApplicationDbContext context) : base(context) { }
    }
}
