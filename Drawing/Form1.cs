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
	public partial class Form1:Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void _lr1_Click(object sender,EventArgs e)
		{
			(new LR1()).Show();
		}
		private void _lr2_Click(object sender,EventArgs e)
		{
			(new LR2()).Show();
		}
		private void _lr3_Click(object sender,EventArgs e)
		{
			(new LR3()).Show();
		}
	}
}