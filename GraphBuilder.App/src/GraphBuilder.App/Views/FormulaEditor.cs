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
using System.Globalization;

namespace GraphBuilder.App.Views
{
    partial class FormulaEditor : UserControl
    {
        private FormulaContext _context;
        private int _contextId;

        public delegate void CancelEventHandler(FormulaEditor editor);
        public delegate void SaveEventHandler(FormulaEditor editor);

        public event CancelEventHandler Cancel;
        public event SaveEventHandler Save;

        public int ContextId => _contextId;
        public FormulaContext Context => _context;

        public FormulaEditor(FormulaContext context, int contextId)
        {
            InitializeComponent();

            _context = context;
            _contextId = contextId;

            _formulaInputBox.Text = _context.BoundFormula.Defintion;
            _interpolationModeBox.SelectedIndex = (int)context.InterpolationMode;

            UpdateParameterBox();
            UpdateErrorBox();
            UpdateFormulaColor(_context.LineColor);
        }

        private void UpdateParameterBox()
        {
            _parameterListBox.Items.Clear();

            if (_context.ContextErrors.Any())
            {
                return;
            }

            foreach (string name in _context.ParameterNames)
            {
                _parameterListBox.Items.Add(name);
            }
        }

        private void UpdateErrorBox()
        {
            _errorListBox.Items.Clear();

            if (!_context.ContextErrors.Any())
            {
                return;
            }

            foreach (string message in _context.ContextErrors.Messages)
            {
                _errorListBox.Items.Add(message);
            }
        }

        private void UpdateFormulaColor(Color color)
        {
            _context.LineColor = color;
            _colorDisplay.BackColor = color;
        }

        private void _saveFormulaButton_Click(object sender, EventArgs e)
        {
            if (_context.ContextErrors.Any())
            {
                MessageBox.Show("Для продолжения исправьте ошибки в формуле",
                    "Ошибки в формуле");
                return;
            }

            Save?.Invoke(this);
        }

        private void _cancelEditsButton_Click(object sender, EventArgs e)
        {
            Cancel?.Invoke(this);
        }

        private void _formulaInputBox_TextChanged(object sender, EventArgs e)
        {
            var formula = new Formula(_formulaInputBox.Text);
            _context.Update(formula);
            UpdateParameterBox();
            UpdateErrorBox();
        }

        private void _parameterInputBox_TextChanged(object sender, EventArgs e)
        {
            if (_parameterListBox.SelectedIndex == -1)
            {
                return;
            }

            string paramName = _parameterListBox.SelectedItem.ToString()!;

            double oldValue = _context.GetParameter(paramName);
            string input = _parameterInputBox.Text == "-" ? "0" : _parameterInputBox.Text;
            input = string.IsNullOrEmpty(input) ? "0" : input;

            var culture = new CultureInfo("en-US");
            if (!double.TryParse(input, culture, out double res))
            {
                MessageBox.Show("Необходимо ввести вещественное число");
                _parameterInputBox.Text = oldValue.ToString(culture);
                return;
            }

            _context.SetParameter(paramName, res);
        }

        private void _parameterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string paramName = _parameterListBox.SelectedItem.ToString()!;
            var culture = new CultureInfo("en-US");
            _parameterInputBox.Text = (_context.GetParameter(paramName)).ToString(culture);
        }

        private void _errorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = _errorListBox.SelectedIndex;
            if (index == -1)
            {
                return;
            }

            int location = _context.ContextErrors.Occurrences.ElementAt(
                index).CharIndex;

            _formulaInputBox.Focus();
            _formulaInputBox.Select(location + 1, 0);
        }

        private void _colorDisplay_DoubleClick(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UpdateFormulaColor(dialog.Color);
            }
        }

        private void _interpolationModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mode = (InterpolationMode)_interpolationModeBox.SelectedIndex;
            if (mode == _context.InterpolationMode)
            {
                return;
            }
            _context.InterpolationMode = mode;

            if (_context.InterpolationMode == InterpolationMode.CurveInterpolation)
            {
                MessageBox.Show(
                    "Гладкая интерполяция требует большей вычислительной мощности",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
