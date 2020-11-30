using PinCab.ScreenUtil.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Extensions
{
    public static class ListExtensions
    {
        public static BindingList<T> ToBindingList<T>(this IEnumerable<T> collection)
        {
            return new BindingList<T>(collection.ToList());
        }

        public static SortableBindingList<T> ToSortableBindingList<T>(this IEnumerable<T> collection)
        {
            return new SortableBindingList<T>(collection.ToList());
        }
    }
}
