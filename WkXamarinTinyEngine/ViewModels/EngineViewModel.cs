﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WkXamarinTinyEngine.Services;
using Xamarin.Forms;

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

        public void Initialize(ScrollView mainScrollView, Grid mainGrid)
        {
            attachedScrollView = mainScrollView;
            AttachedGrid = mainGrid;

            engineUIMeshService = DependencyService.Get<IEngineUIMeshService>();
            engineUIMeshService.StartEngine(this);

            SetupScreenSize();
        }

        private void RefreshAttachedMainViews()
        {
            attachedScrollView?.ForceLayout();
            AttachedGrid?.ForceLayout();
        }

        private void SetupScreenSize()
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
