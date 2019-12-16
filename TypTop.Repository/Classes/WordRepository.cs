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