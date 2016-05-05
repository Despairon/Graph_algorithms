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
            this.components = new System.ComponentModel.Container();
            this.graphics = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.bClose = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.renderTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.WideSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeepSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мінімальніОстовніДереваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CruscalsAlgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrimsAlgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.найкоротшіШляхиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Bell_Ford_algToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Floyd_Warsh_algToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DijkstrasAlgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JohnsonsAlgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.максимальнийПотікToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Ford_Falks_AlgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Edm_Carp_AlgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tbWeight = new System.Windows.Forms.ToolStripTextBox();
            this.bHclear = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
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
            this.graphics.ForeColor = System.Drawing.Color.Transparent;
            this.graphics.Location = new System.Drawing.Point(12, 27);
            this.graphics.Name = "graphics";
            this.graphics.Size = new System.Drawing.Size(760, 494);
            this.graphics.StencilBits = ((byte)(0));
            this.graphics.TabIndex = 0;
            this.graphics.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphics_MouseClick);
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(697, 527);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 1;
            this.bClose.Text = "Закрити";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(12, 527);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 2;
            this.bClear.Text = "Очистити";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // renderTimer
            // 
            this.renderTimer.Enabled = true;
            this.renderTimer.Interval = 1;
            this.renderTimer.Tick += new System.EventHandler(this.tDrawing_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.мінімальніОстовніДереваToolStripMenuItem,
            this.найкоротшіШляхиToolStripMenuItem,
            this.максимальнийПотікToolStripMenuItem,
            this.toolStripTextBox1,
            this.tbWeight});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 27);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WideSearchToolStripMenuItem,
            this.DeepSearchToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 23);
            this.toolStripMenuItem1.Text = "Елементарні алгоритми";
            // 
            // WideSearchToolStripMenuItem
            // 
            this.WideSearchToolStripMenuItem.Name = "WideSearchToolStripMenuItem";
            this.WideSearchToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.WideSearchToolStripMenuItem.Text = "Пошук в ширину";
            this.WideSearchToolStripMenuItem.Click += new System.EventHandler(this.WideSearchToolStripMenuItem_Click);
            // 
            // DeepSearchToolStripMenuItem
            // 
            this.DeepSearchToolStripMenuItem.Name = "DeepSearchToolStripMenuItem";
            this.DeepSearchToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.DeepSearchToolStripMenuItem.Text = "Пошук в глибину";
            this.DeepSearchToolStripMenuItem.Click += new System.EventHandler(this.DeepSearchToolStripMenuItem_Click);
            // 
            // мінімальніОстовніДереваToolStripMenuItem
            // 
            this.мінімальніОстовніДереваToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CruscalsAlgToolStripMenuItem,
            this.PrimsAlgToolStripMenuItem});
            this.мінімальніОстовніДереваToolStripMenuItem.Name = "мінімальніОстовніДереваToolStripMenuItem";
            this.мінімальніОстовніДереваToolStripMenuItem.Size = new System.Drawing.Size(165, 23);
            this.мінімальніОстовніДереваToolStripMenuItem.Text = "Мінімальні остовні дерева";
            // 
            // CruscalsAlgToolStripMenuItem
            // 
            this.CruscalsAlgToolStripMenuItem.Name = "CruscalsAlgToolStripMenuItem";
            this.CruscalsAlgToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.CruscalsAlgToolStripMenuItem.Text = "Алгоритм Крускала";
            this.CruscalsAlgToolStripMenuItem.Click += new System.EventHandler(this.CruscalsAlgToolStripMenuItem_Click);
            // 
            // PrimsAlgToolStripMenuItem
            // 
            this.PrimsAlgToolStripMenuItem.Name = "PrimsAlgToolStripMenuItem";
            this.PrimsAlgToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.PrimsAlgToolStripMenuItem.Text = "Алгоритм Пріма";
            this.PrimsAlgToolStripMenuItem.Click += new System.EventHandler(this.PrimsAlgToolStripMenuItem_Click);
            // 
            // найкоротшіШляхиToolStripMenuItem
            // 
            this.найкоротшіШляхиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Bell_Ford_algToolStripMenuItem,
            this.Floyd_Warsh_algToolStripMenuItem,
            this.DijkstrasAlgToolStripMenuItem,
            this.JohnsonsAlgToolStripMenuItem});
            this.найкоротшіШляхиToolStripMenuItem.Name = "найкоротшіШляхиToolStripMenuItem";
            this.найкоротшіШляхиToolStripMenuItem.Size = new System.Drawing.Size(126, 23);
            this.найкоротшіШляхиToolStripMenuItem.Text = "Найкоротші шляхи";
            // 
            // Bell_Ford_algToolStripMenuItem
            // 
            this.Bell_Ford_algToolStripMenuItem.Name = "Bell_Ford_algToolStripMenuItem";
            this.Bell_Ford_algToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.Bell_Ford_algToolStripMenuItem.Text = "Алгоритм Беллмана-Форда";
            this.Bell_Ford_algToolStripMenuItem.Click += new System.EventHandler(this.Bell_Ford_algToolStripMenuItem_Click);
            // 
            // Floyd_Warsh_algToolStripMenuItem
            // 
            this.Floyd_Warsh_algToolStripMenuItem.Name = "Floyd_Warsh_algToolStripMenuItem";
            this.Floyd_Warsh_algToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.Floyd_Warsh_algToolStripMenuItem.Text = "Алгоритм Флойда-Варшала";
            this.Floyd_Warsh_algToolStripMenuItem.Click += new System.EventHandler(this.Floyd_Warsh_algToolStripMenuItem_Click);
            // 
            // DijkstrasAlgToolStripMenuItem
            // 
            this.DijkstrasAlgToolStripMenuItem.Name = "DijkstrasAlgToolStripMenuItem";
            this.DijkstrasAlgToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.DijkstrasAlgToolStripMenuItem.Text = "Алгоритм Дейкстри";
            this.DijkstrasAlgToolStripMenuItem.Click += new System.EventHandler(this.DijkstrasAlgToolStripMenuItem_Click);
            // 
            // JohnsonsAlgToolStripMenuItem
            // 
            this.JohnsonsAlgToolStripMenuItem.Name = "JohnsonsAlgToolStripMenuItem";
            this.JohnsonsAlgToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.JohnsonsAlgToolStripMenuItem.Text = "Алгоритм Джонсона";
            // 
            // максимальнийПотікToolStripMenuItem
            // 
            this.максимальнийПотікToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ford_Falks_AlgToolStripMenuItem,
            this.Edm_Carp_AlgToolStripMenuItem});
            this.максимальнийПотікToolStripMenuItem.Name = "максимальнийПотікToolStripMenuItem";
            this.максимальнийПотікToolStripMenuItem.Size = new System.Drawing.Size(135, 23);
            this.максимальнийПотікToolStripMenuItem.Text = "Максимальний потік";
            // 
            // Ford_Falks_AlgToolStripMenuItem
            // 
            this.Ford_Falks_AlgToolStripMenuItem.Name = "Ford_Falks_AlgToolStripMenuItem";
            this.Ford_Falks_AlgToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.Ford_Falks_AlgToolStripMenuItem.Text = "Алгоритм Форда-Фалкерсона";
            // 
            // Edm_Carp_AlgToolStripMenuItem
            // 
            this.Edm_Carp_AlgToolStripMenuItem.Name = "Edm_Carp_AlgToolStripMenuItem";
            this.Edm_Carp_AlgToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.Edm_Carp_AlgToolStripMenuItem.Text = "Алгоритм Едмондса-Карпа";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(70, 23);
            this.toolStripTextBox1.Text = "Вага ребра:";
            // 
            // tbWeight
            // 
            this.tbWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(100, 23);
            this.tbWeight.TextChanged += new System.EventHandler(this.tbWeight_TextChanged);
            // 
            // bHclear
            // 
            this.bHclear.Location = new System.Drawing.Point(358, 527);
            this.bHclear.Name = "bHclear";
            this.bHclear.Size = new System.Drawing.Size(126, 23);
            this.bHclear.TabIndex = 8;
            this.bHclear.Text = "Очистити виділення";
            this.bHclear.UseVisualStyleBackColor = true;
            this.bHclear.Click += new System.EventHandler(this.bHclear_Click);
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.bHclear);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.graphics);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main_form";
            this.Text = "Графові алгоритми";
            this.Shown += new System.EventHandler(this.Main_form_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl graphics;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Timer renderTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem WideSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeepSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мінімальніОстовніДереваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CruscalsAlgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrimsAlgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem найкоротшіШляхиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Bell_Ford_algToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Floyd_Warsh_algToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DijkstrasAlgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JohnsonsAlgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem максимальнийПотікToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Ford_Falks_AlgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Edm_Carp_AlgToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox tbWeight;
        private System.Windows.Forms.Button bHclear;
    }
}

