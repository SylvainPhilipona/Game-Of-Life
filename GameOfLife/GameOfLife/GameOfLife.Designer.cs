namespace GameOfLife
{
    partial class GameOfLife
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panContainer = new System.Windows.Forms.Panel();
            this.btnStartAndStop = new System.Windows.Forms.Button();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.numSize = new System.Windows.Forms.NumericUpDown();
            this.lblGridSize = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRandomGrid = new System.Windows.Forms.Button();
            this.btnLastGeneration = new System.Windows.Forms.Button();
            this.btnSingleGeneration = new System.Windows.Forms.Button();
            this.lblStats = new System.Windows.Forms.Label();
            this.pbGridGeneration = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panContainer
            // 
            this.panContainer.Location = new System.Drawing.Point(16, 15);
            this.panContainer.Margin = new System.Windows.Forms.Padding(4);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(667, 615);
            this.panContainer.TabIndex = 0;
            // 
            // btnStartAndStop
            // 
            this.btnStartAndStop.Location = new System.Drawing.Point(691, 15);
            this.btnStartAndStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartAndStop.Name = "btnStartAndStop";
            this.btnStartAndStop.Size = new System.Drawing.Size(333, 62);
            this.btnStartAndStop.TabIndex = 1;
            this.btnStartAndStop.Text = "Start";
            this.btnStartAndStop.UseVisualStyleBackColor = true;
            this.btnStartAndStop.Click += new System.EventHandler(this.btnStartAndStop_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.LargeChange = 50;
            this.tbSpeed.Location = new System.Drawing.Point(691, 362);
            this.tbSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.tbSpeed.Maximum = 250;
            this.tbSpeed.Minimum = 20;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(333, 56);
            this.tbSpeed.SmallChange = 20;
            this.tbSpeed.TabIndex = 2;
            this.tbSpeed.TickFrequency = 50;
            this.tbSpeed.Value = 20;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // lblSpeed
            // 
            this.lblSpeed.Location = new System.Drawing.Point(691, 400);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(333, 18);
            this.lblSpeed.TabIndex = 3;
            this.lblSpeed.Text = "Speed : xxms";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numSize
            // 
            this.numSize.Location = new System.Drawing.Point(694, 437);
            this.numSize.Margin = new System.Windows.Forms.Padding(4);
            this.numSize.Name = "numSize";
            this.numSize.Size = new System.Drawing.Size(330, 22);
            this.numSize.TabIndex = 4;
            this.numSize.ValueChanged += new System.EventHandler(this.NumSize_ValueChanged);
            // 
            // lblGridSize
            // 
            this.lblGridSize.Location = new System.Drawing.Point(688, 463);
            this.lblGridSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGridSize.Name = "lblGridSize";
            this.lblGridSize.Size = new System.Drawing.Size(336, 21);
            this.lblGridSize.TabIndex = 5;
            this.lblGridSize.Text = "Taille de la grille : xx";
            this.lblGridSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(691, 290);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(333, 62);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnRandomGrid
            // 
            this.btnRandomGrid.Location = new System.Drawing.Point(691, 222);
            this.btnRandomGrid.Margin = new System.Windows.Forms.Padding(4);
            this.btnRandomGrid.Name = "btnRandomGrid";
            this.btnRandomGrid.Size = new System.Drawing.Size(333, 62);
            this.btnRandomGrid.TabIndex = 7;
            this.btnRandomGrid.Text = "Random";
            this.btnRandomGrid.UseVisualStyleBackColor = true;
            this.btnRandomGrid.Click += new System.EventHandler(this.BtnRandomGrid_Click);
            // 
            // btnLastGeneration
            // 
            this.btnLastGeneration.Location = new System.Drawing.Point(691, 153);
            this.btnLastGeneration.Margin = new System.Windows.Forms.Padding(4);
            this.btnLastGeneration.Name = "btnLastGeneration";
            this.btnLastGeneration.Size = new System.Drawing.Size(333, 62);
            this.btnLastGeneration.TabIndex = 8;
            this.btnLastGeneration.Text = "Back";
            this.btnLastGeneration.UseVisualStyleBackColor = true;
            this.btnLastGeneration.Click += new System.EventHandler(this.BtnLastGeneration_Click);
            // 
            // btnSingleGeneration
            // 
            this.btnSingleGeneration.Location = new System.Drawing.Point(691, 84);
            this.btnSingleGeneration.Margin = new System.Windows.Forms.Padding(4);
            this.btnSingleGeneration.Name = "btnSingleGeneration";
            this.btnSingleGeneration.Size = new System.Drawing.Size(333, 62);
            this.btnSingleGeneration.TabIndex = 9;
            this.btnSingleGeneration.Text = "1 generation";
            this.btnSingleGeneration.UseVisualStyleBackColor = true;
            this.btnSingleGeneration.Click += new System.EventHandler(this.BtnSingleGeneration_Click);
            // 
            // lblStats
            // 
            this.lblStats.Location = new System.Drawing.Point(694, 493);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(325, 55);
            this.lblStats.TabIndex = 10;
            this.lblStats.Text = "Nombre de générations : xx\r\nNombre de cellules vivantes : xx\r\nNombre de cellules " +
    "mortes : xx\r\n";
            this.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbGridGeneration
            // 
            this.pbGridGeneration.Location = new System.Drawing.Point(697, 591);
            this.pbGridGeneration.Name = "pbGridGeneration";
            this.pbGridGeneration.Size = new System.Drawing.Size(322, 39);
            this.pbGridGeneration.TabIndex = 11;
            // 
            // GameOfLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 692);
            this.Controls.Add(this.pbGridGeneration);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnSingleGeneration);
            this.Controls.Add(this.btnLastGeneration);
            this.Controls.Add(this.btnRandomGrid);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblGridSize);
            this.Controls.Add(this.numSize);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.btnStartAndStop);
            this.Controls.Add(this.panContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GameOfLife";
            this.Text = "Game of life";
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panContainer;
        private System.Windows.Forms.Button btnStartAndStop;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.Label lblGridSize;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRandomGrid;
        private System.Windows.Forms.Button btnLastGeneration;
        private System.Windows.Forms.Button btnSingleGeneration;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.ProgressBar pbGridGeneration;
    }
}

