using System.Windows.Forms;

using GraphBuilder.App.Controllers;

namespace GraphBuilder.App
{ 
    static class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new SessionContainer().Window);
        }
    }
}