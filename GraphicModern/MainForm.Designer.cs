namespace GraphicModern
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AddLine = new System.Windows.Forms.Button();
            this.AddTriangle = new System.Windows.Forms.Button();
            this.AddRectangle = new System.Windows.Forms.Button();
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.RemoveShape = new System.Windows.Forms.Button();
            this.RadioMirrorNone = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.RadioMirrorOX = new System.Windows.Forms.RadioButton();
            this.RadioMirrorOY = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RadioMirror0 = new System.Windows.Forms.RadioButton();
            this.ExecuteOperations = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.TransferY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TransferX = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.RotateAngle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ScaleOY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ScaleOX = new System.Windows.Forms.TextBox();
            this.LocalCheckBox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ShowAnimationButton = new System.Windows.Forms.Button();
            this.RemoveFrameButton = new System.Windows.Forms.Button();
            this.FramesCountLabel = new System.Windows.Forms.Label();
            this.AddFrameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nextFrameButton = new System.Windows.Forms.Button();
            this.prevFrameButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddLine
            // 
            this.AddLine.Location = new System.Drawing.Point(297, 286);
            this.AddLine.Name = "AddLine";
            this.AddLine.Size = new System.Drawing.Size(64, 23);
            this.AddLine.TabIndex = 1;
            this.AddLine.Text = "Line";
            this.AddLine.UseVisualStyleBackColor = true;
            this.AddLine.Click += new System.EventHandler(this.AddLine_Click);
            // 
            // AddTriangle
            // 
            this.AddTriangle.Location = new System.Drawing.Point(297, 344);
            this.AddTriangle.Name = "AddTriangle";
            this.AddTriangle.Size = new System.Drawing.Size(64, 23);
            this.AddTriangle.TabIndex = 2;
            this.AddTriangle.Text = "Triangle";
            this.AddTriangle.UseVisualStyleBackColor = true;
            this.AddTriangle.Click += new System.EventHandler(this.AddTriangle_Click);
            // 
            // AddRectangle
            // 
            this.AddRectangle.Location = new System.Drawing.Point(297, 315);
            this.AddRectangle.Name = "AddRectangle";
            this.AddRectangle.Size = new System.Drawing.Size(64, 23);
            this.AddRectangle.TabIndex = 3;
            this.AddRectangle.Text = "Rectangle";
            this.AddRectangle.UseVisualStyleBackColor = true;
            this.AddRectangle.Click += new System.EventHandler(this.AddRectangle_Click);
            // 
            // DrawPanel
            // 
            this.DrawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawPanel.BackColor = System.Drawing.Color.White;
            this.DrawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawPanel.Location = new System.Drawing.Point(12, 12);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(418, 272);
            this.DrawPanel.TabIndex = 0;
            this.DrawPanel.TabStop = false;
            this.DrawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPanel_Paint);
            this.DrawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseDown);
            this.DrawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseMove);
            this.DrawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseUp);
            // 
            // RemoveShape
            // 
            this.RemoveShape.Location = new System.Drawing.Point(367, 286);
            this.RemoveShape.Name = "RemoveShape";
            this.RemoveShape.Size = new System.Drawing.Size(63, 23);
            this.RemoveShape.TabIndex = 4;
            this.RemoveShape.Text = "Delete";
            this.RemoveShape.UseVisualStyleBackColor = true;
            this.RemoveShape.Click += new System.EventHandler(this.RemoveShape_Click);
            // 
            // RadioMirrorNone
            // 
            this.RadioMirrorNone.AutoSize = true;
            this.RadioMirrorNone.Checked = true;
            this.RadioMirrorNone.Location = new System.Drawing.Point(6, 18);
            this.RadioMirrorNone.Name = "RadioMirrorNone";
            this.RadioMirrorNone.Size = new System.Drawing.Size(39, 17);
            this.RadioMirrorNone.TabIndex = 10;
            this.RadioMirrorNone.TabStop = true;
            this.RadioMirrorNone.Text = "No";
            this.RadioMirrorNone.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mirror";
            // 
            // RadioMirrorOX
            // 
            this.RadioMirrorOX.AutoSize = true;
            this.RadioMirrorOX.Location = new System.Drawing.Point(6, 36);
            this.RadioMirrorOX.Name = "RadioMirrorOX";
            this.RadioMirrorOX.Size = new System.Drawing.Size(40, 17);
            this.RadioMirrorOX.TabIndex = 12;
            this.RadioMirrorOX.Text = "OX";
            this.RadioMirrorOX.UseVisualStyleBackColor = true;
            // 
            // RadioMirrorOY
            // 
            this.RadioMirrorOY.AutoSize = true;
            this.RadioMirrorOY.Location = new System.Drawing.Point(6, 54);
            this.RadioMirrorOY.Name = "RadioMirrorOY";
            this.RadioMirrorOY.Size = new System.Drawing.Size(40, 17);
            this.RadioMirrorOY.TabIndex = 13;
            this.RadioMirrorOY.Text = "OY";
            this.RadioMirrorOY.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Scale";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.RadioMirror0);
            this.panel1.Controls.Add(this.ExecuteOperations);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.TransferY);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.TransferX);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.RotateAngle);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ScaleOY);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ScaleOX);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.RadioMirrorOY);
            this.panel1.Controls.Add(this.RadioMirrorNone);
            this.panel1.Controls.Add(this.RadioMirrorOX);
            this.panel1.Location = new System.Drawing.Point(444, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 303);
            this.panel1.TabIndex = 15;
            // 
            // RadioMirror0
            // 
            this.RadioMirror0.AutoSize = true;
            this.RadioMirror0.Location = new System.Drawing.Point(6, 72);
            this.RadioMirror0.Name = "RadioMirror0";
            this.RadioMirror0.Size = new System.Drawing.Size(83, 17);
            this.RadioMirror0.TabIndex = 28;
            this.RadioMirror0.Text = "нач. коорд\\";
            this.RadioMirror0.UseVisualStyleBackColor = true;
            // 
            // ExecuteOperations
            // 
            this.ExecuteOperations.Location = new System.Drawing.Point(18, 269);
            this.ExecuteOperations.Name = "ExecuteOperations";
            this.ExecuteOperations.Size = new System.Drawing.Size(75, 23);
            this.ExecuteOperations.TabIndex = 27;
            this.ExecuteOperations.Text = "Done";
            this.ExecuteOperations.UseVisualStyleBackColor = true;
            this.ExecuteOperations.Click += new System.EventHandler(this.ExecuteOperations_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Y";
            // 
            // TransferY
            // 
            this.TransferY.Location = new System.Drawing.Point(50, 238);
            this.TransferY.Name = "TransferY";
            this.TransferY.Size = new System.Drawing.Size(45, 20);
            this.TransferY.TabIndex = 25;
            this.TransferY.Text = "0";
            this.TransferY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransferY_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "X";
            // 
            // TransferX
            // 
            this.TransferX.Location = new System.Drawing.Point(50, 212);
            this.TransferX.Name = "TransferX";
            this.TransferX.Size = new System.Drawing.Size(45, 20);
            this.TransferX.TabIndex = 23;
            this.TransferX.Text = "0";
            this.TransferX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransferX_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 196);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Transform";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Angle";
            // 
            // RotateAngle
            // 
            this.RotateAngle.Location = new System.Drawing.Point(50, 173);
            this.RotateAngle.Name = "RotateAngle";
            this.RotateAngle.Size = new System.Drawing.Size(45, 20);
            this.RotateAngle.TabIndex = 20;
            this.RotateAngle.Text = "0";
            this.RotateAngle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RotateAngle_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Rotate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "OY";
            // 
            // ScaleOY
            // 
            this.ScaleOY.Location = new System.Drawing.Point(50, 134);
            this.ScaleOY.Name = "ScaleOY";
            this.ScaleOY.Size = new System.Drawing.Size(45, 20);
            this.ScaleOY.TabIndex = 17;
            this.ScaleOY.Text = "1";
            this.ScaleOY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScaleOY_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "OX";
            // 
            // ScaleOX
            // 
            this.ScaleOX.Location = new System.Drawing.Point(50, 108);
            this.ScaleOX.Name = "ScaleOX";
            this.ScaleOX.Size = new System.Drawing.Size(45, 20);
            this.ScaleOX.TabIndex = 15;
            this.ScaleOX.Text = "1";
            this.ScaleOX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScaleOX_KeyPress);
            // 
            // LocalCheckBox
            // 
            this.LocalCheckBox.AutoSize = true;
            this.LocalCheckBox.Enabled = false;
            this.LocalCheckBox.Location = new System.Drawing.Point(454, 12);
            this.LocalCheckBox.Name = "LocalCheckBox";
            this.LocalCheckBox.Size = new System.Drawing.Size(52, 17);
            this.LocalCheckBox.TabIndex = 16;
            this.LocalCheckBox.Text = "Local";
            this.LocalCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ShowAnimationButton);
            this.panel2.Controls.Add(this.RemoveFrameButton);
            this.panel2.Controls.Add(this.FramesCountLabel);
            this.panel2.Controls.Add(this.AddFrameButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nextFrameButton);
            this.panel2.Controls.Add(this.prevFrameButton);
            this.panel2.Location = new System.Drawing.Point(149, 286);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(113, 60);
            this.panel2.TabIndex = 17;
            // 
            // ShowAnimationButton
            // 
            this.ShowAnimationButton.Image = ((System.Drawing.Image)(resources.GetObject("ShowAnimationButton.Image")));
            this.ShowAnimationButton.Location = new System.Drawing.Point(64, 3);
            this.ShowAnimationButton.Name = "ShowAnimationButton";
            this.ShowAnimationButton.Size = new System.Drawing.Size(22, 22);
            this.ShowAnimationButton.TabIndex = 6;
            this.ShowAnimationButton.UseVisualStyleBackColor = true;
            this.ShowAnimationButton.Click += new System.EventHandler(this.ShowAnimationButton_Click);
            // 
            // RemoveFrameButton
            // 
            this.RemoveFrameButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveFrameButton.Image")));
            this.RemoveFrameButton.Location = new System.Drawing.Point(88, 3);
            this.RemoveFrameButton.Name = "RemoveFrameButton";
            this.RemoveFrameButton.Size = new System.Drawing.Size(22, 22);
            this.RemoveFrameButton.TabIndex = 5;
            this.RemoveFrameButton.UseVisualStyleBackColor = true;
            this.RemoveFrameButton.Click += new System.EventHandler(this.RemoveFrameButton_Click);
            // 
            // FramesCountLabel
            // 
            this.FramesCountLabel.AutoSize = true;
            this.FramesCountLabel.Location = new System.Drawing.Point(38, 39);
            this.FramesCountLabel.Name = "FramesCountLabel";
            this.FramesCountLabel.Size = new System.Drawing.Size(24, 13);
            this.FramesCountLabel.TabIndex = 4;
            this.FramesCountLabel.Text = "1/1";
            // 
            // AddFrameButton
            // 
            this.AddFrameButton.Image = ((System.Drawing.Image)(resources.GetObject("AddFrameButton.Image")));
            this.AddFrameButton.Location = new System.Drawing.Point(42, 3);
            this.AddFrameButton.Name = "AddFrameButton";
            this.AddFrameButton.Size = new System.Drawing.Size(22, 22);
            this.AddFrameButton.TabIndex = 3;
            this.AddFrameButton.UseVisualStyleBackColor = true;
            this.AddFrameButton.Click += new System.EventHandler(this.AddFrameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кадры";
            // 
            // nextFrameButton
            // 
            this.nextFrameButton.Location = new System.Drawing.Point(88, 35);
            this.nextFrameButton.Name = "nextFrameButton";
            this.nextFrameButton.Size = new System.Drawing.Size(20, 20);
            this.nextFrameButton.TabIndex = 1;
            this.nextFrameButton.Text = ">";
            this.nextFrameButton.UseVisualStyleBackColor = true;
            this.nextFrameButton.Click += new System.EventHandler(this.nextFrameButton_Click);
            // 
            // prevFrameButton
            // 
            this.prevFrameButton.Location = new System.Drawing.Point(3, 35);
            this.prevFrameButton.Name = "prevFrameButton";
            this.prevFrameButton.Size = new System.Drawing.Size(20, 20);
            this.prevFrameButton.TabIndex = 0;
            this.prevFrameButton.Text = "<";
            this.prevFrameButton.UseVisualStyleBackColor = true;
            this.prevFrameButton.Click += new System.EventHandler(this.prevFrameButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(366, 315);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(64, 22);
            this.SaveButton.TabIndex = 18;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(367, 343);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(63, 22);
            this.OpenButton.TabIndex = 19;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 370);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LocalCheckBox);
            this.Controls.Add(this.RemoveShape);
            this.Controls.Add(this.DrawPanel);
            this.Controls.Add(this.AddRectangle);
            this.Controls.Add(this.AddTriangle);
            this.Controls.Add(this.AddLine);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddLine;
        private System.Windows.Forms.Button AddTriangle;
        private System.Windows.Forms.Button AddRectangle;
        private System.Windows.Forms.PictureBox DrawPanel;
        private System.Windows.Forms.Button RemoveShape;
        private System.Windows.Forms.RadioButton RadioMirrorNone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton RadioMirrorOX;
        private System.Windows.Forms.RadioButton RadioMirrorOY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ExecuteOperations;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TransferY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TransferX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox RotateAngle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ScaleOY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ScaleOX;
        private System.Windows.Forms.RadioButton RadioMirror0;
        private System.Windows.Forms.CheckBox LocalCheckBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nextFrameButton;
        private System.Windows.Forms.Button prevFrameButton;
        private System.Windows.Forms.Button AddFrameButton;
        private System.Windows.Forms.Label FramesCountLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button RemoveFrameButton;
        private System.Windows.Forms.Button ShowAnimationButton;
    }
}

