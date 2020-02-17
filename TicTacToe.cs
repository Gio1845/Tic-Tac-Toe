using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static int MATRIX_SIZE = 3;

        //static char[,] matrix = new char[3, 3] {{'1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'}};
        static char[,] matrix = new char[3, 3] {{' ', ' ', ' '}, {' ', ' ', ' '}, {' ', ' ', ' '}};

        static void PrintMatrix (){
              for(int y = 0; y < MATRIX_SIZE; y++){
                string line = "";
                for(int x = 0; x < MATRIX_SIZE; x++){
                    //interpolate string
                   // Console.WriteLine($"[y, x] = {y}, {x}");
                    line += matrix[y, x] + "|";
                }
                line = line.Substring(0, line.Length - 1);

                Console.WriteLine(line);
                Console.WriteLine("------");
            }
        }
        static void Main(string[] args)
        {
          
            PrintMatrix();
            
            }
        }
    }

