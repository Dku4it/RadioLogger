namespace _03Radiograbber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button11 = new Button();
            button12 = new Button();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            comboBox11 = new ComboBox();
            progressBar11 = new ProgressBar();
            pictureBox1 = new PictureBox();
            comboBox12 = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            jrock = new PictureBox();
            svobodnoe = new PictureBox();
            textBox15 = new TextBox();
            toolStripStatusLabel12 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel5 = new ToolStripStatusLabel();
            statusStrip1 = new StatusStrip();
            comboBox7 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jrock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svobodnoe).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button11
            // 
            button11.Location = new Point(419, 119);
            button11.Name = "button11";
            button11.Size = new Size(53, 23);
            button11.TabIndex = 12;
            button11.Text = "Select";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click_1;
            // 
            // button12
            // 
            button12.BackColor = Color.LightGray;
            button12.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button12.ForeColor = SystemColors.ControlText;
            button12.Location = new Point(397, 196);
            button12.Name = "button12";
            button12.Size = new Size(78, 35);
            button12.TabIndex = 2;
            button12.Text = "Run";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = SystemColors.GrayText;
            label3.Location = new Point(21, 122);
            label3.Name = "label3";
            label3.Size = new Size(139, 15);
            label3.TabIndex = 7;
            label3.Text = "Select destination Folder:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = SystemColors.GrayText;
            label4.Location = new Point(21, 205);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 8;
            label4.Text = "Enter URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(35, 243);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 4;
            label2.Text = "Status:";
            // 
            // comboBox11
            // 
            comboBox11.FormattingEnabled = true;
            comboBox11.Location = new Point(85, 202);
            comboBox11.Name = "comboBox11";
            comboBox11.Size = new Size(306, 23);
            comboBox11.TabIndex = 1;
            comboBox11.Tag = "";
            comboBox11.SelectedIndexChanged += comboBox11_SelectedIndexChanged;
            // 
            // progressBar11
            // 
            progressBar11.Location = new Point(0, 276);
            progressBar11.Name = "progressBar11";
            progressBar11.Size = new Size(487, 14);
            progressBar11.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(487, 105);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // comboBox12
            // 
            comboBox12.FormattingEnabled = true;
            comboBox12.Location = new Point(165, 159);
            comboBox12.Name = "comboBox12";
            comboBox12.Size = new Size(171, 23);
            comboBox12.TabIndex = 13;
            comboBox12.TextChanged += ComboBox12_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(97, 162);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 12;
            label1.Text = "Select File:";
            // 
            // button1
            // 
            button1.Location = new Point(343, 159);
            button1.Name = "button1";
            button1.Size = new Size(53, 23);
            button1.TabIndex = 14;
            button1.Text = "Go to";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // jrock
            // 
            jrock.BackColor = SystemColors.Control;
            jrock.Image = (Image)resources.GetObject("jrock.Image");
            jrock.Location = new Point(46, 150);
            jrock.Name = "jrock";
            jrock.Size = new Size(40, 40);
            jrock.SizeMode = PictureBoxSizeMode.CenterImage;
            jrock.TabIndex = 14;
            jrock.TabStop = false;
            jrock.Visible = false;
            // 
            // svobodnoe
            // 
            svobodnoe.BackColor = SystemColors.Control;
            svobodnoe.BackgroundImageLayout = ImageLayout.Zoom;
            svobodnoe.Image = (Image)resources.GetObject("svobodnoe.Image");
            svobodnoe.Location = new Point(46, 150);
            svobodnoe.Name = "svobodnoe";
            svobodnoe.Size = new Size(40, 40);
            svobodnoe.SizeMode = PictureBoxSizeMode.CenterImage;
            svobodnoe.TabIndex = 15;
            svobodnoe.TabStop = false;
            svobodnoe.Tag = "";
            svobodnoe.Visible = false;
            // 
            // textBox15
            // 
            textBox15.BackColor = SystemColors.ButtonFace;
            textBox15.BorderStyle = BorderStyle.None;
            textBox15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBox15.ForeColor = Color.FromArgb(0, 64, 0);
            textBox15.Location = new Point(83, 243);
            textBox15.Multiline = true;
            textBox15.Name = "textBox15";
            textBox15.ReadOnly = true;
            textBox15.Size = new Size(392, 34);
            textBox15.TabIndex = 0;
            textBox15.TabStop = false;
            textBox15.MouseDoubleClick += textBox15_MouseDoubleClick;
            // 
            // toolStripStatusLabel12
            // 
            toolStripStatusLabel12.AutoSize = false;
            toolStripStatusLabel12.BorderSides = ToolStripStatusLabelBorderSides.Right;
            toolStripStatusLabel12.BorderStyle = Border3DStyle.SunkenInner;
            toolStripStatusLabel12.ForeColor = SystemColors.GrayText;
            toolStripStatusLabel12.Name = "toolStripStatusLabel12";
            toolStripStatusLabel12.Size = new Size(175, 19);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.AutoSize = false;
            toolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Right;
            toolStripStatusLabel2.BorderStyle = Border3DStyle.SunkenInner;
            toolStripStatusLabel2.ForeColor = Color.Gray;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.RightToLeft = RightToLeft.No;
            toolStripStatusLabel2.Size = new Size(162, 19);
            toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.AutoSize = false;
            toolStripStatusLabel5.ForeColor = Color.Gray;
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new Size(135, 19);
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Transparent;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel12, toolStripStatusLabel2, toolStripStatusLabel5 });
            statusStrip1.Location = new Point(0, 287);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(487, 24);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // comboBox7
            // 
            comboBox7.FormattingEnabled = true;
            comboBox7.Location = new Point(166, 119);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(247, 23);
            comboBox7.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(487, 311);
            Controls.Add(comboBox7);
            Controls.Add(progressBar11);
            Controls.Add(textBox15);
            Controls.Add(svobodnoe);
            Controls.Add(jrock);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboBox12);
            Controls.Add(pictureBox1);
            Controls.Add(statusStrip1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button12);
            Controls.Add(comboBox11);
            Controls.Add(button11);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(503, 350);
            MinimumSize = new Size(503, 350);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Radio Logger 2.4.6";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)jrock).EndInit();
            ((System.ComponentModel.ISupportInitialize)svobodnoe).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button11;
        private Button button12;
        private Label label3;
        private Label label4;
        private Label label2;
        private ComboBox comboBox11;
        private ProgressBar progressBar11;
        private PictureBox pictureBox1;
        private ComboBox comboBox12;
        private Label label1;
        private Button button1;
        private PictureBox jrock;
        private PictureBox svobodnoe;
        private TextBox textBox15;
        private ToolStripStatusLabel toolStripStatusLabel12;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private StatusStrip statusStrip1;
        private ComboBox comboBox7;
    }
}
