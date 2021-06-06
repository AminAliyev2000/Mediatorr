using Mediatorr.Commands;
using Mediatorr.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mediatorr.ViewModels
{
    public class StartPage : INotifyPropertyChanged
    {
        private string _nickname;
        private readonly List<Chat> _subscribers = new List<Chat>();
        private readonly List<ListBox> _listBoxes = new List<ListBox>();
        public event PropertyChangedEventHandler PropertyChanged;

        public StartPage()
        {
            JoinCommand = new RelayCommand(JoinClick, delegate { return string.IsNullOrWhiteSpace(Nickname) == false; });
        }

        public ObservableCollection<string> Messages { get; set; } = new ObservableCollection<string>();
        public RelayCommand JoinCommand { get; set; }

        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; OnPropertyChanged(); }
        }

        private void JoinClick(object parameter = null)
        {
            Subscribe();
            NotifyAllSubscribers($"{Nickname} : Joined at {DateTime.Now}");
            Nickname = default;
        }

        public void NotifyAllSubscribers(string message)
        {
            Messages.Add(message);

            for (int i = 0; i < _listBoxes.Count; i++)
            {
                _listBoxes[i].ScrollIntoView(_listBoxes[i].Items[_listBoxes[i].Items.Count - 1]);
            }
        }

        public void Subscribe()
        {
            _subscribers.Add(new Chat(this, Nickname));

            WindowOfChat chatWindow = new WindowOfChat
            {
                DataContext = _subscribers[_subscribers.Count - 1],
            };

            _listBoxes.Add(chatWindow.LstBxChat);

            chatWindow.Show();
        }

        public void Unsubscribe(Chat subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
