using System.Globalization;
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

namespace ManuelBelausteguiChallengeM5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DateChange(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SelectClick(object sender, RoutedEventArgs e)
        {
            
            if(Calendar.SelectedDate.HasValue)
            {
                DateTime date = Calendar.SelectedDate.Value;
                DateTime current = DateTime.Today.Date;
                TimeSpan diff = date.Date - current;
                int difDays = (int)diff.TotalDays;
                if(difDays> 0) { 
                    string dateString = date.ToString("dddd,MMMM,dd,yyyy");
                    DateTime time = DateTime.Parse(TimeTextBox.Text);
                    string timeString = time.ToString("hh:mm tt");
                    string result = $"Your appointment is on {dateString} at {timeString}. It's {difDays} days from today";
                    MessageBox.Show(result);
                }
                else
                {
                    string error = "Date is before current date. Pick a valid date";
                    MessageBox.Show(error);
                }
                
            }
            else
            {
                string error = "Invalid Date Selected";
                MessageBox.Show(error);
            }
           
        }

        private void DownClick(object sender, RoutedEventArgs e)
        {
            ChangeTime(-1);
        }

        private void UpClick(object sender, RoutedEventArgs e)
        {
            ChangeTime(1);
        }
        private void ChangeTime( int adj)
        {
            DateTime time= DateTime.Parse(TimeTextBox.Text);
            int caret = TimeTextBox.CaretIndex;
            if(caret < 2)
            {
                time = time.AddHours(adj);
            }
            else if (caret < 5)
            {
                time = time.AddMinutes(adj);
            }
            else
            {
                time = time.AddHours(adj * 12);
            }
            TimeTextBox.Text= time.ToString("hh:mm tt");
        }
    }
}