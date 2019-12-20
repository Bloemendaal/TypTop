using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TypTop.Database;
using TypTop.Shared;

namespace TypTop.Repository
{
    public class WorldRepository : Repository<World>, IWorldRepository
    {
        public WorldRepository(Context context) : base(context)
        {
        }

        

    }
}
