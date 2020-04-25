// Rostyslav L. KN-19 Lab 4 Var 13

using System;
using System.Drawing;
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

        readonly System.Timers.Timer t = new System.Timers.Timer(1000.0/60); // 60 FPS

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.jokeMode ^= true;
        }
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

        #region CONSTS
        const int sqInitX = 5, sqInitY = 5;
        const int sqInitW = 50, sqInitH = 50;
        const int sqInitVX = 5, sqInitVY = 5;

        const int ssqInitW = 100;
        const int ssqInitVX = -2; // only negative

        const int circInitW = 60;
        #endregion

        // Square
        int sq_CurX = sqInitX, sq_CurY = sqInitY;
        int sq_VX = sqInitVX, sq_VY = sqInitVY;
        // Square around circle
        int ssq_CurX = 0, ssq_CurY =  0;
        int ssq_VX = ssqInitVX, ssq_VY = 0;
        int state = 1; // 1 left 2 up 3 right 4 down
        public bool jokeMode = false;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(Color.White);
            // Square
            if (sq_CurX + sq_VX + sqInitW > this.Width)
            {
                sq_CurX = this.Width - sqInitW;
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
            if (sq_CurY + sq_VY + sqInitH > this.Height)
            {
                sq_CurY = this.Height - sqInitH;
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

            e.Graphics.DrawRectangle(r, new Rectangle(sq_CurX, sq_CurY, sqInitW, sqInitH)); // Square
            if(jokeMode) e.Graphics.DrawString("DVD", new Font("Arial", 16 * sqInitW / 50), bl_b, sq_CurX, sq_CurY + sqInitH / 4);

            e.Graphics.DrawPolygon(g, new Point[] { new Point(30, 400), new Point(30, 450), new Point(80, 450) }); // Sq Triangle
            e.Graphics.DrawEllipse(b, new Rectangle(140, 180, 100, 60)); // Ellipse 
            e.Graphics.FillPolygon(y, new Point[] { new Point(300, 350), new Point(315, 385), new Point(360, 390), new Point(330, 410), new Point(350, 440), new Point(300, 420), 
                                                    new Point(250, 440), new Point(270, 410), new Point(240, 390), new Point(285, 385) }); // Star 

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
            e.Graphics.DrawEllipse(g, this.Width / 2 - circInitW / 2, this.Height / 2 - circInitW / 2, circInitW, circInitW);

            switch (state) // Switch state if needed
            {
                case 1:
                    {
                        if (ssq_CurX + ssq_VX <= -(ssqInitW - circInitW))
                        {
                            ssq_CurX = -(ssqInitW - circInitW);
                            ssq_VX = 0;
                            ssq_VY = ssqInitVX;
                            state = 2;
                        }
                        break;
                    }
                case 2:
                    {
                        if (ssq_CurY + ssq_VY <= -(ssqInitW - circInitW))
                        {
                            ssq_CurY = -(ssqInitW - circInitW);
                            ssq_VX = -ssqInitVX;
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
                            ssq_VY = -ssqInitVX;
                            state = 4;
                        }
                        break;
                    }
                case 4:
                    {
                        if (ssq_CurY + ssq_VY >= 0)
                        {
                            ssq_CurY = 0;
                            ssq_VX = ssqInitVX;
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
            e.Graphics.DrawRectangle(b, this.Width / 2 - circInitW / 2 + ssq_CurX, this.Height / 2 - circInitW / 2 + ssq_CurY, ssqInitW, ssqInitW);
            
            #endregion
        }
    }
}
