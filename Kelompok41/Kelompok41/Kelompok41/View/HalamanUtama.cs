using Kelompok41.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kelompok41
{
    public class HalamanUtama : ContentPage
    {
        public HalamanUtama()
        {
            this.Title = "Data Mahasiswa";

            StackLayout stacklayout = new StackLayout();
            Button tombol = new Button();
            tombol.Text = "Tambah Data";
            tombol.Clicked += Button_Tambah_Clicked;
            stacklayout.Children.Add(tombol);

            tombol = new Button();
            tombol.Text = "Lihat Data";
            tombol.Clicked += Button_Lihat_Clicked;
            stacklayout.Children.Add(tombol);

            tombol = new Button();
            tombol.Text = "Edit";
            tombol.Clicked += Button_Edit_Clicked;
            stacklayout.Children.Add(tombol);

            tombol = new Button();
            tombol.Text = "Hapus";
            tombol.Clicked += Button_Hapus_Clicked;
            stacklayout.Children.Add(tombol);

            Content = stacklayout;
        }

        private async void Button_Tambah_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HalamanTambahData());
        }
        private async void Button_Lihat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HalamanLihatData());
        }

        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HalamanEditData());
        }
        private async void Button_Hapus_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HalamanHapusData());
        }

    }
}
