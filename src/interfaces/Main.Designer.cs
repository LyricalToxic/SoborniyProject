namespace SoborniyProject.src.interfaces
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.carModel = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trafficPage = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.greenColor = new System.Windows.Forms.TextBox();
            this.yellowColor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.currentLightTraffic = new System.Windows.Forms.ComboBox();
            this.nextColor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.redColor = new System.Windows.Forms.TextBox();
            this.addNewTraffic = new System.Windows.Forms.Button();
            this.currentColor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.distance = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.currentTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.carPage = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.deceleration = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.acceleration = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameCar = new System.Windows.Forms.TextBox();
            this.addCar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.trafficPage.SuspendLayout();
            this.carPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.trafficPage);
            this.tabControl1.Controls.Add(this.carPage);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1444, 679);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.carModel);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1436, 647);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(993, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 55;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // carModel
            // 
            this.carModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.carModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.carModel.Image = ((System.Drawing.Image)(resources.GetObject("carModel.Image")));
            this.carModel.Location = new System.Drawing.Point(0, 236);
            this.carModel.Name = "carModel";
            this.carModel.Size = new System.Drawing.Size(164, 62);
            this.carModel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carModel.TabIndex = 54;
            this.carModel.TabStop = false;
            this.carModel.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(45, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(311, 91);
            this.button1.TabIndex = 53;
            this.button1.Text = "Характеристика";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(434, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(318, 31);
            this.label7.TabIndex = 52;
            this.label7.Text = "Керівництво програмою";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(572, 376);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(311, 91);
            this.button3.TabIndex = 51;
            this.button3.Text = "Запуск програми\r\n";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 148);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1433, 157);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // trafficPage
            // 
            this.trafficPage.Controls.Add(this.label8);
            this.trafficPage.Controls.Add(this.greenColor);
            this.trafficPage.Controls.Add(this.yellowColor);
            this.trafficPage.Controls.Add(this.label1);
            this.trafficPage.Controls.Add(this.label9);
            this.trafficPage.Controls.Add(this.currentLightTraffic);
            this.trafficPage.Controls.Add(this.nextColor);
            this.trafficPage.Controls.Add(this.label10);
            this.trafficPage.Controls.Add(this.redColor);
            this.trafficPage.Controls.Add(this.addNewTraffic);
            this.trafficPage.Controls.Add(this.currentColor);
            this.trafficPage.Controls.Add(this.label11);
            this.trafficPage.Controls.Add(this.distance);
            this.trafficPage.Controls.Add(this.label12);
            this.trafficPage.Controls.Add(this.currentTime);
            this.trafficPage.Controls.Add(this.label13);
            this.trafficPage.Controls.Add(this.label14);
            this.trafficPage.Location = new System.Drawing.Point(4, 28);
            this.trafficPage.Name = "trafficPage";
            this.trafficPage.Padding = new System.Windows.Forms.Padding(3);
            this.trafficPage.Size = new System.Drawing.Size(1436, 647);
            this.trafficPage.TabIndex = 1;
            this.trafficPage.Text = "Light Traffic";
            this.trafficPage.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(670, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 23);
            this.label8.TabIndex = 44;
            this.label8.Text = "Час зеленого кольору";
            // 
            // greenColor
            // 
            this.greenColor.Location = new System.Drawing.Point(881, 324);
            this.greenColor.Name = "greenColor";
            this.greenColor.Size = new System.Drawing.Size(137, 26);
            this.greenColor.TabIndex = 43;
            // 
            // yellowColor
            // 
            this.yellowColor.Location = new System.Drawing.Point(881, 283);
            this.yellowColor.Name = "yellowColor";
            this.yellowColor.Size = new System.Drawing.Size(137, 26);
            this.yellowColor.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(670, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 23);
            this.label1.TabIndex = 41;
            this.label1.Text = "Час жовтого кольору";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(661, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 23);
            this.label9.TabIndex = 40;
            this.label9.Text = "Час червного кольору\r\n";
            // 
            // currentLightTraffic
            // 
            this.currentLightTraffic.FormattingEnabled = true;
            this.currentLightTraffic.Location = new System.Drawing.Point(541, 117);
            this.currentLightTraffic.Name = "currentLightTraffic";
            this.currentLightTraffic.Size = new System.Drawing.Size(269, 27);
            this.currentLightTraffic.TabIndex = 39;
            // 
            // nextColor
            // 
            this.nextColor.Location = new System.Drawing.Point(333, 340);
            this.nextColor.Name = "nextColor";
            this.nextColor.Size = new System.Drawing.Size(137, 26);
            this.nextColor.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(171, 340);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 23);
            this.label10.TabIndex = 37;
            this.label10.Text = "Наступний колір\r\n";
            // 
            // redColor
            // 
            this.redColor.Location = new System.Drawing.Point(881, 236);
            this.redColor.Name = "redColor";
            this.redColor.Size = new System.Drawing.Size(137, 26);
            this.redColor.TabIndex = 36;
            // 
            // addNewTraffic
            // 
            this.addNewTraffic.BackColor = System.Drawing.Color.White;
            this.addNewTraffic.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addNewTraffic.Location = new System.Drawing.Point(554, 516);
            this.addNewTraffic.Name = "addNewTraffic";
            this.addNewTraffic.Size = new System.Drawing.Size(289, 34);
            this.addNewTraffic.TabIndex = 35;
            this.addNewTraffic.Text = "Додати новий світлофор";
            this.addNewTraffic.UseVisualStyleBackColor = false;
            this.addNewTraffic.Click += new System.EventHandler(this.addNewTraffic_Click);
            // 
            // currentColor
            // 
            this.currentColor.Location = new System.Drawing.Point(333, 208);
            this.currentColor.Name = "currentColor";
            this.currentColor.Size = new System.Drawing.Size(137, 26);
            this.currentColor.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(23, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(304, 23);
            this.label11.TabIndex = 33;
            this.label11.Text = "Який колір на даний момент часу";
            // 
            // distance
            // 
            this.distance.Location = new System.Drawing.Point(333, 250);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(137, 26);
            this.distance.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(101, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(224, 23);
            this.label12.TabIndex = 31;
            this.label12.Text = "Відстань до  світлофора";
            // 
            // currentTime
            // 
            this.currentTime.Location = new System.Drawing.Point(331, 291);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(137, 26);
            this.currentTime.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(86, 288);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(239, 23);
            this.label13.TabIndex = 29;
            this.label13.Text = "Час роботи теперешнього";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(567, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(243, 26);
            this.label14.TabIndex = 28;
            this.label14.Text = "Вибирайте світлофор";
            // 
            // carPage
            // 
            this.carPage.Controls.Add(this.label5);
            this.carPage.Controls.Add(this.deceleration);
            this.carPage.Controls.Add(this.label4);
            this.carPage.Controls.Add(this.acceleration);
            this.carPage.Controls.Add(this.label3);
            this.carPage.Controls.Add(this.speed);
            this.carPage.Controls.Add(this.label2);
            this.carPage.Controls.Add(this.nameCar);
            this.carPage.Controls.Add(this.addCar);
            this.carPage.Location = new System.Drawing.Point(4, 28);
            this.carPage.Name = "carPage";
            this.carPage.Padding = new System.Windows.Forms.Padding(3);
            this.carPage.Size = new System.Drawing.Size(1436, 647);
            this.carPage.TabIndex = 2;
            this.carPage.Text = "Car";
            this.carPage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Гальмування";
            // 
            // deceleration
            // 
            this.deceleration.Location = new System.Drawing.Point(528, 257);
            this.deceleration.Name = "deceleration";
            this.deceleration.Size = new System.Drawing.Size(100, 26);
            this.deceleration.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Прискорення";
            // 
            // acceleration
            // 
            this.acceleration.Location = new System.Drawing.Point(216, 363);
            this.acceleration.Name = "acceleration";
            this.acceleration.Size = new System.Drawing.Size(100, 26);
            this.acceleration.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Швидкість";
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(216, 313);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(100, 26);
            this.speed.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Назва автомобіля";
            // 
            // nameCar
            // 
            this.nameCar.Location = new System.Drawing.Point(216, 261);
            this.nameCar.Name = "nameCar";
            this.nameCar.Size = new System.Drawing.Size(100, 26);
            this.nameCar.TabIndex = 1;
            // 
            // addCar
            // 
            this.addCar.Location = new System.Drawing.Point(121, 456);
            this.addCar.Name = "addCar";
            this.addCar.Size = new System.Drawing.Size(234, 62);
            this.addCar.TabIndex = 0;
            this.addCar.Text = "Додати автомобіль";
            this.addCar.UseVisualStyleBackColor = true;
            this.addCar.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 610);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "Main";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.trafficPage.ResumeLayout(false);
            this.trafficPage.PerformLayout();
            this.carPage.ResumeLayout(false);
            this.carPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox carModel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage trafficPage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox greenColor;
        private System.Windows.Forms.TextBox yellowColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox currentLightTraffic;
        private System.Windows.Forms.TextBox nextColor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox redColor;
        private System.Windows.Forms.Button addNewTraffic;
        private System.Windows.Forms.TextBox currentColor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox distance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox currentTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage carPage;
        private System.Windows.Forms.Button addCar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox deceleration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox acceleration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameCar;
        private System.Windows.Forms.Button button2;
    }
}