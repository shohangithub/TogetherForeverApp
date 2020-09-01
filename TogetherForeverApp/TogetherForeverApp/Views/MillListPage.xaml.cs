using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using TogetherForeverApp.Models;
using TogetherForeverApp.Services;
using TogetherForeverApp.ViewModels.Mills;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TogetherForeverApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MillListPage : ContentPage
    {
        MillViewModel _viewModel;
        public ObservableCollection<Mill> MillList { get; }
        public Command LoadMillsCommand { get; }
        public MillListPage()
        {
            //_viewModel = new MillViewModel();
            //MillList = new ObservableCollection<Mill>();
            //ExecuteLoadMillsCommand();
            InitializeComponent();
            BindingContext = _viewModel = new MillViewModel();

          

            

            #region Data Templete Content
            DataTemplate dataTemplete = new DataTemplate(() =>
            {

                #region Label Content
                Label memberNamelabel = new Label { TextColor = Color.Black };
                memberNamelabel.SetBinding(Label.TextProperty, "MemberName");

                StackLayout breakFastLabel = new StackLayout
                {
                    HeightRequest=100,
                    Children = { new Frame {
                                            Padding =new Thickness(5,0),
                                            CornerRadius=50,
                                            HeightRequest=100,
                                            Content =  new Label {
                                                                TextColor = Color.White,
                                                                BackgroundColor=Color.Red,
                                                                Text="NO",
                                                                Padding=new Thickness(0,0),
                                                                HorizontalOptions=LayoutOptions.Center
                                                                
                                            }
            }
                    }
                };
                
               
                

                #endregion

                #region Image Content
                Image image = new Image
                {
                    Source = "croppedmembericon.png",
                    HeightRequest = 200

                };
                #endregion

                #region Grid Content
                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.2, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.5, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.1, GridUnitType.Star) });
                grid.Children.Add(image);
                grid.Children.Add(memberNamelabel);
                grid.Children.Add(breakFastLabel);
                Grid.SetColumn(image, 0);
                Grid.SetColumn(memberNamelabel, 1);
                Grid.SetColumn(breakFastLabel, 2);
                #endregion

                #region Frame Content
                var frame = new Frame
                {
                    BorderColor = Color.Gray,
                    CornerRadius = 5,
                    Padding = 8,
                    Content = new StackLayout
                    {
                        Children =
                        {
                            grid
                        }
                    }
                };
                #endregion

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                           frame
                        }
                    }
                };
            });

            #endregion

            #region Collection View Content
            CollectionView collectionView = new CollectionView
            {
                ItemsSource = MillList,
                SelectionMode = SelectionMode.None
            };
            collectionView.ItemTemplate = dataTemplete;

            #endregion

            #region ListView Content
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = MillList,
                ItemTemplate = dataTemplete
            };
            #endregion

            #region Refresh View Content
            RefreshView refreshView = new RefreshView();

            ICommand refreshCommand = new Command(() =>
            {
                // IsRefreshing is true
                // Refresh data here
                refreshView.IsRefreshing = IsBusy;
            });
            refreshView.Command = LoadMillsCommand;
            refreshView.IsRefreshing = IsBusy;
            refreshView.Content = listView;

            //  collectionView.SetBinding(ItemsView.ItemsSourceProperty, "MillId"); ;
            #endregion

            #region Image Content
            var imageButton = new ImageButton
            {
                Source = "plus.png",
                 HeightRequest=40,
                 WidthRequest=40,
                 CornerRadius=10,
                 Command= _viewModel.AddMillCommand

            };

            #endregion

            #region Absolute Layout Content
            var absoluteLayout = new AbsoluteLayout
            {
                Children = { refreshView, imageButton }
            };
            AbsoluteLayout.SetLayoutBounds(imageButton, new Rectangle(0.95, 0.95, 80, 80));
            AbsoluteLayout.SetLayoutFlags(imageButton, AbsoluteLayoutFlags.PositionProportional);
            #endregion

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            //Content = absoluteLayout;
        }
        async Task ExecuteLoadMillsCommand()
        {
            try
            {
                MillList.Clear();
                var items = await new MillDataStore().GetItemsAsync(true);
                // var items = await MillStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    var member = await new MemberDataStore().GetItemAsync();
                    item.MemberName = member.MemberName;
                    MillList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    _viewModel.OnAppearing();
        //}
    }
    


}