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
	public partial class LR3:Form
	{
		public i.Drawing.LR3.LR LR;
		public i.Drawing.iDraw D;
		public i.Drawing.iAngle A;
		public LR3()
		{
			InitializeComponent();
			this.LR=new i.Drawing.LR3.LR(
				new i.Drawing.D2.iPoint(50,50),
				new i.Drawing.D2.iPoint(100,350),
				new i.Drawing.D2.iPoint(175,100),
				new i.Drawing.D2.iPoint(125,225),
				new i.Drawing.D2.iPoint(250,400),
				new i.Drawing.D2.iPoint(300,350),
				new i.Drawing.D2.iPoint(350,400),
				new i.Drawing.D2.iPoint(400,300));
			D=new i.Drawing.iDraw(_p);
			D.Start(this.Do,0,30);
		}
		private void Do(Graphics G)
		{
			G.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			this.LR.POINT[2].X+=(float)(4D*System.Math.Sin(A+0.2F));
			this.LR.POINT[3].X+=(float)(4D*System.Math.Sin(A+0.5F));
			this.LR.POINT[4].Y-=(float)(4D*System.Math.Sin(A+0.7F));
			this.LR.POINT[5].Y-=(float)(4D*System.Math.Sin(A+0.8F));
			this.LR.POINT[6].Y-=(float)(4D*System.Math.Sin(A+1F));
			this.LR.POINT[7].Y-=(float)(4D*System.Math.Sin(A-0.5F));
			if(this.LR.POINT.Length==8)
			{
				if(A<System.Math.PI)
				{
					var L=this.LR.POINT.ToList();
					L.Add(new i.Drawing.D2.iPoint(450,450));
					L.Add(new i.Drawing.D2.iPoint(450,225));
					this.LR.POINT=L.ToArray();
				}
			}
			else
			{
				if(A>System.Math.PI)
				{
					var L=this.LR.POINT.ToList();
					L.RemoveAt(L.Count-1);
					L.RemoveAt(L.Count-1);
					this.LR.POINT=L.ToArray();
				}
			}
			this.LR.Draw(G,new Font("Arial",16),0F,Color.Black,8F,Color.Red,0.001F,Color.Blue,Color.White);
			A+=0.03F;
		}
	}
}