using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkPad
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(args.Length == 0)
               Application.Run(new DarkPad());
            else
            {
                for(int i=0; i<args.Length; ++i)
                {
                    Application.Run(new DarkPad(args[i]));
                }
            }
        }
    }
}
