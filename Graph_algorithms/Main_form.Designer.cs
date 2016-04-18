namespace Graph_algorithms
{
    partial class Main_form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.graphics = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.bClose = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bDeepSearch = new System.Windows.Forms.Button();
            this.bWideSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bPrimsAlg = new System.Windows.Forms.Button();
            this.bCruscalsAlg = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bJohnsonsAlg = new System.Windows.Forms.Button();
            this.bFloyd_Warsh_alg = new System.Windows.Forms.Button();
            this.bBell_Ford_alg = new System.Windows.Forms.Button();
            this.bDijkstrasAlg = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bEdm_Carp_Alg = new System.Windows.Forms.Button();
            this.bFord_Falks_Alg = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphics
            // 
            this.graphics.AccumBits = ((byte)(0));
            this.graphics.AutoCheckErrors = false;
            this.graphics.AutoFinish = false;
            this.graphics.AutoMakeCurrent = true;
            this.graphics.AutoSwapBuffers = true;
            this.graphics.BackColor = System.Drawing.Color.White;
            this.graphics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphics.ColorBits = ((byte)(32));
            this.graphics.DepthBits = ((byte)(16));
            this.graphics.ForeColor = System.Drawing.Color.White;
            this.graphics.Location = new System.Drawing.Point(13, 167);
            this.graphics.Name = "graphics";
            this.graphics.Size = new System.Drawing.Size(818, 400);
            this.graphics.StencilBits = ((byte)(0));
            this.graphics.TabIndex = 0;
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(756, 573);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 1;
            this.bClose.Text = "Закрити";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(12, 573);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 2;
            this.bClear.Text = "Очистити";
            this.bClear.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bDeepSearch);
            this.groupBox1.Controls.Add(this.bWideSearch);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 149);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Елементарні алгоритми";
            // 
            // bDeepSearch
            // 
            this.bDeepSearch.Location = new System.Drawing.Point(6, 85);
            this.bDeepSearch.Name = "bDeepSearch";
            this.bDeepSearch.Size = new System.Drawing.Size(188, 23);
            this.bDeepSearch.TabIndex = 1;
            this.bDeepSearch.Text = "Пошук в глибину";
            this.bDeepSearch.UseVisualStyleBackColor = true;
            // 
            // bWideSearch
            // 
            this.bWideSearch.Location = new System.Drawing.Point(6, 56);
            this.bWideSearch.Name = "bWideSearch";
            this.bWideSearch.Size = new System.Drawing.Size(188, 23);
            this.bWideSearch.TabIndex = 0;
            this.bWideSearch.Text = "Пошук в ширину";
            this.bWideSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bPrimsAlg);
            this.groupBox2.Controls.Add(this.bCruscalsAlg);
            this.groupBox2.Location = new System.Drawing.Point(219, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 149);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Мінімальні остовні дерева";
            // 
            // bPrimsAlg
            // 
            this.bPrimsAlg.Location = new System.Drawing.Point(6, 85);
            this.bPrimsAlg.Name = "bPrimsAlg";
            this.bPrimsAlg.Size = new System.Drawing.Size(188, 23);
            this.bPrimsAlg.TabIndex = 1;
            this.bPrimsAlg.Text = "Алгоритм Пріма";
            this.bPrimsAlg.UseVisualStyleBackColor = true;
            // 
            // bCruscalsAlg
            // 
            this.bCruscalsAlg.Location = new System.Drawing.Point(6, 56);
            this.bCruscalsAlg.Name = "bCruscalsAlg";
            this.bCruscalsAlg.Size = new System.Drawing.Size(188, 23);
            this.bCruscalsAlg.TabIndex = 0;
            this.bCruscalsAlg.Text = "Алгоритм Крускала";
            this.bCruscalsAlg.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bJohnsonsAlg);
            this.groupBox3.Controls.Add(this.bFloyd_Warsh_alg);
            this.groupBox3.Controls.Add(this.bBell_Ford_alg);
            this.groupBox3.Controls.Add(this.bDijkstrasAlg);
            this.groupBox3.Location = new System.Drawing.Point(425, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 149);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Найкоротші шляхи";
            // 
            // bJohnsonsAlg
            // 
            this.bJohnsonsAlg.Location = new System.Drawing.Point(6, 114);
            this.bJohnsonsAlg.Name = "bJohnsonsAlg";
            this.bJohnsonsAlg.Size = new System.Drawing.Size(188, 23);
            this.bJohnsonsAlg.TabIndex = 3;
            this.bJohnsonsAlg.Text = "Алгоритм Джонсона";
            this.bJohnsonsAlg.UseVisualStyleBackColor = true;
            // 
            // bFloyd_Warsh_alg
            // 
            this.bFloyd_Warsh_alg.Location = new System.Drawing.Point(6, 56);
            this.bFloyd_Warsh_alg.Name = "bFloyd_Warsh_alg";
            this.bFloyd_Warsh_alg.Size = new System.Drawing.Size(188, 23);
            this.bFloyd_Warsh_alg.TabIndex = 2;
            this.bFloyd_Warsh_alg.Text = "Алгоритм Флойда-Варшалла";
            this.bFloyd_Warsh_alg.UseVisualStyleBackColor = true;
            // 
            // bBell_Ford_alg
            // 
            this.bBell_Ford_alg.Location = new System.Drawing.Point(6, 27);
            this.bBell_Ford_alg.Name = "bBell_Ford_alg";
            this.bBell_Ford_alg.Size = new System.Drawing.Size(188, 23);
            this.bBell_Ford_alg.TabIndex = 0;
            this.bBell_Ford_alg.Text = "Алгоритм Беллмана-Форда";
            this.bBell_Ford_alg.UseVisualStyleBackColor = true;
            // 
            // bDijkstrasAlg
            // 
            this.bDijkstrasAlg.Location = new System.Drawing.Point(6, 85);
            this.bDijkstrasAlg.Name = "bDijkstrasAlg";
            this.bDijkstrasAlg.Size = new System.Drawing.Size(188, 23);
            this.bDijkstrasAlg.TabIndex = 1;
            this.bDijkstrasAlg.Text = "Алгоритм Дейкстри";
            this.bDijkstrasAlg.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bEdm_Carp_Alg);
            this.groupBox4.Controls.Add(this.bFord_Falks_Alg);
            this.groupBox4.Location = new System.Drawing.Point(631, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 149);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Максимальний потік";
            // 
            // bEdm_Carp_Alg
            // 
            this.bEdm_Carp_Alg.Location = new System.Drawing.Point(13, 85);
            this.bEdm_Carp_Alg.Name = "bEdm_Carp_Alg";
            this.bEdm_Carp_Alg.Size = new System.Drawing.Size(181, 23);
            this.bEdm_Carp_Alg.TabIndex = 1;
            this.bEdm_Carp_Alg.Text = "Алгоритм Едмондса-Карпа";
            this.bEdm_Carp_Alg.UseVisualStyleBackColor = true;
            // 
            // bFord_Falks_Alg
            // 
            this.bFord_Falks_Alg.Location = new System.Drawing.Point(13, 56);
            this.bFord_Falks_Alg.Name = "bFord_Falks_Alg";
            this.bFord_Falks_Alg.Size = new System.Drawing.Size(181, 23);
            this.bFord_Falks_Alg.TabIndex = 0;
            this.bFord_Falks_Alg.Text = "Алгоритм Форда-Фалкерсона";
            this.bFord_Falks_Alg.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 573);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 608);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.graphics);
            this.Name = "Main_form";
            this.Text = "Графові алгоритми";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl graphics;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bDeepSearch;
        private System.Windows.Forms.Button bWideSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bPrimsAlg;
        private System.Windows.Forms.Button bCruscalsAlg;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bJohnsonsAlg;
        private System.Windows.Forms.Button bFloyd_Warsh_alg;
        private System.Windows.Forms.Button bDijkstrasAlg;
        private System.Windows.Forms.Button bBell_Ford_alg;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bEdm_Carp_Alg;
        private System.Windows.Forms.Button bFord_Falks_Alg;
        private System.Windows.Forms.Button button1;
    }
}

