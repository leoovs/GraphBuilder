using GraphBuilder.App.Controllers;
using GraphBuilder.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphBuilder.App.Views
{
    partial class MainWindow : Form
    {
        private FormulaRegistry _registry;

        public MainWindow(FormulaRegistry registry)
        {
            InitializeComponent();
            _registry = registry;
            EngageMainMenu();
        }

        private void SetControl(UserControl control)
        {
            control.Dock = DockStyle.Fill;
            control.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            control.Anchor |= AnchorStyles.Top | AnchorStyles.Bottom;

            _uiContainer.Controls.Clear();
            _uiContainer.Controls.Add(control, 0, 0);
        }

        private MainMenu EngageMainMenu()
        {
            var mainMenu = new MainMenu(_registry);

            mainMenu.EditFormula += EditFormula;
            mainMenu.DeleteFormula += DeleteFormula;
            mainMenu.EnableFormula += EnableFormula;

            SetControl(mainMenu);

            return mainMenu;
        }

        private FormulaEditor EngageFormulaEditor(FormulaContext ctx, int contextId)
        {
            var editor = new FormulaEditor(ctx, contextId);
            editor.Save += SaveFormulaEdit;
            editor.Cancel += CancelFormulaEdit;

            SetControl(editor);

            return editor;
        }

        private void EditFormula(int index)
        {
            FormulaContext ctx;
            if (-1 == index)
            {
                ctx = new FormulaContext().DoDefaultSetup();
                ctx.Update(new Formula(""));
            }
            else
            {
                var original = _registry.GetContext(index);
                ctx = new FormulaContext().InheritSetup(original);
                ctx.Update(original.BoundFormula);
            }

            FormulaEditor editor = EngageFormulaEditor(ctx, index);
        }

        private void DeleteFormula(MainMenu sender, int index)
        {
            const int NotSelected = -1;
            if (index == NotSelected)
            {
                return;
            }

            _registry.RemoveContext(index);
            sender.Graph.Redraw(_registry);
        }

        private void EnableFormula(MainMenu sender, int index, bool enable)
        {
            sender.Graph.Redraw(_registry);
        }

        private void SaveFormulaEdit(FormulaEditor sender)
        {
            if (sender.ContextId == -1)
            {
                _registry.AddContext(sender.Context);
            }
            else
            {
                _registry.SetContext(sender.ContextId, sender.Context);
            }

            MainMenu menu = EngageMainMenu();
        }

        private void CancelFormulaEdit(FormulaEditor sender)
        {
            EngageMainMenu();
        }
    }
}
