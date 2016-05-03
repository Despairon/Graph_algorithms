namespace Graph_algorithms
{
    partial class MinRoutesForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGoal = new System.Windows.Forms.TextBox();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Кінець шляху";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Початок шляху";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "Введіть, будь-ласка, початкову вершину, \r\nта вершину, до якої необхідно знайти шл" +
    "ях";
            // 
            // tbGoal
            // 
            this.tbGoal.Location = new System.Drawing.Point(125, 118);
            this.tbGoal.Name = "tbGoal";
            this.tbGoal.Size = new System.Drawing.Size(100, 20);
            this.tbGoal.TabIndex = 10;
            // 
            // tbStart
            // 
            this.tbStart.Location = new System.Drawing.Point(125, 62);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(100, 20);
            this.tbStart.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Прийняти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Закрити";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MinRoutesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbGoal);
            this.Controls.Add(this.tbStart);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MinRoutesForm";
            this.Text = "Пошук мінімального шляху";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGoal;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}