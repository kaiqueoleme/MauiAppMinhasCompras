﻿using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        string _descricao;
        double _quantidade;
        double _preco;
        string _categoria;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { 
            get => _descricao; 
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new Exception("Por favor, preencha a descrição");
                }

                _descricao = value;
            } 
        }   
        public double Quantidade 
        {
            get => _quantidade; 
            set
            {
                if (value == 0)
                {
                    throw new Exception("Por favor, insira um valor diferente de zero para a quantidade");
                }

                _quantidade = value;
            } 
        }
        public double Preco 
        {
            get => _preco; 
            set
            {
                if (value == 0)
                {
                    throw new Exception("Por favor, insira um valor diferente de zero para o preço");
                }

                _preco = value;
            }
        }
        public double Total { get => Quantidade * Preco; }

        public string Categoria { 
            get => _categoria; 
            set 
            { 
                _categoria = value; 
            } 
        }

    }
}
