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
    /// Interaction logic for openRequest.xaml
    /// </summary>
    public partial class openRequest : Window
    {
        private IController m_controller;
        string m_userName;
        int m_adId;
        public openRequest(int adID, string user_name, IController controller)
        {
            m_controller = controller;
            m_userName = user_name;
            m_adId = adID;
            InitializeComponent();
            counterBlock.Text = "70";
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            string content = textBox_content.Text;
            m_controller.sendRequest(m_adId, m_userName, content);
        }

        private void textBox_content_TextChanged(object sender, TextChangedEventArgs e)
        {
            int numberOfCharsTyped = textBox_content.Text.Count();
            if (numberOfCharsTyped > 70)// check the length of the content
            {
                m_controller.message("תוכן הבקשה מוגבל לעד 70 תווים");
                textBox_content.Text = textBox_content.Text.Substring(0, 69);
                numberOfCharsTyped -= 1;
            }
            counterBlock.Text = 70 - numberOfCharsTyped + "";
        }
    }
}
