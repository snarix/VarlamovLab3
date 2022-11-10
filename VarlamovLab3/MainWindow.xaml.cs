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
using LibMatrix;
using Lib_3;

namespace VarlamovLab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height += 25;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AboutProgramm(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }

        Matrix<int> matrix;

        private void CreateArray(object sender, RoutedEventArgs e)
        {
            if (Create.IsEnabled)
            {
                ClearArray.IsEnabled = true;
                Save.IsEnabled = true;
                Default.IsEnabled = true;
                Calculate.IsEnabled = true;
            }

            if (!int.TryParse(RowCount.Text, out int rowcount) || !int.TryParse(ColumnCount.Text, out int columncount))
            {
                MessageBox.Show("Неверный размер массива");
                return;
            }
            if (columncount <= 0 || rowcount <= 0)
            {
                MessageBox.Show("Размер массива должен быть больше 0");
                return;
            }

            matrix = new Matrix<int>(rowcount, columncount);
            matrix.CreateArray();
            Table.ItemsSource = matrix.ToDataTable().DefaultView;           
        }
        private void CalculateArray(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(ExtensionMatrix.ArrayDifference(matrix).ToString());
        }

        private void DefaultArray(object sender, RoutedEventArgs e)
        {

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            matrix.Clear();
            Table.ItemsSource = null;
        }

        private void SaveArray(object sender, RoutedEventArgs e)
        {

        }

        private void LoadArray(object sender, RoutedEventArgs e)
        {

        }


    }
}
