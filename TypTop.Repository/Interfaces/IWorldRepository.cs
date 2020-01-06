using System;
using System.Collections.Generic;
using System.Text;
using TypTop.Database;

namespace TypTop.Repository
{
    public interface IWorldRepository : IRepository<World>
    {

        public void AddWorld(string description, int index, int stars, string background, string button, string hoverButton);

    }
}
