namespace FoodAppUi
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(342, 139);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 0;
            button1.Text = "Find";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(76, 39);
            label1.Name = "label1";
            label1.Size = new Size(391, 50);
            label1.TabIndex = 1;
            label1.Text = "Enter the barcode below";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(76, 140);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(249, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(76, 252);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(391, 205);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 202);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 4;
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 502);
            Controls.Add(label2);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Food ECode Scanner";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Label label2;
    }
}
