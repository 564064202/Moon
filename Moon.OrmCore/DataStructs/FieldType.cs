using System;

namespace Moon.Orm
{
	/// <summary>
	/// �ֶ�����
	/// </summary>
	public enum FieldType
	{
		/// <summary>
		/// һ�����͵��ֶ�
		/// </summary>
		Common,
		/// <summary>
		/// Ψһ����
		/// </summary>
		OnlyPrimaryKey,
		/// <summary>
		/// ���е�һ������
		/// </summary>
		OnePrimaryKey,
		/// <summary>
		/// Ψһ���
		/// </summary>
		OnlyForeignKey,
		/// <summary>
		/// ���
		/// </summary>
		ForeignKey,
		/// <summary>
		/// �������ֶ�,�������ʽ��������
		/// </summary>
		FunctionField,
		/// <summary>
		/// *
		/// </summary>
		AllStar,
	}
}

