using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace PALM_Lab_2_4_win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            t.Elapsed += MainLoop;
            t.Start();
        }

        private void MainLoop(object sender, ElapsedEventArgs e)
        {
            t.Start();
            pictureBox1.Invalidate();
        }

        System.Timers.Timer t = new System.Timers.Timer(1000.0/60); // 60 FPS

        
    }
    public class BetterPictureBox : PictureBox
    {
        public BetterPictureBox()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        readonly Pen b = new Pen(Color.Blue);
        readonly Pen r = new Pen(Color.Red);
        readonly Pen g = new Pen(Color.Green);
        readonly SolidBrush y = new SolidBrush(Color.Yellow);
        // Square
        int sq_CurX = 5, sq_CurY = 5;
        int sq_VX = 5, sq_VY = 5;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(Color.White);
            // Square
            if (sq_CurX + sq_VX + 50 > this.Width)
            {
                sq_CurX = this.Width - 50;
                sq_VX = -sq_VX;
            }
            else if (sq_CurX + sq_VX < 0)
            {
                sq_CurX = 0;
                sq_VX = -sq_VX;
            }
            else
            {
                sq_CurX += sq_VX;
            }
            if (sq_CurY + sq_VY + 50 > this.Height)
            {
                sq_CurY = this.Height - 50;
                sq_VY = -sq_VY;
            }
            else if (sq_CurY + sq_VY < 0)
            {
                sq_CurY = 0;
                sq_VY = -sq_VY;
            }
            else
            {
                sq_CurY += sq_VY;
            }

            e.Graphics.DrawRectangle(r, new Rectangle(sq_CurX, sq_CurY, 50, 50)); // Square

            e.Graphics.DrawPolygon(g, new Point[] { new Point(30, 30), new Point(30, 90), new Point(80, 90) }); // Sq Triangle
            e.Graphics.DrawEllipse(b, new Rectangle(140, 180, 100, 60)); // Ellipse
            e.Graphics.FillPolygon(y, new Point[] { new Point(300, 300), new Point(315, 335), new Point(360, 340), new Point(330, 360), new Point(350, 390), new Point(300, 370), 
                                                    new Point(250, 390), new Point(270, 360), new Point(240, 340), new Point(285, 335) }); // Star

        }
    }
}
