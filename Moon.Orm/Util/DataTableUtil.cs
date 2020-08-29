/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/8/13
 * 时间: 10:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;

namespace Moon.Orm.Util
{
	/// <summary>
	/// 将DataTable转换为List&lt;T&gt;的形式(采用Emit方式)
	/// </summary>
	public class DataTableUtil
	{
		/// <summary>
		/// 将DataTable转换为List&lt;T&gt;的形式(采用Emit方式)
		/// </summary>
		/// <param name="dt">dataTable</param>
		/// <typeparam name="T">对应的实体类</typeparam>
		/// <returns>List&lt;T&gt;</returns>
		public static List<T> ConvertDataTableToList<T>(DataTable dt)
		{
			List<T> list = new List<T>();
			if (dt == null) return list;
			DataTableEntityBuilder<T> eblist = DataTableEntityBuilder<T>.CreateBuilder(dt.Rows[0]);
			foreach (DataRow info in dt.Rows)
				list.Add(eblist.Build(info));
			return list;
		}

		internal class DataTableEntityBuilder<T>
		{
			private static readonly MethodInfo getValueMethod = typeof(DataRow).GetMethod("get_Item", new Type[] { typeof(int) });
			private static readonly MethodInfo isDBNullMethod = typeof(DataRow).GetMethod("IsNull", new Type[] { typeof(int) });
			private delegate T Load(DataRow dataRecord);

			private Load handler;
			private DataTableEntityBuilder() { }

			public T Build(DataRow dataRecord)
			{
				return handler(dataRecord);
			}

			public static DataTableEntityBuilder<T> CreateBuilder(DataRow dataRow)
			{
				DataTableEntityBuilder<T> dynamicBuilder = new DataTableEntityBuilder<T>();
				DynamicMethod method = new DynamicMethod("DynamicCreateEntity", typeof(T), new Type[] { typeof(DataRow) }, typeof(T), true);
				ILGenerator generator = method.GetILGenerator();
				LocalBuilder result = generator.DeclareLocal(typeof(T));
				generator.Emit(OpCodes.Newobj, typeof(T).GetConstructor(Type.EmptyTypes));
				generator.Emit(OpCodes.Stloc, result);

				for (int index = 0; index < dataRow.ItemArray.Length; index++)
				{
					PropertyInfo propertyInfo = typeof(T).GetProperty(dataRow.Table.Columns[index].ColumnName);
					Label endIfLabel = generator.DefineLabel();
					if (propertyInfo != null && propertyInfo.GetSetMethod() != null)
					{
						generator.Emit(OpCodes.Ldarg_0);
						generator.Emit(OpCodes.Ldc_I4, index);
						generator.Emit(OpCodes.Callvirt, isDBNullMethod);
						generator.Emit(OpCodes.Brtrue, endIfLabel);
						generator.Emit(OpCodes.Ldloc, result);
						generator.Emit(OpCodes.Ldarg_0);
						generator.Emit(OpCodes.Ldc_I4, index);
						generator.Emit(OpCodes.Callvirt, getValueMethod);
						generator.Emit(OpCodes.Unbox_Any, propertyInfo.PropertyType);
						generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());
						generator.MarkLabel(endIfLabel);
					}
				}
				generator.Emit(OpCodes.Ldloc, result);
				generator.Emit(OpCodes.Ret);
				dynamicBuilder.handler = (Load)method.CreateDelegate(typeof(Load));
				return dynamicBuilder;
			}
		}
	}
}
