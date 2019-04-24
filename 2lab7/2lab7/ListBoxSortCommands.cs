using _2lab7UserControlLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace _2lab7
{
    public class ListBoxSortCommands
    {
        public static RoutedUICommand AscendingSort;

        static ListBoxSortCommands()
        {
            AscendingSort = new RoutedUICommand("AscendingSort", "AscendingSort", typeof(ListBoxSortCommands));
        }
    }
}
