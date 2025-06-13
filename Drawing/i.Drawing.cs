namespace i
{
	namespace Drawing
	{
		public class iVector
		{
			private float[] DATA;
			/// <summary>
			/// Количество элементов
			/// </summary>
			public int N
			{
				get
				{
					return this.DATA.Length;
				}
			}
			public float this[int N]
			{
				get
				{
					return this.DATA[N];
				}
				set
				{
					this.DATA[N]=value;
				}
			}
			public iVector(params float[] Data)
			{
				this.DATA=new float[Data.Length];
				for(int i1=0;i1<this.N;i1++)
				{
					this.DATA[i1]=Data[i1];
				}
			}
			public iVector(int N)
			{
				this.DATA=new float[N];
			}
			public iVector(int N,float Value)
				: this(N)
			{
				this.Set(Value);
			}
			public iVector(iVector Vector)
			{
				this.DATA=new float[Vector.N];
				for(int i1=0;i1<this.N;i1++)
				{
					this[i1]=Vector[i1];
				}
			}
			public void Set(float Value)
			{
				for(int i1=0;i1<this.N;i1++)
				{
					this[i1]=Value;
				}
			}
			public iVector Negative()
			{
				iVector V=new iVector(this.N);
				for(int i1=0;i1<V.N;i1++)
				{
					V[i1]=-this[i1];
				}
				return V;
			}
			public static iVector Add(iVector Vector,float Value)
			{
				iVector V=new iVector(Vector.N);
				for(int i1=0;i1<V.N;i1++)
				{
					V[i1]=Vector[i1]+Value;
				}
				return V;
			}
			public static iVector Add(iVector V1,iVector V2)
			{
				if(V1.N==V2.N)
				{
					iVector V=new iVector(V1.N);
					for(int i1=0;i1<V.N;i1++)
					{
						V[i1]=V1[i1]+V2[i1];
					}
					return V;
				}
				else
				{
					throw new System.Exception();
				}
			}
			public static iVector Subtract(iVector V1,float Value)
			{
				iVector V=new iVector(V1.N);
				for(int i1=0;i1<V.N;i1++)
				{
					V[i1]=V1[i1]-Value;
				}
				return V;
			}
			public static iVector Subtract(float Value,iVector Vector)
			{
				iVector V=new iVector(Vector.N);
				for(int i1=0;i1<V.N;i1++)
				{
					V[i1]=Value-Vector[i1];
				}
				return V;
			}
			public static iVector Subtract(iVector V1,iVector V2)
			{
				if(V1.N==V2.N)
				{
					iVector V=new iVector(V1.N);
					for(int i1=0;i1<V.N;i1++)
					{
						V[i1]=V1[i1]-V2[i1];
					}
					return V;
				}
				else
				{
					throw new System.Exception();
				}
			}
			public static iVector Multiply(iVector Vector,float Value)
			{
				iVector V=new iVector(Vector.N);
				for(int i1=0;i1<V.N;i1++)
				{
					V[i1]=Vector[i1]*Value;
				}
				return V;
			}
			public static float Multiply(iVector V1,iVector V2)
			{
				if(V1.N==V2.N)
				{
					float Value=0;
					for(int i1=0;i1<V1.N;i1++)
					{
						Value+=V1[i1]*V2[i1];
					}
					return Value;
				}
				else
				{
					throw new System.Exception();
				}
			}
			public static iVector Divide(iVector Vector,float Value)
			{
				iVector V=new iVector(Vector.N);
				for(int i1=0;i1<V.N;i1++)
				{
					V[i1]=Vector[i1]/Value;
				}
				return V;
			}
			public static iVector operator-(iVector V)
			{
				return V.Negative();
			}
			public static iVector operator+(iVector V,float Value)
			{
				return iVector.Add(V,Value);
			}
			public static iVector operator+(float Value,iVector V)
			{
				return iVector.Add(V,Value);
			}
			public static iVector operator+(iVector V1,iVector V2)
			{
				return iVector.Add(V1,V2);
			}
			public static iVector operator-(iVector V,float Value)
			{
				return iVector.Subtract(V,Value);
			}
			public static iVector operator-(float Value,iVector V)
			{
				return iVector.Subtract(Value,V);
			}
			public static iVector operator-(iVector V1,iVector V2)
			{
				return iVector.Subtract(V1,V2);
			}
			public static iVector operator*(iVector V,float Value)
			{
				return iVector.Multiply(V,Value);
			}
			public static iVector operator*(float Value,iVector V)
			{
				return iVector.Multiply(V,Value);
			}
			public static float operator*(iVector V1,iVector V2)
			{
				return iVector.Multiply(V1,V2);
			}
			public static iVector operator/(iVector V,float Value)
			{
				return iVector.Divide(V,Value);
			}
		}
		public class iMatrix
		{
			private float[,] DATA;
			/// <summary>
			/// Количество строк
			/// </summary>
			public int N1
			{
				get
				{
					return this.DATA.GetLength(0);
				}
			}
			/// <summary>
			/// Количество столбцов
			/// </summary>
			public int N2
			{
				get
				{
					return this.DATA.GetLength(1);
				}
			}
			public float this[int N1,int N2]
			{
				get
				{
					return this.DATA[N1,N2];
				}
				set
				{
					this.DATA[N1,N2]=value;
				}
			}
			public iMatrix(float[,] Data)
			{
				this.DATA=new float[Data.GetLength(0),Data.GetLength(1)];
				for(int i1=0;i1<this.N1;i1++)
				{
					for(int i2=0;i2<this.N2;i2++)
					{
						this.DATA[i1,i2]=Data[i1,i2];
					}
				}
			}
			public iMatrix(int N1,int N2)
			{
				this.DATA=new float[N1,N2];
			}
			public iMatrix(int N1,int N2,float Value) : this(N1,N2)
			{
				this.Set(Value);
			}
			public iMatrix(iMatrix Matrix)
			{
				this.DATA=new float[Matrix.N1,Matrix.N2];
				for(int i1=0;i1<this.N1;i1++)
				{
					for(int i2=0;i2<this.N2;i2++)
					{
						this[i1,i2]=Matrix[i1,i2];
					}
				}
			}
			public void Set(float Value)
			{
				for(int i1=0;i1<this.N1;i1++)
				{
					for(int i2=0;i2<this.N2;i2++)
					{
						this[i1,i2]=Value;
					}
				}
			}
			public iVector Row(int N1)
			{
				iVector V=new iVector(this.N2);
				for(int i1=0;i1<V.N;i1++)
				{
					V[i1]=this[N1,i1];
				}
				return V;
			}
			public iVector Column(int N2)
			{
				iVector V=new iVector(this.N1);
				for(int i1=0;i1<V.N;i1++)
				{
					V[i1]=this[i1,N2];
				}
				return V;
			}
			public iMatrix T()
			{
				iMatrix M=new iMatrix(this.N2,this.N1);
				for(int i1=0;i1<this.N1;i1++)
				{
					for(int i2=0;i2<this.N2;i2++)
					{
						M[i2,i1]=this[i1,i2];
					}
				}
				return M;
			}
			public iMatrix Negative()
			{
				iMatrix M=new iMatrix(this.N1,this.N2);
				for(int i1=0;i1<M.N1;i1++)
				{
					for(int i2=0;i2<M.N2;i2++)
					{
						M[i1,i2]=-this[i1,i2];
					}
				}
				return M;
			}
			public static iMatrix Add(iMatrix V1,float Value)
			{
				iMatrix M=new iMatrix(V1.N1,V1.N2);
				for(int i1=0;i1<M.N1;i1++)
				{
					for(int i2=0;i2<M.N2;i2++)
					{
						M[i1,i2]=V1[i1,i2]+Value;
					}
				}
				return M;
			}
			public static iMatrix Add(iMatrix V1,iMatrix V2)
			{
				if(V1.N1==V2.N1&&V1.N2==V2.N2)
				{
					iMatrix M=new iMatrix(V1.N1,V1.N2);
					for(int i1=0;i1<M.N1;i1++)
					{
						for(int i2=0;i2<M.N2;i2++)
						{
							M[i1,i2]=V1[i1,i2]+V2[i1,i2];
						}
					}
					return M;
				}
				else
				{
					throw new System.Exception();
				}
			}
			public static iMatrix Subtract(iMatrix V1,float Value)
			{
				iMatrix M=new iMatrix(V1.N1,V1.N2);
				for(int i1=0;i1<M.N1;i1++)
				{
					for(int i2=0;i2<M.N2;i2++)
					{
						M[i1,i2]=V1[i1,i2]-Value;
					}
				}
				return M;
			}
			public static iMatrix Subtract(float Value,iMatrix V1)
			{
				iMatrix M=new iMatrix(V1.N1,V1.N2);
				for(int i1=0;i1<M.N1;i1++)
				{
					for(int i2=0;i2<M.N2;i2++)
					{
						M[i1,i2]=Value-V1[i1,i2];
					}
				}
				return M;
			}
			public static iMatrix Subtract(iMatrix V1,iMatrix V2)
			{
				if(V1.N1==V2.N1&&V1.N2==V2.N2)
				{
					iMatrix M=new iMatrix(V1.N1,V1.N2);
					for(int i1=0;i1<M.N1;i1++)
					{
						for(int i2=0;i2<M.N2;i2++)
						{
							M[i1,i2]=V1[i1,i2]-V2[i1,i2];
						}
					}
					return M;
				}
				else
				{
					throw new System.Exception();
				}
			}
			public static iMatrix Multiply(iMatrix Matrix,float Value)
			{
				iMatrix M=new iMatrix(Matrix.N1,Matrix.N2);
				for(int i1=0;i1<M.N1;i1++)
				{
					for(int i2=0;i2<M.N2;i2++)
					{
						M[i1,i2]=Matrix[i1,i2]*Value;
					}
				}
				return M;
			}
			public static iVector Multiply(iMatrix Matrix,iVector Vector)
			{
				if(Matrix.N2==Vector.N)
				{
					iVector V=new iVector(Matrix.N1);
					for(int i1=0;i1<Matrix.N1;i1++)
					{
						V[i1]=Matrix.Row(i1)*Vector;
					}
					return V;
				}
				else
				{
					throw new System.Exception();
				}
			}
			public static iVector Multiply(iVector Vector,iMatrix Matrix)
			{
				if(Matrix.N1==Vector.N)
				{
					iVector V=new iVector(Matrix.N2);
					for(int i1=0;i1<Matrix.N2;i1++)
					{
						V[i1]=Matrix.Column(i1)*Vector;
					}
					return V;
				}
				else
				{
					throw new System.Exception();
				}
			}
			public static iMatrix Multiply(iMatrix M1,iMatrix M2)
			{
				if(M1.N1==M2.N2&&M1.N2==M2.N1)
				{
					iMatrix M=new iMatrix(M1.N1,M2.N2);
					for(int i1=0;i1<M1.N1;i1++)
					{
						for(int i2=0;i2<M2.N2;i2++)
						{
							M[i1,i2]=M1.Row(i1)*M2.Column(i2);
						}
					}
					return M;
				}
				else
				{
					throw new System.Exception();
				}
			}
			public static iMatrix Divide(iMatrix Matrix,float Value)
			{
				iMatrix M=new iMatrix(Matrix.N1,Matrix.N2);
				for(int i1=0;i1<M.N1;i1++)
				{
					for(int i2=0;i2<M.N2;i2++)
					{
						M[i1,i2]=Matrix[i1,i2]/Value;
					}
				}
				return M;
			}
			public static iMatrix operator-(iMatrix M)
			{
				return M.Negative();
			}
			public static iMatrix operator+(iMatrix M,float Value)
			{
				return iMatrix.Add(M,Value);
			}
			public static iMatrix operator+(iMatrix M1,iMatrix M2)
			{
				return iMatrix.Add(M1,M2);
			}
			public static iMatrix operator-(iMatrix M,float Value)
			{
				return iMatrix.Subtract(M,Value);
			}
			public static iMatrix operator-(float Value,iMatrix M)
			{
				return iMatrix.Subtract(Value,M);
			}
			public static iMatrix operator-(iMatrix M1,iMatrix M2)
			{
				return iMatrix.Subtract(M1,M2);
			}
			public static iMatrix operator*(iMatrix M,float Value)
			{
				return iMatrix.Multiply(M,Value);
			}
			public static iMatrix operator*(float Value,iMatrix M)
			{
				return iMatrix.Multiply(M,Value);
			}
			public static iVector operator*(iMatrix M,iVector V)
			{
				return iMatrix.Multiply(M,V);
			}
			public static iVector operator*(iVector V,iMatrix M)
			{
				return iMatrix.Multiply(V,M);
			}
			public static iMatrix operator*(iMatrix M1,iMatrix M2)
			{
				return iMatrix.Multiply(M1,M2);
			}
			public static iMatrix operator/(iMatrix M,float Value)
			{
				return iMatrix.Divide(M,Value);
			}
		}
		public struct iAngle
		{
			private float VALUE;
			public iAngle(float A)
			{
				this.VALUE=0;
				this.Value=A;
			}
			public iAngle(iAngle A)
			{
				this.VALUE=0;
				this.Value=A.VALUE;
			}
			private void Normalize()
			{
				while(this.VALUE>=System.Math.PI*2)
				{
					this.VALUE-=(float)System.Math.PI*2;
				}
				while(this.VALUE<0)
				{
					this.VALUE+=(float)System.Math.PI*2;
				}
			}
			private float Value
			{
				get
				{
					return this.VALUE;
				}
				set
				{
					this.VALUE=value;
					this.Normalize();
				}
			}
			public float ToDegree()
			{
				return (float)(this.Value*(180/System.Math.PI));
			}
			public static iAngle FromDegree(float Degree)
			{
				return new iAngle((float)(Degree/(180/System.Math.PI)));
			}
			public static implicit operator float(iAngle A)
			{
				return A.Value;
			}
			public static implicit operator iAngle(float F)
			{
				return new iAngle(F);
			}
			public static iAngle operator-(iAngle A)
			{
				return new iAngle(-A.Value);
			}
			public static iAngle operator+(iAngle A1,iAngle A2)
			{
				return new iAngle(A1.Value+A2.Value);
			}
			public static iAngle operator+(iAngle A,float F)
			{
				return new iAngle(A.Value+F);
			}
			public static iAngle operator+(float F,iAngle A)
			{
				return new iAngle(A.Value+F);
			}
			public static iAngle operator-(iAngle A1,iAngle A2)
			{
				return new iAngle(A1.Value-A2.Value);
			}
			public static iAngle operator-(float F,iAngle A)
			{
				return new iAngle(F-A.Value);
			}
			public static iAngle operator-(iAngle A,float F)
			{
				return new iAngle(A.Value-F);
			}
			public static iAngle operator*(iAngle A,float F)
			{
				return new iAngle(A.Value*F);
			}
			public static iAngle operator*(float F,iAngle A)
			{
				return new iAngle(A.Value*F);
			}
			public static iAngle operator/(iAngle A,float F)
			{
				return new iAngle(A.Value/F);
			}
			public override string ToString()
			{
				return this.Value.ToString();
			}
		}
		public class iCounter
		{
			private int COUNT;
			private int MAX;
			public iCounter(int Count,int Max)
			{
				this.COUNT=Count;
				this.MAX=Max;
			}
			public iCounter(int Max)
			{
				this.MAX=Max;
			}
			public int Tick()
			{
				int I=this.COUNT;
				if(++this.COUNT>=this.MAX)
				{
					this.COUNT-=this.MAX;
				}
				return I;
			}
			public void Null()
			{
				this.COUNT=0;
			}
			public int Get()
			{
				return this.COUNT;
			}
		}
		public class iDraw
		{
			private System.Windows.Forms.PictureBox PB;
			private System.Threading.Timer TIMER;
			private System.Action<System.Drawing.Graphics> A;
			public iDraw(System.Windows.Forms.PictureBox PB)
			{
				this.PB=PB;
				this.TIMER=null;
			}
			public void Start(System.Action<System.Drawing.Graphics> A,int Due,int Period)
			{
				if(this.TIMER==null)
				{
					this.TIMER=new System.Threading.Timer(this.DO,null,Due,Period);
					this.A=A;
					this.PB.Paint+=new System.Windows.Forms.PaintEventHandler(Paint);
				}
			}
			private void DO(object State)
			{
				lock(PB)
				{
					this.PB.Invalidate();
				}
			}
			void Paint(object sender,System.Windows.Forms.PaintEventArgs e)
			{
				this.A(e.Graphics);
			}
			public void Stop()
			{
				if(this.TIMER!=null)
				{
					this.TIMER.Dispose();
					this.TIMER=null;
					this.A=null;
					this.PB.Paint-=new System.Windows.Forms.PaintEventHandler(Paint);
				}
			}
		}
	}
}