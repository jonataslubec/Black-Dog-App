using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BlackDog.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
           // Icon = Helpers.StringHelper.FixPathImage("slideout.png");

        }

        public static bool IsRetrato(double width, double height)
        {
            return (width < height);
        }

        public static bool IsRun(System.ComponentModel.PropertyChangedEventArgs e)
        {
            return (e.PropertyName == "IsRunning");
        }



        private ICommand shareCommand;
        public ICommand ShareCommand
        {
            get { return shareCommand ?? (shareCommand = new Command(async () => await ExecuteShareCommand())); }
        }


        private async Task ExecuteShareCommand()
        {
            //await CrossShare.Current.Share("Segue link " + Share);
        }


        private string share = string.Empty;
        public const string SharePropertyName = "Share";

        public string Share
        {
            get { return share; }
            set { SetProperty(ref share, value); }
        }



        private string title = string.Empty;
        public const string TitlePropertyName = "Title";


        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

       
        private string icon = null;
        public const string IconPropertyName = "Icon";
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }



        bool isError;
        public bool IsError
        {
            get { return isError; }
            set
            {
                if (SetProperty(ref isError, value))
                    isNotError = !IsError;
            }
        }

        bool isNotError = true;
        public bool IsNotError
        {
            get { return isNotError; }
            private set { SetProperty(ref isNotError, value); }
        }



        bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (SetProperty(ref isBusy, value))
                    IsNotBusy = !isBusy;
            }
        }

        bool isNotBusy = true;
        public bool IsNotBusy
        {
            get { return isNotBusy; }
            private set { SetProperty(ref isNotBusy, value); }
        }



        private bool _selected;

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BackgroundColor"));
            }
        }

        public Color BackgroundColor
        {
            get
            {
                if (Selected)
                    return Color.Black;
                else
                    return Color.Blue;
            }
        }

        private bool canLoadMore = true;
        public const string CanLoadMorePropertyName = "CanLoadMore";
        public bool CanLoadMore
        {
            get { return canLoadMore; }
            set { SetProperty(ref canLoadMore, value); }
        }

        protected bool SetProperty<T>(
            ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {


            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
            return true;
        }


        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
