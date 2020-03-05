using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        /// <summary>
        /// Matrix length
        /// </summary>
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

        static void PrintMatrix()
        {
            /// <summary>
            /// adds a value to the matrix in the especified position.
            /// </summary>
            /// <param name= "value"> value to add</param>
            /// <param name= "y"> y position</param>
            /// <param name= "x"> x position</param>
            for (int y = 0; y < MATRIX_SIZE; y++)
            {
                string line = "";
                for (int x = 0; x < MATRIX_SIZE; x++)
                {
                    //interpolate string
                    // Console.WriteLine($"[y, x] = {y}, {x}");
                    line += matrix[y, x] + "|";
                }
                line = line.Substring(0, line.Length - 1);

                Console.WriteLine(line);
                Console.WriteLine("------");
            }
        }
        
        static void AddValue(char value, int y, int x)
        {
            matrix[y, x] = value;

        }
        /// <summary>
        /// que tanto el usuario como la IA no se pueda sobreescibir datos
        /// </summary>
        static void InputRequest()
        {
             bool validPositionSelected = false;

            int y = 0;
            int x = 0;

            while(!validPositionSelected){
                Console.WriteLine("Escribe las cordenadas de la fomra y,x donde quieres hacer tu movimiento y presiona enter");
                string userInoutCoordinates = Console.ReadLine();

                //quitar espacio
                userInoutCoordinates = userInoutCoordinates.Replace(" ", " ");

                //separar en un arreglo de valores con ","
                string[] coordinates = userInoutCoordinates.Split(",");


                //convertir en cordenadas tipo entero
                y = Convert.ToInt32(coordinates[0]);
                x = Convert.ToInt32(coordinates[1]);
                bool isValueDefined = IsValueInMatrix(y, x);

                validPositionSelected = !isValueDefined;

                if(!validPositionSelected){
                    Console.WriteLine("esa pocision ya esta ocupada");
                }
            }

            AddValue('X', y, x);
        }

        static bool IsValueInMatrix(int y, int x)
        {
            bool isEmpty = matrix[y, x] == ' ';

            return !isEmpty;
        }
        /// <summary>
        /// Inteligencia artificial
        /// </summary>
        static void AiRequest()
        {
            Random r = new Random();



            bool validPositionSelected = false;

            int y = 0;
            int x = 0;

            while (!validPositionSelected)
            {

                y = (int)Math.Floor(r.NextDouble() * 3);
                x = Convert.ToInt32(Math.Floor(r.NextDouble() * 3));
                bool isValueDefined = IsValueInMatrix(y, x);

                validPositionSelected = !isValueDefined;
            }
            //add to matrix
            AddValue('O', y, x);
        }
        /// <summary>
        /// verificar que sean 3 en 1 en todas las direcciones
        /// </summary>
        /// <returns></returns>
        static bool CheckTheeLines()
        {
            char value = ' ';
            bool sameValue = true;
            //filas
            /* int y = 0;
            char value = ' ';
            bool sameValue = true;
            for(int x = 0; x < 3; x++){
                if(x == 0){
                value = matrix[y,x];
                }else
                {
                    sameValue = sameValue && (value == matrix[y, x]);
                }
            } */
            for (int y = 0; y < 3; y++)
            {
                 value = ' ';
                 sameValue = true;
                for (int x = 0; x < 3; x++)
                {
                    if (x == 0)
                    {
                        value = matrix[y, x];
                    }
                    else
                    {
                        sameValue = sameValue && (value == matrix[y, x]);
                    }
                }
                if (sameValue && value != ' ')
                {
                    return true;
                }

            }
            //columnas
            for (int x = 0; x < 3; x++)
            {
                 value = ' ';
                 sameValue = true;
                for (int y = 0; y < 3; y++)
                {
                    if (y == 0)
                    {
                        value = matrix[y, x];
                    }
                    else
                    {
                        sameValue = sameValue && (value == matrix[y, x]);
                    }
                }
                if (sameValue && value != ' '){
                    return true;
                }
            }

            //diagonales

            for (int i = 0; i < 3; i++){
                if( i == 0){
                    value = matrix[i, i];
                }else{
                    sameValue = sameValue && (value == matrix[i, i]);
                }

                if(sameValue  && value != ' ' && i == 2){
                    return true;
                }

            }

            value = ' ';
                   sameValue = true;
                 for (int y = 0; y < 3; y++) {
                   int x = 2 - y;

                  if(y == 0) {
                    value = matrix[y, y];
                  }else {
                    sameValue = sameValue && (value == matrix[y, y]);
                  }

                  if (sameValue && value != ' ' && y == 2) {
                    return true;
                  }
                 }
            return false;
        }
        
        static void Main(string[] args)
        {

            /*  PrintMatrix();
             InputRequest();
             AiRequest();
             PrintMatrix(); */

             

            /// <summary>
            /// verificar que el juego haya finalizado 
            /// </summary>
            bool gameOver = false;
            int turns = 0;
            while (!gameOver)
            {
                InputRequest();
                turns++;
                //check if user won
                gameOver = CheckTheeLines();
                //end after 9 turns
                if (turns >= 9)
                {
                    gameOver = true;
                }
                if (!gameOver)
                {
                    AiRequest();
                    turns++;
                    //Check if Ai won
                    gameOver = CheckTheeLines();
                }
                Console.WriteLine();
                PrintMatrix();


            } 
            PrintMatrix();
            Console.WriteLine("Game Over");

        }


    }
}

