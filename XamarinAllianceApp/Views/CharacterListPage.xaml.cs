﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAllianceApp.Controllers;
using XamarinAllianceApp.Models;
using XamarinAllianceApp.Services;

namespace XamarinAllianceApp.Views
{
    public partial class CharacterListPage : ContentPage
    {
       // private CharacterService service;
        private CharactersService mobileService;

        public CharacterListPage()
        {
            InitializeComponent();

            //  service = new CharacterService();
            mobileService = new CharactersService();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Set syncItems to true in order to synchronize the data on startup when running in offline mode
           await RefreshItems(true);



        }

        // http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/listview/#pulltorefresh
        public async void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;
            try
            {
                await RefreshItems(false);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                list.EndRefresh();
            }

            if (error != null)
            {
                await DisplayAlert("Refresh Error", "Couldn't refresh data (" + error.Message + ")", "OK");
            }
        }

        public async void OnSyncItems(object sender, EventArgs e)
        {
            await RefreshItems(true);
        }

        private async Task RefreshItems(bool showActivityIndicator)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
            {
                characterList.ItemsSource = await mobileService.GetCharactersAsync();
            }
        }

        private class ActivityIndicatorScope : IDisposable
        {
            private bool showIndicator;
            private ActivityIndicator indicator;
            private Task indicatorDelay;

            public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator)
            {
                this.indicator = indicator;
                this.showIndicator = showIndicator;

                if (showIndicator)
                {
                    indicatorDelay = Task.Delay(2000);
                    SetIndicatorActivity(true);
                }
                else
                {
                    indicatorDelay = Task.FromResult(0);
                }
            }

            private void SetIndicatorActivity(bool isActive)
            {
                this.indicator.IsVisible = isActive;
                this.indicator.IsRunning = isActive;
            }

            public void Dispose()
            {
                if (showIndicator)
                {
                    indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }

        private async void characterList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCharacter = e.SelectedItem as Character;
            if (selectedCharacter!=null)
            {
                await Navigation.PushAsync(new CharacterPage(selectedCharacter));
            }
        }
    }
}

