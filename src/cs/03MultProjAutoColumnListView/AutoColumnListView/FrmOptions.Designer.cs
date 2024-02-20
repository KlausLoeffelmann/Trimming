namespace AutoColumnListViewDemo;

partial class FrmOptions
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
        _schemaSelectorControl = new WinFormsControls.SchemaSelectorControl();
        _btnOk = new Button();
        SuspendLayout();
        // 
        // _schemaSelectorControl
        // 
        _schemaSelectorControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _schemaSelectorControl.BorderStyle = BorderStyle.FixedSingle;
        _schemaSelectorControl.Location = new Point(12, 12);
        _schemaSelectorControl.Name = "_schemaSelectorControl";
        _schemaSelectorControl.SchemaType = null;
        _schemaSelectorControl.Size = new Size(511, 547);
        _schemaSelectorControl.TabIndex = 0;
        // 
        // _btnOk
        // 
        _btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _btnOk.DialogResult = DialogResult.OK;
        _btnOk.Location = new Point(412, 570);
        _btnOk.Name = "_btnOk";
        _btnOk.Size = new Size(111, 38);
        _btnOk.TabIndex = 1;
        _btnOk.Text = "OK";
        _btnOk.UseVisualStyleBackColor = true;
        // 
        // FrmOptions
        // 
        AcceptButton = _btnOk;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(535, 614);
        Controls.Add(_btnOk);
        Controls.Add(_schemaSelectorControl);
        Name = "FrmOptions";
        Text = "Options";
        ResumeLayout(false);
    }

    #endregion

    private WinFormsControls.SchemaSelectorControl _schemaSelectorControl;
    private Button _btnOk;
}
