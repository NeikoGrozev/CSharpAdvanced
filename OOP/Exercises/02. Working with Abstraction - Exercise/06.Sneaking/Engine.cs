namespace Sneaking
{
    using System;

    class Engine
    {
        private char[][] room;
        private int samPositionRow;
        private int samPositionCol;
        private int enemyRow;
        private int enemyCol;

        public void Run()
        {
            CreateRoom();

            char[] moves = Console.ReadLine()
                .ToCharArray();
            
            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemy();
                CheckPositionEnemy();

                if (samPositionCol < enemyCol && room[enemyRow][enemyCol] == 'd' && enemyRow == samPositionRow)
                {
                    PrintSamIsDaed();
                    PrintRoom();
                    break;
                }
                else if (enemyCol < samPositionCol && room[enemyRow][enemyCol] == 'b' && enemyRow == samPositionRow)
                {
                    PrintSamIsDaed();
                    PrintRoom();
                    break;
                }

                room[samPositionRow][samPositionCol] = '.';

                char ch = moves[i];
                MoveSam(ch);              
                room[samPositionRow][samPositionCol] = 'S';

                CheckPositionEnemy();
               
                if (room[enemyRow][enemyCol] == 'N' && samPositionRow == enemyRow)
                {
                    room[enemyRow][enemyCol] = 'X';
                    Console.WriteLine("Nikoladze killed!");

                    PrintRoom();
                    break;
                }
            }
        }

        private void CreateRoom()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];

                    if (room[row][col] == 'S')
                    {
                        samPositionRow = row;
                        samPositionCol = col;
                    }
                }
            }
        }

        private void MoveEnemy()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private void MoveSam(char ch)
        {
            switch (ch)
            {
                case 'U':
                    samPositionRow--;
                    break;
                case 'D':
                    samPositionRow++;
                    break;
                case 'L':
                    samPositionCol--;
                    break;
                case 'R':
                    samPositionCol++;
                    break;
                default:
                    break;
            }
        }

        private void PrintSamIsDaed()
        {
            room[samPositionRow][samPositionCol] = 'X';
            Console.WriteLine($"Sam died at {samPositionRow}, {samPositionCol}");
        }

        private void CheckPositionEnemy()
        {
            for (int j = 0; j < room[samPositionRow].Length; j++)
            {
                if (room[samPositionRow][j] != '.' && room[samPositionRow][j] != 'S')
                {
                    enemyRow = samPositionRow;
                    enemyCol = j;
                }
            }
        }

        private void PrintRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
