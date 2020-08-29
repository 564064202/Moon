/*
 * 由SharpDevelop创建。
 * 用户： qinshichuan
 * 日期: 2012-11-28
 * 时间: 22:15
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;
using System.Collections.Concurrent;

namespace Moon.Orm
{
    /// <summary>
    /// MoonFastInvoker,给实体赋值
    /// </summary>
    public class MoonFastInvoker<T> where T : new()
    {
        /// <summary>
        /// SetMethodHandler
        /// </summary>
        public delegate void SetMethodHandler(T instance, object value);
        private const string set_ = "set_";
        private const string SET_METHOD = "SetMethod";
        /// <summary>
        /// 设置指定类型实体的某一个属性的值
        /// </summary>
        /// <param name="t">对象</param>
        /// <param name="property">对象的属性</param>
        /// <param name="value">对象的值</param>
        public static void SetTValue(T t, PropertyInfo property, object value)
        {
            Type myType = typeof(T);
            long typeCode = RuntimeHelpers.GetHashCode(myType);
            string key = typeCode + property.Name;
            Type propertyType = property.PropertyType;
            bool exist = false;
            SetMethodHandler handler = null;
            if (SetMethodHandler_DIC.TryGetValue(key, out handler))
            {
                exist = true;
            }
            if (exist == false)
            {
                MethodInfo propertySetMetod = property.GetSetMethod();
                DynamicMethod dy = new DynamicMethod(SET_METHOD, null, new Type[] { myType, typeof(object) });
                ILGenerator il = dy.GetILGenerator();
                LocalBuilder local = il.DeclareLocal(propertyType, true);
                il.Emit(OpCodes.Ldarg_1);
                if (propertyType.IsValueType)
                {
                    il.Emit(OpCodes.Unbox_Any, propertyType);// 如果是值类型，拆箱 string = (string)object;
                }
                else
                {
                    il.Emit(OpCodes.Castclass, propertyType);// 如果是引用类型，转换 Class = object as Class
                }
                il.Emit(OpCodes.Stloc, local);// 将上面的拆箱或转换，赋值到本地变量，现在这个本地变量是一个与目标函数相同数据类型的字段了。
                il.Emit(OpCodes.Ldarg_0);   // 加载第一个参数 owner
                il.Emit(OpCodes.Ldloc, local);// 加载本地参数
                il.EmitCall(OpCodes.Callvirt, propertySetMetod, null);//调用函数
                il.Emit(OpCodes.Ret);   // 返回

                handler = dy.CreateDelegate(typeof(SetMethodHandler)) as SetMethodHandler;
                SetMethodHandler_DIC[key] = handler;

            }
            if (propertyType != value.GetType())
            {
                value = TypeUtil.ConvertTo(value, propertyType);
            }
            handler.Invoke(t, value);
        }
        /// <summary>
        /// 设置指定对象指定属性的值
        /// </summary>
        /// <param name="t">指定的对象</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">属性值</param>
        public static void SetTValue(T t, string propertyName, object value)
        {
            Type myType = typeof(T);
            long typeCode = RuntimeHelpers.GetHashCode(myType);
            string key = typeCode + propertyName;

            bool exist = false;
            SetMethodHandler handler = null;
            lock (SetMethodHandler_DIC_LOCK)
            {
                if (SetMethodHandler_DIC.ContainsKey(key))
                {
                    handler = SetMethodHandler_DIC[key];
                    exist = true;
                }
            }

            PropertyInfo property = myType.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
            {
                return;
            }
            Type propertyType = property.PropertyType;

            if (exist == false)
            {


                MethodInfo propertySetMetod = property.GetSetMethod();

                DynamicMethod dy = new DynamicMethod(SET_METHOD, null, new Type[] { myType, typeof(object) });
                ILGenerator il = dy.GetILGenerator();
                LocalBuilder local = il.DeclareLocal(propertyType, true);
                il.Emit(OpCodes.Ldarg_1);
                if (propertyType.IsValueType)
                {
                    il.Emit(OpCodes.Unbox_Any, propertyType);// 如果是值类型，拆箱 string = (string)object;
                }
                else
                {
                    il.Emit(OpCodes.Castclass, propertyType);// 如果是引用类型，转换 Class = object as Class
                }
                il.Emit(OpCodes.Stloc, local);// 将上面的拆箱或转换，赋值到本地变量，现在这个本地变量是一个与目标函数相同数据类型的字段了。
                il.Emit(OpCodes.Ldarg_0);   // 加载第一个参数 owner
                il.Emit(OpCodes.Ldloc, local);// 加载本地参数
                il.EmitCall(OpCodes.Callvirt, propertySetMetod, null);//调用函数
                il.Emit(OpCodes.Ret);   // 返回

                handler = dy.CreateDelegate(typeof(SetMethodHandler)) as SetMethodHandler;
                lock (SetMethodHandler_DIC_LOCK)
                {
                    if (SetMethodHandler_DIC.ContainsKey(key))
                    {
                        handler = SetMethodHandler_DIC[key];

                    }
                    else
                    {
                        SetMethodHandler_DIC[key] = handler;
                    }
                }

            }

            if (propertyType != value.GetType())
            {
                value = TypeUtil.ConvertTo(value, propertyType);
            }
            handler.Invoke(t, value);
        }

        /// <summary>
        /// Get T from IDataRecord
        /// </summary>
        /// <param name="record">IDataRecord type</param>
        /// <returns>T的对象</returns>
        public static T GetTFrom(IDataRecord record)
        {
            T ret = new T();
            Type myType = typeof(T);
            long typeCode = RuntimeHelpers.GetHashCode(myType);
            int fieldCount = record.FieldCount;
            for (int i = 0; i < fieldCount; i++)
            {
                bool isNull = record.IsDBNull(i);
                if (!isNull)
                {
                    string propertyName = record.GetName(i);
                    object value = record[i];
                    string key = typeCode + propertyName;

                    bool exist = false;
                    SetMethodHandler handler = null;
                    if (SetMethodHandler_DIC.TryGetValue(key, out handler))
                    {
                        exist = true;
                    }

                    if (exist == false)
                    {
                        lock (SetMethodHandler_DIC_LOCK)
                        {
                            if (!SetMethodHandler_DIC.TryGetValue(key, out handler))
                            {
                                PropertyInfo property = myType.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                                if (property == null)
                                {
                                    Moon.Orm.Util.LogUtil.Error(myType.FullName+"中不存在属性"+ propertyName);
                                }
                                Type propertyType = property.PropertyType;
                                MethodInfo propertySetMetod = property.GetSetMethod();
                                KeyPropertyTypeMap[key] = propertyType;
                                DynamicMethod dy = new DynamicMethod(SET_METHOD, null, new Type[] { myType, typeof(object) });
                                ILGenerator il = dy.GetILGenerator();
                                LocalBuilder local = il.DeclareLocal(propertyType, true);
                                il.Emit(OpCodes.Ldarg_1);
                                if (propertyType.IsValueType)
                                {
                                    il.Emit(OpCodes.Unbox_Any, propertyType);// 如果是值类型，拆箱 string = (string)object;
                                }
                                else
                                {
                                    il.Emit(OpCodes.Castclass, propertyType);// 如果是引用类型，转换 Class = object as Class
                                }
                                il.Emit(OpCodes.Stloc, local);// 将上面的拆箱或转换，赋值到本地变量，现在这个本地变量是一个与目标函数相同数据类型的字段了。
                                il.Emit(OpCodes.Ldarg_0);   // 加载第一个参数 owner
                                il.Emit(OpCodes.Ldloc, local);// 加载本地参数
                                il.EmitCall(OpCodes.Callvirt, propertySetMetod, null);//调用函数
                                il.Emit(OpCodes.Ret);   // 返回

                                handler = dy.CreateDelegate(typeof(SetMethodHandler)) as SetMethodHandler;
                                SetMethodHandler_DIC[key] = handler;
                            }
                        }
                    }

                    try
                    {
                        var propertyType = KeyPropertyTypeMap[key];
                        if (propertyType != null && value.GetType() != propertyType)
                        {
                            value = TypeUtil.ConvertTo(value, propertyType);
                        }
                        handler.Invoke(ret, value);
                    }
                    catch (InvalidCastException ex)
                    {
                        var valueType = value.GetType().FullName;
                        var instanceType = ret.GetType().FullName;
                        var msg = "类型:{0}的属性:{1},在赋值为{2}(类型为:{3})时出错";
                        msg = string.Format(msg, instanceType, propertyName, value, valueType);
                        Moon.Orm.Util.LogUtil.Exception(ex);
                        Moon.Orm.Util.LogUtil.Error(msg);
                        throw new InvalidCastException(msg);
                    }

                }
            }
            return ret;
        }

        /// <summary>
        /// SetMethodHandler_DIC
        /// </summary>
        private static ConcurrentDictionary<string, SetMethodHandler> SetMethodHandler_DIC = new ConcurrentDictionary<string, SetMethodHandler>();

        /// <summary>
        /// SetMethodHandler_DIC_LOCK
        /// </summary>
        private static readonly T SetMethodHandler_DIC_LOCK = new T();


        /// <summary>
		/// SetMethodHandler_DIC
		/// </summary>
		private static ConcurrentDictionary<string, Type> KeyPropertyTypeMap = new ConcurrentDictionary<string, Type>();
    }
}
