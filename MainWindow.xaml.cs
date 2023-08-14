using LiveCharts.Configurations;
using Sales_Dashboard.UserControls;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using static Sales_Dashboard.MainWindow;
using static System.Net.Mime.MediaTypeNames;

namespace Sales_Dashboard
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DispatcherTimer timer2;
        private DispatcherTimer timer3;

        ObservableCollection<Member> members = new ObservableCollection<Member>();
        ObservableCollection<Member> dataCollection = new ObservableCollection<Member>();

        int contadorclientes = 1;
        int contadorid= 1;
        int atenderusu= 1;
        int atendidosusu= 1;
        public MainWindow()
        {
            InitializeComponent();

            DateTime fechaActual = DateTime.Now;

            string fechaFormateada = fechaActual.ToString("dddd d 'de' MMMM");

            //fecha.Text = fechaFormateada.ToUpper();



            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();


            ReproductorDePrueba.Source = new Uri(@"C:\Users\Daniel Moya\Downloads\Sales-Dashboard-WPF-master\Sales-Dashboard-WPF-master\Images\BANCO BANELCO (1).mp4");
            ReproductorDePrueba.MediaEnded += MediaElement_MediaEnded;
            ReproductorDePrueba.Play();


        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            ReproductorDePrueba.Position = TimeSpan.Zero;
            ReproductorDePrueba.Play();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;

            string fechaFormateada = fechaActual.ToString("dddd d 'de' MMMM");

            DateTime horaActual = DateTime.Now;

            hora.Text = fechaFormateada.ToUpper() + " HORA : " + horaActual.ToString("HH:mm:ss");
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1280;
                    this.Height = 780;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            boton1.Visibility = boton1.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            boton2.Visibility = boton2.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            boton3.Visibility = boton3.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            boton4.Visibility = boton4.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            boton5.Visibility = boton5.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            boton6.Visibility = boton6.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void prueba_Click(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.Items.Count > 0)
            {
                DataGridRow firstRow = (DataGridRow)membersDataGrid.ItemContainerGenerator.ContainerFromIndex(0);
                if (firstRow != null)
                {
                    DataGridCell firstCell = (DataGridCell)membersDataGrid.Columns[2].GetCellContent(firstRow).Parent;
                    if (firstCell != null)
                    {
                        string contenido = ((TextBlock)firstCell.Content).Text;
                        DateTime ahora = DateTime.Now;
                        string horaActual = ahora.ToString("HH:mm:ss");
                        // Crear una instancia de tu UserControl
                        UserCard userControl = new UserCard();

                        // Asignar los datos recuperados a las propiedades del UserControl
                        userControl.Title = contenido;
                        userControl.IsActive = true;
                        userControl.UpPrice = horaActual;                   
                        userControl.Image = new BitmapImage(new Uri("/Images/u2.png", UriKind.Relative));

                        // Mostrar el UserControl en algún lugar de tu interfaz
                        // Por ejemplo, si tu UserControl está dentro de un contenedor llamado "contenedorUserControl":
                        // Establecer la opacidad inicial del UserControl a 0
                        userControl.Opacity = 0;

                        // Agregar el UserControl al WrapPanel
                        hola.Children.Add(userControl);
                        myMediaElement.Source = new Uri("C:\\Users\\Daniel Moya\\Downloads\\Sales-Dashboard-WPF-master\\Sales-Dashboard-WPF-master\\Images\\tono 1.WAV");
                        myMediaElement.Play();
                        // Crear y configurar la animación de desvanecimiento
                        DoubleAnimation fadeInAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = 1,
                            Duration = TimeSpan.FromSeconds(1),
                            EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
                        };

                        // Iniciar la animación
                        userControl.BeginAnimation(OpacityProperty, fadeInAnimation);

                        // Eliminar el elemento de la colección subyacente

                        if (membersDataGrid.ItemsSource is ObservableCollection<Member> items && items.Count > 0)
                        {
                            items.RemoveAt(0);
                        }
                        atender.Text = atendidosusu++.ToString();
                        atendidos.Text = membersDataGrid.Items.Count.ToString();
                        // Crear y configurar el DispatcherTimer
                        timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromSeconds(30);
                        timer.Tick += Timer_Tick1;

                        // Iniciar el DispatcherTimer
                        timer.Start();
                    }
                }
            }
        }



        private void prueba2_Click(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.Items.Count > 0)
            {
                DataGridRow firstRow = (DataGridRow)membersDataGrid.ItemContainerGenerator.ContainerFromIndex(0);
                if (firstRow != null)
                {
                    DataGridCell firstCell = (DataGridCell)membersDataGrid.Columns[2].GetCellContent(firstRow).Parent;
                    if (firstCell != null)
                    {
                        string contenido = ((TextBlock)firstCell.Content).Text;
                        DateTime ahora = DateTime.Now;
                        string horaActual = ahora.ToString("HH:mm:ss");
                        // Crear una instancia de tu UserControl
                        UserCard userControl = new UserCard();

                        // Asignar los datos recuperados a las propiedades del UserControl
                        userControl.Title = contenido;
                        userControl.IsActive = true;
                        userControl.UpPrice = horaActual;
                        userControl.Image = new BitmapImage(new Uri("/Images/u2.png", UriKind.Relative));

                        // Mostrar el UserControl en algún lugar de tu interfaz
                        // Por ejemplo, si tu UserControl está dentro de un contenedor llamado "contenedorUserControl":

                        // Establecer la opacidad inicial del UserControl a 0
                        userControl.Opacity = 0;
                        myMediaElement.Source = new Uri("C:\\Users\\Daniel Moya\\Downloads\\Sales-Dashboard-WPF-master\\Sales-Dashboard-WPF-master\\Images\\tono 1.WAV");
                        myMediaElement.Play();
                        // Agregar el UserControl al WrapPanel
                        hola1.Children.Add(userControl);

                        // Crear y configurar la animación de desvanecimiento
                        DoubleAnimation fadeInAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = 1,
                            Duration = TimeSpan.FromSeconds(1),
                            EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
                        };

                        // Iniciar la animación
                        userControl.BeginAnimation(OpacityProperty, fadeInAnimation);
                        // Eliminar el elemento de la colección subyacente


                        if (membersDataGrid.ItemsSource is ObservableCollection<Member> items && items.Count > 0)
                        {
                            items.RemoveAt(0);
                        }
                        atender.Text = atendidosusu++.ToString();
                        atendidos.Text = membersDataGrid.Items.Count.ToString();
                        // Crear y configurar el DispatcherTimer
                        timer2 = new DispatcherTimer();
                        timer2.Interval = TimeSpan.FromSeconds(30);
                        timer2.Tick += Timer_Tick2;

                        // Iniciar el DispatcherTimer
                        timer2.Start();
                    }
                }
            }
        }

        private void prueba3_Click(object sender, RoutedEventArgs e)
        {


            if (membersDataGrid.Items.Count > 0)
            {
                DataGridRow firstRow = (DataGridRow)membersDataGrid.ItemContainerGenerator.ContainerFromIndex(0);
                if (firstRow != null)
                {
                    DataGridCell firstCell = (DataGridCell)membersDataGrid.Columns[2].GetCellContent(firstRow).Parent;
                    if (firstCell != null)
                    {
                        string contenido = ((TextBlock)firstCell.Content).Text;
                        DateTime ahora = DateTime.Now;
                        string horaActual = ahora.ToString("HH:mm:ss");
                        // Crear una instancia de tu UserControl
                        UserCard userControl = new UserCard();

                        // Asignar los datos recuperados a las propiedades del UserControl
                        userControl.Title = contenido;
                        userControl.IsActive = true;
                        userControl.UpPrice = horaActual;
                        userControl.Image = new BitmapImage(new Uri("/Images/u2.png", UriKind.Relative));


                        // Establecer la opacidad inicial del UserControl a 0
                        userControl.Opacity = 0;
                        myMediaElement.Source = new Uri("C:\\Users\\Daniel Moya\\Downloads\\Sales-Dashboard-WPF-master\\Sales-Dashboard-WPF-master\\Images\\tono 1.WAV");
                        myMediaElement.Play();
                        // Agregar el UserControl al WrapPanel
                        hola2.Children.Add(userControl);

                        // Crear y configurar la animación de desvanecimiento
                        DoubleAnimation fadeInAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = 1,
                            Duration = TimeSpan.FromSeconds(1),
                            EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
                        };

                        // Iniciar la animación
                        userControl.BeginAnimation(OpacityProperty, fadeInAnimation);

                        if (membersDataGrid.ItemsSource is ObservableCollection<Member> items && items.Count > 0)
                        {
                            items.RemoveAt(0);
                        }

                        atender.Text = atendidosusu++.ToString();
                        atendidos.Text = membersDataGrid.Items.Count.ToString();
                        // Crear y configurar el DispatcherTimer
                        timer3 = new DispatcherTimer();
                        timer3.Interval = TimeSpan.FromSeconds(30);
                        timer3.Tick += Timer_Tick3;

                        // Iniciar el DispatcherTimer
                        timer3.Start();
                    }
                }
            }
        }


        private void Timer_Tick2(object sender, EventArgs e)
        {
            // Detener el DispatcherTimer
            timer2.Stop();

            hola1.Children.Clear();
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            // Detener el DispatcherTimer
            timer.Stop();

            hola.Children.Clear();
        }

        private void Timer_Tick3(object sender, EventArgs e)
        {
            // Detener el DispatcherTimer
            timer3.Stop();

            hola2.Children.Clear();
        }


        private void boton1_Click(object sender, RoutedEventArgs e)
        {

            myMediaElement.Source = new Uri("C:\\Users\\Daniel Moya\\Downloads\\Sales-Dashboard-WPF-master\\Sales-Dashboard-WPF-master\\Images\\Charming Bell - Samsung 2009 Notification Tune.wav");
            myMediaElement.Play();

            DateTime fechaHoraActual = DateTime.Now;
            string fechaHoraTexto = fechaHoraActual.ToString("dd/MM/yyyy HH:mm:ss");
            members.Add(new Member { Number = contadorid++.ToString() , Name = fechaHoraTexto , Position = "CC-0"+contadorclientes++, Email = "NORMAL", Phone = "Banco Banelco" });

            membersDataGrid.ItemsSource = members;
            atendidos.Text = membersDataGrid.Items.Count.ToString();
        }

        private void boton2_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source = new Uri("C:\\Users\\Daniel Moya\\Downloads\\Sales-Dashboard-WPF-master\\Sales-Dashboard-WPF-master\\Images\\Charming Bell - Samsung 2009 Notification Tune.wav");
            myMediaElement.Play();
            DateTime fechaHoraActual = DateTime.Now;
            string fechaHoraTexto = fechaHoraActual.ToString("dd/MM/yyyy HH:mm:ss");
            members.Add(new Member { Number = contadorid++.ToString(), Name = fechaHoraTexto, Position = "CP-0" + contadorclientes++, Email = "PREFERENCIAL", Phone = "Banco Banelco" });

            membersDataGrid.ItemsSource = members;
            atendidos.Text = membersDataGrid.Items.Count.ToString();
        }

        private void boton3_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source = new Uri("C:\\Users\\Daniel Moya\\Downloads\\Sales-Dashboard-WPF-master\\Sales-Dashboard-WPF-master\\Images\\Charming Bell - Samsung 2009 Notification Tune.wav");
            myMediaElement.Play();
            DateTime fechaHoraActual = DateTime.Now;
            string fechaHoraTexto = fechaHoraActual.ToString("dd/MM/yyyy HH:mm:ss");
            members.Add(new Member { Number = contadorid++.ToString(), Name = fechaHoraTexto, Position = "CSR-0" + contadorclientes++, Email = "SERVICIO RAPIDO", Phone = "Banco Banelco" });

            membersDataGrid.ItemsSource = members;
            atendidos.Text = membersDataGrid.Items.Count.ToString();
        }

        public class Member
        {
       
            public string Number { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void desabilitar_Click(object sender, RoutedEventArgs e)
        {
            if (desabilitartxt.Text == "Desabilitar")
            {
                desabilitartxt.Text = "Habilitar";
                prueba.Visibility = Visibility.Hidden;
            }
            else if (desabilitartxt.Text == "Habilitar")
            {
                desabilitartxt.Text = "Desabilitar";
                prueba.Visibility = Visibility.Visible;
            }
        }

        private void miToggleButton_Checked_1(object sender, RoutedEventArgs e)
        {
            // Crear el degradado
            RadialGradientBrush gradientBrush = new RadialGradientBrush();
            gradientBrush.GradientOrigin = new Point(0.5, 0.5);
            gradientBrush.Center = new Point(0.5, 0.5);
            gradientBrush.RadiusX = 0.5;
            gradientBrush.RadiusY = 0.5;

            // Agregar los colores y las posiciones de parada al degradado
            gradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF4B6CB7"), 0));
            gradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF182848"), 1));

            // Asignar el degradado al Background del Border
            bordermain.Background = gradientBrush;


            // Crear el degradado
            LinearGradientBrush gradientBrush1 = new LinearGradientBrush();
            gradientBrush1.StartPoint = new Point(0, 0);
            gradientBrush1.EndPoint = new Point(1, 1);

            // Agregar los colores y las posiciones de parada al degradado
            gradientBrush1.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF4B6CB7"), 0));
            gradientBrush1.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF182848"), 0.8));

            // Asignar el degradado al Background del Border
            panel.Background = gradientBrush1;


        }

        private void miToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            bordermain.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));


            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(0, 0);
            gradientBrush.EndPoint = new Point(0, 1);

            gradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FB7154"), 0));
            gradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FB6161"), 0.8));

            panel.Background = gradientBrush;

        }

        private void salir_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void desabilitar1_Click(object sender, RoutedEventArgs e)
        {
            if (dasabilitar12.Text == "Desabilitar")
            {
                dasabilitar12.Text = "Habilitar";
                prueba1.Visibility = Visibility.Hidden;
            }
            else if (dasabilitar12.Text == "Habilitar")
            {
                dasabilitar12.Text = "Desabilitar";
                prueba1.Visibility = Visibility.Visible;
            }
        }

        private void desabilitar2_Click(object sender, RoutedEventArgs e)
        {
            if (desabilitar123.Text == "Desabilitar")
            {
                desabilitar123.Text = "Habilitar";
                prueba2.Visibility = Visibility.Hidden;
            }
            else if (desabilitar123.Text == "Habilitar")
            {
                desabilitar123.Text = "Desabilitar";
                prueba2.Visibility = Visibility.Visible;
            }
        }

        private void miToggleButton2_Checked(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source = new Uri("C:\\Users\\Daniel Moya\\Downloads\\Sales-Dashboard-WPF-master\\Sales-Dashboard-WPF-master\\Images\\Eagles - Hotel California (Instrumental).wav");
            myMediaElement.Play();
        }

        private void miToggleButton2_Unchecked(object sender, RoutedEventArgs e)
        {
            myMediaElement.Source = new Uri("C:\\Users\\Daniel Moya\\Downloads\\Sales-Dashboard-WPF-master\\Sales-Dashboard-WPF-master\\Images\\nothing really matters that much to me anymore..wav");
            myMediaElement.Pause();
        }

        private void reiniciar_Click(object sender, RoutedEventArgs e)
        {
            membersDataGrid.ItemsSource = dataCollection;

            dataCollection.Clear();
            atendidos.Text = "0";
            atender.Text = "0";
        }
    }
}