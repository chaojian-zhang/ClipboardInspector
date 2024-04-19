using System.Globalization;
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

            foreach (var item in DataTypes.OrderBy(t => t))
                DataTypeSelector.Items.Add(item);
            DataTypeSelector.SelectedItem = DataFormats.Text;
        }
        #endregion

        #region Data
        public static HashSet<string> DataTypes = [
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
            {string.Join("\n", DataTypes.Where(Clipboard.ContainsData).OrderBy(t => t).Select(t => $"        {t} [{Clipboard.ContainsData(t)}]"))}
                Others:
            {string.Join("\n", DataTypes.Where(t => !Clipboard.ContainsData(t)).OrderBy(t => t).Select(t => $"        {t}"))}
            """;

            DataTypeSelector.Items.Clear();
            foreach (var item in DataTypes.Where(Clipboard.ContainsData).OrderBy(t => t))
                DataTypeSelector.Items.Add(item);
            DataTypeSelector.SelectedItem = DataTypeSelector.Items[0];
        }
        private void GetDataPreviewButton_Click(object sender, RoutedEventArgs e)
        {
            string dataType = DataTypeSelector.SelectedItem as string;
            if (!Clipboard.ContainsData(dataType))
            {
                ContentPreviewTextBox.Text = "Invalid. Data doesn't exist.";
                return;
            }

            if (dataType == DataFormats.Text 
                || dataType == DataFormats.Html
                || dataType == DataFormats.UnicodeText 
                || dataType == DataFormats.Rtf 
                || dataType == DataFormats.OemText
                || dataType == DataFormats.CommaSeparatedValue
            )
                ContentPreviewTextBox.Text = Clipboard.GetData(dataType).ToString();
            else
                ContentPreviewTextBox.Text = "Not handled.";
        }
        private void ClearDataPreviewButton_Click(object sender, RoutedEventArgs e)
        {
            ContentPreviewTextBox.Clear();
        }
        #endregion
    }
}