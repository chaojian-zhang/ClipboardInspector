using System.Windows;
using System.Windows.Controls;

namespace ClipboardInspector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Construction
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Data
        public HashSet<string> DataTypes = [
            DataFormats.Bitmap,
            DataFormats.XamlPackage,
            DataFormats.Xaml,
            DataFormats.WaveAudio,
            DataFormats.UnicodeText,
            DataFormats.Tiff,
            DataFormats.Text,
            DataFormats.SymbolicLink,
            DataFormats.StringFormat,
            DataFormats.Serializable,
            DataFormats.Rtf,
            DataFormats.Riff,
            DataFormats.Palette,
            DataFormats.OemText,
            DataFormats.MetafilePicture,
            DataFormats.Locale,
            DataFormats.Html,
            DataFormats.FileDrop,
            DataFormats.EnhancedMetafile,
            DataFormats.Dif,
            DataFormats.Dib,
            DataFormats.CommaSeparatedValue,
            DataFormats.PenData
        ];
        #endregion

        #region Events
        private void Window_Activated(object sender, EventArgs e)
        {
            Stats.Text = $"""
            Clipboard:
                Contains Audio: {Clipboard.ContainsAudio()}
                Contains Text: {Clipboard.ContainsText()}
                Contains File Drop List: {Clipboard.ContainsFileDropList()}
                Contains Image: {Clipboard.ContainsImage()}
                Contains Data:
            {string.Join("\n", DataTypes.OrderBy(t => Clipboard.ContainsData(t)).Select(t => $"        {t} [{Clipboard.ContainsData(t)}]"))}
            """;
        }
        private void GetDataPreviewButton_Click(object sender, RoutedEventArgs e)
        {
            string dataType = (string)(DataTypeSelector.SelectedItem as ComboBoxItem).Content;
            switch (dataType)
            {
                case nameof(DataFormats.Text):
                case nameof(DataFormats.Locale):
                    if (Clipboard.ContainsData(dataType))
                        ContentPreviewTextBox.Text = Clipboard.GetData(dataType).ToString();
                    break;
                default:
                    break;
            }
        }
        private void ClearDataPreviewButton_Click(object sender, RoutedEventArgs e)
        {
            ContentPreviewTextBox.Clear();
        }
        #endregion
    }
}