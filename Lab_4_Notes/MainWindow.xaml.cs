using System;
using System.IO;
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
using Microsoft.Win32;

namespace Lab_4_Notes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

     
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var bc = new BrushConverter();
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            if (selectedIndex == 0) {
                Text_Box.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
            }
            else if (selectedIndex == 1)
            {
                Text_Box.Background = (Brush)bc.ConvertFrom("#FFE07A5F");
            }
            else if (selectedIndex == 2)
            {
                Text_Box.Background = (Brush)bc.ConvertFrom("#FF3b5998");
            }
            else if (selectedIndex == 3)
            {
                Text_Box.Background = (Brush)bc.ConvertFrom("#FF81B29A");
            }
            
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            if (selectedIndex == 0)
            {
                Text_Box.FontSize = 12;
            }
            else if (selectedIndex == 1)
            {
                Text_Box.FontSize = 14;

            }
            else if (selectedIndex == 2)
            {
                Text_Box.FontSize = 16;
            }
            else if (selectedIndex == 3)
            {
                Text_Box.FontSize = 18;
            }
        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            if (selectedIndex == 0)
            {
                Text_Box.FontFamily = new FontFamily("Arial");
            }
            else if (selectedIndex == 1)
            {
                Text_Box.FontFamily = new FontFamily("Times New Roman");
            }
            else if (selectedIndex == 2)
            {
                Text_Box.FontFamily = new FontFamily("Verdana");
            }
            else if (selectedIndex == 3)
            {
                Text_Box.FontFamily = new FontFamily("Georgia");

            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Filter = "Textfiles|*.txt|All Files|*.*";
            fileDialog.DefaultExt = ".txt";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (fileDialog.ShowDialog() == true) {
                FileInfo fileInfo = new FileInfo(fileDialog.FileName);

                StreamReader reader = new StreamReader(fileInfo.Open(FileMode.Open, FileAccess.Read), Encoding.UTF8);

                Text_Box.Text = reader.ReadToEnd();

                reader.Close();
                return;

            }

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Textfiles|*.txt|All Files|*.*";
            saveFileDialog.DefaultExt = ".txt";
            if (saveFileDialog.ShowDialog()== true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.OpenFile(), System.Text.Encoding.UTF8))
                {
                    sw.Write(Text_Box.Text);
                    sw.Close();
                }
            }
        }
    }
}
