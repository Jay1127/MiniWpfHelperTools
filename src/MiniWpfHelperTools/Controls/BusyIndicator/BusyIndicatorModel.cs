﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MiniWpfHelperTools
{
    public class BusyIndicatorModel : IDialogModel, INotifyPropertyChanged
    {
        private string _title;
        private string _message;
        private bool _isShown;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NotifyPropertyChanged();
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsShown
        {
            get => _isShown;
            set
            {
                bool requestClose = _isShown && !value;

                _isShown = value;

                if (requestClose)
                {
                    RequestClose?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public ICommand CancelCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler RequestClose;

        public BusyIndicatorModel(
                    string title = "",
                    string content = "",
                    bool isIndeterminate = true,
                    double minValue = 0,
                    double maxValue = 100,
                    double value = 0)
        {
            Title = title;
            Message = content;
            IsShown = false;
        }

        private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}