using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
class Program
{
    static void Main()
    {
        Console.WindowHeight = 16;
        Console.WindowWidth = 32;
        int screenwidth = Console.WindowWidth;
        int screenheight = Console.WindowHeight;
        Console.WindowHeight += 2;
        Random randomnummer = new Random();
        // TODO: NEEDS FIX
        //
        // pixel hoofd = new pixel();
        // hoofd.xpos = screenwidth / 2;
        // hoofd.ypos = screenheight / 2;
        // hoofd.schermkleur = ConsoleColor.Red;
        string movement = "RIGHT";
        List<int> telje = new List<int>();

        int tailLength = 0;

        List<Pixel> tail = new List<Pixel>();

        int score = 0;
        Pixel hoofd = new Pixel();
        hoofd.xPos = screenwidth / 2;
        hoofd.yPos = screenheight / 2;
        hoofd.schermKleur = ConsoleColor.Red;

        List<int> teljePositie = new List<int>();

        teljePositie.Add(hoofd.xPos);
        teljePositie.Add(hoofd.yPos);

        DateTime tijd = DateTime.Now;
        string obstacle = "*";
        int obstacleXpos = randomnummer.Next(1, screenwidth - 2);
        int obstacleYpos = randomnummer.Next(1, screenheight - 2);
        while (true)
        {
            Console.Clear();
            //Draw Obstacle
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(obstacleXpos, obstacleYpos);
            Console.Write(obstacle);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < screenwidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
            }
            for (int i = 0; i < screenwidth; i++)
            {
                Console.SetCursorPosition(i, screenheight - 1);
                Console.Write("■");
            }
            for (int i = 0; i < screenheight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
            }
            for (int i = 0; i < screenheight; i++)
            {
                Console.SetCursorPosition(screenwidth - 1, i);
                Console.Write("■");
            }
            Console.ForegroundColor =  ConsoleColor.DarkGreen;
            Console.WriteLine("\nScore: " + score);
            Console.ForegroundColor = ConsoleColor.White;
            //Console.Write("H");

            tail.Insert(0, new Pixel { xPos = hoofd.xPos, yPos = hoofd.yPos });
            
            while (tail.Count > tailLength+1)
            {
                tail.RemoveAt(tail.Count - 1);
            }

            for (int i = 0; i < tail.Count(); i++)
            {
                Console.SetCursorPosition(tail[i].xPos, tail[i].yPos);
                Console.Write("■");
            }
            //Draw Snake
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");

            ConsoleKeyInfo info = Console.ReadKey();
            //Game Logic
            switch (info.Key)
            {
                case ConsoleKey.UpArrow:
                    movement = "UP";
                    break;
                case ConsoleKey.DownArrow:
                    movement = "DOWN";
                    break;
                case ConsoleKey.LeftArrow:
                    movement = "LEFT";
                    break;
                case ConsoleKey.RightArrow:
                    movement = "RIGHT";
                    break;
            }
            if (movement == "UP")
                hoofd.yPos--;
            if (movement == "DOWN")
                hoofd.yPos++;
            if (movement == "LEFT")
                hoofd.xPos--;
            if (movement == "RIGHT")
                hoofd.xPos++;
            //Hindernis treffen (translated: Hit an obstacle)
            if (hoofd.xPos == obstacleXpos && hoofd.yPos == obstacleYpos)
            {
                score++;
                obstacleXpos = randomnummer.Next(1, screenwidth - 2);
                obstacleYpos = randomnummer.Next(1, screenheight - 2);
                tailLength++;
            }
            //Kollision mit Wände oder mit sich selbst (translated: Colliding with walls or with yourself)
            if (hoofd.xPos == 0 || hoofd.xPos == screenwidth - 1 || hoofd.yPos == 0 || hoofd.yPos == screenheight - 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
                Console.WriteLine("Dein Score ist: " + score);
                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 2);
                Environment.Exit(0);
            }
            for (int i = 0; i < tail.Count(); i++ )
            {
                if (hoofd.xPos == tail[i].xPos && hoofd.yPos == tail[i].yPos)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
                    Console.WriteLine("Game Over");
                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
                    Console.WriteLine("Dein Score ist: " + score);
                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 2);
                    Environment.Exit(0);
                }
            }
            Thread.Sleep(50);
        }
    }
}
public class Pixel
{
    public int xPos { get; set; }
    public int yPos { get; set; }
    public ConsoleColor schermKleur { get; set; }
    public string karacter { get; set; }
}
public class Obstakel
{
    public int Xpos { get; set; }
    public int Ypos { get; set; }
    public ConsoleColor schermKleur { get; set; }
    public string karacter { get; set; }
}