﻿namespace ProjectWork
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
            this.pathField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.browse = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.getEmails = new System.Windows.Forms.Button();
            this.groupNumberBox = new System.Windows.Forms.ComboBox();
            this.emailsBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // pathField
            // 
            this.pathField.Location = new System.Drawing.Point(116, 33);
            this.pathField.Name = "pathField";
            this.pathField.Size = new System.Drawing.Size(511, 22);
            this.pathField.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Group Number:";
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(648, 33);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(96, 39);
            this.browse.TabIndex = 3;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(17, 85);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(164, 62);
            this.load.TabIndex = 4;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // getEmails
            // 
            this.getEmails.Location = new System.Drawing.Point(17, 234);
            this.getEmails.Name = "getEmails";
            this.getEmails.Size = new System.Drawing.Size(164, 62);
            this.getEmails.TabIndex = 5;
            this.getEmails.Text = "Get Emails";
            this.getEmails.UseVisualStyleBackColor = true;
            this.getEmails.Click += new System.EventHandler(this.getEmails_Click);
            // 
            // groupNumberBox
            // 
            this.groupNumberBox.FormattingEnabled = true;
            this.groupNumberBox.Location = new System.Drawing.Point(126, 180);
            this.groupNumberBox.Name = "groupNumberBox";
            this.groupNumberBox.Size = new System.Drawing.Size(133, 24);
            this.groupNumberBox.TabIndex = 6;
            // 
            // emailsBox
            // 
            this.emailsBox.FormattingEnabled = true;
            this.emailsBox.ItemHeight = 16;
            this.emailsBox.Location = new System.Drawing.Point(453, 180);
            this.emailsBox.Name = "emailsBox";
            this.emailsBox.Size = new System.Drawing.Size(278, 116);
            this.emailsBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(765, 337);
            this.Controls.Add(this.emailsBox);
            this.Controls.Add(this.groupNumberBox);
            this.Controls.Add(this.getEmails);
            this.Controls.Add(this.load);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathField);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button getEmails;
        private System.Windows.Forms.ComboBox groupNumberBox;
        private System.Windows.Forms.ListBox emailsBox;
    }
}

