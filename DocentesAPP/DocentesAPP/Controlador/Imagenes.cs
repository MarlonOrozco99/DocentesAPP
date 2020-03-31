using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DocentesAPP
{
   public class Imagenes
    {
        public static ImageSource LogoUtap { get; } = ImageSource.FromFile("LogoUtap.png");
        public static ImageSource Plus { get; } = ImageSource.FromFile("Plus.png");
        public static ImageSource Back { get; } = ImageSource.FromFile("Back.png");
    }
}
