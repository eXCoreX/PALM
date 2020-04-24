// Rostyslav L. Lab 4 Var 13

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
    public partial class MainForm : Form
    {
        public MainForm()
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
        readonly Pen bl = new Pen(Color.Black, 4);
        readonly SolidBrush bl_b = new SolidBrush(Color.Black);
        readonly SolidBrush y = new SolidBrush(Color.Yellow);
        // Square
        int sq_CurX = 5, sq_CurY = 5;
        int sq_VX = 5, sq_VY = 5;

        // Square around circle
        int ssq_CurX = 0, ssq_CurY =  0;
        int ssq_VX = -2, ssq_VY = 0;
        int state = 1; // 1 left 2 up 3 right 4 down

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

            #region BicycleDrawing
            e.Graphics.DrawEllipse(bl, new Rectangle(500, 400, 50, 50));
            e.Graphics.DrawEllipse(bl, new Rectangle(590, 400, 50, 50));
            e.Graphics.DrawLine(bl, 525, 425, 565, 425);
            e.Graphics.FillEllipse(bl_b, 555, 415, 20, 20);
            e.Graphics.DrawLine(bl, 565, 425, 600, 385);
            e.Graphics.DrawLine(bl, 600, 385, 615, 425);
            e.Graphics.DrawLine(bl, 600, 385, 545, 385);
            e.Graphics.DrawLine(bl, 545, 385, 525, 425);
            e.Graphics.DrawLine(bl, 545, 385, 565, 425);
            e.Graphics.DrawLine(bl, 545, 385, 540, 370);
            e.Graphics.DrawLine(bl, 530, 370, 555, 370);
            e.Graphics.DrawLine(bl, 600, 385, 600, 375);
            #endregion

            #region Task C
            e.Graphics.DrawEllipse(g, this.Width / 2 - 40, this.Height / 2 - 40, 80, 80);

            switch (state)
            {
                case 1:
                    {
                        if (ssq_CurX + ssq_VX <= -40)
                        {
                            ssq_CurX = -40;
                            ssq_VX = 0;
                            ssq_VY = -2;
                            state = 2;
                        }
                        break;
                    }
                case 2:
                    {
                        if (ssq_CurY + ssq_VY <= -40)
                        {
                            ssq_CurY = -40;
                            ssq_VX = 2;
                            ssq_VY = 0;
                            state = 3;
                        }
                        break;
                    }
                case 3:
                    {
                        if (ssq_CurX + ssq_VX >= 0)
                        {
                            ssq_CurX = 0;
                            ssq_VX = 0;
                            ssq_VY = 2;
                            state = 4;
                        }
                        break;
                    }
                case 4:
                    {
                        if (ssq_CurY + ssq_VY >= 0)
                        {
                            ssq_CurY = 0;
                            ssq_VX = -2;
                            ssq_VY = 0;
                            state = 1;
                        }
                        break;
                    }
                default:
                    break;
            }

            // Moving square
            ssq_CurX += ssq_VX;
            ssq_CurY += ssq_VY;
            e.Graphics.DrawRectangle(b, this.Width / 2 - 40 + ssq_CurX, this.Height / 2 - 40 + ssq_CurY, 120, 120);
            
            #endregion
        }
    }
}
