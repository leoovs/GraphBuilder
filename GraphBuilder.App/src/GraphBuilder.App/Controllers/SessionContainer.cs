using GraphBuilder.App.Models;
using GraphBuilder.App.Views;

namespace GraphBuilder.App.Controllers
{
    class SessionContainer
    {
        private FormulaRegistry _registry = new FormulaRegistry();
        private MainWindow _mainWindow;

        public MainWindow Window => _mainWindow;

        public SessionContainer()
        {
            _mainWindow = new MainWindow(_registry);
        }
    }
}