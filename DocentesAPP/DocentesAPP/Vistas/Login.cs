using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocentesAPP
{
    public class Login : ContentPage
    {
        RelativeLayout VistaPrincipal;
        StackLayout VistaCirculo;
        StackLayout VistaGeneral;
        Entry entryDocumento, entryCodigo, entryPassword;
        Label Bienvenidos;
        Button buttonAcceder;
        ImageSource Logo;
        Label OlvidarPassword;
        BoxView Circulo;
        BoxView Circulo2;
        uint Tiempo = 200;
        PaginaPrincipal paginaprincipal;
        Image Back;
        TapGestureRecognizer TapBack;

        public Login()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            paginaprincipal = new PaginaPrincipal
            {
                TranslationX = 420,
                BackgroundColor = Color.White

            };
            CrearVistas();
            AgregarVistas();
            AgregarEventos();
        }

        void CrearVistas()
        {
            VistaPrincipal = new RelativeLayout();
            entryCodigo = new Entry
            {
                Placeholder = "Codigo"
            };
            entryDocumento = new Entry
            {
                Placeholder = "Documento"
            };
            entryPassword = new Entry
            {
                Placeholder = "Contraseña"
            };
            buttonAcceder = new Button
            {
                Text = "Acceder A la App",
                //Scale = 0 //tamaño al que inicia el boton

            };
            Bienvenidos = new Label
            {
                Text = "Bienvenidos"
            };
            Circulo = new BoxView
            {
                BackgroundColor = Color.Black,
                CornerRadius = 40,
                Scale = 20
            };
            Back = new Image
            {
                Source = Imagenes.Back,
                IsVisible = false

            };
            //Circulo2 = new BoxView
            //{
            //    Scale = 20,
            //    BackgroundColor = Color.Red,
            //    CornerRadius = 40
            //};
            VistaGeneral = new StackLayout();
            VistaCirculo = new StackLayout();

            buttonAcceder.Clicked += ButtonAcceder_Clicked;

            TapBack = new TapGestureRecognizer();

            Back.GestureRecognizers.Add(TapBack);

            VistaGeneral.HorizontalOptions = LayoutOptions.Center;
            VistaGeneral.VerticalOptions = LayoutOptions.CenterAndExpand;

        }

        private async void ButtonAcceder_Clicked(object sender, EventArgs e)
        {
            Rectangle dimensiones = paginaprincipal.Bounds;
            await paginaprincipal.TranslateTo(0, 0, 300);
            Back.IsVisible = true;
        }
        async Task AnimacionInicial()
        {

            await buttonAcceder.ScaleTo(0.80, Tiempo);
            await buttonAcceder.ScaleTo(1, Tiempo);
        }
        async Task AnimacionCirculo()
        {
            uint Tiempo1 = 800;
            //await Circulo2.ScaleTo(0, Tiempo1);
            await Circulo.ScaleTo(0, Tiempo1);
            Circulo.BackgroundColor = Color.Blue;
            await Circulo.ScaleTo(40, Tiempo1);

            await Circulo.FadeTo(0, Tiempo1);


        }


        protected override async void OnAppearing()
        {
            base.OnAppearing(); //Se activa a lo que ingrese a la pagina
                                //await Task.Delay(800);

            await AnimacionCirculo();

            // await AnimacionCirculo2();


            //await AnimacionCirculo();

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing(); //antes de ir de la pagina se ejecuta
        }
        void AgregarVistas()
        {
            VistaGeneral.Children.Add(Bienvenidos);
            VistaGeneral.Children.Add(entryCodigo);
            VistaGeneral.Children.Add(entryDocumento);
            VistaGeneral.Children.Add(entryPassword);
            VistaGeneral.Children.Add(buttonAcceder);
            //            VistaGeneral.Children.Add(VistaPrincipal);


            VistaPrincipal.Children.Add(Circulo,
           //Constraint.RelativeToParent((p) => { return p.Width * 0; }), // X Posicion
           //Constraint.RelativeToParent((p) => { return p.Height * 0; }),// Y Posicion
           Constraint.RelativeToParent((p) => { return p.Width * 0.45; }),
           Constraint.RelativeToParent((p) => { return p.Height * 0.4; }));

            VistaPrincipal.Children.Add(VistaGeneral,
                Constraint.RelativeToParent((p) => { return p.Width * 0.3; }),
                Constraint.RelativeToParent((p) => { return p.Width * 0.4; })
                );
            //VistaPrincipal.Children.Add(Circulo2,
            //    Constraint.RelativeToParent((p) => { return p.Width * 0.45; }),
            //    Constraint.RelativeToParent((p => { return p.Height * 0.4; })));

            VistaPrincipal.Children.Add(paginaprincipal,
       Constraint.RelativeToParent((p) => { return p.Width * 0; }), // X Posicion
       Constraint.RelativeToParent((p) => { return p.Height * 0; }),// Y Posicion
       Constraint.RelativeToParent((p) => { return p.Width; }),
       Constraint.RelativeToParent((p) => { return p.Height; }));
            VistaPrincipal.Children.Add(Back,
               Constraint.RelativeToParent((p) => { return p.Width * 0; }),
               Constraint.RelativeToParent((p) => { return p.Width * 0; })
               );
            Content = VistaPrincipal;

        }

        void AgregarEventos()
        {
            Back.GestureRecognizers.Add(TapBack);
            TapBack.Tapped += TapBack_Tapped;
        }
  

        private async void TapBack_Tapped(object sender, EventArgs e)
        {
            await paginaprincipal.TranslateTo(450, 0, 200);
            Back.IsVisible = false;

        }
    }
}