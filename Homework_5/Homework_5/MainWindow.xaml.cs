using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pixel pixel = new Pixel();
        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Grid1.Visibility = Visibility.Visible;
            Grid2.Visibility = Visibility.Hidden;
            Grid3.Visibility = Visibility.Hidden;
            UpdateWindow();
        }

        private void btnColor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pixel.R = int.Parse(tbRed.Text);
                pixel.G = int.Parse(tbGreen.Text);
                pixel.B = int.Parse(tbBlue.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Вводить нужно числа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Вводить нужно числа в диапазоне от 0 до 255!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                UpdateWindow();
            }
        }
        private void btnXY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pixel.X = int.Parse(tbX.Text);
                pixel.Y = int.Parse(tbY.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Вводить нужно числа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Произошло непредвиденное исключение!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                UpdateWindow();
            }
            lblResult.Content = ($"({pixel.X};{pixel.Y})");
        }
        public void UpdateWindow()
        {
            tbX.Text = pixel.X.ToString();
            tbY.Text = pixel.Y.ToString();
            tbRed.Text = pixel.R.ToString();
            tbGreen.Text = pixel.G.ToString();
            tbBlue.Text = pixel.B.ToString();
            byte r = (byte)pixel.R;
            byte g = (byte)pixel.G;
            byte b = (byte)pixel.B;
            tbPixel.Background = new SolidColorBrush(Color.FromArgb(255, r, g, b));
        }
        class Pixel
        {
            private int m_x;
            private int m_y;
            private int m_R;
            private int m_G;
            private int m_B;
            public Pixel()
            {
                Random rnd = new Random();
                m_R = rnd.Next(0, 256);
                m_G = rnd.Next(0, 256);
                m_B = rnd.Next(0, 256);
                m_x = 100;
                m_y = 100;
            }
            public int Y
            {
                set
                {
                    if (value > 0)
                        m_y = value;
                }
                get
                {
                    return m_y;
                }
            }
            public int X
            {
                set
                {
                    if (value > 0 && value < 100)
                        m_x = value;
                }
                get
                {
                    return m_x;
                }
            }
            public int R
            {
                set
                {
                    if (value >= 0 && value <= 255)
                        m_R = value;
                    else
                        throw new Exception("WrongRGB");
                }
                get
                {
                    return m_R;
                }
            }
            public int G
            {
                set
                {
                    if (value >= 0 && value <= 255)
                        m_G = value;
                    else
                        throw new Exception("WrongRGB");
                }
                get
                {
                    return m_G;
                }
            }
            public int B
            {
                set
                {
                    if (value >= 0 && value <= 255)
                        m_B = value;
                    else
                        throw new Exception("WrongRGB");
                }
                get
                {
                    return m_B;
                }
            }
            public override string ToString()
            {
                return $"Цвет:R({m_R}), G({m_G}), B({m_B}), координаты ({m_x}; {m_y})";
            }
        }
    }
}
