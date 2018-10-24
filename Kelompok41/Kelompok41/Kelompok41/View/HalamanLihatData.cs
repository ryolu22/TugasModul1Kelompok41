using Kelompok41.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kelompok41.View
{
    public class HalamanLihatData : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db4");
        public ObservableCollection<DataMahasiswa> DataMahasiswa
        {
            get;
            set;
        }
        public Command < DataMahasiswa > RemoveCommand
        {
            get
            {
                return new Command<DataMahasiswa>((Datamahasiswa) => {
                    DataMahasiswa.Remove(Datamahasiswa);
                });
            }
        }
        public HalamanLihatData()
        {
            this.Title = "Data Mahasiswa";
          

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<DataMahasiswa>().OrderBy(x => x.Nama).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}
