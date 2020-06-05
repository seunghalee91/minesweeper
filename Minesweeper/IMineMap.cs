namespace Minesweeper
{
    public interface IMineMap
    {
        int CountBombs { get; }
        int Height { get; }
        MineItem[,] MineItems { get; set; }
        int Width { get; }

        bool CheckEndGame();
        void Click(int y, int x);
        void GenerateBombs(int value);
        void GenerateCountNearBombs();
    }
}