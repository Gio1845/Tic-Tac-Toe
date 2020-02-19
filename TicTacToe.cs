using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static int MATRIX_SIZE = 3;

        //static char[,] matrix = new char[3, 3] {{'1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'}};

        /// <summary>
        /// matrix array [y,x]
        /// </summary>
        /// <value>Empty matrix</value>
        static char[,] matrix = new char[3, 3] {
            {' ', ' ', ' '}, 
            {' ', ' ', ' '}, 
            {' ', ' ', ' '}
            
            };
            /// <summary>
            /// prints the matrix
            /// </summary>

        static void PrintMatrix (){
            /// <summary>
            /// adds a value to the matrix in the especified position.
            /// </summary>
            /// <param name= "value"> value to add</param>
            /// <param name= "y"> y position</param>
            /// <param name= "x"> x position</param>
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
        static void AddValue(char value, int y, int x) {
            matrix[y,x] = value;

        }

        static void InputRequest(){
            Console.WriteLine("Escribe las cordenadas de la fomra y,x donde quieres hacer tu movimiento y presiona enter");
            string userInoutCoordinates = Console.ReadLine();

            //quitar espacio
            userInoutCoordinates = userInoutCoordinates.Replace(" ", " ");

            //separar en un arreglo de valores con ","
            string[] coordinates = userInoutCoordinates.Split(",");


            //convertir en cordenadas tipo entero
            int y = Convert.ToInt32(coordinates[0]);
            int x = Convert.ToInt32(coordinates[1]);

            AddValue('X', y, x);
        }

        static bool IsValueInMatrix(int y, int x){
            bool isEmpty = matrix[y,x] == ' ';

            return !isEmpty;
        }
        static void AiRequest(){
            Random r = new Random();

          

            bool validPositionSelected = false;

            int y = 0;
            int x = 0;

           while(!validPositionSelected){
                 y = (int) Math.Floor(r.NextDouble() * 3);
                 x = Convert.ToInt32(Math.Floor(r.NextDouble() * 3));
                bool isValueDefined = IsValueInMatrix(y,x);

                validPositionSelected = !isValueDefined;
           }
            //add to matrix
            AddValue('O', y, x);
        }

        static void Main(string[] args)
        {
          
            PrintMatrix();
            InputRequest();
            AiRequest();
            PrintMatrix();


            bool gameEnded = false;
            int turns = 0;

            }
            
        }
    }

           