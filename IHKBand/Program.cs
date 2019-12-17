using System;
using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            try
            {
               Application.Run(new Form1());
            }
            catch (Exception e)
            {
               Application.Run(new Alert("Message:\n"+e.Message+"\nSource:\n"+e.Source+"\nStackTrace:\n"+e.StackTrace+"\nTargetSite\n"+e.TargetSite));
            }
        }
    }
}
