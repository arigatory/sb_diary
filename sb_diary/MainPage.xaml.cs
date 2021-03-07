using sb_diary.DataProvider;
using sb_diary.Model;
using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace sb_diary
{
    public sealed partial class MainPage : Page
    {
        private EntryDataProvider _entryDataProvider;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            App.Current.Suspending += App_Suspending;
            _entryDataProvider = new EntryDataProvider();
        }

        private async void App_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await _entryDataProvider.SaveEntriesAsync(entryListView.Items.OfType<Entry>());
            deferral.Complete();
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            entryListView.Items.Clear();

            var entries = await _entryDataProvider.LoadEntriesAsync();
            foreach (var entry in entries)
            {
                entryListView.Items.Add(entry);
            }
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

        private void EntryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var entry = entryListView.SelectedItem as Entry;
            txtTitle.Text = entry?.Title ?? "";
            txtText.Text = entry?.Text ?? "";
            chkIsImportant.IsChecked = entry?.IsImportant;
        }
    }
}
