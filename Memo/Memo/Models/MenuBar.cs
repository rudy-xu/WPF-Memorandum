using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo.Models
{
	/// <summary>
	/// 左侧菜单栏实体类
	/// </summary>
    public class MenuBar: BindableBase
    {
		private string _icon;

		public string Icon
		{
			get { return _icon; }
			set { _icon = value; }
		}


		private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}


		/// <summary>
		/// 用于菜单导航
		/// </summary>
		private string _navigation;

		public string Navigation
        {
			get { return _navigation; }
			set { _navigation = value; }
		}

	}
}
