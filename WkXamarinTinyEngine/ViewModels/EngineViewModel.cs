using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WkXamarinTinyEngine.Models.Settings;
using WkXamarinTinyEngine.Services;
using Xamarin.Forms;
using System;

namespace WkXamarinTinyEngine.ViewModels
{
    /// <summary>
    /// The Binding Context of the MainPage/StartupPage need to be set as this class or another one that inherets this class.
    /// </summary>
    public class EngineViewModel : INotifyPropertyChanged
    {
        private double currentScreenWidth;
        public double CurrentScreenWidth
        {
            get => currentScreenWidth;
            set
            {
                SetProperty(ref currentScreenWidth, value);
                RefreshAttachedMainViews();
            }
        }

        private double currentScreenHeight;
        public double CurrentScreenHeight
        {
            get => currentScreenHeight;
            set
            {
                SetProperty(ref currentScreenHeight, value);
                RefreshAttachedMainViews();
            }
        }

        private IEngineUIMeshService engineUIMeshService;
        private ScrollView attachedScrollView;
        internal Grid AttachedGrid;

        /// <summary>
        /// Starts the engine with desired configurations.
        /// </summary>
        /// <param name="mainScrollView">(Optional) You can use a Scroll View as parent of the Main View.</param>
        /// <param name="mainGrid">The required main grid of the engine. This element will be the parent of all your UI elements.</param>
        /// <param name="engineSettings">(Optional) The settings of the engine.</param>
        public void StartEngine(ScrollView mainScrollView, Grid mainGrid, EngineSettings engineSettings = null)
        {
            attachedScrollView = mainScrollView;
            AttachedGrid = mainGrid ?? throw new Exception("The Main Grid, in the StartEngine() parameter, cannot be null!");

            engineUIMeshService = DependencyService.Get<IEngineUIMeshService>();
            engineUIMeshService.Initialize(this, engineSettings);

            ChangeCurrentScreenSize();
        }

        private void RefreshAttachedMainViews()
        {
            attachedScrollView?.ForceLayout();
            AttachedGrid?.ForceLayout();
        }

        private void ChangeCurrentScreenSize()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                CurrentScreenHeight = engineUIMeshService.CurrentScreenHeight;
                CurrentScreenWidth = engineUIMeshService.CurrentScreenWidth;
            });
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
    }
}
