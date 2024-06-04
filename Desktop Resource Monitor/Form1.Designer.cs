namespace Desktop_Resource_Monitor
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
            groupBox1 = new GroupBox();
            comboBox1 = new ComboBox();
            label7 = new Label();
            button2 = new Button();
            checkBox1 = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(361, 295);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "설정";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(71, 80);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(203, 23);
            comboBox1.TabIndex = 7;
            // 
            // label7
            // 
            label7.Location = new Point(6, 83);
            label7.Name = "label7";
            label7.Size = new Size(59, 13);
            label7.TabIndex = 6;
            label7.Text = "저장 주기";
            // 
            // button2
            // 
            button2.Location = new Point(280, 52);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "경로 열기";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(265, 215);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(90, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "파일로 저장";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Location = new Point(6, 237);
            label2.Name = "label2";
            label2.Size = new Size(349, 55);
            label2.TabIndex = 3;
            label2.Text = "[사용법]\r\n서비스 > Windows Management Instrumentation가 실행중인지 확인하세요.";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            label1.Location = new Point(6, 27);
            label1.Name = "label1";
            label1.Size = new Size(59, 13);
            label1.TabIndex = 2;
            label1.Text = "저장 경로";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(71, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(203, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(280, 23);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "찾아보기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(379, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 295);
            panel1.TabIndex = 1;
            // 
            // label6
            // 
            label6.Location = new Point(65, 49);
            label6.Name = "label6";
            label6.Size = new Size(162, 16);
            label6.TabIndex = 3;
            label6.Text = "MEM";
            // 
            // label5
            // 
            label5.Location = new Point(15, 49);
            label5.Name = "label5";
            label5.Size = new Size(44, 16);
            label5.TabIndex = 2;
            label5.Text = "MEM";
            // 
            // label4
            // 
            label4.Location = new Point(65, 23);
            label4.Name = "label4";
            label4.Size = new Size(162, 16);
            label4.TabIndex = 1;
            label4.Text = "CPU";
            // 
            // label3
            // 
            label3.Location = new Point(15, 23);
            label3.Name = "label3";
            label3.Size = new Size(44, 16);
            label3.TabIndex = 0;
            label3.Text = "CPU";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 319);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBox1;
        private Button button1;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label5;
        private CheckBox checkBox1;
        private Button button2;
        private Label label7;
        private ComboBox comboBox1;
    }
}
