namespace Drawing
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components=null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing&&(components!=null))
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
			this._lr2=new System.Windows.Forms.Button();
			this._lr1=new System.Windows.Forms.Button();
			this._lr3=new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _lr2
			// 
			this._lr2.Location=new System.Drawing.Point(12,41);
			this._lr2.Name="_lr2";
			this._lr2.Size=new System.Drawing.Size(75,23);
			this._lr2.TabIndex=3;
			this._lr2.Text="LR2";
			this._lr2.UseVisualStyleBackColor=true;
			this._lr2.Click+=new System.EventHandler(this._lr2_Click);
			// 
			// _lr1
			// 
			this._lr1.Location=new System.Drawing.Point(12,12);
			this._lr1.Name="_lr1";
			this._lr1.Size=new System.Drawing.Size(75,23);
			this._lr1.TabIndex=4;
			this._lr1.Text="LR1";
			this._lr1.UseVisualStyleBackColor=true;
			this._lr1.Click+=new System.EventHandler(this._lr1_Click);
			// 
			// _lr3
			// 
			this._lr3.Location=new System.Drawing.Point(12,70);
			this._lr3.Name="_lr3";
			this._lr3.Size=new System.Drawing.Size(75,23);
			this._lr3.TabIndex=5;
			this._lr3.Text="LR3";
			this._lr3.UseVisualStyleBackColor=true;
			this._lr3.Click+=new System.EventHandler(this._lr3_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions=new System.Drawing.SizeF(6F,14F);
			this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize=new System.Drawing.Size(98,266);
			this.Controls.Add(this._lr3);
			this.Controls.Add(this._lr1);
			this.Controls.Add(this._lr2);
			this.Font=new System.Drawing.Font("Arial",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(204)));
			this.FormBorderStyle=System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name="Form1";
			this.Text="Select LR";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _lr2;
		private System.Windows.Forms.Button _lr1;
		private System.Windows.Forms.Button _lr3;
	}
}

