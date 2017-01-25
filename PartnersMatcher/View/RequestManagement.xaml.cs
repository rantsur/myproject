using PartnersMatcher.Controller;
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
using System.Windows.Shapes;

namespace PartnersMatcher.View
{
    /// <summary>
    /// Interaction logic for RequestManagement.xaml
    /// </summary>
    public partial class RequestManagement : Window//mor
    {
        private IController m_controller;
        string m_userName;

        public RequestManagement(IController controller, string userName, Tuple<List<string>, List<string>> info)
        {
            m_controller = controller;
            InitializeComponent();
            m_userName = userName;
            button_approve.IsEnabled = false;
            button_reject.IsEnabled = false;
            textBlockForInformation.Text = "!שלום" + " " + m_userName; // set user name value
            displayWaitforMeRequests(info.Item1);
            displayMyRequests(info.Item2);
        }

        public void displayMyRequests(List<string> myRequest)
        {
            for (int i = 0; i < myRequest.Count; i++)
            {
                Grid itemGrid = new Grid();

                //set columns
                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = new GridLength(170); // Status column
                itemGrid.ColumnDefinitions.Add(c1);
                ColumnDefinition c2 = new ColumnDefinition();
                c2.Width = new GridLength(80); // AdID column
                itemGrid.ColumnDefinitions.Add(c2);

                string[] splittedRecord = myRequest[i].Split(';');
                for (int j = 0; j < 2; j++) // insert data
                {
                    Label l = new Label();
                    l.Content = splittedRecord[j];
                    Grid.SetColumn(l, 1 - j);

                    if (i == 0) // emphsize headline
                        l.FontWeight = FontWeights.Bold;

                    l.VerticalAlignment = VerticalAlignment.Center;
                    l.HorizontalAlignment = HorizontalAlignment.Center;
                    itemGrid.Children.Add(l);
                }
                listBox_waitForResponse.Items.Add(itemGrid);
            }
        }

        public void displayWaitforMeRequests(List<string> requestList)
        {
            textBlockCounter.Text = (requestList.Count - 1).ToString(); // set number of requests text block
            for (int i = 0; i < requestList.Count; i++)
            {
                Grid itemGrid = new Grid();

                //set columns
                ColumnDefinition c3 = new ColumnDefinition();
                //c3.Width = new GridLength(1, GridUnitType.Star); // content column
                c3.Width = new GridLength(400); // content column
                itemGrid.ColumnDefinitions.Add(c3);
                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = new GridLength(90); // userName column
                itemGrid.ColumnDefinitions.Add(c1);
                ColumnDefinition c2 = new ColumnDefinition();
                c2.Width = new GridLength(80); // ID column
                itemGrid.ColumnDefinitions.Add(c2);

                string[] splittedRecord = requestList[i].Split(';');
                for (int j = 0; j < 3; j++) // insert data
                {
                    Label l = new Label();
                    l.Content = splittedRecord[j];
                    Grid.SetColumn(l, 2 - j);

                    if (i == 0) // emphsize headline
                        l.FontWeight = FontWeights.Bold;

                    l.VerticalAlignment = VerticalAlignment.Center;
                    l.HorizontalAlignment = HorizontalAlignment.Center;
                    itemGrid.Children.Add(l);
                }
                listBox_waitForMe.Items.Add(itemGrid);
            }
        }

        private void button_approve_Click(object sender, RoutedEventArgs e)
        {
            if (listBox_waitForMe.SelectedItem != null)
            {
                Label id = (Label)((Grid)listBox_waitForMe.SelectedItem).Children[0];
                int adId = int.Parse(id.Content.ToString());
                Label userName = (Label)((Grid)listBox_waitForMe.SelectedItem).Children[1];
                m_controller.approveRequest(adId, userName.Content.ToString(), m_controller.UserName);
                listBox_waitForMe.Items.Remove(listBox_waitForMe.SelectedIndex);
                button_approve.IsEnabled = false;
                button_reject.IsEnabled = false;
            }
            else
                m_controller.message("נא לבחור בקשה מהרשימה");
        }

        private void button_reject_Click(object sender, RoutedEventArgs e)
        {
            if (listBox_waitForMe.SelectedItem != null)
            {
                Label id = (Label)((Grid)listBox_waitForMe.SelectedItem).Children[0];
                Label userName = (Label)((Grid)listBox_waitForMe.SelectedItem).Children[1];
                m_controller.rejectRequest(int.Parse(id.Content.ToString()), userName.Content.ToString(), m_controller.UserName);
                listBox_waitForMe.Items.Remove(listBox_waitForMe.SelectedIndex);
                button_approve.IsEnabled = false;
                button_reject.IsEnabled = false;
            }
            else
                m_controller.message("נא לבחור בקשה מהרשימה");
        }

        private void listBox_waitForMe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox_waitForMe.SelectedIndex == 0) // choose the headline
            {
                listBox_waitForMe.UnselectAll();
                button_approve.IsEnabled = false;
                button_reject.IsEnabled = false;
                return;
            }
            button_approve.IsEnabled = true;
            button_reject.IsEnabled = true;
        }

        private void myEvent(object sender, SelectionChangedEventArgs e)
        {
            listBox_waitForResponse.UnselectAll();
            button_approve.IsEnabled = false;
            button_reject.IsEnabled = false;
        }

        private void listBox_waitForMe_GotFocus(object sender, RoutedEventArgs e)
        {
            if(listBox_waitForMe.SelectedItem!=null)
            {
                button_approve.IsEnabled = true;
                button_reject.IsEnabled = true;
            }
        }
    }
}