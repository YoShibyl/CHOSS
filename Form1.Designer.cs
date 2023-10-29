using System;

namespace CHOSS
{
    partial class CHOSS
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            browseButton = new Button();
            label2 = new Label();
            currentsongFileDialog = new OpenFileDialog();
            configSelectBox = new ComboBox();
            currentsongTxtPathBox = new TextBox();
            saveConfigButton = new Button();
            btnStartStop = new Button();
            githubLink = new LinkLabel();
            wsGroupBox = new GroupBox();
            label7 = new Label();
            portBox = new TextBox();
            passBox = new TextBox();
            label6 = new Label();
            ipBox = new TextBox();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            menuSceneBox = new TextBox();
            gameSceneBox = new TextBox();
            scenesGroupBox = new GroupBox();
            wsGroupBox.SuspendLayout();
            scenesGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(533, 38);
            label1.TabIndex = 0;
            label1.Text = "Clone Hero OBS Scene Switcher (CHOSS)";
            label1.Click += label1_Click;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(16, 144);
            browseButton.Margin = new Padding(4);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(272, 36);
            browseButton.TabIndex = 1;
            browseButton.Text = "Browse for currentsong.txt";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(13, 105);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(125, 25);
            label2.TabIndex = 2;
            label2.Text = "Configuration:";
            // 
            // currentsongFileDialog
            // 
            currentsongFileDialog.FileName = "currentsong.txt";
            // 
            // configSelectBox
            // 
            configSelectBox.DisplayMember = "ScoreSpy CH";
            configSelectBox.DropDownStyle = ComboBoxStyle.DropDownList;
            configSelectBox.FormattingEnabled = true;
            configSelectBox.ImeMode = ImeMode.NoControl;
            configSelectBox.Items.AddRange(new object[] { "--", "Clone Hero", "ScoreSpy CH", "YARG", "Custom 1", "Custom 2" });
            configSelectBox.Location = new Point(158, 102);
            configSelectBox.Margin = new Padding(4);
            configSelectBox.Name = "configSelectBox";
            configSelectBox.Size = new Size(206, 33);
            configSelectBox.TabIndex = 3;
            configSelectBox.ValueMember = "ScoreSpy CH";
            configSelectBox.SelectedIndexChanged += configSelectBox_SelectedIndexChanged;
            // 
            // currentsongTxtPathBox
            // 
            currentsongTxtPathBox.Location = new Point(296, 145);
            currentsongTxtPathBox.Margin = new Padding(4);
            currentsongTxtPathBox.Name = "currentsongTxtPathBox";
            currentsongTxtPathBox.Size = new Size(306, 31);
            currentsongTxtPathBox.TabIndex = 2;
            // 
            // saveConfigButton
            // 
            saveConfigButton.Location = new Point(372, 102);
            saveConfigButton.Margin = new Padding(4);
            saveConfigButton.Name = "saveConfigButton";
            saveConfigButton.Size = new Size(232, 36);
            saveConfigButton.TabIndex = 5;
            saveConfigButton.Text = "Save Configuration";
            saveConfigButton.UseVisualStyleBackColor = true;
            saveConfigButton.Click += saveConfigButton_Click;
            // 
            // btnStartStop
            // 
            btnStartStop.Location = new Point(278, 297);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(329, 73);
            btnStartStop.TabIndex = 9;
            btnStartStop.Text = "Connect";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // githubLink
            // 
            githubLink.AutoSize = true;
            githubLink.Location = new Point(12, 57);
            githubLink.Name = "githubLink";
            githubLink.Size = new Size(301, 25);
            githubLink.TabIndex = 8;
            githubLink.TabStop = true;
            githubLink.Text = "https://github.com/YoShibyl/CHOSS";
            githubLink.LinkClicked += linkLabel1_LinkClicked;
            // 
            // wsGroupBox
            // 
            wsGroupBox.Controls.Add(label7);
            wsGroupBox.Controls.Add(portBox);
            wsGroupBox.Controls.Add(passBox);
            wsGroupBox.Controls.Add(label6);
            wsGroupBox.Controls.Add(ipBox);
            wsGroupBox.Controls.Add(label3);
            wsGroupBox.Location = new Point(278, 183);
            wsGroupBox.Name = "wsGroupBox";
            wsGroupBox.Size = new Size(329, 108);
            wsGroupBox.TabIndex = 10;
            wsGroupBox.TabStop = false;
            wsGroupBox.Text = "Websocket Connection Settings";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(217, 35);
            label7.Name = "label7";
            label7.Size = new Size(16, 25);
            label7.TabIndex = 5;
            label7.Text = ":";
            // 
            // portBox
            // 
            portBox.Location = new Point(233, 32);
            portBox.Name = "portBox";
            portBox.Size = new Size(90, 31);
            portBox.TabIndex = 2;
            portBox.Text = "4455";
            // 
            // passBox
            // 
            passBox.Location = new Point(104, 69);
            passBox.Name = "passBox";
            passBox.PasswordChar = '•';
            passBox.Size = new Size(219, 31);
            passBox.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 72);
            label6.Name = "label6";
            label6.Size = new Size(87, 25);
            label6.TabIndex = 2;
            label6.Text = "Password";
            // 
            // ipBox
            // 
            ipBox.Location = new Point(75, 32);
            ipBox.Name = "ipBox";
            ipBox.Size = new Size(141, 31);
            ipBox.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 35);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 0;
            label3.Text = "IP/Port";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 111);
            label5.Name = "label5";
            label5.Size = new Size(203, 25);
            label5.TabIndex = 4;
            label5.Text = "Menu/stats scene name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 34);
            label4.Name = "label4";
            label4.Size = new Size(193, 25);
            label4.TabIndex = 3;
            label4.Text = "Gameplay scene name:";
            // 
            // menuSceneBox
            // 
            menuSceneBox.Location = new Point(9, 139);
            menuSceneBox.Name = "menuSceneBox";
            menuSceneBox.Size = new Size(244, 31);
            menuSceneBox.TabIndex = 2;
            // 
            // gameSceneBox
            // 
            gameSceneBox.Location = new Point(9, 62);
            gameSceneBox.Name = "gameSceneBox";
            gameSceneBox.Size = new Size(244, 31);
            gameSceneBox.TabIndex = 1;
            // 
            // scenesGroupBox
            // 
            scenesGroupBox.Controls.Add(label4);
            scenesGroupBox.Controls.Add(label5);
            scenesGroupBox.Controls.Add(gameSceneBox);
            scenesGroupBox.Controls.Add(menuSceneBox);
            scenesGroupBox.Location = new Point(13, 187);
            scenesGroupBox.Name = "scenesGroupBox";
            scenesGroupBox.Size = new Size(259, 183);
            scenesGroupBox.TabIndex = 11;
            scenesGroupBox.TabStop = false;
            scenesGroupBox.Text = "Scene Switcher settings";
            // 
            // CHOSS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(618, 384);
            Controls.Add(scenesGroupBox);
            Controls.Add(wsGroupBox);
            Controls.Add(btnStartStop);
            Controls.Add(githubLink);
            Controls.Add(saveConfigButton);
            Controls.Add(currentsongTxtPathBox);
            Controls.Add(configSelectBox);
            Controls.Add(label2);
            Controls.Add(browseButton);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4, 5, 4, 5);
            Name = "CHOSS";
            Text = "CHOSS";
            Load += CHOSS_Load;
            wsGroupBox.ResumeLayout(false);
            wsGroupBox.PerformLayout();
            scenesGroupBox.ResumeLayout(false);
            scenesGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button browseButton;
        private Label label2;
        private OpenFileDialog currentsongFileDialog;
        private ComboBox configSelectBox;
        private TextBox currentsongTxtPathBox;
        private Button saveConfigButton;
        private Button btnStartStop;
        private LinkLabel githubLink;
        private GroupBox wsGroupBox;
        private Label label3;
        private TextBox menuSceneBox;
        private TextBox gameSceneBox;
        private TextBox ipBox;
        private Label label5;
        private Label label4;
        private Label label6;
        private GroupBox scenesGroupBox;
        private TextBox passBox;
        private Label label7;
        private TextBox portBox;
    }
}