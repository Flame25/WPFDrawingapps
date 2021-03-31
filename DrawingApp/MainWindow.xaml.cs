using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        private Polyline line;
        private Point startPoint;
        private Color color;
        private int lineSize;
        private bool isPaint;
        #endregion

        #region Sizes
        private enum sizes 
        {
            small = 2,
            normal = 5,
            big = 10
        }
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region MouseLeft
        private void ThisCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            line = new Polyline();
            startPoint = e.GetPosition(ThisCanvas);
            if (isPaint)
            {
                line.Stroke = new SolidColorBrush(color);
            }

            else
            {
                line.Stroke = new SolidColorBrush(Colors.White);
            }
            
            line.StrokeThickness = lineSize; 
            ThisCanvas.Children.Add(line); 
        }
        #endregion

        //Start Drawing Line based on Vector (currentPoint returns vector) 
        #region Start Drawing
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPoint = e.GetPosition(ThisCanvas);
                
                if(currentPoint != startPoint)
                { 
                    line.Points.Add(currentPoint);
                }
            }
        }
        #endregion

        #region Undo Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = ThisCanvas.Children.Count; 
            if(count > 0)
            {
                ThisCanvas.Children.RemoveAt(count - 1); 
            }
        }
        #endregion

        #region Clear Button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ThisCanvas.Children.Clear(); 
        }

        #endregion

        #region Colors
        private void BlackButton_Checked(object sender, RoutedEventArgs e)
        {
            color = Colors.Black; 
        }

        private void BlueButton_Checked(object sender, RoutedEventArgs e)
        { 
            color = Colors.Blue;
        }

        private void RedButton_Checked(object sender, RoutedEventArgs e)
        {
            color = Colors.Red; 
        }

        #endregion

        #region Line Size
        private void BigButton_Checked(object sender, RoutedEventArgs e)
        {
            lineSize = (int)sizes.big; 
        }

        private void SmallButton_Checked(object sender, RoutedEventArgs e)
        {
            lineSize = (int)sizes.small;
        }

        private void NormalButton_Checked(object sender, RoutedEventArgs e)
        {
            lineSize = (int)sizes.normal;
        }
        #endregion

        #region Mode
        private void PaintMode_Checked(object sender, RoutedEventArgs e)
        {
            isPaint = true;
        }

        private void DeleteMode_Checked(object sender, RoutedEventArgs e)
        {
            isPaint = false;
        }
        #endregion

    }
}
