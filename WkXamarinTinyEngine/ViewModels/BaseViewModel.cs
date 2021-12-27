using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WkXamarinTinyEngine.ViewModels
{
    internal abstract class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                SetProperty(ref isBusy, value);

                SetProperty(ref isNotBusy, !value);
            }
        }

        private bool isNotBusy = true;
        public bool IsNotBusy
        {
            get => isNotBusy;
            private set => SetProperty(ref isNotBusy, value);
        }

        private string title = string.Empty;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value)) return false;

            backingStore = value;

            OnPropertyChanged(propertyName);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;

            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Quando eu naveguei para uma página
        public virtual Task InitAsync(object args = null) => Task.CompletedTask;

        //Quando eu to voltando para a página
        public virtual Task BackAsync(object args = null) => Task.CompletedTask;

        public Task DisplayAlert(string title, string message, string cancel) =>
            MainThread.IsMainThread
            ? Application.Current.MainPage.DisplayAlert(title, message, cancel)
            : MainThread.InvokeOnMainThreadAsync(() => Application.Current.MainPage.DisplayAlert(title, message, cancel));

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            if (MainThread.IsMainThread) return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);

                tcs.TrySetResult(result);
            });

            return tcs.Task;
        }
    }
}
