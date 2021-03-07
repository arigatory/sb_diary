using sb_diary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sb_diary.Model
{
    public class Entry : Observable
    {
        private string _title;
        private string _text;
        private bool _isImportant;
        private string _author;
        private DateTime _dateOfCreation;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
        public bool IsImportant
        {
            get => _isImportant;
            set
            {
                _isImportant = value;
                OnPropertyChanged();
            }
        }
        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateOfCreation
        {
            get => _dateOfCreation; set
            {
                _dateOfCreation = value;
                OnPropertyChanged();
            }
        }
    }
}
