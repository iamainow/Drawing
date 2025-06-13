namespace i
{
	namespace Drawing
	{
		namespace D2
		{
			//передвигает объект
			public interface IMove
			{
				void Move(i.Drawing.D2.iPoint P);
			}
			//поворачивает объект по часовой стрелке
			public interface IRotate
			{
				void Rotate(i.Drawing.iAngle A);
			}
			public struct iPoint:IMove,IRotate
			{
				public float X,Y;
				public iPoint(float X,float Y)
				{
					this.X=X;
					this.Y=Y;
				}
				public iPoint(iPoint P)
				{
					this.X=P.X;
					this.Y=P.Y;
				}
				public void Move(i.Drawing.D2.iPoint P)
				{
					this+=P;
				}
				public void Rotate(i.Drawing.iAngle A)
				{
					float Sin=(float)System.Math.Sin(A);
					float Cos=(float)System.Math.Cos(A);
					this=new iPoint(this.X*Cos-this.Y*Sin,this.X*Sin+this.Y*Cos);
				}
				public void Rotate(iAngle A,iPoint P)
				{
					this.Move(-P);
					this.Rotate(A);
					this.Move(P);
				}
				public static iPoint operator-(iPoint P)
				{
					return new iPoint(-P.X,-P.Y);
				}
				public static iPoint operator+(iPoint P1,iPoint P2)
				{
					return new iPoint(P1.X+P2.X,P1.Y+P2.Y);
				}
				public static iPoint operator+(iPoint P,float F)
				{
					return new iPoint(P.X+F,P.Y+F);
				}
				public static iPoint operator+(float F,iPoint P)
				{
					return new iPoint(P.X+F,P.Y+F);
				}
				public static iPoint operator-(iPoint P1,iPoint P2)
				{
					return new iPoint(P1.X-P2.X,P1.Y-P2.Y);
				}
				public static iPoint operator-(iPoint P,float F)
				{
					return new iPoint(P.X-F,P.Y-F);
				}
				public static iPoint operator-(float F,iPoint P)
				{
					return new iPoint(F-P.X,F-P.Y);
				}
				public static iPoint operator*(iPoint P,float F)
				{
					return new iPoint(P.X*F,P.Y*F);
				}
				public static iPoint operator*(float F,iPoint P)
				{
					return new iPoint(P.X*F,P.Y*F);
				}
				public static iPoint operator*(iPoint P1,iPoint P2)
				{
					return new iPoint(P1.X*P2.X,P1.Y*P2.Y);
				}
				public static iPoint operator/(iPoint P,float F)
				{
					return new iPoint(P.X/F,P.Y/F);
				}
				public static iPoint operator/(float F,iPoint P)
				{
					return new iPoint(F/P.X,F/P.Y);
				}
				public static iPoint operator/(iPoint P1,iPoint P2)
				{
					return new iPoint(P1.X/P2.X,P1.Y/P2.Y);
				}
				public static implicit operator iPoint(float F)
				{
					return new iPoint(F,F);
				}
				public static implicit operator System.Drawing.PointF(iPoint P)
				{
					return new System.Drawing.PointF(P.X,P.Y);
				}
				public static implicit operator iPoint(System.Drawing.PointF P)
				{
					return new iPoint(P.X,P.Y);
				}
				public static implicit operator System.Drawing.SizeF(iPoint P)
				{
					return new System.Drawing.SizeF(P.X,P.Y);
				}
				public override string ToString()
				{
					return this.X.ToString()+","+this.Y.ToString();
				}
			}
			public struct iVector:IMove,IRotate
			{
				public iPoint P1;
				public iPoint P2;
				public iPoint D
				{
					get
					{
						return P2-P1;
					}
					set
					{
						this.P2=P1+value;
					}
				}
				public float Length
				{
					get
					{
						return (float)System.Math.Sqrt(this.D.X*this.D.X+this.D.Y*this.D.Y);
					}
					set
					{
						this.P2+=((value/this.Length)-1)*this.D;
					}
				}
				public iAngle Angle
				{
					get
					{
						float L=this.Length;
						double Sin1=System.Math.Asin((this.P2.Y-this.P1.Y)/L);
						double Sin2=System.Math.PI-Sin1;
						double Cos1=System.Math.Acos((this.P2.X-this.P1.X)/L);
						if(System.Math.Abs(Sin1-Cos1)<=System.Math.Abs(Sin2-Cos1))
						{
							return new iAngle((float)Sin1);
						}
						else
						{
							return new iAngle((float)Sin2);
						}
					}
				}
				public iVector(iPoint Point,iAngle Angle,float Length)
				{
					this.P1=Point;
					this.P2.X=this.P1.X+(float)(System.Math.Cos(Angle)*Length);
					this.P2.Y=this.P1.Y+(float)(System.Math.Sin(Angle)*Length);
				}
				public iVector(iPoint P1,iPoint P2)
				{
					this.P1=P1;
					this.P2=P2;
				}
				public iVector(iVector V)
				{
					this.P1=V.P1;
					this.P2=V.P2;
				}
				public void Move(iPoint P)
				{
					this.P1.Move(P);
					this.P2.Move(P);
				}
				public void Rotate(i.Drawing.iAngle A)
				{
					this.P2.Rotate(A,this.P1);
				}
				public void Rotate(iAngle A,iPoint P)
				{
					this.P1.Rotate(A,P);
					this.P2.Rotate(A,P);
				}
				public static iVector operator-(iVector V)
				{
					return new iVector(-V.P1,-V.P2);
				}
				public static iVector operator+(iVector V1,iVector V2)
				{
					return new iVector(V1.P1+V2.P1,V1.P2+V2.P2);
				}
			}
		}
	}
}