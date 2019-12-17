using System;
using System.Collections.Generic;
using System.Text;
using TypTop.Database;

namespace TypTop.Repository
{
    public class WordRepository : Repository<Word>, IWordRepository
    {

        public WordRepository(Context context) : base(context)
        {
        }
    }
}
