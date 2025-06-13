namespace i
{
	namespace Drawing
	{
		namespace D3
		{
			public static class Operation
			{
				public static iPoint MoveX(iPoint Point,float DX)
				{
					return new iPoint(Point.X+DX,Point.Y,Point.Z);
				}
				public static iPoint MoveY(iPoint Point,float DY)
				{
					return new iPoint(Point.X,Point.Y+DY,Point.Z);
				}
				public static iPoint MoveZ(iPoint Point,float DZ)
				{
					return new iPoint(Point.X,Point.Y,Point.Z+DZ);
				}
				public static iPoint Move(iPoint Point,iPoint D)
				{
					return new iPoint(Point+D);
				}
				public static iPoint RotateX(iPoint P,Drawing.iAngle A)
				{
					float Sin=(float)System.Math.Sin(A);
					float Cos=(float)System.Math.Cos(A);
					return new iPoint(P.X,P.Y*Cos-P.Z*Sin,P.Y*Sin+P.Z*Cos);
				}
				public static iPoint RotateY(iPoint P,Drawing.iAngle A)
				{
					float Sin=(float)System.Math.Sin(A);
					float Cos=(float)System.Math.Cos(A);
					return new iPoint(P.X*Cos+P.Z*Sin,P.Y,-P.X*Sin+P.Z*Cos);
				}
				public static iPoint RotateZ(iPoint P,Drawing.iAngle A)
				{
					float Sin=(float)System.Math.Sin(A);
					float Cos=(float)System.Math.Cos(A);
					return new iPoint(P.X*Cos-P.Y*Sin,P.X*Sin+P.Y*Cos,P.Z);
				}
				public static iPoint Rotate(iPoint P,iAngle A)
				{
					return Operation.RotateZ(Operation.RotateY(Operation.RotateX(P,A.X),A.Y),A.Z);
				}
			}
			public struct iPoint
			{
				public float X,Y,Z;
				public iPoint(float X,float Y,float Z)
				{
					this.X=X;
					this.Y=Y;
					this.Z=Z;
				}
				public iPoint(iPoint P)
				{
					this.X=P.X;
					this.Y=P.Y;
					this.Z=P.Z;
				}
				public static iPoint operator-(iPoint P)
				{
					return new iPoint(-P.X,-P.Y,-P.Z);
				}
				public static iPoint operator+(iPoint P1,iPoint P2)
				{
					return new iPoint(P1.X+P2.X,P1.Y+P2.Y,P1.Z+P2.Z);
				}
				public static iPoint operator+(iPoint P,float F)
				{
					return new iPoint(P.X+F,P.Y+F,P.Z+F);
				}
				public static iPoint operator+(float F,iPoint P)
				{
					return new iPoint(P.X+F,P.Y+F,P.Z+F);
				}
				public static iPoint operator-(iPoint P1,iPoint P2)
				{
					return new iPoint(P1.X-P2.X,P1.Y-P2.Y,P1.Z-P2.Z);
				}
				public static iPoint operator-(iPoint P,float F)
				{
					return new iPoint(P.X-F,P.Y-F,P.Z-F);
				}
				public static iPoint operator-(float F,iPoint P)
				{
					return new iPoint(F-P.X,F-P.Y,F-P.Z);
				}
				public static iPoint operator*(iPoint P,float F)
				{
					return new iPoint(P.X*F,P.Y*F,P.Z*F);
				}
				public static iPoint operator*(float F,iPoint P)
				{
					return new iPoint(P.X*F,P.Y*F,P.Z*F);
				}
				public static iPoint operator*(iPoint P1,iPoint P2)
				{
					return new iPoint(P1.X*P2.X,P1.Y*P2.Y,P1.Z*P2.Z);
				}
				public static iPoint operator/(iPoint P,float F)
				{
					return new iPoint(P.X/F,P.Y/F,P.Z/F);
				}
				public static iPoint operator/(iPoint P1,iPoint P2)
				{
					return new iPoint(P1.X/P2.X,P1.Y/P2.Y,P1.Z/P2.Z);
				}
				public static implicit operator iPoint(float F)
				{
					return new iPoint(F,F,F);
				}
				public override string ToString()
				{
					return this.X.ToString()+","+this.Y.ToString()+","+this.Z.ToString();
				}
			}
			public struct iAngle
			{
				public Drawing.iAngle X,Y,Z;
				public iAngle(Drawing.iAngle X,Drawing.iAngle Y,Drawing.iAngle Z)
				{
					this.X=X;
					this.Y=Y;
					this.Z=Z;
				}
				public iAngle(iAngle A)
				{
					this.X=A.X;
					this.Y=A.Y;
					this.Z=A.Z;
				}
				public static iAngle operator-(iAngle A)
				{
					return new iAngle(-A.X,-A.Y,-A.Z);
				}
				public static iAngle operator+(iAngle A1,iAngle A2)
				{
					return new iAngle(A1.X+A2.X,A1.Y+A2.Y,A1.Z+A2.Z);
				}
				public static iAngle operator+(iAngle A,float F)
				{
					return new iAngle(A.X+F,A.Y+F,A.Z+F);
				}
				public static iAngle operator+(float F,iAngle A)
				{
					return new iAngle(A.X+F,A.Y+F,A.Z+F);
				}
				public static iAngle operator-(iAngle A,iAngle A2)
				{
					return new iAngle(A.X-A2.X,A.Y-A2.Y,A.Z-A2.Z);
				}
				public static iAngle operator-(iAngle A,float F)
				{
					return new iAngle(A.X-F,A.Y-F,A.Z-F);
				}
				public static iAngle operator-(float F,iAngle A)
				{
					return new iAngle(F-A.X,F-A.Y,F-A.Z);
				}
				public static iAngle operator*(iAngle A,float F)
				{
					return new iAngle(A.X*F,A.Y*F,A.Z*F);
				}
				public static iAngle operator/(iAngle A,float F)
				{
					return new iAngle(A.X/F,A.Y/F,A.Z/F);
				}
				public override string ToString()
				{
					return this.X.ToString()+","+this.Y.ToString()+","+this.Z.ToString();
				}
			}
			public struct iVector
			{
				public iPoint POINT;
				public iPoint LENGTH;
			}
		}
	}
}