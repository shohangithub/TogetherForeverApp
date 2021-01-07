using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TogetherForeverApp.Models;
using TogetherForeverApp.ViewModels.Members;
using TogetherForeverApp.ViewModels.Mills;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TogetherForeverApp.Utilities;
using TogetherForeverApp.Databases;

namespace TogetherForeverApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemberPage : ContentPage
    {

        
        public static MemberViewModel _viewModel;
        
        public Command LoadMillsCommand { get; }
      
        public MemberPage()
        {
            BindingContext = _viewModel = new MemberViewModel();
            this.Title = _viewModel.Title;


            #region footer section
            Label footer = new Label
            {
                Text = "Develop by Shohan",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                HorizontalOptions = LayoutOptions.End

            };

            #endregion

            #region delete menu item
            var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true };
            deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            deleteAction.Clicked += async (sender, e) =>
            {
                var mi = ((MenuItem)sender);
                await _viewModel.OnDelete((Member)mi.CommandParameter);
            };
            #endregion

            #region tab gesture recognizer
            var tapGestureRecognizer = new TapGestureRecognizer() { NumberOfTapsRequired = 2 };
            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("."));
            tapGestureRecognizer.Tapped += async (s,e) => {
                var x = (TappedEventArgs)e;
                await _viewModel.OnPut((Member)x.Parameter);
            };
            #endregion

            #region create the list view.
            ListView listView = new ListView
            {
                SeparatorVisibility=SeparatorVisibility.None,
                RowHeight=70,
                HasUnevenRows = true, //  enbable list view row height Resize
                // Source of data items.
                ItemsSource = _viewModel.Members,
                

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    
                    Label nameLabel = new Label {
                        TextColor = C_Color.LabelHeaderColor,
                        FontFamily= "Noticia Text",
                        FontAttributes=FontAttributes.Bold,
                        FontSize=18
                    };
                    nameLabel.SetBinding(Label.TextProperty, "MemberName");

                    Label email = new Label
                    {
                        TextColor = C_Color.LabelDetailsColor,
                        FontFamily = "Noticia Text",
                        FontSize = 11
                    };
                    email.SetBinding(Label.TextProperty, "MemberEmail");

                    Label contact = new Label
                    {
                        TextColor = C_Color.LabelDetailsColor,
                        FontFamily = "Noticia Text",
                        FontSize = 11
                    };
                    contact.SetBinding(Label.TextProperty, "MemberContact");


                    #region row grid properties
                    Grid detailGrid = new Grid();
                    
                    //Column Definition
                    detailGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    detailGrid.Children.Add(new StackLayout{
                         HorizontalOptions=LayoutOptions.FillAndExpand,
                         Orientation = StackOrientation.Vertical,
                         Children ={
                            nameLabel,
                            email,
                            contact
                        }
                    });

                    detailGrid.GestureRecognizers.Add(tapGestureRecognizer);

                    #endregion



                    Grid grid = new Grid ();
                   
                    //Column Definition
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

                    //Row Definition
                    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    grid.Children.Add(Controls.CircleImage("croppedmembericon.png",60,60), 0,0);
                    grid.Children.Add(new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Children = {
                           detailGrid
                        }
                    }, 1, 0);



                    var viewCell = new ViewCell();
                    viewCell.ContextActions.Add(deleteAction);
                    viewCell.View = Controls.GridFrame(new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                            {
                                grid
                            }
                    });

                    return viewCell;
                })
            };

            //listView.ItemTapped += (s, e) =>
            //{

            //   // _viewModel.OnDelete((Member)e.Item);
            //     listView.BackgroundColor = Color.Green;
            //};

            #endregion

            #region image button for go to add new page

            var imageButton = new ImageButton
            {
                BackgroundColor = C_Color.ImgBtnBGColor,
                CornerRadius = 50,
                Padding= new Thickness(0,0),
                HeightRequest = 50,
                WidthRequest = 50,
                BorderColor=Color.Gray,
                BorderWidth=2,
                Source = "plus.png",
                Command = _viewModel.AddMemberCommand
            };
            #endregion

            #region absolute layout for image button 

            AbsoluteLayout layout = new AbsoluteLayout()
            {
                 Children=
                {
                    listView,
                    imageButton
                }
            };
            

            AbsoluteLayout.SetLayoutBounds(imageButton, new Rectangle {X =.95,Y=.97,Width = 50, Height = 50 });
            AbsoluteLayout.SetLayoutFlags(imageButton,AbsoluteLayoutFlags.PositionProportional);

            #endregion

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = layout;


        }
    }
}
