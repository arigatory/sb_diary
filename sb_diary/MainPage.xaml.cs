using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace sb_diary
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonAddEntry_Click(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Запись добавлена!");
            await messageDialog.ShowAsync();
        }
    }
}
