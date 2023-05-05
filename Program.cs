using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twiter_Bildings
{
    internal class Program
    {
        public static void createRectangleEXP(int width, int height)//יצירת מלבן דוגמא
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-------1-------");
            for (int i = 0; i < width; i++)//שורה ראשונה
            {
                Console.Write("*");
            }
            Console.WriteLine();
            for (int i = 0; i < height; i++)//גוף המלבן
            {
                Console.Write("*");
                for (int j = 0; j < width - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                Console.WriteLine();

            }
            for (int i = 0; i < width; i++)//שורה ראשונה
            {
                Console.Write("*");
            }
        }
        public static void createTriangularEXP(int height)//יצירת מלבן לדוןגמא
        {
            Console.WriteLine();
            Console.WriteLine("-------2-------");
            string spaceAfter = " ", spaceBefore = "", space = " ";
            for (int i = 0; i < height - 2; i++)//רווחים
            {
                spaceBefore += " ";
            }
            Console.WriteLine(spaceBefore + " *");//קודקוד
            for (int i = 0; i < height - 2; i++)//גוף המלבן+רווחים
            {
                Console.WriteLine(spaceBefore + "*" + spaceAfter + "*");
                spaceAfter += "  ";
                spaceBefore = "";
                for (int j = i + 1; j < height - 2; j++)
                {
                    spaceBefore += space;
                }
            }
            for (int i = 0; i < height; i++)//בסיס
            {
                Console.Write("* ");
            }
        }
        public static void createRealTriangular(int width, int height)//יצירת המשולש
        {
            int Odd = 3, count = 0, res, remainer;
            bool first = true;
            for (int i = 2; i < width; i++)//כמות המספרים האי זוגיים בטווח של מאורך הבסיס עד 1
            {
                if (i % 2 != 0)
                {
                    count++;
                }
            }
            res = (height - 2) / count;//כמות הפעמים שכל שורה של ספרות תופיע 
            remainer = (height - 2) % count;//שארית החלוקה של כמות הפעמים שכל ספרה תופיע

            for (int i = 0; i < count + Odd / 2; i++)//מיקום הקודקוד (רווחים)
            {
                Console.Write(" ");
            }
            Console.Write("*");//קודקוד
            Console.WriteLine();
            for (int i = 0; i < (height - 2) / res; i++)//חלוקה שווה של השורות
            {
                for (int j = 0; j < res; j++)//כמות הפעמים שכל שורה תופיע
                {
                    for (int q = 0; q < remainer && first; q++)//במקרה של שארית- הוספת שורות לקבוצה העליונה
                    {
                        j--;
                        if (q == 0 && res % 2 == 0)//אם הרס זוגי לקדם פעם אחת
                            i++;
                    }
                    first = false;
                    for (int k = 0; k < count; k++)//כמות הרווחים - מיתקזז
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < Odd && Odd < height; k++)//אורך השורה
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Odd += 2;//קידום מספר אי זוגי
                count--;//קיזוז רווחים
            }

            for (int i = 0; i < width; i++)//בסיס
            {
                Console.Write("*");
            }
        }
        public static int GetInput(string str)
        {
            Console.WriteLine(str);
            return int.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            int width, height, building = 1, answre = 1;
            createRectangleEXP(4, 5);
            createTriangularEXP(7);
            Console.WriteLine();

            building = GetInput("enter your choise (1/2) To exit press 3");
            while (building != 3)
            {

                while (building <= 0 || building >= 4)
                {
                    Console.WriteLine("Invalid input- please try again:");
                    building = GetInput("choose one building (1/2)");
                }
                width = GetInput("enter width");
                while (width <= 0)
                {
                    Console.WriteLine("Invalid input- please try again:");
                    width = GetInput("enter width");
                }
                height = GetInput("enter height");
                if (building == 1)
                {
                    if (height - width > 5)
                    {
                        Console.WriteLine("the area of the rectangle is" + height * width);
                    }
                    else
                    {
                        Console.WriteLine("The perimeter of the rectangle is " + (height * 2 + width * 2));
                    }
                }
                else
                {
                    answre = GetInput("To calculate the perimeter of the triangle enter 1. To print the triangle enter 2");
                    while (answre <= 0 || answre >= 3)
                    {
                        answre = GetInput("Invalid input - please try again");
                    }
                    if (answre == 1)
                    {
                        Console.WriteLine("The perimeter of the triangle is " + (width + height * 2));
                    }
                    else
                    {
                        if (width % 2 == 0 || width > height * 2)
                        {
                            Console.WriteLine("The triangle cannot be printed!");
                        }
                        else
                        {
                            if (width % 2 != 0 && width < height * 2)
                            {
                                createRealTriangular(width, height);
                            }
                        }
                    }

                }
                createRectangleEXP(4, 5);
                createTriangularEXP(7);
                Console.WriteLine();

                building = GetInput("enter your choise (1/2) To exit press 3");
            }
            Console.WriteLine(" You have exit the program!");
            Console.ReadLine();
        }
    }
}

