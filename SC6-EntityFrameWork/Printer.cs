using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC6_EntityFrameWork;
public static class Printer
{
    public static void PrinterColor(IPrintable item, ConsoleColor color = ConsoleColor.Green)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(item.ToPrintableString());
        Console.ResetColor();
    }
}


