using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterFace.FlowChart.Icon;
using UserInterFace.FlowChart.Icons;
using Form = UserInterFace.FlowChart.Icons.Form;

namespace UserInterFace.FlowChart
{
    public partial class ToolBox : UserControl
    {
        public Flowchart FlowChart { get; set; }

        public ToolBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add form
            var points = new List<Point>();
            points.Add(new Point(50, 10));
            points.Add(new Point(50, 40));
            points.Add(new Point(0, 40));
            points.Add(new Point(0, 10));
            points.Add(new Point(50, 10));
            points.Add(new Point(50, 0));
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 10));
            var cpoints = new List<Connection>();
            cpoints.Add(new Connection()
            {
                Location = new Point(0 - 10, 20 ),
                Brush = Brushes.DeepSkyBlue,
                UID = FlowChart.cpUIDC++
            });
            cpoints.Add(new Connection()
            {
                Location = new Point(50, 20 + 1),
                Brush = Brushes.DeepSkyBlue,
                UID = FlowChart.cpUIDC++
            });
            cpoints.Add(new Connection()
            {
                Location = new Point(25 - 5, 40),
                Brush = Brushes.DeepSkyBlue,
                UID = FlowChart.cpUIDC++
            });
            FlowChart.AddIcon(new NIcon()
            {
                aColor = Pens.Black,
                DrawPoints = points,
                ID = "Form",
                UID = FlowChart.UIDC++,
                Location = new Point(FlowChart.cAddpoint, FlowChart.cAddpoint),
                Size = new Size(50,40),
                ConnectionPoints = cpoints,
                OptionsControl = new Form()
            });
            FlowChart.cAddpoint += 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //add locig operation
            var points = new List<Point>();
            points.Add(new Point(20, 50));
            points.Add(new Point(40, 50));
            points.Add(new Point(40, 0));
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 50));
            points.Add(new Point(20, 50));
            points.Add(new Point(20, 35));
            points.Add(new Point(15, 25));
            points.Add(new Point(20, 35));
            points.Add(new Point(25, 25));
            points.Add(new Point(15, 25));
            points.Add(new Point(20, 25));
            points.Add(new Point(20, 0));
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 50));
            var cpoints = new List<Connection>();
            cpoints.Add(new Connection()
            {
                Location = new Point(40, 25),
                Brush = Brushes.DeepSkyBlue,
                UID = FlowChart.cpUIDC++
            });
            cpoints.Add(new Connection()
            {
                Location = new Point(20 - 5, 50),
                Brush = Brushes.DeepSkyBlue,
                UID = FlowChart.cpUIDC++
            });
            cpoints.Add(new Connection()
            {
                Location = new Point(0 - 10, 25),
                Brush = Brushes.DeepSkyBlue,
                UID = FlowChart.cpUIDC++
            });
            cpoints.Add(new Connection()
            {
                Location = new Point(25 - 10, 0 - 10),
                Brush = Brushes.DeepSkyBlue,
                UID = FlowChart.cpUIDC++
            });
            FlowChart.AddIcon(new NIcon()
            {
                aColor = Pens.Black,
                DrawPoints = points,
                ID = "Logic",
                UID = FlowChart.UIDC++,
                Location = new Point(FlowChart.cAddpoint, FlowChart.cAddpoint),
                Size = new Size(40, 50),
                ConnectionPoints = cpoints,
                OptionsControl = new Logic()
            });
            FlowChart.cAddpoint += 10;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //add locig operation
            var points = new List<Point>();
            points.Add(new Point(20, 50));
            points.Add(new Point(40, 50));
            points.Add(new Point(40, 0));
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 50));
            //inner
            points.Add(new Point(20, 50));
            points.Add(new Point(20, 35));
            points.Add(new Point(15, 35));
            points.Add(new Point(15, 30));
            points.Add(new Point(20, 30));
            points.Add(new Point(20, 25));
            points.Add(new Point(15, 20));
            points.Add(new Point(15, 5));
            points.Add(new Point(20, 0));
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 50));
            var cpoints = new List<Connection>();
            cpoints.Add(new Connection()
            {
                Location = new Point(40, 25),
                Brush = Brushes.DeepSkyBlue,
                UID = FlowChart.cpUIDC++
            });
            cpoints.Add(new Connection()
            {
                Location = new Point(20 - 5, 50),
                Brush = Brushes.DeepSkyBlue,
                UID = FlowChart.cpUIDC++
            });
            cpoints.Add(new Connection()
            {
                Location = new Point(0 - 10, 25),
                Brush = Brushes.DeepSkyBlue,
                UID = FlowChart.cpUIDC++
            });
            cpoints.Add(new Connection()
            {
                Location = new Point(25 - 10, 0 - 10),
                Brush = Brushes.DeepSkyBlue,
                UID = FlowChart.cpUIDC++
            });
            FlowChart.AddIcon(new NIcon()
            {
                aColor = Pens.Black,
                DrawPoints = points,
                ID = "Convert",
                UID = FlowChart.UIDC++,
                Location = new Point(FlowChart.cAddpoint, FlowChart.cAddpoint),
                Size = new Size(40, 50),
                ConnectionPoints = cpoints,
                OptionsControl = new Icons.Convert()
            });
            FlowChart.cAddpoint += 10;
        }
    }
}
