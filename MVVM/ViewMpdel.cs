using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVM
{
    internal class ViewMpdel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string N
        {
            get
            {
                return Model.n.ToString();
            }
        }
        public List<string> DataList { get; } = Model.fam;
        int index = 0;
        public int IndCh
        {
            set
            {
                index = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ListItem"));
            }
        }

        public string ListItem
        {
            get
            {
                return DataList[index];
            }

        }

        public RoutedCommand command { get; set; } = new RoutedCommand();
        public CommandBinding binding;

        public ViewMpdel()
        {
            binding = new CommandBinding(command);
            binding.Executed += Binding_Executed;
        }

        private void Binding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Model.n++;
            PropertyChanged(this, new PropertyChangedEventArgs("N"));
        }
    }
}
