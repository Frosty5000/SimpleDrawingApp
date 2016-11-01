using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

namespace SimpleDrawingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            //Event handlers for mouse and keyboard actions
            InitializeComponent();

            this.MouseDown += new MouseButtonEventHandler(Canvas_Click);
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            this.PreviewKeyDown += new KeyEventHandler(ctrlReset_KeyDown);
        }



        private void ctrlReset_Click(object sender, RoutedEventArgs e)
        {   //Clears the canvas
            Canvas.Children.Clear();
        }

        private void ctrlReset_KeyDown(object sender, KeyEventArgs e)
        {   //Clears the canvas with Ctrl + X 
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.X)
            {
               Canvas.Children.Clear();
            }
        }

        private void escExit_Click(object sender, RoutedEventArgs e)
        {   //Closes the application
            Close();
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {   //Closes the application with the Esc key.
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void comboBox_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Defining
        }

        private void Canvas_Click(object sender, MouseEventArgs e)
        {
            // Get mouse position.7
            Point p = System.Windows.Input.Mouse.GetPosition(Canvas);

            // Initialize a new shape.
            Rectangle r = new Rectangle();
            Ellipse el = new Ellipse();
            Line l = new Line();


            // Set up shapes size.
             r.Width = 70; el.Width = 70; l.X1 = 50;
             r.Height = 50; el.Height = 50; l.Y1 = 50;

            // User selects color for shape filling.
            if (White1.IsSelected == true) { r.Fill = Brushes.White; el.Fill = Brushes.White; }
            if (Gray1.IsSelected == true) { r.Fill = Brushes.Gray; el.Fill = Brushes.Gray; }
            if (Black1.IsSelected == true) { r.Fill = Brushes.Black; el.Fill = Brushes.Black; }
            if (Yellow1.IsSelected == true) { r.Fill = Brushes.Yellow; el.Fill = Brushes.Yellow; }
            if (Orange1.IsSelected == true) { r.Fill = Brushes.Orange; el.Fill = Brushes.Orange; }
            if (Red1.IsSelected == true) { r.Fill = Brushes.Red; el.Fill = Brushes.Red; }
            if (Green1.IsSelected == true) { r.Fill = Brushes.Green; el.Fill = Brushes.Green; }
            if (Blue1.IsSelected == true) { r.Fill = Brushes.Blue; el.Fill = Brushes.Blue; }
            if (Violet1.IsSelected == true) { r.Fill = Brushes.Violet; el.Fill = Brushes.Violet; }
            if (Pink1.IsSelected == true) { r.Fill = Brushes.Pink; el.Fill = Brushes.Pink; }
            if (Azure1.IsSelected == true) { r.Fill = Brushes.Azure; el.Fill = Brushes.Azure; }
            if (Brown1.IsSelected == true) { r.Fill = Brushes.Brown; el.Fill = Brushes.Brown; }

            // User selects color for shape's outline *Line has no filling since lines have no area to fill, only outlines are necessary*.
            if (White2.IsSelected == true) { r.Stroke = Brushes.White; el.Stroke = Brushes.White; l.Stroke = Brushes.White; }
            if (Gray2.IsSelected == true) { r.Stroke = Brushes.Gray; el.Stroke = Brushes.Gray; l.Stroke = Brushes.Gray; }
            if (Black2.IsSelected == true) { r.Stroke = Brushes.Black; el.Stroke = Brushes.Black; l.Stroke = Brushes.Black; }
            if (Yellow2.IsSelected == true) { r.Stroke = Brushes.Yellow; el.Stroke = Brushes.Yellow; l.Stroke = Brushes.Yellow; }
            if (Orange2.IsSelected == true) { r.Stroke = Brushes.Orange; el.Stroke = Brushes.Orange; l.Stroke = Brushes.Orange; }
            if (Red2.IsSelected == true) { r.Stroke = Brushes.Red; el.Stroke = Brushes.Red; l.Stroke = Brushes.Red; }
            if (Green2.IsSelected == true) { r.Stroke = Brushes.Green; el.Stroke = Brushes.Green; l.Stroke = Brushes.Green; }
            if (Blue2.IsSelected == true) { r.Stroke = Brushes.Blue; el.Stroke = Brushes.Blue; l.Stroke = Brushes.Blue; }
            if (Violet2.IsSelected == true) { r.Stroke = Brushes.Violet; el.Stroke = Brushes.Violet; l.Stroke = Brushes.Violet; }
            if (Pink2.IsSelected == true) { r.Stroke = Brushes.Pink; el.Stroke = Brushes.Pink; l.Stroke = Brushes.Pink; }
            if (Azure2.IsSelected == true) { r.Stroke = Brushes.Azure; el.Stroke = Brushes.Azure; l.Stroke = Brushes.Azure; }
            if (Brown2.IsSelected == true) { r.Stroke = Brushes.Brown; el.Stroke = Brushes.Brown; l.Stroke = Brushes.Brown; }

            string newValue;
            newValue = textBox.Text;

            // Outline thickness of shapes
            r.StrokeThickness = Convert.ToDouble(newValue);
            el.StrokeThickness = Convert.ToDouble(newValue);
            l.StrokeThickness = Convert.ToDouble(newValue);

            // Set up the position in the window, at mouse coordonate.
            Canvas.SetTop(r, p.Y); Canvas.SetTop(el, p.Y); Canvas.SetTop(l, p.Y);
            Canvas.SetLeft(r, p.X); Canvas.SetLeft(el, p.X); Canvas.SetLeft(l, p.X);

            // Add shapes to the Canvas
            if (El.IsSelected == true) { Canvas.Children.Add(el); }
            if (R.IsSelected == true) { Canvas.Children.Add(r); }
            if (L.IsSelected == true) { Canvas.Children.Add(l); }
        }

        
        public void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string newValue;
            newValue = textBox.Text;
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
    }
}
