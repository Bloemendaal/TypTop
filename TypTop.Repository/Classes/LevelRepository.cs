using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TypTop.Database;
using TypTop.Shared;

namespace TypTop.Repository
{
    public class LevelRepository : Repository<Level>, ILevelRepository
    {
        public LevelRepository(Context context) : base(context)
        {
        }

       
    }
}
