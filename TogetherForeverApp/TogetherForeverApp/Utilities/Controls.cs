using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TogetherForeverApp.Utilities
{
    public class Controls
    {
        public static Frame GridFrame(View content)
        {
            return new Frame
            {
                BackgroundColor =Color.FromHex(C_Color.FrameColor),
                CornerRadius = 4,
                Padding = new Thickness(0),
                Margin= new Thickness(0,2),
                Content = content
            };
        }
        public static Frame CircleImage(string imgPath, double width, double height)
        {
            Image image = new Image
            {
                HeightRequest = height,
                WidthRequest = width,
                Source = ImageSource.FromFile(imgPath)
            };
            return new Frame
            {
                CornerRadius = 50,
                HeightRequest = height,
                WidthRequest = width,
                Padding = 3,
                Margin = 5,
                Content = image

            };
        }

    }
}
