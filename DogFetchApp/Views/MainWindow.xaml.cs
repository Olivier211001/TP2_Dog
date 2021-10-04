using ApiHelper;
using DogFetchApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace DogFetchApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel currentViewmodel;
        
        private ModelBreed  cBreed;
        public List<ModelBreed> Breeds;

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.ApiHelper.InitializeClient();

            currentViewmodel = new MainViewModel();
            DataContext = currentViewmodel;
        }
        
       


        private async Task LLB()
        {
            var breedList = await DogApiProcessor.LoadBreedList();
            comboR.ItemsSource = breedList.Keys;
        }
        private void ChangeLangugage(string param)
        {
            Properties.Settings.Default.Language = param;
            Properties.Settings.Default.Save();
            Restart();
        }
        void Restart()
        {
            string messageBoxText = Properties.Resources.messageBoxText;
            string caption = Properties.Resources.caption;
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            if (result == MessageBoxResult.OK)
            {
                System.Diagnostics.Process.Start(Process.GetCurrentProcess().MainModule.FileName);
                Application.Current.Shutdown();
            }
        }
      

        private void f_Click(object sender, RoutedEventArgs e)
        {
            ChangeLangugage("fr");
        }

        private void e_Click(object sender, RoutedEventArgs e)
        {
            ChangeLangugage("en");
        }

        private async void next_Click(object sender, RoutedEventArgs e)
        {
            await Fimage();
        }

        private async void fetch_Click(object sender, RoutedEventArgs e)
        {
            await Fimage();
            next.IsEnabled = true;
        }
        private async Task Fimage()
        {
            Breeds = new List<ModelBreed>();
            string b = comboR.Text;
            string img = comboPics.Text;
            Int32.TryParse(img, out int j);
            for(int i =0; i<j; i++)
            {
                cBreed = await DogApiProcessor.Load_image(b);
                Breeds.Add(cBreed);
            }
            ListI.ItemsSource = Breeds;
        }

        private async void title_Loaded(object sender, RoutedEventArgs e)
        {
            
                await LLB();
                next.IsEnabled = false;
           
        }
    }
}
