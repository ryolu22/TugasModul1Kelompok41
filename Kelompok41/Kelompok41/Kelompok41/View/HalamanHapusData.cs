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
	public class HalamanHapusData : ContentPage
	{

        private ListView _listView;
        private Button tombol;

        DataMahasiswa _data = new DataMahasiswa();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db4");

        public HalamanHapusData ()
		{
            this.Title = "Hapus Data Mahasiswa";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<DataMahasiswa>().OrderBy(x => x.Nama).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);
            Content = stackLayout;

           tombol = new Button();
            tombol.Text = "Hapus";
            tombol.Clicked += tombol_Clicked;
            stackLayout.Children.Add(tombol);
        }
        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _data = (DataMahasiswa)e.SelectedItem;
          

        }
        private async void tombol_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<DataMahasiswa>().Delete(x => x.Id == _data.Id);
            await Navigation.PopAsync();


        }
    }
}