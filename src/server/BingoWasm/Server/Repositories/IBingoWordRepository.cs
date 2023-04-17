namespace BingoWasm.Server.Repositories
{
    public interface IBingoWordRepository
    {
        void AddBingo(BingoWord bingo);
        void RemoveBingo(string bingoId);
        List<BingoWord> GetBingoWords();
    }
}
