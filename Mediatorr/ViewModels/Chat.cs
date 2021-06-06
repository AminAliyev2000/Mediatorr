using Mediatorr.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mediatorr.ViewModels
{
    public class Chat
    {
        public Chat(StartPage startPage,string nickname)
        {

            StartPage = startPage;
            Nickname = nickname;
            SendCommand = new RelayCommand(SendClick);
            LeaveCommand = new RelayCommand(LeaveClick);
            CloseCommand = new RelayCommand(CloseClick);
        }
        
       

        public StartPage StartPage { get; set; }
        public string Nickname { get; set; }
        public RelayCommand SendCommand { get; set; }
        public RelayCommand LeaveCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        private void SendClick(object parameter = null)
        {
            if (parameter is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text) == false)
            {
                StartPage.NotifyAllSubscribers($"{Nickname} : {textBox.Text}");
                textBox.Text = default;
            }
        }

        private void LeaveClick(object parameter = null)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
        }

        private void CloseClick(object parameter = null)
        {
            ExitUser();
        }

        private void ExitUser()
        {
            StartPage.Unsubscribe(this);
            StartPage.NotifyAllSubscribers($"{Nickname} : Left at {DateTime.Now}");
        }
    }
}
