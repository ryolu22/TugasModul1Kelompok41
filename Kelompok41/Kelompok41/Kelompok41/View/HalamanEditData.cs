using Kelompok41.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kelompok41.View
{
    public class HalamanEditData : ContentPage
    {
        private ListView _listView;
        private Entry idEntry;
        private Entry namaEntry;
        private Entry jurusanEntry;
        private Button tombol;

        DataMahasiswa _data = new DataMahasiswa();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db4");

        public HalamanEditData()
        {
            this.Title = "Edit Data Mahasiswa";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<DataMahasiswa>().OrderBy(x => x.Nama).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            idEntry = new Entry();
            idEntry.Placeholder = "ID";
            idEntry.IsVisible = false;
            stackLayout.Children.Add(idEntry);

            namaEntry = new Entry();
            namaEntry.Keyboard = Keyboard.Text;
            namaEntry.Placeholder = "Nama Anda";
            stackLayout.Children.Add(namaEntry);

            jurusanEntry = new Entry();
            jurusanEntry.Keyboard = Keyboard.Text;
            jurusanEntry.Placeholder = "Jurusan";
            stackLayout.Children.Add(jurusanEntry);

            tombol = new Button();
            tombol.Text = "Edit";
            tombol.Clicked += tombol_Clicked;
            stackLayout.Children.Add(tombol);

            Content = stackLayout;
        }

        private async void tombol_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            DataMahasiswa data = new DataMahasiswa()
            {
                Id = Convert.ToInt32(idEntry.Text),
                Nama = namaEntry.Text,
                Jurusan = jurusanEntry.Text
            };
            db.Update(data);
            await Navigation.PopAsync();


        }
        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _data = (DataMahasiswa)e.SelectedItem;
            idEntry.Text = _data.Id.ToString();
            namaEntry.Text = _data.Nama;
            jurusanEntry.Text = _data.Jurusan;

        }
    }
}