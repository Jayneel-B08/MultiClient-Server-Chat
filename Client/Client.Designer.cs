namespace Client
{
    partial class Client
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
        public void InitializeComponent()
        {
            SendBTN = new Button();
            Screen = new RichTextBox();
            Message = new TextBox();
            ConnectBTN = new Button();
            SuspendLayout();
            // 
            // SendBTN
            // 
            SendBTN.Location = new Point(633, 413);
            SendBTN.Name = "SendBTN";
            SendBTN.Size = new Size(114, 36);
            SendBTN.TabIndex = 0;
            SendBTN.Text = "Send";
            SendBTN.UseVisualStyleBackColor = true;
            SendBTN.Click += SendBTN_Click;
            // 
            // Screen
            // 
            Screen.Font = new Font("Segoe UI", 18F);
            Screen.Location = new Point(12, 12);
            Screen.Name = "Screen";
            Screen.ReadOnly = true;
            Screen.Size = new Size(613, 395);
            Screen.TabIndex = 1;
            Screen.Text = "";
            // 
            // Message
            // 
            Message.Font = new Font("Segoe UI", 16F);
            Message.Location = new Point(12, 413);
            Message.Name = "Message";
            Message.Size = new Size(613, 36);
            Message.TabIndex = 2;
            // 
            // ConnectBTN
            // 
            ConnectBTN.Location = new Point(633, 12);
            ConnectBTN.Name = "ConnectBTN";
            ConnectBTN.Size = new Size(114, 36);
            ConnectBTN.TabIndex = 3;
            ConnectBTN.Text = "Connect";
            ConnectBTN.UseVisualStyleBackColor = true;
            ConnectBTN.Click += ConnectBTN_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 461);
            Controls.Add(ConnectBTN);
            Controls.Add(Message);
            Controls.Add(Screen);
            Controls.Add(SendBTN);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button SendBTN;
        public Button ConnectBTN;
        public RichTextBox Screen;
        public TextBox Message;
    }
}
