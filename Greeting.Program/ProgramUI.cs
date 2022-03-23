using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Program
{
    public class ProgramUI
    {
        public void Run()
        {
            SeedContent();
            Menu();
        }
        private void Menu()
        {
            //menu stuff
        }
        private void SeedContent()
        {
            //contentstuff
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
