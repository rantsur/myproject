using PartnersMatcher.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using System.Windows.Shapes;

namespace PartnersMatcher.View
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        IController m_controller;
        public Search(IController controller)
        {
            m_controller = controller;
            InitializeComponent();
            tb_hello.Text = m_controller.UserName;
        }
        public void displayCategoryList(List<string> categoriesList)
        {
            categories.ItemsSource = categoriesList;
        }
        private void category_changed(object sender, RoutedEventArgs e)
        {
            results.Items.Clear();
            m_controller.updateCityList((string)categories.SelectedValue);
        }
        public void displayCityList(List<string> cityList)
        {
            city.ItemsSource = cityList;
        }
        private void search(object sender, RoutedEventArgs e)
        {
            results.Items.Clear();
            m_controller.search((string)categories.SelectedValue, (string)city.SelectedValue);
        }
        public void displaySearchResult(List<List<string>> reader)
        {
            int count = reader[0].Count;
            for (int i = 0; i < reader.Count; i++)
            {
                Grid itemGrid = new Grid();
                for (int j = 0; j < count; j++)
                {
                    ColumnDefinition c1 = new ColumnDefinition();
                    c1.Width = new GridLength(140);
                    itemGrid.ColumnDefinitions.Add(c1);
                }

                for (int j = 0; j < count; j++)
                {
                    Label l = new Label();
                    l.Content = reader[i][j];
                    if (i == 0)
                        l.FontWeight = FontWeights.Bold;
                    Grid.SetColumn(l, count - 1 - j);

                    l.VerticalAlignment = VerticalAlignment.Center;
                    l.HorizontalAlignment = HorizontalAlignment.Center;
                    itemGrid.Children.Add(l);
                }
                results.Items.Add(itemGrid);
            }
        }
        private void request_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Label id = (Label)((Grid)results.SelectedItem).Children[0];
                m_controller.openRequestWindow(int.Parse(id.Content.ToString()), m_controller.UserName);
            }
            catch (Exception)
            {
                m_controller.message("יש לבחור מודעה");
            }
        }
    }
}
