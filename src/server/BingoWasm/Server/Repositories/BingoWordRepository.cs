using BingoWasm.Server.Data;

namespace BingoWasm.Server.Repositories
{
    public class BingoWordRepository : IBingoWordRepository
    {
        private readonly ApplicationDbContext _context;
        public BingoWordRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void AddBingo(BingoWord bingo)
        {
            _context.BingoWords.Add(bingo);
            _context.SaveChanges();
        }

        public List<BingoWord> GetBingoWords()
        {
            return _context.BingoWords.ToList();
        }

        public void RemoveBingo(string bingoName)
        {
            var org = _context.BingoWords.Where(x => x.Name == bingoName).FirstOrDefault();
            if (org != null)
            {
                _context.BingoWords.Remove(org);
                _context.SaveChanges();
            }
        }
    }
}
