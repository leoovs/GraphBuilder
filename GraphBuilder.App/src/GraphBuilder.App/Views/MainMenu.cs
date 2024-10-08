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
    partial class MainMenu : UserControl
    {
        private FormulaRegistry _registry;

        public delegate void EditFormulaEventHandler(int index);
        public delegate void DeleteFormulaEventHandler(MainMenu sender, int index);
        public delegate void EnableFormulaEventHandler(MainMenu sender, int index, bool enable);

        public event EditFormulaEventHandler EditFormula;
        public event DeleteFormulaEventHandler DeleteFormula;
        public event EnableFormulaEventHandler EnableFormula;

        public GraphViewer Graph => _graphViewer;

        public MainMenu(FormulaRegistry registry)
        {
            InitializeComponent();
            _registry = registry;
            UpdateListBoxOfFormulas();
            Graph.Redraw(_registry);
        }

        private void UpdateListBoxOfFormulas()
        {
            _listBoxOfFormulas.Items.Clear();

            for (int iCtx = 0; iCtx < _registry.Size; iCtx++)
            {
                FormulaContext ctx = _registry.GetContext(iCtx);
                bool enabled = _registry.IsEnabled(iCtx);

                _listBoxOfFormulas.Items.Add(ctx.BoundFormula.Defintion, enabled);
            }
        }

        private void _listBoxOfFormulas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            _registry.Enable(e.Index, e.NewValue == CheckState.Checked);
            EnableFormula?.Invoke(this, e.Index, e.NewValue == CheckState.Checked);
        }

        private void _editFormulaButton_Click(object sender, EventArgs e)
        {
            int formulaIndex = _listBoxOfFormulas.SelectedIndex;
            const int NotSelected = -1;

            if (formulaIndex != NotSelected)
            {
                EditFormula?.Invoke(formulaIndex);
            }
        }

        private void _addFormulaButton_Click(object sender, EventArgs e)
        {
            const int AddNewFormula = -1;
            EditFormula?.Invoke(AddNewFormula);
        }

        private void _deleteFormula_Click(object sender, EventArgs e)
        {
            int formulaIndex = _listBoxOfFormulas.SelectedIndex;
            DeleteFormula?.Invoke(this, formulaIndex);
            UpdateListBoxOfFormulas();
        }
    }
}
