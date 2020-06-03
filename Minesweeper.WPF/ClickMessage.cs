namespace Minesweeper.WPF
{
    public class ClickMessage
    {
        public ClickMessage(int y, int x)
        {
            Y = y;
            X = x;
        }

        public int Y { get; set; }
        public int X { get; set; }
    }
}