namespace WinFormsControls
{
    partial class SchemaSelectorControl
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
            _propertyGrid = new PropertyGrid();
            _lblGridCaption = new Label();
            SuspendLayout();
            // 
            // _propertyGrid
            // 
            _propertyGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _propertyGrid.Location = new Point(16, 59);
            _propertyGrid.Name = "_propertyGrid";
            _propertyGrid.Size = new Size(546, 803);
            _propertyGrid.TabIndex = 1;
            // 
            // _lblGridCaption
            // 
            _lblGridCaption.AutoSize = true;
            _lblGridCaption.Location = new Point(16, 21);
            _lblGridCaption.Name = "_lblGridCaption";
            _lblGridCaption.Size = new Size(89, 20);
            _lblGridCaption.TabIndex = 2;
            _lblGridCaption.Text = "GridCaption";
            // 
            // SchemaSelectorControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(_lblGridCaption);
            Controls.Add(_propertyGrid);
            Name = "SchemaSelectorControl";
            Size = new Size(581, 878);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PropertyGrid _propertyGrid;
        private Label _lblGridCaption;
    }
}
