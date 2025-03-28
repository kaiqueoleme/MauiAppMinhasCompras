using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class RelatorioCateg : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
    ObservableCollection<dynamic> TotalPorCategoria = new ObservableCollection<dynamic>();
    public RelatorioCateg()
	{
		InitializeComponent();
        lst_categ.ItemsSource = TotalPorCategoria;
    }
    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();

            List<Produto> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));

            var totalPorCategoria = lista.GroupBy(i => i.Categoria)
                .Select(g => new
                {
                    Categoria = g.Key,
                    TotalGasto = g.Sum(p => p.Total)
                });

            // Atualizando a coleção para exibição no relatório
            TotalPorCategoria.Clear();
            foreach (var item in totalPorCategoria)
            {
                TotalPorCategoria.Add(item);
            }


        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}