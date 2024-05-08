using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mperugachiAC5.Models
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Tarea> Tareas { get; set; } = new ObservableCollection<Tarea>();

        public MainViewModel()
        {

        }

        public void EliminarTarea(Tarea tarea)
        {
            Tareas.Remove(tarea);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Tarea
    {
        public int Id { get; set; }
    }
}
