/*
 * 由SharpDevelop创建。
 * 用户： qscq
 * 日期: 2014/8/4
 * 时间: 10:07
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace Moon.Orm.Util
{
	/// <summary>
	/// Description of ListUtil.
	/// </summary>
	public class ListUtil
	{
		/// <summary>
		/// 将一个list数据,分成n个list,每个list中的数据条数为count(当然不够时,就让它不够)
		/// </summary>
		/// <param name="list">list</param>
		/// <param name="count">每个list中的数据条数</param>
		/// <returns>多个list</returns>
		public static List<List<T>>  GetCountListList<T>(List<T> list,int count){
			List<List<T>> retList=new List<List<T>>();
			if(count==0){
				return retList;
			}
			int zhengshu=list.Count/count;
			int yushu=list.Count%count;
			for (int i = 1; i <= zhengshu; i++) {
				int listIndexStart=(i-1)*count;
				int listIndexEnd=i*count-1;
				var tempList=new List<T>();
				for (int index = listIndexStart; index <= listIndexEnd; index++) {
					tempList.Add(list[index]);
				}
				retList.Add(tempList);
			}
			if (yushu!=0) {
				int listIndexStart=list.Count-yushu;
				int listIndexEnd=list.Count-1;
				var tempList=new List<T>();
				for (int index = listIndexStart; index <= listIndexEnd; index++) {
					tempList.Add(list[index]);
				}
				retList.Add(tempList);
			}
			return retList;
		}
	}
}
