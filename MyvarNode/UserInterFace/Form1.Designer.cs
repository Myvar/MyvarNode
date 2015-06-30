namespace UserInterFace
{
  partial class Form1
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
            this.flowchart1 = new UserInterFace.FlowChart.Flowchart();
            this.toolBox1 = new UserInterFace.FlowChart.ToolBox();
            this.SuspendLayout();
            // 
            // flowchart1
            // 
            this.flowchart1.Location = new System.Drawing.Point(177, 52);
            this.flowchart1.Name = "flowchart1";
            this.flowchart1.Size = new System.Drawing.Size(792, 630);
            this.flowchart1.TabIndex = 0;
            // 
            // toolBox1
            // 
            this.toolBox1.FlowChart = null;
            this.toolBox1.Location = new System.Drawing.Point(1, 136);
            this.toolBox1.Name = "toolBox1";
            this.toolBox1.Size = new System.Drawing.Size(170, 277);
            this.toolBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 752);
            this.Controls.Add(this.toolBox1);
            this.Controls.Add(this.flowchart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

    }

    #endregion

    private FlowChart.Flowchart flowchart1;
    private FlowChart.ToolBox toolBox1;
  }
}

