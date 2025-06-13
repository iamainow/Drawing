namespace i
{
	namespace Drawing
	{
		namespace LR2
		{
			public enum Position:byte
			{
				X,
				Y,
			}
			public struct iSpecialPoint
			{
				public float VALUE;
				public Position POSITION;
				public iSpecialPoint(float Value,Position Position)
				{
					this.VALUE=Value;
					this.POSITION=Position;
				}
				public static implicit operator float(iSpecialPoint SP)
				{
					return SP.VALUE;
				}
			}
			public class iArgument
			{
				public iSpecialPoint P2;
				public Drawing.D2.iPoint P3,P4;
				public iArgument(iSpecialPoint P2,Drawing.D2.iPoint P3,Drawing.D2.iPoint P4)
				{
					this.P2=P2;
					this.P3=P3;
					this.P4=P4;
				}
			}
			public class LR
			{
				public static readonly iMatrix M=new iMatrix(new float[,]{
					{-1,3,-3,1},
					{3,-6,3,0},
					{-3,3,0,0},
					{1,0,0,0}});
				public Drawing.D2.iPoint P1,P2,P3,P4;
				public iArgument[] ARGUMENT;
				public LR(Drawing.D2.iPoint P1,Drawing.D2.iPoint P2,Drawing.D2.iPoint P3,Drawing.D2.iPoint P4,iArgument[] Argument)
				{
					this.P1=P1;
					this.P2=P2;
					this.P3=P3;
					this.P4=P4;
					this.ARGUMENT=Argument;
				}
				private Drawing.D2.iPoint FindPoint(iSpecialPoint SP,Drawing.D2.iPoint P3,Drawing.D2.iPoint P4)
				{
					switch(SP.POSITION)
					{
						case Position.X:
							return new i.Drawing.D2.iPoint(SP,P4.Y+((SP-P4.X)/(P4.X-P3.X)*(P4.Y-P3.Y)));
						case Position.Y:
							return new i.Drawing.D2.iPoint(P4.X+((SP-P4.Y)/(P4.Y-P3.Y)*(P4.X-P3.X)),SP);
						default:
							throw new System.Exception();
					}
				}
				private Drawing.D2.iPoint[] GetPoints()
				{
					Drawing.D2.iPoint[] P=new i.Drawing.D2.iPoint[4+this.ARGUMENT.Length*3];
					P[0]=this.P1;
					P[1]=this.P2;
					P[2]=this.P3;
					P[3]=this.P4;
					for(int i1=0;i1<this.ARGUMENT.Length;i1++)
					{
						P[4+i1*3]=this.FindPoint(this.ARGUMENT[i1].P2,P[4+i1*3-2],P[4+i1*3-1]);
						P[4+i1*3+1]=this.ARGUMENT[i1].P3;
						P[4+i1*3+2]=this.ARGUMENT[i1].P4;
					}
					return P;
				}
				private void DrawA(System.Drawing.Graphics G,Drawing.D2.iPoint P1,Drawing.D2.iPoint P2,Drawing.D2.iPoint P3,Drawing.D2.iPoint P4,float Step,System.Drawing.Color Color)
				{
					Drawing.D2.Draw.iFuction F=new Drawing.D2.Draw.iFuction(
						new System.Func<float,float>((V) => new iVector(V*V*V,V*V,V,1)*LR.M*new iVector(P1.X,P2.X,P3.X,P4.X)),
						new System.Func<float,float>((V) => new iVector(V*V*V,V*V,V,1)*LR.M*new iVector(P1.Y,P2.Y,P3.Y,P4.Y)),
						Step,new System.Drawing.Pen(Color));
					F.Draw(G);
				}
				private void DrawA(Drawing.D2.iPoint[] Point,System.Drawing.Graphics G,float Step,System.Drawing.Color[] Color)
				{
					iCounter C=new iCounter(Color.Length);
					for(int i1=3;i1<Point.Length;i1+=3)
					{
						this.DrawA(G,Point[i1-3],Point[i1-2],Point[i1-1],Point[i1],Step,Color[C.Tick()]);
					}
				}
				private void DrawB(Drawing.D2.iPoint[] Point,System.Drawing.Graphics G,float Size,System.Drawing.Color Color)
				{
					System.Drawing.SolidBrush SB=new System.Drawing.SolidBrush(Color);
					for(int i1=0;i1<Point.Length;i1++)
					{
						new Drawing.D2.Draw.iFillEllips(Point[i1]-Size/2,Size,SB).Draw(G);
					}
				}
				private void DrawC(Drawing.D2.iPoint[] Point,System.Drawing.Graphics G,System.Drawing.Font Font,Drawing.D2.iPoint[] OffSet,System.Drawing.Color[] Color)
				{
					iCounter C1=new iCounter(Color.Length);
					iCounter C2=new iCounter(OffSet.Length);
					new Drawing.D2.Draw.iText(Point[0]+OffSet[C2.Get()],"1",Font,new System.Drawing.SolidBrush(Color[C1.Get()])).Draw(G);
					new Drawing.D2.Draw.iText(Point[1]+OffSet[C2.Get()],"2",Font,new System.Drawing.SolidBrush(Color[C1.Get()])).Draw(G);
					new Drawing.D2.Draw.iText(Point[2]+OffSet[C2.Get()],"3",Font,new System.Drawing.SolidBrush(Color[C1.Get()])).Draw(G);
					new Drawing.D2.Draw.iText(Point[3]+OffSet[C2.Get()],"4",Font,new System.Drawing.SolidBrush(Color[C1.Get()])).Draw(G);
					C1.Tick();
					C2.Tick();
					for(int i1=6;i1<Point.Length;i1+=3,C1.Tick(),C2.Tick())
					{
						new Drawing.D2.Draw.iText(Point[i1-3]+OffSet[C2.Get()],"1",Font,new System.Drawing.SolidBrush(Color[C1.Get()])).Draw(G);
						new Drawing.D2.Draw.iText(Point[i1-2]+OffSet[C2.Get()],"2",Font,new System.Drawing.SolidBrush(Color[C1.Get()])).Draw(G);
						new Drawing.D2.Draw.iText(Point[i1-1]+OffSet[C2.Get()],"3",Font,new System.Drawing.SolidBrush(Color[C1.Get()])).Draw(G);
						new Drawing.D2.Draw.iText(Point[i1]+OffSet[C2.Get()],"4",Font,new System.Drawing.SolidBrush(Color[C1.Get()])).Draw(G);
					}
				}
				public void Draw(System.Drawing.Graphics G,float Step,float RoundSize,System.Drawing.Font Font,Drawing.D2.iPoint[] TextOffSet,System.Drawing.Color Line,System.Drawing.Color[] Color)
				{
					Drawing.D2.iPoint[] P=this.GetPoints();
					this.DrawC(P,G,Font,TextOffSet,Color);
					this.DrawB(P,G,RoundSize,Line);
					this.DrawA(P,G,Step,Color);
				}
				public void Draw(System.Drawing.Graphics G,float Step,float RoundSize,System.Drawing.Font Font,Drawing.D2.iPoint[] TextOffSet,System.Drawing.Color Line,System.Drawing.Color[] Color,System.Drawing.Color Clear)
				{
					G.Clear(Clear);
					this.Draw(G,Step,RoundSize,Font,TextOffSet,Line,Color);
				}
				public void Draw(System.Drawing.Graphics G,System.Drawing.Color[] Color)
				{
					this.Draw(G,0.01F,5F,new System.Drawing.Font("Arial",16),new i.Drawing.D2.iPoint[]{-20F,0F},System.Drawing.Color.Black,Color);
				}
				public void Draw(System.Drawing.Graphics G,System.Drawing.Color[] Color,System.Drawing.Color Clear)
				{
					G.Clear(Clear);
					this.Draw(G,Color);
				}
			}
		}
	}
}