
namespace ProyectoVacunacionCovid.View
{
    partial class frmVaccinationProcess
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
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvWaitingCitizen = new System.Windows.Forms.DataGridView();
            this.waitingTimer = new System.Windows.Forms.Timer(this.components);
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvWaitingQueue = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTimer = new System.Windows.Forms.Label();
            this.panelAnimation = new System.Windows.Forms.Panel();
            this.btnObservation = new System.Windows.Forms.Button();
            this.btnWaitingQueue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitingCitizen)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitingQueue)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::ProyectoVacunacionCovid.Properties.Resources._007__close;
            this.btnExit.Location = new System.Drawing.Point(756, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(37, 34);
            this.btnExit.TabIndex = 0;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProyectoVacunacionCovid.Properties.Resources.logo_covid;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(54)))), ((int)(((byte)(164)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 107);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(160, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 83);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(170, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proceso de vacunacion";
            // 
            // dgvWaitingCitizen
            // 
            this.dgvWaitingCitizen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvWaitingCitizen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWaitingCitizen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaitingCitizen.Location = new System.Drawing.Point(14, 39);
            this.dgvWaitingCitizen.MultiSelect = false;
            this.dgvWaitingCitizen.Name = "dgvWaitingCitizen";
            this.dgvWaitingCitizen.ReadOnly = true;
            this.dgvWaitingCitizen.RowTemplate.Height = 25;
            this.dgvWaitingCitizen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWaitingCitizen.Size = new System.Drawing.Size(231, 460);
            this.dgvWaitingCitizen.TabIndex = 3;
            this.dgvWaitingCitizen.TabStop = false;
            this.dgvWaitingCitizen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWaitingCitizen_CellContentClick);
            // 
            // waitingTimer
            // 
            this.waitingTimer.Interval = 1000;
            this.waitingTimer.Tick += new System.EventHandler(this.waitingTimer_Tick);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Location = new System.Drawing.Point(12, 160);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(787, 543);
            this.tabMain.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvWaitingQueue);
            this.tabPage1.Controls.Add(this.dgvWaitingCitizen);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(779, 515);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvWaitingQueue
            // 
            this.dgvWaitingQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvWaitingQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWaitingQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaitingQueue.Location = new System.Drawing.Point(323, 39);
            this.dgvWaitingQueue.MultiSelect = false;
            this.dgvWaitingQueue.Name = "dgvWaitingQueue";
            this.dgvWaitingQueue.RowTemplate.Height = 25;
            this.dgvWaitingQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWaitingQueue.Size = new System.Drawing.Size(437, 460);
            this.dgvWaitingQueue.TabIndex = 4;
            this.dgvWaitingQueue.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(779, 515);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTimer);
            this.panel3.Controls.Add(this.panelAnimation);
            this.panel3.Controls.Add(this.btnObservation);
            this.panel3.Controls.Add(this.btnWaitingQueue);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(805, 47);
            this.panel3.TabIndex = 6;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimer.ForeColor = System.Drawing.Color.White;
            this.lblTimer.Location = new System.Drawing.Point(636, 8);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(117, 28);
            this.lblTimer.TabIndex = 4;
            this.lblTimer.Text = "00:00 am";
            // 
            // panelAnimation
            // 
            this.panelAnimation.BackColor = System.Drawing.Color.AliceBlue;
            this.panelAnimation.Location = new System.Drawing.Point(13, 41);
            this.panelAnimation.Name = "panelAnimation";
            this.panelAnimation.Size = new System.Drawing.Size(197, 6);
            this.panelAnimation.TabIndex = 2;
            // 
            // btnObservation
            // 
            this.btnObservation.BackColor = System.Drawing.Color.Transparent;
            this.btnObservation.FlatAppearance.BorderSize = 0;
            this.btnObservation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnObservation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnObservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObservation.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnObservation.ForeColor = System.Drawing.Color.White;
            this.btnObservation.Location = new System.Drawing.Point(209, 0);
            this.btnObservation.Name = "btnObservation";
            this.btnObservation.Size = new System.Drawing.Size(194, 47);
            this.btnObservation.TabIndex = 1;
            this.btnObservation.Text = "Observacion";
            this.btnObservation.UseVisualStyleBackColor = false;
            this.btnObservation.Click += new System.EventHandler(this.btnObservation_Click);
            // 
            // btnWaitingQueue
            // 
            this.btnWaitingQueue.BackColor = System.Drawing.Color.Transparent;
            this.btnWaitingQueue.FlatAppearance.BorderSize = 0;
            this.btnWaitingQueue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnWaitingQueue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnWaitingQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaitingQueue.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWaitingQueue.ForeColor = System.Drawing.Color.White;
            this.btnWaitingQueue.Location = new System.Drawing.Point(16, 0);
            this.btnWaitingQueue.Name = "btnWaitingQueue";
            this.btnWaitingQueue.Size = new System.Drawing.Size(194, 47);
            this.btnWaitingQueue.TabIndex = 0;
            this.btnWaitingQueue.Text = "Lista de espera";
            this.btnWaitingQueue.UseVisualStyleBackColor = false;
            this.btnWaitingQueue.Click += new System.EventHandler(this.btnWaitingQueue_Click);
            // 
            // frmVaccinationProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(89)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(805, 734);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVaccinationProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proceso de Vacunacion";
            this.Load += new System.EventHandler(this.frmVaccinationProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitingCitizen)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitingQueue)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvWaitingCitizen;
        private System.Windows.Forms.Timer waitingTimer;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnWaitingQueue;
        private System.Windows.Forms.Button btnObservation;
        private System.Windows.Forms.Panel panelAnimation;
        private System.Windows.Forms.DataGridView dgvWaitingQueue;
        private System.Windows.Forms.Label lblTimer;
    }
}