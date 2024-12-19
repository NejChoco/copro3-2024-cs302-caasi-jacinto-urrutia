using System; 

namespace title
{
    public class pixelatedTitle
    {
        public void renderTitle()
        {
           Console.ForegroundColor = ConsoleColor.DarkYellow;
            string[] earthbound = new string[]
           {
                "███████╗ █████╗ ██████╗ ████████╗██╗  ██╗██████╗  ██████╗ ██╗   ██╗███╗   ██╗██████╗ ",
                "██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██║  ██║██╔══██╗██╔═══██╗██║   ██║████╗  ██║██╔══██╗",
                "█████╗  ███████║██████╔╝   ██║   ███████║██████═╝██║   ██║██║   ██║██╔██╗ ██║██║  ██║",
                "██╔══╝  ██╔══██║██ ███═╗   ██║   ██╔══██║██╔══██╗██║   ██║██║   ██║██║╚██╗██║██║  ██║",
                "███████╗██║  ██║██ ║███║   ██║   ██║  ██║██████╔╝╚██████╔╝╚██████╔╝██║ ╚████║██████╔╝",
                "╚══════╝╚═╝  ╚═╝╚══╝ ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═════╝  ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝╚═════╝ "
           };

            foreach (string line in earthbound)
            {
                Console.WriteLine(line);
            }
            Console.ResetColor();

            Console.WriteLine("\t\t  ========== The Asyshin Prophecy =========="); 
        }
    }
}