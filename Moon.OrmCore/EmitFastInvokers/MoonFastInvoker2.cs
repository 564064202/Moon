//*
// * 由SharpDevelop创建。
// * 用户： qinshichuan
// * 日期: 2012-11-28
// * 时间: 22:15
// * 
// * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
// */
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Common;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Reflection.Emit;
//namespace Moon.Orm
//{
//	/// <summary>
//	/// MoonFastInvoker,给实体赋值
//	/// </summary>
//	public class MoonFastInvoker2
//	{
//		/// <summary>
//		/// SetMethodHandler
//		/// </summary>
//		public delegate void SetMethodHandler(object instance,object value);
//		private const string set_="set_";
//		private const string SET_METHOD="SetMethod";
//		/// <summary>
//		/// 设置指定类型实体的某一个属性的值
//		/// </summary>
//		/// <param name="t">对象</param>
//		/// <param name="property">对象的属性</param>
//		/// <param name="value">对象的值</param>
//		public static void SetTValue(object t,PropertyInfo property,object value){
//			Type myType=t.GetType();
//			long typeCode=RuntimeHelpers.GetHashCode(myType);
//			string key=typeCode+property.Name;
//			
//			bool exist=false;
//			SetMethodHandler handler=null;
//			lock(SetMethodHandler_DIC_LOCK){
//				if(SetMethodHandler_DIC.ContainsKey(key)){
//					handler=SetMethodHandler_DIC[key];
//					exist=true;
//				}
//			}
//			if (exist==false) {
//				Type propertyType=property.PropertyType;
//				MethodInfo propertySetMetod=property.GetSetMethod();
//				
//				DynamicMethod dy=new DynamicMethod(SET_METHOD,null,new Type[]{myType,typeof(object)});
//				ILGenerator il=dy.GetILGenerator();
//				LocalBuilder local = il.DeclareLocal(propertyType, true);
//				il.Emit(OpCodes.Ldarg_1);
//				if (propertyType.IsValueType)
//				{
//					il.Emit(OpCodes.Unbox_Any, propertyType);// 如果是值类型，拆箱 string = (string)object;
//				}
//				else
//				{
//					il.Emit(OpCodes.Castclass, propertyType);// 如果是引用类型，转换 Class = object as Class
//				}
//				il.Emit(OpCodes.Stloc, local);// 将上面的拆箱或转换，赋值到本地变量，现在这个本地变量是一个与目标函数相同数据类型的字段了。
//				il.Emit(OpCodes.Ldarg_0);   // 加载第一个参数 owner
//				il.Emit(OpCodes.Ldloc, local);// 加载本地参数
//				il.EmitCall(OpCodes.Callvirt, propertySetMetod, null);//调用函数
//				il.Emit(OpCodes.Ret);   // 返回
//				
//				handler=dy.CreateDelegate(typeof(SetMethodHandler)) as SetMethodHandler;
//				lock(SetMethodHandler_DIC_LOCK){
//					if(SetMethodHandler_DIC.ContainsKey(key)){
//						handler=SetMethodHandler_DIC[key];
//						
//					}else{
//						SetMethodHandler_DIC[key]=handler;
//					}
//				}
//
//			}
//			handler.Invoke(t,value);
//		}
//		/// <summary>
//		/// 设置指定对象指定属性的值
//		/// </summary>
//		/// <param name="t">指定的对象</param>
//		/// <param name="propertyName">属性名</param>
//		/// <param name="value">属性值</param>
//		public static void SetTValue(object t,string propertyName,object value){
//			Type myType=t.GetType();
//			long typeCode=RuntimeHelpers.GetHashCode(myType);
//			string key=typeCode+propertyName;
//			
//			bool exist=false;
//			SetMethodHandler handler=null;
//			lock(SetMethodHandler_DIC_LOCK){
//				if(SetMethodHandler_DIC.ContainsKey(key)){
//					handler=SetMethodHandler_DIC[key];
//					exist=true;
//				}
//			}
//			if (exist==false) {
//				
//				PropertyInfo property=myType.GetProperty(propertyName,BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
//				if (property==null) {
//					return;
//				}
//				Type propertyType=property.PropertyType;
//				MethodInfo propertySetMetod=property.GetSetMethod();
//				
//				DynamicMethod dy=new DynamicMethod(SET_METHOD,null,new Type[]{myType,typeof(object)});
//				ILGenerator il=dy.GetILGenerator();
//				LocalBuilder local = il.DeclareLocal(propertyType, true);
//				il.Emit(OpCodes.Ldarg_1);
//				if (propertyType.IsValueType)
//				{
//					il.Emit(OpCodes.Unbox_Any, propertyType);// 如果是值类型，拆箱 string = (string)object;
//				}
//				else
//				{
//					il.Emit(OpCodes.Castclass, propertyType);// 如果是引用类型，转换 Class = object as Class
//				}
//				il.Emit(OpCodes.Stloc, local);// 将上面的拆箱或转换，赋值到本地变量，现在这个本地变量是一个与目标函数相同数据类型的字段了。
//				il.Emit(OpCodes.Ldarg_0);   // 加载第一个参数 owner
//				il.Emit(OpCodes.Ldloc, local);// 加载本地参数
//				il.EmitCall(OpCodes.Callvirt, propertySetMetod, null);//调用函数
//				il.Emit(OpCodes.Ret);   // 返回
//				
//				handler=dy.CreateDelegate(typeof(SetMethodHandler)) as SetMethodHandler;
//				lock(SetMethodHandler_DIC_LOCK){
//					if(SetMethodHandler_DIC.ContainsKey(key)){
//						handler=SetMethodHandler_DIC[key];
//						
//					}else{
//						SetMethodHandler_DIC[key]=handler;
//					}
//				}
//
//			}
//			handler.Invoke(t,value);
//		}
//		 
//		/// <summary>
//		/// SetMethodHandler_DIC
//		/// </summary>
//		public static Dictionary<string,SetMethodHandler> SetMethodHandler_DIC=new Dictionary<string, SetMethodHandler>();
//		/// <summary>
//		/// SetMethodHandler_DIC_LOCK
//		/// </summary>
//		public static readonly object SetMethodHandler_DIC_LOCK=new object();
//	}
//}
