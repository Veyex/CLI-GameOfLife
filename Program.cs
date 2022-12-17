using System.Threading;

namespace CLI_GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            GoL goL = new GoL();
            goL.Init();
            goL.TestTwo();
            while (true)
            {
                goL.DrawCellArray();
                goL.CalculateNeighbours();
                goL.CellStateUpdate();
                Thread.Sleep(100);
            }
        }
    }
}