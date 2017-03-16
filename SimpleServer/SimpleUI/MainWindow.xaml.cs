using System;
using System.Windows;
using Library;

namespace SimpleUI {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void Submit_Click(object sender, RoutedEventArgs e) {
            Message con = new Message(Input.Text,"Donald Duck", DateTime.Now.ToLongTimeString());
            Request request = new Request(Request.Type.Upload, con);
            byte[] data = new Serialization<Request>().Serialize(request);
            Screen.Content = Client.StartClient(data);
        }

        private void Input_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Input.Width = 380;
        }

        private void Input_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Submit_Click(sender, e);
            }
        }
    }
}