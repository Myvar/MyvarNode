using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpFormEditorDemo;

namespace UserInterFace.FlowChart.Icons
{
    public partial class Form : UserControl
    {
        public NIcon Data { get; set; }
        public Flowchart Flowchart { get; set; }



        public Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private DesignerFrame frm = new DesignerFrame();

        private bool firstrun = false;

        private void Form_Load(object sender, EventArgs e)
        
        {
            
            toolBox1.AddTab("Input", 0);
            toolBox1.AddTab("Cosmetics", 0);
            toolBox1[0].AddItem("Lable", 0);
            toolBox1[0].AddItem("Plain TextBox",0);
            toolBox1[0].AddItem("Number TextBox", 0);
            toolBox1[0].AddItem("Password TextBox", 0);
            toolBox1[0].AddItem("Email TextBox", 0);
            toolBox1[0].AddItem("Date TextBox", 0);
            toolBox1[0].AddItem("Regex TextBox", 0);

            toolBox1[1].AddItem("Lable", 0);
            toolBox1[1].AddItem("Group Box", 0);

            toolBox1.Font = new Font("Arial", 8);
            toolBox1.BackColor = SystemColors.Control;
            toolBox1.ItemSelectedColor = Color.LightGray;

            frm.pr = propertyGrid1;

            ParentForm.VisibleChanged += (o, args) =>
            {
                if (!firstrun)
                {
                    ParentForm.FormClosing += ParentForm_FormClosing;
                    this.ParentForm.Size = new Size(600, 600);
                    ParentForm.WindowState = FormWindowState.Maximized;

                    PropertyGrid pr = new PropertyGrid();
                    pr.Dock = DockStyle.Right;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopMost = true;
                    frm.WindowState = FormWindowState.Normal;
                    frm.ShowInTaskbar = false;
                    frm.Show();
                    //frm.Visible = false;
                    timer1.Enabled = true;
                    firstrun = true;
                }
            };
            ParentForm.MouseCaptureChanged += ParentForm_MouseCaptureChanged;

        }

        void ParentForm_MouseCaptureChanged(object sender, EventArgs e)
        {
            
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Close();
            timer1.Enabled = false;

        }

        private bool showL = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            FormWindowState fws = FormWindowState.Minimized;
            Point location = splitContainer2.Panel1.PointToScreen(Point.Empty);
            frm.Location = location;
            frm.Size = splitContainer2.Panel1.Size;
            if (ParentForm.Capture)
            {
                frm.TopMost = true;
            }
            else
            {
                frm.TopMost = false;
            }
            if (ParentForm != null && frm != null)
            {


                if (ParentForm.WindowState == FormWindowState.Minimized)
                {
                    if (frm.WindowState != FormWindowState.Minimized)
                    {
                        fws = FormWindowState.Minimized;
                    }
                }
                else if (ParentForm.WindowState == FormWindowState.Normal)
                {
                    if (frm.WindowState != FormWindowState.Normal)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                }




                if (frm.WindowState != fws)
                {
                    //  frm.WindowState = fws;
                }
            }



        }

        private bool IsControlAtFront(Control control)
        {
            while (control.Parent != null)
            {
                if (control.Parent.Controls.GetChildIndex(control) == 0)
                {
                    control = control.Parent;
                    if (control.Parent == null)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabControl1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {


        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"]) //your specific tabname
            {
                try
                {

                    frm.Visible = true;
                    showL = true;

                }
                catch
                {

                }

            }
            else
            {
                frm.Visible = false;
                showL = false;
            }
        }
    }
}
            