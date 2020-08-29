using System;
using System.Data;
using System.Data.Common;

namespace Moon.Orm
{
	/// <summary>
	/// ado�ķ�������
	/// </summary>
	public  class DbAdoMethod
	{
		/// <summary>
		/// ����
		/// </summary>
		/// <param name="linkString">�����ַ���</param>
		public DbAdoMethod(string linkString){
			this.LinkString=linkString;
		}
		/// <summary>
		/// ����һ��DbConnection
		/// </summary>
		/// <returns>DbConnection</returns>
		public virtual DbConnection CreateConnection(){
			return null;
		}
		/// <summary>
		/// ����һ��DbCommand
		/// </summary>
		/// <returns>DbCommand</returns>
		public virtual DbCommand CreateDbCommand(){
			return null;
		}
		/// <summary>
		/// ����һ��DbDataAdapter
		/// </summary>
		/// <returns>DbDataAdapter</returns>
		public virtual DbDataAdapter CreateDataAdapter(){
			return null;
		}
		/// <summary>
		/// ����һ��DbDataSourceEnumerator
		/// </summary>
		/// <returns>DbDataSourceEnumerator</returns>
		public virtual DbDataSourceEnumerator CreateDataSourceEnumerator (){
			return null;
		}
		/// <summary>
		/// ����һ��DbParameter
		/// </summary>
		/// <returns>DbParameter</returns>
		public virtual DbParameter CreateParameter (){
			return null;
		}
		/// <summary>
		/// ����һ��DbCommandBuilder
		/// </summary>
		/// <returns>DbCommandBuilder</returns>
		public virtual DbCommandBuilder CreateCommandBuilder()
		{
			return null;
		}
		/// <summary>
		/// �����ַ���
		/// </summary>
		public string LinkString{
			get;
			set;
		}
	}
}

