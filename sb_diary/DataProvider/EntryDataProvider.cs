using Newtonsoft.Json;
using sb_diary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace sb_diary.DataProvider
{
    public class EntryDataProvider
    {
        private static readonly string _entriesFileName = "entries.json";
        private static readonly StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        public async Task<IEnumerable<Entry>> LoadEntriesAsync()
        {
            var storageFile = await _localFolder.TryGetItemAsync(_entriesFileName) as StorageFile;
            List<Entry> entriesList = null;

            if (storageFile == null)
            {
                entriesList = new List<Entry>
                {
                    new Entry{
                        Title="Моя первая заметка",
                        Text="Я начал делать приложение для Skillbox. Надеюсь, что у меня получается",
                        IsImportant=false,
                        Author = "Я",
                        DateOfCreation = DateTime.Today
                    },
                    new Entry{
                        Title="Мысли вслух", 
                        Text="Было бы хорошо сделать когда-нибудь это приложение кросс-платформенным, но я пока не знаю как", 
                        IsImportant=true,
                        Author = "Я",
                        DateOfCreation = DateTime.Today
                    }
                };
            }
            else
            {
                using (var stream = await storageFile.OpenAsync(FileAccessMode.Read))
                {
                    using (var dataReader = new DataReader(stream))
                    {
                        await dataReader.LoadAsync((uint)stream.Size);
                        var json = dataReader.ReadString((uint)stream.Size);
                        entriesList = JsonConvert.DeserializeObject<List<Entry>>(json);
                    }
                }
            }
            return entriesList.OrderBy(ent => ent.DateOfCreation);
        }

        public async Task SaveEntriesAsync(IEnumerable<Entry> entries)
        {
            var storageFile = await _localFolder.CreateFileAsync(_entriesFileName, CreationCollisionOption.ReplaceExisting);

            using (var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (var dataWriter = new DataWriter(stream))
                {
                    var json = JsonConvert.SerializeObject(entries, Formatting.Indented);
                    dataWriter.WriteString(json);
                    await dataWriter.StoreAsync();
                }
            }
        }
    }
}
