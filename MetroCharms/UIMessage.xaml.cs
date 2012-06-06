using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace MetroCharms
{
    public enum MessageType
    {
        NotSet = 0,
        Error,
        Info,
        Success,
        Question
    }

    public partial class UIMessage
    {
        #region Fields

        private SolidColorBrush _errorBrush;
        private SolidColorBrush _infoBrush;
        private SolidColorBrush _successBrush;
        private SolidColorBrush _questionBrush;

        private BitmapImage _errorImage;
        private BitmapImage _infoImage;
        private BitmapImage _successImage;
        private BitmapImage _questionImage;

        private Storyboard _fadeInStoryboard;
        private Storyboard _fadeOutStoryboard;

        #endregion

        #region Constructor

        public UIMessage()
        {
            InitializeComponent();
            CheckResourcesAreAvailable();

            _fadeInStoryboard.Completed += (sender, args) => _fadeOutStoryboard.Begin();
        }

        #endregion

        #region Dependency Properties: MessageType, Text

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("MessageType",
                                        typeof(MessageType),
                                        typeof(UIMessage),
                                        new PropertyMetadata(MessageType.NotSet, TypePropertyChanged));

        private static void TypePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var uiMessage = (UIMessage)dependencyObject;
            uiMessage.Display.SetValue(Border.BackgroundProperty, uiMessage.GetBrush(uiMessage.MessageType));
            uiMessage.Icon.SetValue(Image.SourceProperty, uiMessage.GetImage(uiMessage.MessageType));
        }

        public MessageType MessageType
        {
            get { return (MessageType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text",
                                        typeof(string),
                                        typeof(UIMessage),
                                        new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion

        #region Methods

        private void CheckResourcesAreAvailable()
        {
            _errorBrush = (SolidColorBrush)this.Resources["ErrorBrush"];
            _infoBrush = (SolidColorBrush)this.Resources["InfoBrush"];
            _successBrush = (SolidColorBrush)this.Resources["SuccessBrush"];
            _questionBrush = (SolidColorBrush)this.Resources["QuestionBrush"];
            _errorImage = (BitmapImage)this.Resources["ErrorImage"];
            _infoImage = (BitmapImage)this.Resources["InfoImage"];
            _successImage = (BitmapImage)this.Resources["SuccessImage"];
            _questionImage = (BitmapImage)this.Resources["QuestionImage"];
            _fadeInStoryboard = (Storyboard)this.Resources["FadeIn"];
            _fadeOutStoryboard = (Storyboard)this.Resources["FadeOut"];

            if (_errorBrush == null) throw new Exception("Missing ErrorBrush resource");
            if (_infoBrush == null) throw new Exception("Missing InfoBrush resource");
            if (_successBrush == null) throw new Exception("Missing SuccessBrush resource");
            if (_questionBrush == null) throw new Exception("Missing QuestionBrush resource");
            if (_errorImage == null) throw new Exception("Missing BitmapImage ErrorImage resource");
            if (_infoImage == null) throw new Exception("Missing BitmapImage InfoImage resource");
            if (_successImage == null) throw new Exception("Missing BitmapImage SuccessImage resource");
            if (_questionImage == null) throw new Exception("Missing BitmapImage QuestionImage resource");
            if (_fadeInStoryboard == null) throw new Exception("Missing Storyboard FadeIn resource");
            if (_fadeOutStoryboard == null) throw new Exception("Missing Storyboard FadeOut resource");
        }

        private SolidColorBrush GetBrush(MessageType type)
        {
            SolidColorBrush brush = null;
            switch (type)
            {
                case MessageType.Info:
                    brush = _infoBrush;
                    break;
                case MessageType.Error:
                    brush = _errorBrush;
                    break;
                case MessageType.Success:
                    brush = _successBrush;
                    break;
                case MessageType.Question:
                    brush = _questionBrush;
                    break;
            }
            return brush;
        }

        private BitmapImage GetImage(MessageType type)
        {
            BitmapImage image = null;
            switch (type)
            {
                case MessageType.Info:
                    image = _infoImage;
                    break;
                case MessageType.Error:
                    image = _errorImage;
                    break;
                case MessageType.Success:
                    image = _successImage;
                    break;
                case MessageType.Question:
                    image = _questionImage;
                    break;
            }
            return image;
        }

        public void Show()
        {
            _fadeInStoryboard.Begin();
        }

        #endregion
    }
}