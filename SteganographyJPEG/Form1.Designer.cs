namespace SteganographyJPEG
{
    partial class Form1
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
            this.groupBoxEncode = new System.Windows.Forms.GroupBox();
            this.textBoxGetEncodeKey = new System.Windows.Forms.TextBox();
            this.labelEncodeKeyName = new System.Windows.Forms.Label();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.buttonGetMessage = new System.Windows.Forms.Button();
            this.labelMessageName = new System.Windows.Forms.Label();
            this.buttonGetEncodeContainer = new System.Windows.Forms.Button();
            this.labelEncodeContainerName = new System.Windows.Forms.Label();
            this.groupBoxDecode = new System.Windows.Forms.GroupBox();
            this.textBoxGetDecodeKey = new System.Windows.Forms.TextBox();
            this.labelDecodeKeyName = new System.Windows.Forms.Label();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.buttonGetDecodeContainer = new System.Windows.Forms.Button();
            this.labelGetDecodeCantainerName = new System.Windows.Forms.Label();
            this.buttonGetStatParams = new System.Windows.Forms.Button();
            this.groupBoxEncode.SuspendLayout();
            this.groupBoxDecode.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEncode
            // 
            this.groupBoxEncode.Controls.Add(this.textBoxGetEncodeKey);
            this.groupBoxEncode.Controls.Add(this.labelEncodeKeyName);
            this.groupBoxEncode.Controls.Add(this.buttonEncode);
            this.groupBoxEncode.Controls.Add(this.buttonGetMessage);
            this.groupBoxEncode.Controls.Add(this.labelMessageName);
            this.groupBoxEncode.Controls.Add(this.buttonGetEncodeContainer);
            this.groupBoxEncode.Controls.Add(this.labelEncodeContainerName);
            this.groupBoxEncode.Location = new System.Drawing.Point(10, 10);
            this.groupBoxEncode.Name = "groupBoxEncode";
            this.groupBoxEncode.Size = new System.Drawing.Size(250, 400);
            this.groupBoxEncode.TabIndex = 0;
            this.groupBoxEncode.TabStop = false;
            this.groupBoxEncode.Text = "Закодировать";
            // 
            // textBoxGetEncodeKey
            // 
            this.textBoxGetEncodeKey.Location = new System.Drawing.Point(10, 210);
            this.textBoxGetEncodeKey.Name = "textBoxGetEncodeKey";
            this.textBoxGetEncodeKey.Size = new System.Drawing.Size(200, 22);
            this.textBoxGetEncodeKey.TabIndex = 8;
            // 
            // labelEncodeKeyName
            // 
            this.labelEncodeKeyName.Location = new System.Drawing.Point(10, 180);
            this.labelEncodeKeyName.Name = "labelEncodeKeyName";
            this.labelEncodeKeyName.Size = new System.Drawing.Size(150, 27);
            this.labelEncodeKeyName.TabIndex = 7;
            this.labelEncodeKeyName.Text = "Ключ:";
            // 
            // buttonEncode
            // 
            this.buttonEncode.Location = new System.Drawing.Point(50, 350);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(150, 40);
            this.buttonEncode.TabIndex = 6;
            this.buttonEncode.Text = "закодировать\r\n";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // buttonGetMessage
            // 
            this.buttonGetMessage.Location = new System.Drawing.Point(10, 130);
            this.buttonGetMessage.Name = "buttonGetMessage";
            this.buttonGetMessage.Size = new System.Drawing.Size(100, 40);
            this.buttonGetMessage.TabIndex = 5;
            this.buttonGetMessage.Text = "выбрать";
            this.buttonGetMessage.UseVisualStyleBackColor = true;
            this.buttonGetMessage.Click += new System.EventHandler(this.buttonGetMessage_Click);
            // 
            // labelMessageName
            // 
            this.labelMessageName.Location = new System.Drawing.Point(10, 100);
            this.labelMessageName.Name = "labelMessageName";
            this.labelMessageName.Size = new System.Drawing.Size(150, 27);
            this.labelMessageName.TabIndex = 4;
            this.labelMessageName.Text = "Файл-сообщение:";
            // 
            // buttonGetEncodeContainer
            // 
            this.buttonGetEncodeContainer.Location = new System.Drawing.Point(10, 50);
            this.buttonGetEncodeContainer.Name = "buttonGetEncodeContainer";
            this.buttonGetEncodeContainer.Size = new System.Drawing.Size(100, 40);
            this.buttonGetEncodeContainer.TabIndex = 3;
            this.buttonGetEncodeContainer.Text = "выбрать";
            this.buttonGetEncodeContainer.UseVisualStyleBackColor = true;
            this.buttonGetEncodeContainer.Click += new System.EventHandler(this.buttonGetEncodeContainer_Click);
            // 
            // labelEncodeContainerName
            // 
            this.labelEncodeContainerName.Location = new System.Drawing.Point(10, 20);
            this.labelEncodeContainerName.Name = "labelEncodeContainerName";
            this.labelEncodeContainerName.Size = new System.Drawing.Size(150, 27);
            this.labelEncodeContainerName.TabIndex = 2;
            this.labelEncodeContainerName.Text = "Файл-контейнер:";
            // 
            // groupBoxDecode
            // 
            this.groupBoxDecode.Controls.Add(this.textBoxGetDecodeKey);
            this.groupBoxDecode.Controls.Add(this.labelDecodeKeyName);
            this.groupBoxDecode.Controls.Add(this.buttonDecode);
            this.groupBoxDecode.Controls.Add(this.buttonGetDecodeContainer);
            this.groupBoxDecode.Controls.Add(this.labelGetDecodeCantainerName);
            this.groupBoxDecode.Location = new System.Drawing.Point(320, 10);
            this.groupBoxDecode.Name = "groupBoxDecode";
            this.groupBoxDecode.Size = new System.Drawing.Size(250, 400);
            this.groupBoxDecode.TabIndex = 1;
            this.groupBoxDecode.TabStop = false;
            this.groupBoxDecode.Text = "Декодировать";
            // 
            // textBoxGetDecodeKey
            // 
            this.textBoxGetDecodeKey.Location = new System.Drawing.Point(10, 210);
            this.textBoxGetDecodeKey.Name = "textBoxGetDecodeKey";
            this.textBoxGetDecodeKey.Size = new System.Drawing.Size(200, 22);
            this.textBoxGetDecodeKey.TabIndex = 9;
            // 
            // labelDecodeKeyName
            // 
            this.labelDecodeKeyName.Location = new System.Drawing.Point(10, 180);
            this.labelDecodeKeyName.Name = "labelDecodeKeyName";
            this.labelDecodeKeyName.Size = new System.Drawing.Size(150, 27);
            this.labelDecodeKeyName.TabIndex = 9;
            this.labelDecodeKeyName.Text = "Ключ:";
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(61, 350);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(150, 40);
            this.buttonDecode.TabIndex = 9;
            this.buttonDecode.Text = "декодировать";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // buttonGetDecodeContainer
            // 
            this.buttonGetDecodeContainer.Location = new System.Drawing.Point(10, 50);
            this.buttonGetDecodeContainer.Name = "buttonGetDecodeContainer";
            this.buttonGetDecodeContainer.Size = new System.Drawing.Size(100, 40);
            this.buttonGetDecodeContainer.TabIndex = 9;
            this.buttonGetDecodeContainer.Text = "выбрать";
            this.buttonGetDecodeContainer.UseVisualStyleBackColor = true;
            this.buttonGetDecodeContainer.Click += new System.EventHandler(this.buttonGetDecodeContainer_Click);
            // 
            // labelGetDecodeCantainerName
            // 
            this.labelGetDecodeCantainerName.Location = new System.Drawing.Point(10, 20);
            this.labelGetDecodeCantainerName.Name = "labelGetDecodeCantainerName";
            this.labelGetDecodeCantainerName.Size = new System.Drawing.Size(150, 27);
            this.labelGetDecodeCantainerName.TabIndex = 9;
            this.labelGetDecodeCantainerName.Text = "Файл-контейнер:";
            // 
            // buttonGetStatParams
            // 
            this.buttonGetStatParams.Location = new System.Drawing.Point(10, 416);
            this.buttonGetStatParams.Name = "buttonGetStatParams";
            this.buttonGetStatParams.Size = new System.Drawing.Size(150, 40);
            this.buttonGetStatParams.TabIndex = 2;
            this.buttonGetStatParams.Text = "Стат. хар-ки";
            this.buttonGetStatParams.UseVisualStyleBackColor = true;
            this.buttonGetStatParams.Click += new System.EventHandler(this.buttonGetStatParams_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 565);
            this.Controls.Add(this.buttonGetStatParams);
            this.Controls.Add(this.groupBoxEncode);
            this.Controls.Add(this.groupBoxDecode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SteganographyJPEG";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxEncode.ResumeLayout(false);
            this.groupBoxEncode.PerformLayout();
            this.groupBoxDecode.ResumeLayout(false);
            this.groupBoxDecode.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Button buttonGetDecodeContainer;
        private System.Windows.Forms.Button buttonGetStatParams;
        private System.Windows.Forms.Label labelDecodeKeyName;
        private System.Windows.Forms.Label labelGetDecodeCantainerName;
        private System.Windows.Forms.TextBox textBoxGetDecodeKey;

        private System.Windows.Forms.Label labelEncodeKeyName;
        private System.Windows.Forms.TextBox textBoxGetEncodeKey;

        private System.Windows.Forms.Button buttonGetMessage;
        private System.Windows.Forms.Button buttonEncode;

        private System.Windows.Forms.Button buttonGetEncodeContainer;
        private System.Windows.Forms.Label labelEncodeContainerName;
        private System.Windows.Forms.Label labelMessageName;

        private System.Windows.Forms.GroupBox groupBoxDecode;
        private System.Windows.Forms.GroupBox groupBoxEncode;

        #endregion
    }
}