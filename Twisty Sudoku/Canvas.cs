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
            InitializeComponent();
            cubeWatcher = new Observer();
            cubeWatcher.sub(this);
            theCube = Cube.getCube(cubeWatcher);
        }

        public void update()
        {
            Invalidate();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            theCube.draw(panel.CreateGraphics(), panel.Width, panel.Height);
        }
    }
}
