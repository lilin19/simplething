using System;
using System.Windows;
using Library;

namespace SimpleUI {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void Submit_Click(object sender, RoutedEventArgs e) {
            Msg con = new Msg();
            con.content = Input.Text;
            con.date = DateTime.Now.ToLongDateString();
            AsynchronousClient.StartClient(con.content);
            Screen.Text = con.content;
        }
    }
}