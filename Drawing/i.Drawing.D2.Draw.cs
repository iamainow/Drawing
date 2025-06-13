namespace i
{
	namespace Drawing
	{
		namespace D2
		{
			namespace Draw
			{
				public interface IDraw
				{
					void Draw(System.Drawing.Graphics G);
				}
				public interface IDraw2D:IMove,IRotate,IDraw
				{
				}
				public struct iLine:IMove,IRotate,IDraw
				{
					public iPoint P1;
					public iPoint P2;
					public System.Drawing.Pen PEN;
					public iLine(iPoint P1,iPoint P2,System.Drawing.Pen Pen)
					{
						this.P1=P1;
						this.P2=P2;
						this.PEN=Pen;
					}
					public iLine(iLine L)
					{
						this.P1=L.P1;
						this.P2=L.P2;
						this.PEN=L.PEN;
					}
					public void Move(i.Drawing.D2.iPoint P)
					{
						this.P1.Move(P);
						this.P2.Move(P);
					}
					public void Rotate(iAngle A)
					{
						this.P1.Rotate(A);
						this.P2.Rotate(A);
					}
					public void Rotate(iAngle A,i.Drawing.D2.iPoint P)
					{
						this.Move(-P);
						this.Rotate(A);
						this.Move(P);
					}
					public void Draw(System.Drawing.Graphics G)
					{
						G.DrawLine(this.PEN,this.P1,this.P2);
					}
				}
				public struct iPath:IMove,IRotate,IDraw
				{
					public iPoint[] POINT;
					public System.Drawing.Pen PEN;
					public iPath(iPoint[] Point,System.Drawing.Pen Pen)
					{
						this.POINT=Point;
						this.PEN=Pen;
					}
					public iPath(iPath P)
					{
						this.POINT=P.POINT;
						this.PEN=P.PEN;
					}
					public void Move(i.Drawing.D2.iPoint P)
					{
						for(int i1=0;i1<this.POINT.Length;i1++)
						{
							this.POINT[i1].Move(P);
						}
					}
					public void Rotate(iAngle A)
					{
						for(int i1=0;i1<this.POINT.Length;i1++)
						{
							this.POINT[i1].Rotate(A);
						}
					}
					public void Rotate(iAngle A,i.Drawing.D2.iPoint P)
					{
						this.Move(-P);
						this.Rotate(A);
						this.Move(P);
					}
					public void Draw(System.Drawing.Graphics G)
					{
						System.Drawing.Drawing2D.GraphicsPath GP=new System.Drawing.Drawing2D.GraphicsPath();
						for(int i1=1;i1<this.POINT.Length;i1++)
						{
							GP.AddLine(this.POINT[i1-1],this.POINT[i1]);
						}
						G.DrawPath(PEN,GP);
					}
				}
				public class iEllips:IMove,IRotate,IDraw
				{
					public iPoint POINT;
					public iPoint LENGTH;
					public System.Drawing.Pen PEN;
					public iEllips(iPoint Point,iPoint Length,System.Drawing.Pen Pen)
					{
						this.POINT=Point;
						this.LENGTH=Length;
						this.PEN=Pen;
					}
					public iEllips(iEllips E)
					{
						this.POINT=E.POINT;
						this.LENGTH=E.LENGTH;
						this.PEN=E.PEN;
					}
					public void Move(i.Drawing.D2.iPoint P)
					{
						this.POINT.Move(P);
					}
					public void Rotate(iAngle A)
					{
						this.POINT.Rotate(A);
						this.LENGTH.Rotate(A);
					}
					public void Rotate(iAngle A,i.Drawing.D2.iPoint P)
					{
						this.POINT.Move(-P);
						this.POINT.Rotate(A);
						this.POINT.Move(P);
					}
					public void Draw(System.Drawing.Graphics G)
					{
						G.DrawEllipse(this.PEN,new System.Drawing.RectangleF(this.POINT,this.LENGTH));
					}
				}
				public class iFillEllips:IMove,IRotate,IDraw
				{
					public iPoint POINT;
					public iPoint LENGTH;
					public System.Drawing.Brush BRUSH;
					public iFillEllips(iPoint Point,iPoint Length,System.Drawing.Brush Brush)
					{
						this.POINT=Point;
						this.LENGTH=Length;
						this.BRUSH=Brush;
					}
					public iFillEllips(iFillEllips FE)
					{
						this.POINT=FE.POINT;
						this.LENGTH=FE.LENGTH;
						this.BRUSH=FE.BRUSH;
					}
					public void Move(i.Drawing.D2.iPoint P)
					{
						this.POINT.Move(P);
					}
					public void Rotate(iAngle A)
					{
						this.POINT.Rotate(A);
						this.LENGTH.Rotate(A);
					}
					public void Rotate(iAngle A,i.Drawing.D2.iPoint P)
					{
						this.POINT.Move(-P);
						this.POINT.Rotate(A);
						this.POINT.Move(P);
					}
					public void Draw(System.Drawing.Graphics G)
					{
						G.FillEllipse(this.BRUSH,new System.Drawing.RectangleF(this.POINT,this.LENGTH));
					}
				}
				public class iFuction:IMove,IRotate,IDraw
				{
					public System.Collections.Generic.List<iPoint> POINT;
					public System.Drawing.Pen PEN;
					public iFuction(System.Func<float,float> FX,System.Func<float,float> FY,float Step,System.Drawing.Pen Pen)
					{
						this.POINT=new System.Collections.Generic.List<iPoint>();
						for(float f1=0;f1<=1;f1+=Step)
						{
							this.POINT.Add(new iPoint(FX(f1),FY(f1)));
						}
						this.PEN=Pen;
					}
					public iFuction(System.Func<float,iPoint> F,float Step,System.Drawing.Pen Pen)
					{
						this.POINT=new System.Collections.Generic.List<iPoint>();
						for(float f1=0;f1<=1;f1+=Step)
						{
							this.POINT.Add(F(f1));
						}
						this.PEN=Pen;
					}
					public iFuction(iFuction F)
					{
						this.POINT=F.POINT;
						this.PEN=F.PEN;
					}
					public void Move(i.Drawing.D2.iPoint P)
					{
						for(int i1=0;i1<this.POINT.Count;i1++)
						{
							this.POINT[i1].Move(P);
						}
					}
					public void Rotate(iAngle A)
					{
						for(int i1=0;i1<this.POINT.Count;i1++)
						{
							this.POINT[i1].Rotate(A);
						}
					}
					public void Rotate(iAngle A,i.Drawing.D2.iPoint P)
					{
						this.Move(-P);
						this.Rotate(A);
						this.Move(P);
					}
					public void Draw(System.Drawing.Graphics G)
					{
						System.Drawing.Drawing2D.GraphicsPath GP=new System.Drawing.Drawing2D.GraphicsPath();
						for(int i1=1;i1<this.POINT.Count;i1++)
						{
							GP.AddLine(this.POINT[i1-1],this.POINT[i1]);
						}
						G.DrawPath(PEN,GP);
					}
				}
				public class iText:IMove,IRotate,IDraw
				{
					public iPoint POINT;
					public string TEXT;
					public System.Drawing.Font FONT;
					public System.Drawing.Brush BRUSH;
					public iText(iPoint Point,string Text,System.Drawing.Font Font,System.Drawing.Brush Brush)
					{
						this.POINT=Point;
						this.TEXT=Text;
						this.FONT=Font;
						this.BRUSH=Brush;
					}
					public iText(iText T)
					{
						this.POINT=T.POINT;
						this.TEXT=T.TEXT;
						this.FONT=T.FONT;
						this.BRUSH=T.BRUSH;
					}
					public void Move(i.Drawing.D2.iPoint P)
					{
						this.POINT.Move(P);
					}
					public void Rotate(iAngle A)
					{
						this.POINT.Rotate(A);
					}
					public void Rotate(iAngle A,i.Drawing.D2.iPoint P)
					{
						this.Move(-P);
						this.Rotate(A);
						this.Move(P);
					}
					public void Draw(System.Drawing.Graphics G)
					{
						G.DrawString(this.TEXT,this.FONT,this.BRUSH,this.POINT);
					}
				}
				public class iArrow:IMove,IRotate,IDraw
				{
					public iVector VECTOR;
					public iAngle MINIANGLE;
					public float MINILENGTH;
					public System.Drawing.Pen PEN;
					public iArrow(iVector Vector,iAngle MiniAngle,float MiniLength,System.Drawing.Pen Pen)
					{
						this.VECTOR=Vector;
						this.MINIANGLE=MiniAngle;
						this.MINILENGTH=MiniLength;
						this.PEN=Pen;
					}
					public iArrow(iVector Vector,System.Drawing.Pen Pen)
						:this(Vector,0.4F,Vector.Length/5,Pen)
					{
					}
					public iArrow(iArrow A)
					{
						this.VECTOR=A.VECTOR;
						this.MINIANGLE=A.MINIANGLE;
						this.MINILENGTH=A.MINILENGTH;
						this.PEN=A.PEN;
					}
					public void Move(i.Drawing.D2.iPoint P)
					{
						this.VECTOR.Move(P);
					}
					public void Rotate(iAngle A)
					{
						this.VECTOR.Rotate(A);
					}
					public void Rotate(iAngle A,i.Drawing.D2.iPoint P)
					{
						this.VECTOR.Rotate(A,P);
					}
					public void Draw(System.Drawing.Graphics G)
					{
						iVector V1,V2,V3;
						V1=this.VECTOR;
						V2=new iVector(V1.P2,V1.Angle-(float)System.Math.PI+this.MINIANGLE,this.MINILENGTH);
						V3=new iVector(V1.P2,V1.Angle-(float)System.Math.PI-this.MINIANGLE,this.MINILENGTH);
						G.DrawLine(this.PEN,V1.P1,V1.P2);
						G.DrawLine(this.PEN,V2.P1,V2.P2);
						G.DrawLine(this.PEN,V3.P1,V3.P2);
					}
				}
				public class iSpace:System.Collections.Generic.List<IDraw2D>,IMove,IRotate,IDraw
				{
					public iSpace()
					{
					}
					public iSpace(System.Collections.Generic.List<IDraw2D> List)
						: base(List)
					{
					}
					public void Move(iPoint P)
					{
						foreach(var V in this)
						{
							V.Move(P);
						}
					}
					public void Rotate(iAngle A)
					{
						foreach(var V in this)
						{
							V.Rotate(A);
						}
					}
					public void Rotate(iAngle A,iPoint P)
					{
						foreach(var V in this)
						{
							V.Move(-P);
							V.Rotate(A);
							V.Move(P);
						}
					}
					public void Draw(System.Drawing.Graphics G)
					{
						foreach(var V in this)
						{
							V.Draw(G);
						}
					}
					public void Draw(System.Drawing.Graphics G,System.Drawing.Color Color)
					{
						G.Clear(Color);
						this.Draw(G);
					}
				}
			}
		}
	}
}