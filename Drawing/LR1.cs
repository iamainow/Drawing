using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Drawing
{
	public partial class LR1:Form
	{
		public i.Drawing.LR1.LR LR;
		public i.Drawing.iDraw D;
		public LR1()
		{
			InitializeComponent();
			this.LR=new i.Drawing.LR1.LR(new i.Drawing.D2.iVector[]{
				new i.Drawing.D2.iVector(new i.Drawing.D2.iPoint(100,100),i.Drawing.iAngle.FromDegree(-60),100),
				new i.Drawing.D2.iVector(new i.Drawing.D2.iPoint(200,125),0,125),
				new i.Drawing.D2.iVector(new i.Drawing.D2.iPoint(350,150),i.Drawing.iAngle.FromDegree(60),80),
				new i.Drawing.D2.iVector(new i.Drawing.D2.iPoint(325,300),i.Drawing.iAngle.FromDegree(-90),50),
				new i.Drawing.D2.iVector(new i.Drawing.D2.iPoint(275,425),i.Drawing.iAngle.FromDegree(180),150),
				new i.Drawing.D2.iVector(new i.Drawing.D2.iPoint(150,400),i.Drawing.iAngle.FromDegree(145),75),
				new i.Drawing.D2.iVector(new i.Drawing.D2.iPoint(50,300),-0.6F,150),
			});
			D=new i.Drawing.iDraw(_p);
			D.Start(this.Do,0,30);
		}
		private void Do(Graphics G)
		{
			G.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			i.Drawing.iAngle A=0.03F;
			this.LR.VECTOR[1].Rotate(A);
			this.LR.VECTOR[2].Rotate(-1.5F*A);
			this.LR.VECTOR[2].Length=300*(((float)System.Math.Sin(this.LR.VECTOR[2].Angle)+1.1F)/3);
			this.LR.VECTOR[5].Rotate(A/2);
			this.LR.Draw(G,0.02F,Color.White,new Color[] {
				Color.Red,
				Color.Green,
				Color.Blue
			});
		}
	}
}