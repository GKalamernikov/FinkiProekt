using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twisty_Sudoku
{
    public partial class Canvas : Form, Monitor
    {
        Cube theCube;
        Observer cubeWatcher;
        public Canvas()
        {
            cubeWatcher = new Observer();
            cubeWatcher.sub(this);
            theCube = Cube.getCube(cubeWatcher);
            InitializeComponent();
        }
        
        public void update()
        {
            Invalidate();
            panel.Invalidate();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            theCube.handleDown(e.X, e.Y);
        }
        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            theCube.handleUp(e.X, e.Y);
            if (theCube.isSolved())
            {
                timer1.Stop();
                TimeSpan i_minutes = TimeSpan.FromSeconds(i);
                MessageBox.Show("Congratulations! Your solving time is: " +
                    String.Format("{0:D2}:{1:D2}:{2:D2}", i_minutes.Hours, i_minutes.Minutes, i_minutes.Seconds)
                    + "\n Click SCRAMBLE to start again.");
                i = 0;
                time.Text = "";
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            theCube.handleMove(e.X, e.Y);
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            theCube.draw(panel.CreateGraphics(), panel.Width, panel.Height);
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            TimeSpan i_minutes = TimeSpan.FromSeconds(i);
            time.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", i_minutes.Hours, i_minutes.Minutes, i_minutes.Seconds);
        }

        private void scramble_Click(object sender, EventArgs e)
        {
            theCube.scramble();
            timer1.Start();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            theCube.reset();
            theCube = Cube.getCube(cubeWatcher);
            timer1.Stop();
            i = 0;
            time.Text = "";
        }
    }
}
