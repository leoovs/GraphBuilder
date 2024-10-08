namespace GraphBuilder.App.Views
{
    partial class FormulaEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _parentTableLayout = new TableLayoutPanel();
            _titleLabel = new Label();
            _formulaInputBox = new TextBox();
            _formulaInputLabel = new Label();
            _errorListBox = new ListBox();
            _parameterListBox = new ComboBox();
            _parameterInputBox = new TextBox();
            _colorDisplay = new Panel();
            _colorPickerLabel = new Label();
            _saveFormulaButton = new Button();
            _cancelEditsButton = new Button();
            _interpolationModeBox = new ComboBox();
            _parentTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // _parentTableLayout
            // 
            _parentTableLayout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _parentTableLayout.ColumnCount = 2;
            _parentTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _parentTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 234F));
            _parentTableLayout.Controls.Add(_titleLabel, 0, 0);
            _parentTableLayout.Controls.Add(_formulaInputBox, 0, 2);
            _parentTableLayout.Controls.Add(_formulaInputLabel, 1, 2);
            _parentTableLayout.Controls.Add(_errorListBox, 0, 1);
            _parentTableLayout.Controls.Add(_parameterListBox, 1, 3);
            _parentTableLayout.Controls.Add(_parameterInputBox, 0, 3);
            _parentTableLayout.Controls.Add(_colorDisplay, 0, 4);
            _parentTableLayout.Controls.Add(_colorPickerLabel, 1, 4);
            _parentTableLayout.Controls.Add(_saveFormulaButton, 0, 6);
            _parentTableLayout.Controls.Add(_cancelEditsButton, 1, 6);
            _parentTableLayout.Controls.Add(_interpolationModeBox, 0, 5);
            _parentTableLayout.Location = new Point(3, 3);
            _parentTableLayout.Name = "_parentTableLayout";
            _parentTableLayout.RowCount = 7;
            _parentTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10.810811F));
            _parentTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 89.1891861F));
            _parentTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _parentTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            _parentTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            _parentTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            _parentTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            _parentTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            _parentTableLayout.Size = new Size(450, 398);
            _parentTableLayout.TabIndex = 0;
            // 
            // _titleLabel
            // 
            _titleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _parentTableLayout.SetColumnSpan(_titleLabel, 2);
            _titleLabel.Location = new Point(3, 0);
            _titleLabel.Name = "_titleLabel";
            _titleLabel.Size = new Size(444, 25);
            _titleLabel.TabIndex = 4;
            _titleLabel.Text = "Мастер формул";
            // 
            // _formulaInputBox
            // 
            _formulaInputBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _formulaInputBox.BorderStyle = BorderStyle.FixedSingle;
            _formulaInputBox.Location = new Point(3, 237);
            _formulaInputBox.Name = "_formulaInputBox";
            _formulaInputBox.Size = new Size(210, 23);
            _formulaInputBox.TabIndex = 1;
            _formulaInputBox.TextAlign = HorizontalAlignment.Center;
            _formulaInputBox.TextChanged += _formulaInputBox_TextChanged;
            // 
            // _formulaInputLabel
            // 
            _formulaInputLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _formulaInputLabel.AutoSize = true;
            _formulaInputLabel.Location = new Point(219, 232);
            _formulaInputLabel.Name = "_formulaInputLabel";
            _formulaInputLabel.Size = new Size(228, 34);
            _formulaInputLabel.TabIndex = 0;
            _formulaInputLabel.Text = "Формула";
            _formulaInputLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _errorListBox
            // 
            _errorListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _errorListBox.BorderStyle = BorderStyle.FixedSingle;
            _parentTableLayout.SetColumnSpan(_errorListBox, 2);
            _errorListBox.FormattingEnabled = true;
            _errorListBox.ItemHeight = 15;
            _errorListBox.Location = new Point(3, 28);
            _errorListBox.Name = "_errorListBox";
            _errorListBox.Size = new Size(444, 197);
            _errorListBox.TabIndex = 5;
            _errorListBox.SelectedIndexChanged += _errorListBox_SelectedIndexChanged;
            // 
            // _parameterListBox
            // 
            _parameterListBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _parameterListBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _parameterListBox.FormattingEnabled = true;
            _parameterListBox.Location = new Point(219, 273);
            _parameterListBox.Name = "_parameterListBox";
            _parameterListBox.Size = new Size(228, 23);
            _parameterListBox.TabIndex = 6;
            _parameterListBox.SelectedIndexChanged += _parameterListBox_SelectedIndexChanged;
            // 
            // _parameterInputBox
            // 
            _parameterInputBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _parameterInputBox.BorderStyle = BorderStyle.FixedSingle;
            _parameterInputBox.Location = new Point(3, 273);
            _parameterInputBox.Name = "_parameterInputBox";
            _parameterInputBox.Size = new Size(210, 23);
            _parameterInputBox.TabIndex = 7;
            _parameterInputBox.TextAlign = HorizontalAlignment.Center;
            _parameterInputBox.TextChanged += _parameterInputBox_TextChanged;
            // 
            // _colorDisplay
            // 
            _colorDisplay.Anchor = AnchorStyles.None;
            _colorDisplay.BorderStyle = BorderStyle.Fixed3D;
            _colorDisplay.Location = new Point(82, 309);
            _colorDisplay.Name = "_colorDisplay";
            _colorDisplay.Size = new Size(51, 19);
            _colorDisplay.TabIndex = 8;
            _colorDisplay.DoubleClick += _colorDisplay_DoubleClick;
            // 
            // _colorPickerLabel
            // 
            _colorPickerLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _colorPickerLabel.AutoSize = true;
            _colorPickerLabel.Location = new Point(219, 303);
            _colorPickerLabel.Name = "_colorPickerLabel";
            _colorPickerLabel.Size = new Size(228, 31);
            _colorPickerLabel.TabIndex = 9;
            _colorPickerLabel.Text = "Цвет линии";
            _colorPickerLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _saveFormulaButton
            // 
            _saveFormulaButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _saveFormulaButton.Location = new Point(3, 369);
            _saveFormulaButton.Name = "_saveFormulaButton";
            _saveFormulaButton.Size = new Size(210, 24);
            _saveFormulaButton.TabIndex = 2;
            _saveFormulaButton.Text = "Сохранить";
            _saveFormulaButton.UseVisualStyleBackColor = true;
            _saveFormulaButton.Click += _saveFormulaButton_Click;
            // 
            // _cancelEditsButton
            // 
            _cancelEditsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _cancelEditsButton.Location = new Point(219, 368);
            _cancelEditsButton.Name = "_cancelEditsButton";
            _cancelEditsButton.Size = new Size(228, 25);
            _cancelEditsButton.TabIndex = 3;
            _cancelEditsButton.Text = "Отменить";
            _cancelEditsButton.UseVisualStyleBackColor = true;
            _cancelEditsButton.Click += _cancelEditsButton_Click;
            // 
            // _interpolationModeBox
            // 
            _interpolationModeBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _interpolationModeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _interpolationModeBox.FormattingEnabled = true;
            _interpolationModeBox.Items.AddRange(new object[] { "Линейная интерполяция", "Гладкая интерполяция" });
            _interpolationModeBox.Location = new Point(3, 337);
            _interpolationModeBox.Name = "_interpolationModeBox";
            _interpolationModeBox.Size = new Size(210, 23);
            _interpolationModeBox.TabIndex = 10;
            _interpolationModeBox.SelectedIndexChanged += _interpolationModeBox_SelectedIndexChanged;
            // 
            // FormulaEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_parentTableLayout);
            Name = "FormulaEditor";
            Size = new Size(456, 404);
            _parentTableLayout.ResumeLayout(false);
            _parentTableLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel _parentTableLayout;
        private Label _formulaInputLabel;
        private TextBox _formulaInputBox;
        private Button _saveFormulaButton;
        private Button _cancelEditsButton;
        private Label _titleLabel;
        private ListBox _errorListBox;
        private ComboBox _parameterListBox;
        private TextBox _parameterInputBox;
        private Panel _colorDisplay;
        private Label _colorPickerLabel;
        private ComboBox _interpolationModeBox;
    }
}
