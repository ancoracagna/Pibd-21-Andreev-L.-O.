namespace lab01
{
    partial class FormCar
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
            this.create_button = new System.Windows.Forms.Button();
            this.up_btn = new System.Windows.Forms.Button();
            this.down_btn = new System.Windows.Forms.Button();
            this.left_btn = new System.Windows.Forms.Button();
            this.right_btn = new System.Windows.Forms.Button();
            this.pictureBoxCar = new System.Windows.Forms.PictureBox();
            this.GruzCreate_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCar)).BeginInit();
            this.SuspendLayout();
            // 
            // create_button
            // 
            this.create_button.Location = new System.Drawing.Point(27, 21);
            this.create_button.Name = "create_button";
            this.create_button.Size = new System.Drawing.Size(90, 30);
            this.create_button.TabIndex = 0;
            this.create_button.Text = "Создать";
            this.create_button.UseVisualStyleBackColor = true;
            this.create_button.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // up_btn
            // 
            this.up_btn.Location = new System.Drawing.Point(685, 350);
            this.up_btn.Name = "up_btn";
            this.up_btn.Size = new System.Drawing.Size(49, 30);
            this.up_btn.TabIndex = 1;
            this.up_btn.Text = "↑";
            this.up_btn.UseVisualStyleBackColor = true;
            // 
            // down_btn
            // 
            this.down_btn.Location = new System.Drawing.Point(685, 386);
            this.down_btn.Name = "down_btn";
            this.down_btn.Size = new System.Drawing.Size(49, 30);
            this.down_btn.TabIndex = 2;
            this.down_btn.Text = "↓";
            this.down_btn.UseVisualStyleBackColor = true;
            // 
            // left_btn
            // 
            this.left_btn.Location = new System.Drawing.Point(630, 386);
            this.left_btn.Name = "left_btn";
            this.left_btn.Size = new System.Drawing.Size(49, 30);
            this.left_btn.TabIndex = 3;
            this.left_btn.Text = "←";
            this.left_btn.UseVisualStyleBackColor = true;
            // 
            // right_btn
            // 
            this.right_btn.Location = new System.Drawing.Point(740, 386);
            this.right_btn.Name = "right_btn";
            this.right_btn.Size = new System.Drawing.Size(49, 30);
            this.right_btn.TabIndex = 4;
            this.right_btn.Text = "→";
            this.right_btn.UseVisualStyleBackColor = true;
            // 
            // pictureBoxCar
            // 
            this.pictureBoxCar.Location = new System.Drawing.Point(1, 1);
            this.pictureBoxCar.Name = "pictureBoxCar";
            this.pictureBoxCar.Size = new System.Drawing.Size(799, 448);
            this.pictureBoxCar.TabIndex = 5;
            this.pictureBoxCar.TabStop = false;
            // 
            // GruzCreate_Button
            // 
            this.GruzCreate_Button.Location = new System.Drawing.Point(152, 21);
            this.GruzCreate_Button.Name = "GruzCreate_Button";
            this.GruzCreate_Button.Size = new System.Drawing.Size(97, 30);
            this.GruzCreate_Button.TabIndex = 6;
            this.GruzCreate_Button.Text = "Создать";
            this.GruzCreate_Button.UseVisualStyleBackColor = true;
            this.GruzCreate_Button.Click += new System.EventHandler(this.GruzCreate_Button_Click);
            // 
            // FormCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GruzCreate_Button);
            this.Controls.Add(this.right_btn);
            this.Controls.Add(this.left_btn);
            this.Controls.Add(this.down_btn);
            this.Controls.Add(this.up_btn);
            this.Controls.Add(this.create_button);
            this.Controls.Add(this.pictureBoxCar);
            this.Name = "FormCar";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button create_button;
        private System.Windows.Forms.Button up_btn;
        private System.Windows.Forms.Button down_btn;
        private System.Windows.Forms.Button left_btn;
        private System.Windows.Forms.Button right_btn;
        private System.Windows.Forms.PictureBox pictureBoxCar;
        private System.Windows.Forms.Button GruzCreate_Button;
    }
}

