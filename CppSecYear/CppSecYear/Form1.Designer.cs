namespace CppSecYear
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelXTurn = new System.Windows.Forms.Label();
            this.labelOTurn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1201, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 618);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Старт";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // labelXTurn
            // 
            this.labelXTurn.AutoSize = true;
            this.labelXTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 44F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelXTurn.Location = new System.Drawing.Point(294, 615);
            this.labelXTurn.Name = "labelXTurn";
            this.labelXTurn.Size = new System.Drawing.Size(69, 67);
            this.labelXTurn.TabIndex = 2;
            this.labelXTurn.Text = "X";
            // 
            // labelOTurn
            // 
            this.labelOTurn.AutoSize = true;
            this.labelOTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 44F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOTurn.Location = new System.Drawing.Point(369, 615);
            this.labelOTurn.Name = "labelOTurn";
            this.labelOTurn.Size = new System.Drawing.Size(76, 67);
            this.labelOTurn.TabIndex = 3;
            this.labelOTurn.Text = "O";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 676);
            this.Controls.Add(this.labelOTurn);
            this.Controls.Add(this.labelXTurn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelXTurn;
        private System.Windows.Forms.Label labelOTurn;
    }
}

