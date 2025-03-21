using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			if (txt_quantidade.Text == "")
			{
				txt_quantidade.Text = "0";

            }

			if (txt_preco.Text == "")
			{
                txt_preco.Text = "0";
            }

			Produto p = new Produto
			{
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};
			

			await App.Db.Insert(p);
			await DisplayAlert("Sucesso", "Registro Inserido", "Ok");

		} catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Ok");
		}
    }
}