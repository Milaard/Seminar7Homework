start();
void start()
{
    while (true)
    {
        Console.Clear();

        Console.WriteLine("Задача 47. Задайте двумерный массив размером m*n, заполненный случайными вещественными числами.");
        Console.WriteLine("Задача 50. Напишите программу, которая задает массив, которая на вход принимает число и возвращает индекс этого числа  двумерном массиве, либо что этого числа нет.");
        Console.WriteLine("Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.");
        int numTask = SetNumber("Введите номер задачи");

        switch (numTask)
        {
            case 0: return;
            case 47:
                Console.Clear();
                int rows = SetNumber("Введите количество строк массива");
                int columns = SetNumber("Введите количество столбцов массива");

                double[,] arrayDouble = GetArrayDouble(rows, columns, 0, 10);
                PrintArrayDouble(arrayDouble);
                Console.WriteLine();
                break;
            case 50:
                Console.Clear();
                int row = SetNumber("Введите количество строк массива");
                int column = SetNumber("Введите количество столбцов массива");
                int[,] matrix = GetRandomMatrix(row, column);
                Console.WriteLine("Введите искомое число");
                int number = int.Parse(Console.ReadLine());
                PrintMatrix(matrix);

                if (FindNumber(matrix, number, out column, out row))
                {
                    Console.WriteLine($"Число найдено column = {column}, row = {row}");
                }
                else
                {
                    Console.WriteLine("Данного числа в массиве нет");
                }
                break;
            case 52:
                Console.Clear();
                int row1 = SetNumber("Введите количество строк");
                int column1 = SetNumber("Введите количество столбцов");
                int[,] matrix1 = GetRandomMatr(row1, column1, 10, 0);
                PrintMatrix(matrix1);
                double[] averageColumns = GetResultArray(matrix1);
                Console.WriteLine($"Среднее арифметическое каждого столбца равно {String.Join(";", averageColumns)}");
                char input1 = Console.ReadKey().KeyChar;
                break;
            default: Console.WriteLine("Error"); break;
        }
        Console.WriteLine("Задача выполнена, нажмите любую клавишу");
        Console.ReadKey();
    }
}
int SetNumber(string comment)
{
    Console.Write($" {comment}:");
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}


//"Задача 47. Задайте двумерный массив размером m*n, заполненный случайными вещественными числами."

double[,] GetArrayDouble(int rows, int columns, int minValue, int maxValue)
{
    double[,] result = new double[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = new Random().NextDouble() * 100;
        }
    }
    return result;
}
void PrintArrayDouble(double[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write("{0,6:f2}", inArray[i, j]);
        }
        Console.WriteLine();
    }
}
Console.ReadLine();



//Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
// напишите программукоторая задает массив, которая на вход принимает число и возвращаает индекс это числа  двумерном массиве, либо что этого числа нет

int row = SetNumber("m");
int column = SetNumber("n");
int[,] matrix = GetRandomMatrix(row, column);
Console.WriteLine("Введите искомое число");
int number = int.Parse(Console.ReadLine());
PrintMatrix(matrix);

int[,] GetRandomMatrix(int row, int column, int maxValue = 10, int minValue = 0)
{
    int[,] matrix = new int[row, column];
    var random = new Random();
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            matrix[i, j] = random.Next(minValue, maxValue + 1);
        }
    }
    return matrix;
}

bool FindNumber(int[,] matr, int number, out int colum, out int row)
{

    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            if (matr[i, j] == number)
            {
                colum = j;
                row = i;
                return true;
            }

        }

    }
    colum = 0;
    row = 0;
    return false;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write($"{matrix[i, j]} ");
        }
        System.Console.WriteLine();
    }
}


//Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

double[] GetResultArray(int[,] matrix1)
{
    double[] result = new double[matrix1.GetLength(1)];
    for (int j = 0; j < matrix1.GetLength(1); j++)
    {
        double sum = 0;
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            sum += matrix1[i, j];
        }
        result[j] = Math.Round(sum / matrix1.GetLength(0), 2);
    }
    return result;
}

int[,] GetRandomMatr(int rows1, int column1, int maxValue = 10, int minValue = 0)
{
    int[,] result = new int[rows1, column1];
    var random = new Random();
    for (int i = 0; i < rows1; i++)
    {
        for (int j = 0; j < column1; j++)
        {
            result[i, j] = random.Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintMatr(int[,] matrix1)
{
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            System.Console.Write($"{matrix1[i, j]} ");
        }
        System.Console.WriteLine();
    }
}
