using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static bool loop_main = true;
        static string[] board = new string[9] {" ", " ", " ", " ", " ", " ", " ", " ", " "};
        static void Main(string[] args)
        {
            bool main_loop = true;
            int boardnumber = 0;
            Title();
            while (main_loop)
            {
                DrawGrid();
                bool breakloop = false;
                string again = "";
                while (loop_main)
                {
                    PlayerMove();
                    Console.WriteLine("");
                    CheckWin();
                    DrawGrid();
                    if (loop_main == true)
                    {
                        Console.WriteLine("");
                        ComputerMove();
                        Console.WriteLine("");
                        DrawGrid();
                        CheckWin();
                    }
                }

                while (boardnumber < 9)
                {
                    board[boardnumber] = " ";
                    boardnumber = boardnumber + 1;
                }

                Console.WriteLine("Board reset");
                Console.WriteLine("");
                while (!breakloop)
                {
                    Console.WriteLine("Play again?");
                    try
                    {
                        again = Console.ReadLine();
                        if (again == "yes" || again == "y" || again == "Yes" || again == "YES" || again == "Y")
                        {
                            Console.WriteLine("Starting game");
                            loop_main = true;
                            breakloop = true;
                        }
                        if (again == "no" || again == "n" || again == "No" || again == "NO" || again == "N")
                        {
                            Console.WriteLine("Ending game, press any button to exit");
                            main_loop = false;
                            breakloop = true;
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Error has occured please try again");
                    }
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }

        static void DrawGrid()
        {
            Console.WriteLine("{0}|{1}|{2}", board[0], board[1], board[2]);
            Console.WriteLine("------"); 
            Console.WriteLine("{0}|{1}|{2}", board[3], board[4], board[5]);
            Console.WriteLine("------");
            Console.WriteLine("{0}|{1}|{2}", board[6], board[7], board[8]);
        }

        static void Title()
        {
            Console.WriteLine("Welcome to tic tac toe");
            Console.WriteLine("The rules are simple:");
            Console.WriteLine("You get 3 in a row you win");
            Console.WriteLine("You cannot place the tic/tac outside the grid");
            Console.WriteLine("You cannot place your tic/tac ontop of another players tic/tac");
            Console.WriteLine();
        }

        static void PlayerMove() 
        {
            bool looping = true;
            while (looping)
            {
                Console.WriteLine();
                Console.WriteLine("Input space to go into (0, 1, 2, etc up to 8)");

                try
                {
                    int move = Convert.ToInt32(Console.ReadLine());
                    if (move >= 0 && move < 9)
                    {
                        if (CheckBoard(move) == 0)
                        {
                            board[move] = "X";
                            looping = false;
                        }
                        else
                        {
                            Console.WriteLine("Space taken, pick a new space");
                        }
                    }
                }

                catch
                {
                    Console.WriteLine("Error");
                }
            }
        }
        static void ComputerMove()
        {
            bool looping = true;
            Console.WriteLine("Computers turn");
            var rand = new Random();
            while (looping)
            {
                int RandomNumber = rand.Next(0, 9);
                if (CheckBoard(RandomNumber) == 0)
                {
                    board[RandomNumber] = "O";
                    looping = false;
                }
            }
        }

        static int CheckBoard(int position) 
        {
            if (board[position] == " ")
            {
                return 0;
            }
            else 
            {
                return 1;
            }
        }
        static void CheckWin()
        {
            int checking = 0;
            int place = 0;

            if (possible_wins("X") == 1)
            {
                Console.WriteLine("Player has won");
                loop_main = false;
            }
            if (possible_wins("O") == 1)
            {
                Console.WriteLine("Computer has won");
                loop_main = false;
            }
            if (possible_wins("X") == 0 && possible_wins("O") == 0)
            {
                foreach (string i in board)
                {
                    if(board[place] != " ")
                    {
                        checking = checking + 1;
                    }
                    place = place + 1;
                }
                if (checking == 9)
                {
                    Console.WriteLine("Draw");
                    loop_main = false;
                }
            }
        }

        static int possible_wins (string player)
        {
            //vertical |
            if (board[0] == player && board[1] == player && board[2] == player)
            {
                return 1;
            }

            if (board[3] == player && board[4] == player && board[5] == player)
            {
                return 1;
            }

            if (board[6] == player && board[7] == player && board[8] == player)
            {
                return 1;
            }

            //horizontal -
            if (board[0] == player && board[3] == player && board[6] == player)
            {
                return 1;
            }

            if (board[1] == player && board[4] == player && board[7] == player)
            {
                return 1;
            }

            if (board[2] == player && board[5] == player && board[8] == player)
            {
                return 1;
            }


            //diagnal /
            if (board[0] == player && board[4] == player && board[8] == player)
            {
                return 1;
            }

            if (board[6] == player && board[4] == player && board[2] == player)
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }
    }
}
