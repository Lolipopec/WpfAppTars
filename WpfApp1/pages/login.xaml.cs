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
using System.Data.Entity;
using WPF1;

namespace WpfApp1.pages
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BaseConnect.CurrentUsers = BaseConnect.BaseModel.auth.FirstOrDefault(x => x.login == txtLogin.Text && x.password == txtPassword.Password);
                if (BaseConnect.CurrentUsers != null)
                {//тут будет алгоритм перехода на страницу в зависимости от роля пользователя
                    switch(BaseConnect.CurrentUsers.role)
                    {
                        case 1:
                            MessageBox.Show("Вы зашли как админ");
                            LoadPages.MainFrame.Navigate(new adminMenu());
                            break;
                        case 2:
                            MessageBox.Show("Вы зашли как обычный пользователь");
                            LoadPages.MainFrame.Navigate(new Info());
                            break;
                    }
                    LoadPages.MainFrame.Navigate(new Info());
                    MessageBox.Show("Ооо добро пожаловать");

                }
                else
                {
                    MessageBox.Show("Что-то не так, попробуй снова!");
                }
            }
            catch { MessageBox.Show("Неизвестная ошибка :/"); }
           

            
        }

        private void btnRegn_Click(object sender, RoutedEventArgs e)
        {
           LoadPages.MainFrame.Navigate(new reg());
        }

    }
}
