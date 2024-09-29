using System;
using System.Drawing;
using System.Windows.Forms;

namespace showfall
{
    public partial class Main : Form
    {
        private const int SnowflakeCount = 50;

        private Timer timer;
        private Snowflake[] snowflakes;
        private Image snowflakeImage;

        public Main()
        {
            InitializeComponent();
            InitializeSnowfall();
        }

        private void InitializeSnowfall()
        {
            snowflakeImage = Properties.Resources.show;

            snowflakes = new Snowflake[SnowflakeCount];

            for (var i = 0; i < SnowflakeCount; i++)
            {
                snowflakes[i] = new Snowflake(Width, Height);
            }

            timer = new Timer();
            timer.Interval = 5;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.Fall();
                Invalidate(snowflake.GetBounds());
                Invalidate(snowflake.GetPrevBounds());
            }

        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var snowflake in snowflakes)
            {
                g.DrawImage(snowflakeImage, snowflake.X, snowflake.Y, 20, 20);
            }
        }
    }
}
