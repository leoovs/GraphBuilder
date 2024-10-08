namespace GraphBuilder.App.Views
{
    partial class MainWindow
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
            _uiContainer = new TableLayoutPanel();
            SuspendLayout();
            // 
            // _uiContainer
            // 
            _uiContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _uiContainer.ColumnCount = 1;
            _uiContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _uiContainer.Location = new Point(12, 12);
            _uiContainer.Name = "_uiContainer";
            _uiContainer.RowCount = 1;
            _uiContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _uiContainer.Size = new Size(1036, 582);
            _uiContainer.TabIndex = 0;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 606);
            Controls.Add(_uiContainer);
            Name = "MainWindow";
            Text = "Построитель графиков";
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel _uiContainer;
    }
}