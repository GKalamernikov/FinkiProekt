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
            time.Text = i.ToString();
            //uslov za zavrseno
            //{ timer1.Stop()
            // MessageBox.Show("Congratulations! Your solving time is: " + i);
            // i = 0;
            // time.Text = "";
            //}
            if (i == 360)
            {
                timer1.Stop();
                MessageBox.Show("Your time's up!");
                i = 0;
                time.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }
    }
}
