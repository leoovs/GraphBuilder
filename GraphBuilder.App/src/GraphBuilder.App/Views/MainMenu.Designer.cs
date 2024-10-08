namespace GraphBuilder.App.Views
{
    partial class MainMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _panels = new SplitContainer();
            _menuTableLayoutParent = new TableLayoutPanel();
            _formulaSettingsLabel = new Label();
            _listBoxOfFormulas = new CheckedListBox();
            _editFormulaButton = new Button();
            _addFormulaButton = new Button();
            _deleteFormula = new Button();
            _graphViewer = new GraphViewer();
            ((System.ComponentModel.ISupportInitialize)_panels).BeginInit();
            _panels.Panel1.SuspendLayout();
            _panels.Panel2.SuspendLayout();
            _panels.SuspendLayout();
            _menuTableLayoutParent.SuspendLayout();
            SuspendLayout();
            // 
            // _panels
            // 
            _panels.BorderStyle = BorderStyle.FixedSingle;
            _panels.Dock = DockStyle.Fill;
            _panels.Location = new Point(0, 0);
            _panels.Name = "_panels";
            // 
            // _panels.Panel1
            // 
            _panels.Panel1.Controls.Add(_menuTableLayoutParent);
            // 
            // _panels.Panel2
            // 
            _panels.Panel2.Controls.Add(_graphViewer);
            _panels.Size = new Size(1007, 527);
            _panels.SplitterDistance = 286;
            _panels.TabIndex = 0;
            // 
            // _menuTableLayoutParent
            // 
            _menuTableLayoutParent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _menuTableLayoutParent.ColumnCount = 1;
            _menuTableLayoutParent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _menuTableLayoutParent.Controls.Add(_formulaSettingsLabel, 0, 0);
            _menuTableLayoutParent.Controls.Add(_listBoxOfFormulas, 0, 1);
            _menuTableLayoutParent.Controls.Add(_editFormulaButton, 0, 2);
            _menuTableLayoutParent.Controls.Add(_addFormulaButton, 0, 3);
            _menuTableLayoutParent.Controls.Add(_deleteFormula, 0, 4);
            _menuTableLayoutParent.Location = new Point(12, 12);
            _menuTableLayoutParent.Name = "_menuTableLayoutParent";
            _menuTableLayoutParent.RowCount = 5;
            _menuTableLayoutParent.RowStyles.Add(new RowStyle(SizeType.Percent, 9.030837F));
            _menuTableLayoutParent.RowStyles.Add(new RowStyle(SizeType.Percent, 90.96916F));
            _menuTableLayoutParent.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            _menuTableLayoutParent.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            _menuTableLayoutParent.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _menuTableLayoutParent.Size = new Size(260, 501);
            _menuTableLayoutParent.TabIndex = 0;
            // 
            // _formulaSettingsLabel
            // 
            _formulaSettingsLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _formulaSettingsLabel.AutoSize = true;
            _formulaSettingsLabel.Location = new Point(3, 10);
            _formulaSettingsLabel.Name = "_formulaSettingsLabel";
            _formulaSettingsLabel.Size = new Size(254, 15);
            _formulaSettingsLabel.TabIndex = 0;
            _formulaSettingsLabel.Text = "Формулы";
            _formulaSettingsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _listBoxOfFormulas
            // 
            _listBoxOfFormulas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _listBoxOfFormulas.FormattingEnabled = true;
            _listBoxOfFormulas.Location = new Point(3, 38);
            _listBoxOfFormulas.Name = "_listBoxOfFormulas";
            _listBoxOfFormulas.ScrollAlwaysVisible = true;
            _listBoxOfFormulas.Size = new Size(254, 346);
            _listBoxOfFormulas.TabIndex = 1;
            _listBoxOfFormulas.ItemCheck += _listBoxOfFormulas_ItemCheck;
            // 
            // _editFormulaButton
            // 
            _editFormulaButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _editFormulaButton.Location = new Point(3, 399);
            _editFormulaButton.Name = "_editFormulaButton";
            _editFormulaButton.Size = new Size(254, 23);
            _editFormulaButton.TabIndex = 2;
            _editFormulaButton.Text = "Изменить";
            _editFormulaButton.UseVisualStyleBackColor = true;
            _editFormulaButton.Click += _editFormulaButton_Click;
            // 
            // _addFormulaButton
            // 
            _addFormulaButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _addFormulaButton.Location = new Point(3, 436);
            _addFormulaButton.Name = "_addFormulaButton";
            _addFormulaButton.Size = new Size(254, 23);
            _addFormulaButton.TabIndex = 3;
            _addFormulaButton.Text = "Добавить";
            _addFormulaButton.UseVisualStyleBackColor = true;
            _addFormulaButton.Click += _addFormulaButton_Click;
            // 
            // _deleteFormula
            // 
            _deleteFormula.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _deleteFormula.Location = new Point(3, 472);
            _deleteFormula.Name = "_deleteFormula";
            _deleteFormula.Size = new Size(254, 23);
            _deleteFormula.TabIndex = 4;
            _deleteFormula.Text = "Удалить";
            _deleteFormula.UseVisualStyleBackColor = true;
            _deleteFormula.Click += _deleteFormula_Click;
            // 
            // _graphViewer
            // 
            _graphViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _graphViewer.Location = new Point(3, 12);
            _graphViewer.Name = "_graphViewer";
            _graphViewer.Size = new Size(697, 501);
            _graphViewer.TabIndex = 0;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_panels);
            Name = "MainMenu";
            Size = new Size(1007, 527);
            _panels.Panel1.ResumeLayout(false);
            _panels.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_panels).EndInit();
            _panels.ResumeLayout(false);
            _menuTableLayoutParent.ResumeLayout(false);
            _menuTableLayoutParent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer _panels;
        private TableLayoutPanel _menuTableLayoutParent;
        private Label _formulaSettingsLabel;
        private CheckedListBox _listBoxOfFormulas;
        private Button _editFormulaButton;
        private Button _addFormulaButton;
        private Button _deleteFormula;
        private GraphViewer _graphViewer;
    }
}