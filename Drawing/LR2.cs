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
	public partial class LR2:Form
	{
		public i.Drawing.LR2.LR LR;
		public i.Drawing.iDraw D;
		i.Drawing.iAngle A;
		public LR2()
		{
			InitializeComponent();
			this.LR=new i.Drawing.LR2.LR(
				new i.Drawing.D2.iPoint(50,450),new i.Drawing.D2.iPoint(150,250),new i.Drawing.D2.iPoint(350,450),new i.Drawing.D2.iPoint(250,250),new i.Drawing.LR2.iArgument[]{
				new i.Drawing.LR2.iArgument(new i.Drawing.LR2.iSpecialPoint(150,i.Drawing.LR2.Position.X),new i.Drawing.D2.iPoint(450,50),new i.Drawing.D2.iPoint(350,250)),
				new i.Drawing.LR2.iArgument(new i.Drawing.LR2.iSpecialPoint(350,i.Drawing.LR2.Position.Y),new i.Drawing.D2.iPoint(450,200),new i.Drawing.D2.iPoint(450,250)),
				});
			D=new i.Drawing.iDraw(_p);
			D.Start(this.Do,0,30);
		}
		private void Do(Graphics G)
		{
			G.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			this.LR.P1.X+=(float)(2D*System.Math.Sin(A));
			this.LR.ARGUMENT[0].P2.VALUE+=(float)(1D*System.Math.Sin(A));
			this.LR.ARGUMENT[1].P4.Y+=(float)(2D*System.Math.Sin(A));
			this.LR.Draw(G,new Color[]{Color.Red,Color.Green,Color.Blue},Color.White);
			A+=0.03F;
		}
	}
}