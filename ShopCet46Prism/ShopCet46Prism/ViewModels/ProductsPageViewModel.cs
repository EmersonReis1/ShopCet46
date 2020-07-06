﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ShopCet46.Common.Models;
using ShopCet46.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ShopCet46Prism.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private List<ProductResponse> _products;

        public ProductsPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            Title = "Products Page";
            LoadProductsAsync();

        }


        public List<ProductResponse> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }



        private async void LoadProductsAsync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();


            Response response = await _apiService.GetListAsync<ProductResponse>(url, "/api", "/Products");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            Products = (List<ProductResponse>)response.Result;
        }


    }
}
