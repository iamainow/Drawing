namespace i
{
	namespace Drawing
	{
		namespace LR3
		{
			public class LR
			{
				public static readonly iMatrix M=(1/6F)*new iMatrix(new float[,]{
					{-1,3,-3,1},
					{3,-6,3,0},
					{-3,0,3,0},
					{1,4,1,0}});
				public Drawing.D2.iPoint[] POINT;
				public LR(params Drawing.D2.iPoint[] Point)
				{
					this.POINT=Point;
				}
				private void DrawA(System.Drawing.Graphics G,float Step,System.Drawing.Color Color)
				{
					for(int i1=3;i1<this.POINT.Length;i1++)
					{
						new Drawing.D2.Draw.iFuction(
						new System.Func<float,float>((V) => new iVector(V*V*V,V*V,V,1)*LR.M*new iVector(this.POINT[i1-3].X,this.POINT[i1-2].X,this.POINT[i1-1].X,this.POINT[i1].X)),
						new System.Func<float,float>((V) => new iVector(V*V*V,V*V,V,1)*LR.M*new iVector(this.POINT[i1-3].Y,this.POINT[i1-2].Y,this.POINT[i1-1].Y,this.POINT[i1].Y)),
						Step,new System.Drawing.Pen(Color)).Draw(G);
					}
				}
				private void DrawB(System.Drawing.Graphics G,float Size,System.Drawing.Color Color)
				{
					System.Drawing.SolidBrush SB=new System.Drawing.SolidBrush(Color);
					for(int i1=0;i1<this.POINT.Length;i1++)
					{
						new Drawing.D2.Draw.iFillEllips(this.POINT[i1]-Size/2,Size,SB).Draw(G);
					}
				}
				private void DrawC(System.Drawing.Graphics G,System.Drawing.Font Font,Drawing.D2.iPoint OffSet,System.Drawing.Color Color)
				{
					System.Drawing.SolidBrush SB=new System.Drawing.SolidBrush(Color);
					for(int i1=0;i1<this.POINT.Length;i1++)
					{
						new Drawing.D2.Draw.iText(this.POINT[i1]+OffSet,(i1+1).ToString(),Font,SB).Draw(G);
					}
				}
				public void Draw(System.Drawing.Graphics G,System.Drawing.Font Font,Drawing.D2.iPoint TextOffSet,System.Drawing.Color Text,float RoundSize,System.Drawing.Color Round,float Step,System.Drawing.Color Line)
				{
					this.DrawC(G,Font,TextOffSet,Text);
					this.DrawB(G,RoundSize,Round);
					this.DrawA(G,Step,Line);
				}
				public void Draw(System.Drawing.Graphics G,System.Drawing.Font Font,Drawing.D2.iPoint TextOffSet,System.Drawing.Color Text,float RoundSize,System.Drawing.Color Round,float Step,System.Drawing.Color Line,System.Drawing.Color Clear)
				{
					G.Clear(Clear);
					this.Draw(G,Font,TextOffSet,Text,RoundSize,Round,Step,Line);
				}
			}
		}
	}
}