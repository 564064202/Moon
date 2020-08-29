/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-9-8
 * 时间: 12:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MoonDB;
using Moon.Orm;
namespace Enterprise
{
	/// <summary>
	/// Description of FrmEditCell.
	/// </summary>
	public partial class FrmEditCell : Form
	{
		private FrmEditCell()
		{
			
			this.MaximizeBox=false;
			this.TopMost=true;
			InitializeComponent();
		}
		private static FrmEditCell _frm;
		static FrmEditCell(){
			_frm=new FrmEditCell();
		}
		public static FrmEditCell GetSingleton()
		{
			return _frm;
		}
		private long _ID;
		private string _FieldName;
		private string _CellValue;
		private DataGridView _dgv;
		public void SetValue(long id,string fieldName,string cellValue,DataGridView dgv){
			tbCell.Text=cellValue;
			this.Text="当前修改字段:("+fieldName+"),ID为"+id;
			_CellValue=cellValue;
			_FieldName=fieldName;
			_ID=id;
			_dgv=dgv;
		}
		
		void FrmEditCellFormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel=true;
		}
		
		void TbCellMouseDoubleClick(object sender, MouseEventArgs e)
		{
			tbCell.SelectAll();
		}
		
		void BtnUpdateClick(object sender, EventArgs e)
		{
			string value=tbCell.Text;
			DateTime dt;
			bool markPrimaryField;
			if (_FieldName=="AddTime") {
				bool ok=DateTime.TryParse(value,out dt);
				if (!ok) {
					MessageBox.Show("数据格式错误","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					tbCell.SelectAll();
					tbCell.Focus();
					return;
				}else{
					LinkHistory his=new LinkHistory();
					his.AddTime=dt;
					his.SetOnlyMark(LinkHistoryTable.ID.Equal(_ID));
					DBFactory.Update(his);
					 
					
				}
			}
			else if (_FieldName=="MarkPrimaryField") {
				bool ok=bool.TryParse(value,out markPrimaryField);
				if (!ok) {
					MessageBox.Show("数据格式错误","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					tbCell.SelectAll();
					tbCell.Focus();
					return;
				}
				else{
					LinkHistory his=new LinkHistory();
					his.MarkPrimaryField=markPrimaryField;
					his.SetOnlyMark(LinkHistoryTable.ID.Equal(_ID));
					DBFactory.Update(his);
					 
				}
			}else{
				LinkHistory his=new LinkHistory();
				his.Set("["+_FieldName+"]",value);
				his.SetOnlyMark(LinkHistoryTable.ID.Equal(_ID));
				DBFactory.Update(his);
				 
			}
			_dgv.SelectedCells[0].Value=value;
			this.Hide();
		}
	}
}
