using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWatcher
{
    public class ClassNode
    {
        public ObservableCollection<ClassNode>? SubNodes { get; }
        public string Title { get; }
        public string Value { get; }

        public ClassNode(string title, string value)
        {
            Title = title;
            Value = value;
        }

        public ClassNode(string title, string value, ObservableCollection<ClassNode> subNodes)
        {
            Title = title;
            Value = value;
            SubNodes = subNodes;
        }
    }
}
