using System.Windows;
using REG_MARK_LIB;

namespace ПР5._2
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

        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            if (REG_MARK_LIB_Class.CheckMark(textBoxNumber.Text))
            {
                MessageBox.Show("Номер введен верно. \nДанный номер будет меняться по ходу программы", "Успех");
                ButtonUpg.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Номер введен неверно. Введите новый номер");
                ButtonUpg.IsEnabled = false;
            }
        }
        private void ButtonUpg_Click(object sender, RoutedEventArgs e)
        {
            if (REG_MARK_LIB_Class.CheckMark(textBoxNumber.Text))
            {
                string numb = REG_MARK_LIB_Class.GetNextMarkAfter(textBoxNumber.Text);
                MessageBox.Show(numb);
                textBoxNumber.Text = numb;
            }
            else
            {
                MessageBox.Show("Данный номер не подходит для увеличения серии");
            }
        }
    }
}
