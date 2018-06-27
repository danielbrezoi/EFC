using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientOrder.Domain.Tools
{
    public class ClientChangeTracker : INotifyPropertyChanged
    {
        private bool isDirty = false;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsDirty
        {
            get => isDirty;
            set => SetWithNotify(value, ref isDirty);
        }

        protected void SetWithNotify<T>(T value, ref T field, [CallerMemberName] string propertyName = "")
        {
            if(!Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }



    }
}
