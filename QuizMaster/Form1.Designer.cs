namespace QuizMaster
{
    partial class Form1
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
            this.startQuiz = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startQuiz
            // 
            this.startQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startQuiz.Location = new System.Drawing.Point(512, 466);
            this.startQuiz.Name = "startQuiz";
            this.startQuiz.Size = new System.Drawing.Size(259, 65);
            this.startQuiz.TabIndex = 0;
            this.startQuiz.Text = "Start quiz";
            this.startQuiz.UseVisualStyleBackColor = true;
            this.startQuiz.UseWaitCursor = true;
            this.startQuiz.Click += new System.EventHandler(this.start_quiz_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(609, 468);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(9, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(723, 69);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to Quiz Master!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 799);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.startQuiz);
            this.Name = "Form1";
            this.Text = "Quiz Master";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startQuiz;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}

