using System;
namespace Football
{
    public class Draw
    {
        public void DrawPoint(int x, int y, char sym)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void DrawStadium(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {

                Console.SetCursorPosition(i, 0);
                Console.Write('=');

            }

            for (int i = 0; i < height; i++)
            {

                Console.SetCursorPosition(0, i);
                Console.Write('|');

            }
            for (int i = 0; i < width; i++)
            {

                Console.SetCursorPosition(i, height);
                Console.Write('=');

            }

            for (int i = 0; i < height; i++)
            {

                Console.SetCursorPosition(width, i);
                Console.Write('|');

            }

        }




    }

}