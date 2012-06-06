using System.Windows;

namespace MetroCharms
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void imageButtonFavs_Click(object sender, RoutedEventArgs e)
        {
            Message.MessageType = MessageType.Question;
            Message.Text = "Favs...";
            Message.Show();
        }

        private void imageButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            Message.MessageType = MessageType.Success;
            Message.Text = "Setting...";
            Message.Show();
        }

        private void imageButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Message.MessageType = MessageType.Error;
            Message.Text = "Saving...";
            Message.Show();
        }

        private void imageButtonCamera_Click(object sender, RoutedEventArgs e)
        {
            Message.MessageType = MessageType.Info;
            Message.Text = "Camera...";
            Message.Show();
        }

        private void imageButtonFlag_Click(object sender, RoutedEventArgs e)
        {
            Message.MessageType = MessageType.Success;
            Message.Text = "Love Metro! :)";
            Message.Show();
        }
	}
}