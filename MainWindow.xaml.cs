using PropertyChanged;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfAppExam
{
    public partial class MainWindow : Window
    {
        public bool capsLockEnabled = false;

        ViewModel viewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string buttonName = e.Key.ToString();
            Button myButton = this.FindName(buttonName) as Button;
            if (myButton != null)
            {
                myButton.Margin = new Thickness(2);
                myButton.SetValue(BorderThicknessProperty, new Thickness(0, 0, 0, 5));

                WorkText(buttonName);

                viewModel.GameText(viewModel.letter);
            }

        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            string buttonName = e.Key.ToString();
            Button myButton = this.FindName(buttonName) as Button;
            if (myButton != null)
            {
                myButton.Margin = new Thickness(5);
                myButton.ClearValue(BorderThicknessProperty);
            }
        }

        public void WorkText(string button)
        {

            if (button.Length == 1)
            {
                if ((Keyboard.Modifiers & ModifierKeys.Shift) != ModifierKeys.Shift && !capsLockEnabled)
                {
                    button = button.ToLower();
                    viewModel.letter = button; 
                }
                else
                {
                    viewModel.letter = button;
                }
                
            }

            if (button.Length == 2)
            {
                button = button[1].ToString();
                viewModel.letter = button;
            }

            if (button == "Oem3") { button = "`"; viewModel.letter = button; }
            if (button == "OemMinus") { button = "-"; viewModel.letter = button; }
            if (button == "OemPlus") { button = "="; viewModel.letter = button; }
            if (button == "OemOpenBrackets") { button = "["; viewModel.letter = button; }
            if (button == "Oem6") { button = "]"; viewModel.letter = button; }
            if (button == "Oem5") { button = "\\"; viewModel.letter = button; }
            if (button == "Oem1") { button = ";"; viewModel.letter = button; }
            if (button == "OemQuotes") { button = "'"; viewModel.letter = button; }
            if (button == "OemComma") { button = ","; viewModel.letter = button; }
            if (button == "OemPeriod") { button = "."; viewModel.letter = button; }
            if (button == "OemQuestion") { button = "/"; viewModel.letter = button; }
            if (button == "Space") { button = " "; viewModel.letter = button; }
            if (button == "LeftShift") { button = "LeftShift"; viewModel.letter = button; }

            if (button == "Capital")
            {
                capsLockEnabled = !capsLockEnabled;
                return;
            }
        }
    }
}