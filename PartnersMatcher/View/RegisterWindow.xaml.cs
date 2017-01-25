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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private IController m_controller;
        public RegisterWindow(IController controller)
        {
            m_controller = controller;
            InitializeComponent();
            initializeLists();
        }

        private void initializeLists()
        {
            for (int i = 2002; i > 1930; i--) //initialize years list
                lb_yaer.Items.Add(i.ToString());

            for (int i = 1; i < 13; i++) //initialize months list
                lb_month.Items.Add(i.ToString());

            for (int i = 1; i < 32; i++) //initialize days list
                lb_day.Items.Add(i.ToString());

            lb_gender.Items.Add("זכר"); //initialize gender list
            lb_gender.Items.Add("נקבה");
            lb_gender.Items.Add("אחר");

            lb_prof.Items.Add("סטודנט"); //initialize occupation list
            lb_prof.Items.Add("שכיר");
            lb_prof.Items.Add("עצמאי");
            lb_prof.Items.Add("מובטל");

            lb_animal.Items.Add("מגדל חיה"); //initialize animals list
            lb_animal.Items.Add("אוהב");
            lb_animal.Items.Add("שונא");
            lb_animal.Items.Add("לא משנה");

            lb_family.Items.Add("נשוי"); //initialize martial status list
            lb_family.Items.Add("רווק");
            lb_family.Items.Add("גרוש");
        }

        private void createNewUser_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> userData = new Dictionary<string, string>();
            userData.Add("user name", tb_username.Text);
            userData.Add("password", tb_password.Password);
            userData.Add("verify password", tb_verPassword.Password);
            userData.Add("first name", tb_fname.Text);
            userData.Add("last name", tb_lname.Text);
            userData.Add("city", tb_city.Text);
            userData.Add("street", tb_street.Text);
            userData.Add("mail", tb_email.Text);
            userData.Add("discription", tb_general.Text);

            Dictionary<string, ComboBox> comboBox = new Dictionary<string, ComboBox>();
            comboBox.Add("gender", lb_gender);
            comboBox.Add("day", lb_day);
            comboBox.Add("month", lb_month);
            comboBox.Add("year", lb_yaer);
            comboBox.Add("martial status", lb_family);
            comboBox.Add("occupation", lb_prof);
            comboBox.Add("animals", lb_animal);

            m_controller.createNewUser(userData, comboBox, cb_smoke);
        }
    }
}
