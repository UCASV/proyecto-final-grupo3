
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.clmDUI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCurrentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProgressbar = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitingCitizen)).BeginInit();
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
            this.pictureBox1.Size = new System.Drawing.Size(154, 127);
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
            this.panel1.Size = new System.Drawing.Size(805, 144);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(166, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 125);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(176, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proceso de vacunacion";
            // 
            // dgvWaitingCitizen
            // 
            this.dgvWaitingCitizen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaitingCitizen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDUI,
            this.clmNombre,
            this.clmCurrentTime,
            this.clmProgressbar});
            this.dgvWaitingCitizen.Location = new System.Drawing.Point(24, 239);
            this.dgvWaitingCitizen.Name = "dgvWaitingCitizen";
            this.dgvWaitingCitizen.RowTemplate.Height = 25;
            this.dgvWaitingCitizen.Size = new System.Drawing.Size(754, 446);
            this.dgvWaitingCitizen.TabIndex = 3;
            // 
            // waitingTimer
            // 
            this.waitingTimer.Interval = 1000;
            this.waitingTimer.Tick += new System.EventHandler(this.waitingTimer_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(90, 173);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(124, 46);
            this.progressBar1.TabIndex = 4;
            // 
            // clmDUI
            // 
            this.clmDUI.HeaderText = "DUI";
            this.clmDUI.Name = "clmDUI";
            // 
            // clmNombre
            // 
            this.clmNombre.HeaderText = "Nombre";
            this.clmNombre.Name = "clmNombre";
            // 
            // clmCurrentTime
            // 
            this.clmCurrentTime.HeaderText = "Tiempo transcurrido";
            this.clmCurrentTime.Name = "clmCurrentTime";
            // 
            // clmProgressbar
            // 
            this.clmProgressbar.HeaderText = "Progreso";
            this.clmProgressbar.Name = "clmProgressbar";
            // 
            // frmVaccinationProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(89)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(805, 734);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dgvWaitingCitizen);
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDUI;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurrentTime;
        private System.Windows.Forms.DataGridViewImageColumn clmProgressbar;
    }
}