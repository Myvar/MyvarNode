namespace UserInterFace.FlowChart
{
  partial class Flowchart
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
            this.components = new System.ComponentModel.Container();
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // DrawTimer
            // 
            this.DrawTimer.Enabled = true;
            this.DrawTimer.Interval = 1;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // Flowchart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Flowchart";
            this.Size = new System.Drawing.Size(1230, 660);
            this.Load += new System.EventHandler(this.Flowchart_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Flowchart_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Flowchart_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Flowchart_KeyUp);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Flowchart_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Flowchart_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Flowchart_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Flowchart_MouseUp);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer DrawTimer;
  }
}
