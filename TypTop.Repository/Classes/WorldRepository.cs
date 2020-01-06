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


        public void AddWorld(string description, int index, int stars, string background, string button, string hoverButton)
        {
            Add(new World
            {
                Description = description,
                Index = index,
                Stars = stars,
                Background = background,
                Button = button,
                HoverButton = hoverButton
            });
        }
    }
}
