namespace CLI_GameOfLife
{
    class GoL
    {
        public int rowNum;
        public int columnNum;
        public int[,] cellArray;
        public int[,] neighbourArray;

        public GoL()
        {
            cellArray = new int[rowNum, columnNum];
            neighbourArray = new int[rowNum, columnNum];
        }

        public void Init()
        {
            Console.WriteLine("Enter No. of Rows:");
            rowNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter No. of Columns:");
            columnNum = Convert.ToInt32(Console.ReadLine());
            cellArray = new int[rowNum, columnNum];
            neighbourArray = new int[rowNum, columnNum];
            for (int targetY = 0; targetY < rowNum; targetY++)
            {
                for (int targetX = 0; targetX < columnNum; targetX++)
                {
                    cellArray[targetX, targetY] = 0;
                }
            }
        }

        public void Test()
        {
            cellArray[4 ,5] = 1;
            cellArray[3, 5] = 1;
            cellArray[5, 5] = 1;
        }

        public void TestTwo()
        {
            cellArray[1, 0] = 1;
            cellArray[2, 1] = 1;
            cellArray[1, 2] = 1;
            cellArray[2, 2] = 1;
            cellArray[0, 2] = 1;
        }

        public void CalculateNeighbours()
        {
            int total;
            for (int targetY = 0; targetY < rowNum; targetY++)
            {
                for (int targetX = 0; targetX < columnNum; targetX++)
                {
                    total = 0;
                    for (int neighbourY = targetY-1; neighbourY < targetY+2; neighbourY++)
                    {
                        for (int neighbourX = targetX - 1; neighbourX < targetX + 2; neighbourX++)
                        {
                            if (neighbourY < rowNum & neighbourX < columnNum & neighbourY >= 0 & neighbourX >= 0)
                            {
                                total += cellArray[neighbourY, neighbourX];
                            }
                        }
                    }
                    if (cellArray[targetY, targetX] == 1)
                    {
                        neighbourArray[targetY, targetX] = total - 1;
                    }
                    else
                    {
                        neighbourArray[targetY, targetX] = total;
                    }
                }
            }
        }

        public void CellStateUpdate()
        {
            for (int targetY = 0; targetY < rowNum; targetY++)
            {
                for (int targetX = 0; targetX < columnNum; targetX++)
                {
                    if (neighbourArray[targetY, targetX] == 3 & cellArray[targetY,targetX] == 0)
                    {
                        cellArray[targetY, targetX] = 1;
                    }
                    else if (neighbourArray[targetY, targetX] < 2 | neighbourArray[targetY, targetX] > 3 & cellArray[targetY, targetX] == 1)
                    {
                        cellArray[targetY, targetX] = 0;
                    }
                }
            }
        }

        public void DrawCellArray()
        {
            Console.Clear();
            for (int targetY = 0; targetY < rowNum; targetY++)
            {
                Console.Write("\n");
                for (int targetX = 0; targetX < columnNum; targetX++)
                {
                    if (cellArray[targetY, targetX] == 1)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write("~");
                    }
                    Console.Write("|");
                }
            }
            Console.WriteLine();
        }

        public void DrawNeighbourArray()
        {
            for (int targetY = 0; targetY < rowNum; targetY++)
            {
                Console.WriteLine();
                for (int targetX = 0; targetX < columnNum; targetX++)
                {
                    Console.Write(neighbourArray[targetY, targetX]);
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
