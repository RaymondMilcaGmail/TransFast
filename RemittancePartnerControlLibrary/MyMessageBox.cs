using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TransFastControlLibrary
{
	public partial class MyMessageBox : Form
	{
		public enum MyMessageBoxButton { Ok = 1, OkCancel = 2, YesNo = 3, YesCancel = 4 }
		public enum MyMessageType { ForOK = 1, ForExclamation = 2, ForCritical = 3, ForInfo = 4, ForQues = 5 }
		public enum MyMessageResponse { Ok = 1, Yes = 2, Cancel = 3, No = 4 }

		static MyMessageBox MyForm;
		static MyMessageResponse ButtonResponse;
		//public static Form OwnerForm = null;
		int btn1value = 0;
		int btn2value = 0;

		public MyMessageBox()
		{
			InitializeComponent();
		}

		#region Message Box with owner form
		public static MyMessageResponse ShowMe(Form OwnerForm, string MyMessage, string MessageCaption, MyMessageBoxButton MsgButton, MyMessageType MsgType)
		{
			MyForm = new MyMessageBox();
			MyForm.lblMsg.Text = MyForm.ParseMessage(MyMessage);
			MyForm.Text = MessageCaption;

			#region Design the button of the MessageBox
			if (MsgButton == MyMessageBoxButton.Ok)
			{
				MyForm.Btn1.Text = "OK";
				MyForm.Btn1.Visible = true;
				MyForm.Btn2.Visible = false;
				MyForm.btn1value = 1;
				MyForm.btn2value = 0;
			}
			else
			{
				if (MsgButton == MyMessageBoxButton.OkCancel)
				{
					MyForm.Btn1.Text = "Cancel";
					MyForm.Btn2.Text = "OK";
					MyForm.Btn1.Visible = true;
					MyForm.Btn2.Visible = true;
					MyForm.btn1value = 3;
					MyForm.btn2value = 1;
				}
				else
				{
					if (MsgButton == MyMessageBoxButton.YesCancel)
					{
						MyForm.Btn1.Text = "Cancel";
						MyForm.Btn2.Text = "Yes";
						MyForm.Btn1.Visible = true;
						MyForm.Btn2.Visible = true;
						MyForm.btn1value = 3;
						MyForm.btn2value = 2;
					}
					else
					{
						if (MsgButton == MyMessageBoxButton.YesNo)
						{
							MyForm.Btn1.Text = "No";
							MyForm.Btn2.Text = "Yes";
							MyForm.Btn1.Visible = true;
							MyForm.Btn2.Visible = true;
							MyForm.btn1value = 4;
							MyForm.btn2value = 2;
						}
					}
				}
			}
			#endregion

			#region Desing the Message Type
			if (MsgType == MyMessageType.ForCritical)
			{
				MyForm.picStop.Visible = true;
				MyForm.picExcla.Visible = false;
				MyForm.picInfo.Visible = false;
				MyForm.picOk.Visible = false;
				MyForm.picQuestion.Visible = false;
				MyForm.lblMsg.ForeColor = Color.Red;
			}
			else
			{
				if (MsgType == MyMessageType.ForExclamation)
				{
					MyForm.picStop.Visible = false;
					MyForm.picExcla.Visible = true;
					MyForm.picInfo.Visible = false;
					MyForm.picOk.Visible = false;
					MyForm.picQuestion.Visible = false;
					MyForm.lblMsg.ForeColor = Color.SteelBlue;
				}
				else
				{
					if (MsgType == MyMessageType.ForInfo)
					{
						MyForm.picStop.Visible = false;
						MyForm.picExcla.Visible = false;
						MyForm.picInfo.Visible = true;
						MyForm.picOk.Visible = false;
						MyForm.picQuestion.Visible = false;
						MyForm.lblMsg.ForeColor = Color.SteelBlue;
					}
					else
					{
						if (MsgType == MyMessageType.ForOK)
						{
							MyForm.picStop.Visible = false;
							MyForm.picExcla.Visible = false;
							MyForm.picInfo.Visible = false;
							MyForm.picOk.Visible = true;
							MyForm.picQuestion.Visible = false;
							MyForm.lblMsg.ForeColor = Color.SteelBlue;
						}
						else if (MsgType == MyMessageType.ForQues)
						{
							MyForm.picStop.Visible = false;
							MyForm.picExcla.Visible = false;
							MyForm.picInfo.Visible = false;
							MyForm.picOk.Visible = false;
							MyForm.picQuestion.Visible = true;
						}

					}
				}
			}
			#endregion
			//if(OwnerForm!=null)

			MyForm.ShowDialog(OwnerForm);
			return ButtonResponse;
		}

		public static MyMessageResponse ShowMe(Form OwnerForm, string MyMessage)
		{
			MyForm = new MyMessageBox();
			MyForm.lblMsg.Text = MyForm.ParseMessage(MyMessage);
			MyForm.Text = "MESSAGEBOX";

			MyForm.Btn1.Text = "OK";
			MyForm.Btn1.Visible = true;
			MyForm.Btn2.Visible = false;
			MyForm.btn1value = 1;
			MyForm.btn2value = 0;

			MyForm.picStop.Visible = false;
			MyForm.picExcla.Visible = false;
			MyForm.picInfo.Visible = false;
			MyForm.picOk.Visible = true;

			MyForm.lblMsg.ForeColor = Color.SteelBlue;
			MyForm.ShowDialog(OwnerForm);
			return ButtonResponse;
		}

		public static MyMessageResponse ShowMe(Form OwnerForm, string MyMessage, string MessageCaption)
		{
			MyForm = new MyMessageBox();
			MyForm.lblMsg.Text = MyForm.ParseMessage(MyMessage);
			MyForm.Text = MessageCaption;

			MyForm.Btn1.Text = "OK";
			MyForm.Btn1.Visible = true;
			MyForm.Btn2.Visible = false;
			MyForm.btn1value = 1;
			MyForm.btn2value = 0;

			MyForm.picStop.Visible = false;
			MyForm.picExcla.Visible = false;
			MyForm.picInfo.Visible = false;
			MyForm.picOk.Visible = true;

			MyForm.lblMsg.ForeColor = Color.SteelBlue;
			MyForm.ShowDialog(OwnerForm);
			return ButtonResponse;
		}

		public static MyMessageResponse ShowMe(Form OwnerForm, string MyMessage, string MessageCaption, MyMessageBoxButton MsgButton)
		{
			MyForm = new MyMessageBox();
			MyForm.lblMsg.Text = MyForm.ParseMessage(MyMessage);
			MyForm.Text = MessageCaption;

			#region Design the button of the MessageBox
			if (MsgButton == MyMessageBoxButton.Ok)
			{
				MyForm.Btn1.Text = "OK";
				MyForm.Btn1.Visible = true;
				MyForm.Btn2.Visible = false;
				MyForm.btn1value = 1;
				MyForm.btn2value = 0;
			}
			else
			{
				if (MsgButton == MyMessageBoxButton.OkCancel)
				{
					MyForm.Btn1.Text = "Cancel";
					MyForm.Btn2.Text = "OK";
					MyForm.Btn1.Visible = true;
					MyForm.Btn2.Visible = true;
					MyForm.btn1value = 3;
					MyForm.btn2value = 1;
				}
				else
				{
					if (MsgButton == MyMessageBoxButton.YesCancel)
					{
						MyForm.Btn1.Text = "Cancel";
						MyForm.Btn2.Text = "Yes";
						MyForm.Btn1.Visible = true;
						MyForm.Btn2.Visible = true;
						MyForm.btn1value = 3;
						MyForm.btn2value = 2;
					}
					else
					{
						if (MsgButton == MyMessageBoxButton.YesNo)
						{
							MyForm.Btn1.Text = "No";
							MyForm.Btn2.Text = "Yes";
							MyForm.Btn1.Visible = true;
							MyForm.Btn2.Visible = true;
							MyForm.btn1value = 4;
							MyForm.btn2value = 2;
						}
					}
				}
			}
			#endregion

			MyForm.picStop.Visible = false;
			MyForm.picExcla.Visible = false;
			MyForm.picInfo.Visible = false;
			MyForm.picQuestion.Visible = false;
			MyForm.picOk.Visible = true;

			MyForm.lblMsg.ForeColor = Color.SteelBlue;
			MyForm.ShowDialog(OwnerForm);
			return ButtonResponse;
		}
		#endregion

		#region Message Box without owner form
		public static MyMessageResponse ShowMe(string MyMessage, string MessageCaption, MyMessageBoxButton MsgButton, MyMessageType MsgType)
		{
			MyForm = new MyMessageBox();
			MyForm.lblMsg.Text = MyForm.ParseMessage(MyMessage);
			MyForm.Text = MessageCaption;

			#region Design the button of the MessageBox
			if (MsgButton == MyMessageBoxButton.Ok)
			{
				MyForm.Btn1.Text = "OK";
				MyForm.Btn1.Visible = true;
				MyForm.Btn2.Visible = false;
				MyForm.btn1value = 1;
				MyForm.btn2value = 0;
			}
			else
			{
				if (MsgButton == MyMessageBoxButton.OkCancel)
				{
					MyForm.Btn1.Text = "Cancel";
					MyForm.Btn2.Text = "OK";
					MyForm.Btn1.Visible = true;
					MyForm.Btn2.Visible = true;
					MyForm.btn1value = 3;
					MyForm.btn2value = 1;
				}
				else
				{
					if (MsgButton == MyMessageBoxButton.YesCancel)
					{
						MyForm.Btn1.Text = "Cancel";
						MyForm.Btn2.Text = "Yes";
						MyForm.Btn1.Visible = true;
						MyForm.Btn2.Visible = true;
						MyForm.btn1value = 3;
						MyForm.btn2value = 2;
					}
					else
					{
						if (MsgButton == MyMessageBoxButton.YesNo)
						{
							MyForm.Btn1.Text = "No";
							MyForm.Btn2.Text = "Yes";
							MyForm.Btn1.Visible = true;
							MyForm.Btn2.Visible = true;
							MyForm.btn1value = 4;
							MyForm.btn2value = 2;
						}
					}
				}
			}
			#endregion

			#region Desing the Message Type
			if (MsgType == MyMessageType.ForCritical)
			{
				MyForm.picStop.Visible = true;
				MyForm.picExcla.Visible = false;
				MyForm.picInfo.Visible = false;
				MyForm.picOk.Visible = false;
				MyForm.picQuestion.Visible = false;
				MyForm.lblMsg.ForeColor = Color.Red;
			}
			else
			{
				if (MsgType == MyMessageType.ForExclamation)
				{
					MyForm.picStop.Visible = false;
					MyForm.picExcla.Visible = true;
					MyForm.picInfo.Visible = false;
					MyForm.picOk.Visible = false;
					MyForm.picQuestion.Visible = false;
					MyForm.lblMsg.ForeColor = Color.SteelBlue;
				}
				else
				{
					if (MsgType == MyMessageType.ForInfo)
					{
						MyForm.picStop.Visible = false;
						MyForm.picExcla.Visible = false;
						MyForm.picInfo.Visible = true;
						MyForm.picOk.Visible = false;
						MyForm.picQuestion.Visible = false;
						MyForm.lblMsg.ForeColor = Color.SteelBlue;
					}
					else
					{
						if (MsgType == MyMessageType.ForOK)
						{
							MyForm.picStop.Visible = false;
							MyForm.picExcla.Visible = false;
							MyForm.picInfo.Visible = false;
							MyForm.picOk.Visible = true;
							MyForm.picQuestion.Visible = false;
							MyForm.lblMsg.ForeColor = Color.SteelBlue;
						}
						else if (MsgType == MyMessageType.ForQues)
						{
							MyForm.picStop.Visible = false;
							MyForm.picExcla.Visible = false;
							MyForm.picInfo.Visible = false;
							MyForm.picOk.Visible = false;
							MyForm.picQuestion.Visible = true;
						}

					}
				}
			}
			#endregion
			//if(OwnerForm!=null)

			MyForm.ShowDialog();
			return ButtonResponse;
		}

		public static MyMessageResponse ShowMe(string MyMessage)
		{
			MyForm = new MyMessageBox();
			MyForm.lblMsg.Text = MyForm.ParseMessage(MyMessage);
			MyForm.Text = "MESSAGEBOX";

			MyForm.Btn1.Text = "OK";
			MyForm.Btn1.Visible = true;
			MyForm.Btn2.Visible = false;
			MyForm.btn1value = 1;
			MyForm.btn2value = 0;

			MyForm.picStop.Visible = false;
			MyForm.picExcla.Visible = false;
			MyForm.picInfo.Visible = false;
			MyForm.picOk.Visible = true;

			MyForm.lblMsg.ForeColor = Color.SteelBlue;
			MyForm.ShowDialog();
			return ButtonResponse;
		}

		public static MyMessageResponse ShowMe(string MyMessage, string MessageCaption)
		{
			MyForm = new MyMessageBox();
			MyForm.lblMsg.Text = MyForm.ParseMessage(MyMessage);
			MyForm.Text = MessageCaption;

			MyForm.Btn1.Text = "OK";
			MyForm.Btn1.Visible = true;
			MyForm.Btn2.Visible = false;
			MyForm.btn1value = 1;
			MyForm.btn2value = 0;

			MyForm.picStop.Visible = false;
			MyForm.picExcla.Visible = false;
			MyForm.picInfo.Visible = false;
			MyForm.picOk.Visible = true;

			MyForm.lblMsg.ForeColor = Color.SteelBlue;
			MyForm.ShowDialog();
			return ButtonResponse;
		}

		public static MyMessageResponse ShowMe(string MyMessage, string MessageCaption, MyMessageBoxButton MsgButton)
		{
			MyForm = new MyMessageBox();
			MyForm.lblMsg.Text = MyForm.ParseMessage(MyMessage);
			MyForm.Text = MessageCaption;

			#region Design the button of the MessageBox
			if (MsgButton == MyMessageBoxButton.Ok)
			{
				MyForm.Btn1.Text = "OK";
				MyForm.Btn1.Visible = true;
				MyForm.Btn2.Visible = false;
				MyForm.btn1value = 1;
				MyForm.btn2value = 0;
			}
			else
			{
				if (MsgButton == MyMessageBoxButton.OkCancel)
				{
					MyForm.Btn1.Text = "Cancel";
					MyForm.Btn2.Text = "OK";
					MyForm.Btn1.Visible = true;
					MyForm.Btn2.Visible = true;
					MyForm.btn1value = 3;
					MyForm.btn2value = 1;
				}
				else
				{
					if (MsgButton == MyMessageBoxButton.YesCancel)
					{
						MyForm.Btn1.Text = "Cancel";
						MyForm.Btn2.Text = "Yes";
						MyForm.Btn1.Visible = true;
						MyForm.Btn2.Visible = true;
						MyForm.btn1value = 3;
						MyForm.btn2value = 2;
					}
					else
					{
						if (MsgButton == MyMessageBoxButton.YesNo)
						{
							MyForm.Btn1.Text = "No";
							MyForm.Btn2.Text = "Yes";
							MyForm.Btn1.Visible = true;
							MyForm.Btn2.Visible = true;
							MyForm.btn1value = 4;
							MyForm.btn2value = 2;
						}
					}
				}
			}
			#endregion

			MyForm.picStop.Visible = false;
			MyForm.picExcla.Visible = false;
			MyForm.picInfo.Visible = false;
			MyForm.picQuestion.Visible = false;
			MyForm.picOk.Visible = true;

			MyForm.lblMsg.ForeColor = Color.SteelBlue;
			MyForm.ShowDialog();
			return ButtonResponse;
		}

		#endregion



		private string ParseMessage(string Msg)
		{
			string NewMsg = null;
			int xpos = 0;

			for (int xcount = 0; xcount < Msg.Length; xcount++)
			{
				NewMsg = NewMsg + Msg.Substring(xcount, 1);
				xpos = xpos + 1;

				if (xpos >= 40)
				{
					if (Msg.Substring(xcount, 1) == " ")
					{
						NewMsg = NewMsg + "\r\n";
						xpos = 0;
					}
				}
			}

			return NewMsg;
		}

		private void Btn1_Click(object sender, EventArgs e)
		{
			if (btn1value == 1)
			{
				ButtonResponse = MyMessageResponse.Ok;
			}
			else
			{
				if (btn1value == 2)
				{
					ButtonResponse = MyMessageResponse.Yes;
				}
				else
				{
					if (btn1value == 3)
					{
						ButtonResponse = MyMessageResponse.Cancel;
					}
					else
					{
						if (btn1value == 4)
						{
							ButtonResponse = MyMessageResponse.No;
						}
					}
				}
			}
			MyForm.Dispose();
		}

		private void Btn2_Click(object sender, EventArgs e)
		{
			if (btn2value == 1)
			{
				ButtonResponse = MyMessageResponse.Ok;
			}
			else
			{
				if (btn2value == 2)
				{
					ButtonResponse = MyMessageResponse.Yes;
				}
				else
				{
					if (btn2value == 3)
					{
						ButtonResponse = MyMessageResponse.Cancel;
					}
					else
					{
						if (btn2value == 4)
						{
							ButtonResponse = MyMessageResponse.No;
						}
					}
				}
			}
			MyForm.Dispose();
		}

		private void MyMessageBox_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (btn2value == 3)
			{
				ButtonResponse = MyMessageResponse.Cancel;
			}
			else
			{
				if (btn2value == 4)
				{
					ButtonResponse = MyMessageResponse.No;
				}
			}
		}

		private void MyMessageBox_Resize(object sender, EventArgs e)
		{
			this.lblBox.Size = this.Size;
			this.lblHeader.Width = this.Width;
			this.lblFooter.Width = this.Width;
			this.lblFooter.Top = (this.Height - this.lblFooter.Height);
		}

		private void MyMessageBox_Load(object sender, EventArgs e)
		{
			MyForm.lblHeader.Text = this.Text;
		}
	}
}