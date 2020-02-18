using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFThemes;

namespace ListDesignTime
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public ICommand LoadDataCommand { get; private set; }
        public ICommand ParametersCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand ChangeColorCommand { get; private set; }

        public ObservableCollection<Item> Items { get; private set; } = new ObservableCollection<Item>();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            ConfigureCommands();
        }

        private void ConfigureCommands() {
            LoadDataCommand = new Command(async () => await LoadData());
            ParametersCommand = new Command(ParametersCommandMethod);
            RefreshCommand = new Command(Refresh);
            ChangeColorCommand = new Command(ChangeTheme);
        }

        private async void Refresh() {
            IsRefreshing = true;
            await LoadData();
            IsRefreshing = false;
        }

        private void ChangeTheme()
        {
            ThemeManager.ToggleTheme();
        }

        private void ParametersCommandMethod(object parameters)
        {
            System.Console.WriteLine(parameters);
        }

        async Task LoadData()
        {
            await Task.Delay(2000);

            Item item1 = new Item();
            item1.Text = "Item 1";
            item1.Description = "Item 1 Description";

            Item item2 = new Item();
            item2.Text = "Item 2";
            item2.Description = "Item 2 Description";

            Item item3 = new Item();
            item3.Text = "Item 3";
            item3.Description = "Item 3 Description";

            Item item4 = new Item();
            item4.Text = "Item 4";
            item4.Description = "Item 4 Description";

            Items = new ObservableCollection<Item>() { item1, item2, item3, item4 };
            OnPropertyChanged("Items");
        }

        public void ViewCell_Tapped(System.Object sender, ItemTappedEventArgs e)
        {;
            if (e.Item == null) return;
            var selectedItem = e.Item as Item;
            var index = Items.IndexOf(selectedItem);
            System.Console.WriteLine(selectedItem.Text);
            System.Console.WriteLine(index);
        }

    }
}
