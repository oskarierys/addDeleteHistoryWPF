using System;
using System.Collections;
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

namespace listView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private List<string> deletedItems = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            lvEntries.Items.Add(txtEntry.Text);
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            /*
            int index = lvEntries.SelectedIndex;
            lvEntries.Items.RemoveAt(index);
            */

            /*
            var items = lvEntries.Items;

            var itemsList = new ArrayList(items);
            foreach (var item in itemsList)
            {
                lvEntries.Items.Remove(item);
            }
            */

            object item = lvEntries.SelectedItem;
            if (item != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete: {(string)item}", "Sure?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    lvEntries.Items.Remove(item);
                    deletedItems.Add((string)item);
                    UpdateHistory();
                }
            }
        }

        private void btnClc_Click(object sender, RoutedEventArgs e)
        {
            lvEntries.Items.Clear();
        }

        private void UpdateHistory()
        {
            tbHistory.Text = string.Join(Environment.NewLine, deletedItems);
        }
    }
}
