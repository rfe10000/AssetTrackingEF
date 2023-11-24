using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Utility
{
    internal class AssetUtils
    {
        internal static int AssetChoice(List<string> options)
        {
            var cursorYPosition = Console.GetCursorPosition().Top;
            int stopAt = options.Count + cursorYPosition; 
            int currentSelection = cursorYPosition;

            ConsoleKey key;

            Console.CursorVisible = false;

            int selectedListIndex = 0;
            do
            {                
                for (int i = cursorYPosition; i < stopAt; i++)
                {
                    Console.SetCursorPosition(0, i);

                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        selectedListIndex = i - cursorYPosition + 1;

                        Console.Write("> ".PadLeft(2) + options[i - cursorYPosition]);
                        Console.ResetColor();
                    }
                    else
                        Console.Write("  ".PadLeft(2) + options[i - cursorYPosition]);
                    
                }

                key = Console.ReadKey(true).Key;
               
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection > cursorYPosition)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection < stopAt - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.Escape:                      
                        {
                            return -1;//
                        }
                }
            } 
            while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            Console.Write(Environment.NewLine);
            return selectedListIndex; 
        }
    }
}
