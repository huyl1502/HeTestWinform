using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace He.Views
{
    class MyListViewItem<TModel> : ListViewItem
    {
        public MyListViewItem(TModel o)
        {
            PropertyInfo[] propInfos = typeof(TModel).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Text = "";
            for(int i = 0; i < propInfos.Length; i++)
            {
                SubItems.Add(new ListViewSubItem()
                {
                    Text = propInfos[i].GetValue(o, null).ToString(),
            });
            }
        }
    }

    class MyListView<TModel> : ListView
    {
        public MyListView(List<TModel> items)
        {
            CheckBoxes = true;
            GridLines = true;
            FullRowSelect = true;
            View = View.Details;

            PropertyInfo[] propInfos = typeof(TModel).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Columns.Add("");
            foreach(var propInfo in propInfos)
            {
                Columns.Add(new ColumnHeader { 
                    Text = propInfo.Name,
                    TextAlign = HorizontalAlignment.Center,
                    
                });;
            }

            foreach (TModel item in items)
            {
                var i = new MyListViewItem<TModel>(item);
                Items.Add(i);
            }

            AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            HeaderStyle = ColumnHeaderStyle.Nonclickable;
        }
    }
}
