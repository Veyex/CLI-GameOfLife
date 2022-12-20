namespace CLI_GameOfLife
{
    class GoL
    {
        #region Properties & Fields
        public int rowNum;
        public int columnNum;
        public int[,] cellArray;
        public int[,] neighbourArray;
        #endregion

        #region Constructors
        //Defines the amount of rows and columns on the board
        public GoL()
        {
            cellArray = new int[rowNum, columnNum];
            neighbourArray = new int[rowNum, columnNum];
        }
        #endregion

        #region Methods
        //Allows the user to enter the amount of rows and columns on the board
        //Then generates values accordingly
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

            cellArray[1, 0] = 1;
            cellArray[2, 1] = 1;
            cellArray[1, 2] = 1;
            cellArray[2, 2] = 1;
            cellArray[0, 2] = 1;
        }

        //Iterates thru each cell on the board then thru all surrounding cells
        //Adding up the amount of live cells in the surrounding cells and
        //assigns the value to a total for each cell stored in a separate array
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

        //Uses Conway's rule set and the total to set the value to each cell
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

        //Uses the cell values to print the correct symbol to the CLI
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
                        Console.Write("\u2588");
                    }
                    else
                    {
                        Console.Write("\u00A0");
                    }
                    Console.Write("|");
                }
            }
            Console.WriteLine();
        }

        /*
        //Currently unused method for debugging
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
        */
        #endregion
    }
}
