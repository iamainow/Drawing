namespace Drawing
{
	partial class LR3
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
			this._p=new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this._p)).BeginInit();
			this.SuspendLayout();
			// 
			// _p
			// 
			this._p.Dock=System.Windows.Forms.DockStyle.Fill;
			this._p.Location=new System.Drawing.Point(0,0);
			this._p.Name="_p";
			this._p.Size=new System.Drawing.Size(492,466);
			this._p.TabIndex=0;
			this._p.TabStop=false;
			// 
			// LR3
			// 
			this.AutoScaleDimensions=new System.Drawing.SizeF(6F,13F);
			this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize=new System.Drawing.Size(492,466);
			this.Controls.Add(this._p);
			this.FormBorderStyle=System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name="LR3";
			this.Text="LR3";
			((System.ComponentModel.ISupportInitialize)(this._p)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox _p;
	}
}