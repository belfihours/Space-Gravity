namespace Gravity.Drawer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btn_zoom_out = new Button();
            btn_zoom_in = new Button();
            btn_heliocenter = new Button();
            btn_swap = new Button();
            btn_start_ast = new Button();
            btn_start = new Button();
            btn_stop = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_stop);
            panel1.Controls.Add(btn_zoom_out);
            panel1.Controls.Add(btn_zoom_in);
            panel1.Controls.Add(btn_heliocenter);
            panel1.Controls.Add(btn_swap);
            panel1.Controls.Add(btn_start_ast);
            panel1.Controls.Add(btn_start);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1150, 29);
            panel1.TabIndex = 0;
            // 
            // btn_zoom_out
            // 
            btn_zoom_out.Location = new Point(1041, 3);
            btn_zoom_out.Name = "btn_zoom_out";
            btn_zoom_out.Size = new Size(25, 23);
            btn_zoom_out.TabIndex = 5;
            btn_zoom_out.Text = "-";
            btn_zoom_out.UseVisualStyleBackColor = true;
            btn_zoom_out.Click += btn_zoom_out_Click;
            // 
            // btn_zoom_in
            // 
            btn_zoom_in.Location = new Point(1010, 3);
            btn_zoom_in.Name = "btn_zoom_in";
            btn_zoom_in.Size = new Size(25, 23);
            btn_zoom_in.TabIndex = 4;
            btn_zoom_in.Text = "+";
            btn_zoom_in.UseVisualStyleBackColor = true;
            btn_zoom_in.Click += btn_zoom_in_Click;
            // 
            // btn_heliocenter
            // 
            btn_heliocenter.Location = new Point(466, 3);
            btn_heliocenter.Name = "btn_heliocenter";
            btn_heliocenter.Size = new Size(97, 23);
            btn_heliocenter.TabIndex = 3;
            btn_heliocenter.Text = "Heliocenter";
            btn_heliocenter.UseVisualStyleBackColor = true;
            btn_heliocenter.Click += btn_heliocenter_Click;
            // 
            // btn_swap
            // 
            btn_swap.Location = new Point(337, 3);
            btn_swap.Name = "btn_swap";
            btn_swap.Size = new Size(75, 23);
            btn_swap.TabIndex = 2;
            btn_swap.Text = "SWAP";
            btn_swap.UseVisualStyleBackColor = true;
            btn_swap.Click += btn_swap_Click;
            // 
            // btn_start_ast
            // 
            btn_start_ast.Location = new Point(136, 3);
            btn_start_ast.Name = "btn_start_ast";
            btn_start_ast.Size = new Size(147, 23);
            btn_start_ast.TabIndex = 1;
            btn_start_ast.Text = "Start With Asteroids";
            btn_start_ast.UseVisualStyleBackColor = true;
            btn_start_ast.Click += button1_Click;
            // 
            // btn_start
            // 
            btn_start.Location = new Point(3, 3);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(75, 23);
            btn_start.TabIndex = 0;
            btn_start.Text = "Start";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += btn_start_Click;
            // 
            // btn_stop
            // 
            btn_stop.Location = new Point(1075, 3);
            btn_stop.Name = "btn_stop";
            btn_stop.Size = new Size(75, 23);
            btn_stop.TabIndex = 6;
            btn_stop.Text = "STOP";
            btn_stop.UseVisualStyleBackColor = true;
            btn_stop.Click += btn_stop_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 595);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_start;
        private Button btn_start_ast;
        private Button btn_swap;
        private Button btn_heliocenter;
        private Button btn_zoom_out;
        private Button btn_zoom_in;
        private Button btn_stop;
    }
}