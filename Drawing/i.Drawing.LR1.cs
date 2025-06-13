namespace i
{
	namespace Drawing
	{
		namespace LR1
		{
			public class LR
			{
				public static readonly Drawing.iMatrix M=new iMatrix(new float[,]{
					{2,-2,1,1},
					{-3,3,-2,-1},
					{0,0,1,0},
					{1,0,0,0}});
				public Drawing.D2.iVector[] VECTOR;
				public LR(Drawing.D2.iVector[] Vector)
				{
					this.VECTOR=Vector;
				}
				private void DrawA(System.Drawing.Graphics G,float Step,System.Drawing.Color[] Color)
				{
					Drawing.iCounter Count=new iCounter(Color.Length);
					Drawing.D2.Draw.iFuction F;
					for(int i1=0;i1<this.VECTOR.Length-1;i1++)
					{
						Drawing.D2.iPoint P1=VECTOR[i1].P1;
						Drawing.D2.iPoint P2=VECTOR[i1+1].P1;
						Drawing.D2.iPoint R1=VECTOR[i1].P2;
						Drawing.D2.iPoint R2=VECTOR[i1+1].P2;
						Drawing.iVector Gx=new Drawing.iVector(P1.X,P2.X,R1.X-P1.X,R2.X-P2.X);
						Drawing.iVector Gy=new Drawing.iVector(P1.Y,P2.Y,R1.Y-P1.Y,R2.Y-P2.Y);
						F=new Drawing.D2.Draw.iFuction(
							new System.Func<float,float>((V) => new iVector(V*V*V,V*V,V,1)*LR.M*Gx),
							new System.Func<float,float>((V) => new iVector(V*V*V,V*V,V,1)*LR.M*Gy),
							Step,new System.Drawing.Pen(Color[Count.Tick()]));
						F.Draw(G);
					}
				}
				private void DrawB(System.Drawing.Graphics G,System.Drawing.Color[] Color)
				{
					Drawing.iCounter Count=new iCounter(Color.Length);
					Drawing.D2.Draw.iArrow A;
					for(int i1=0;i1<this.VECTOR.Length;i1++)
					{
						A=new Drawing.D2.Draw.iArrow(this.VECTOR[i1],new System.Drawing.Pen(Color[Count.Tick()]));
						A.Draw(G);
					}
				}
				public void Draw(System.Drawing.Graphics G,float Step,System.Drawing.Color[] Color)
				{
					this.DrawB(G,Color);
					this.DrawA(G,Step,Color);
				}
				public void Draw(System.Drawing.Graphics G,float Step,System.Drawing.Color Clear,System.Drawing.Color[] Color)
				{
					G.Clear(Clear);
					this.Draw(G,Step,Color);
				}
			}
		}
	}
}