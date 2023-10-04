namespace DumbledoresArmee
{
	partial class foMain : System.Windows.Forms.Form
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
			buTest1 = new Button();
			SuspendLayout();
			// 
			// buTest1
			// 
			buTest1.Location = new Point(218, 122);
			buTest1.Name = "buTest1";
			buTest1.Size = new Size(177, 23);
			buTest1.TabIndex = 0;
			buTest1.Text = "Klicke auf mich!";
			buTest1.UseVisualStyleBackColor = true;
			buTest1.Click += buTest1_Click;
			// 
			// foMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(buTest1);
			Name = "foMain";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private Button buTest1;
	}
}