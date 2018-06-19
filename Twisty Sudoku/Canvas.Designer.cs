namespace Twisty_Sudoku
{
    partial class Canvas
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
            this.components = new System.ComponentModel.Container();
            this.panel = new System.Windows.Forms.Panel();
            this.debug = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.scramble = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.debug);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(460, 460);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(3, 447);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(39, 13);
            this.debug.TabIndex = 0;
            this.debug.Text = "Debug";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // scramble
            // 
            this.scramble.Location = new System.Drawing.Point(27, 485);
            this.scramble.Name = "scramble";
            this.scramble.Size = new System.Drawing.Size(75, 23);
            this.scramble.TabIndex = 3;
            this.scramble.Text = "SCRAMBLE";
            this.scramble.UseVisualStyleBackColor = true;
            this.scramble.Click += new System.EventHandler(this.scramble_Click);
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(364, 488);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(91, 20);
            this.time.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 491);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time:";
            // 
            // Canvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 520);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.time);
            this.Controls.Add(this.scramble);
            this.Controls.Add(this.panel);
            this.Name = "Canvas";
            this.Text = "Game";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label debug;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button scramble;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Label label1;
    }
}

