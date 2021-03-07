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

        private void ButtonDeleteEntry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            int column = Grid.GetColumn(entryListGrid);
            int newColumn = column == 0 ? 2 : 0;
            Grid.SetColumn(entryListGrid, newColumn);
            moveSymbolIcon.Symbol = newColumn == 0 ? Symbol.Forward : Symbol.Back;
        }
    }
}
