using System.Windows;

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

        #region Events

        #endregion

        private void Window_Activated(object sender, EventArgs e)
        {
            Stats.Text = $"""
            Clipboard:
                Contains Audio: {Clipboard.ContainsAudio()}
                Contains Text: {Clipboard.ContainsText()}
                Contains File Drop List: {Clipboard.ContainsFileDropList()}
                Contains Image: {Clipboard.ContainsImage()}
                Contains Data: 
                    Bitmap [{Clipboard.ContainsData(DataFormats.Bitmap)}]
                    XamlPackage [{Clipboard.ContainsData(DataFormats.XamlPackage)}]
                    Xaml [{Clipboard.ContainsData(DataFormats.Xaml)}]
                    WaveAudio [{Clipboard.ContainsData(DataFormats.WaveAudio)}]
                    UnicodeText [{Clipboard.ContainsData(DataFormats.UnicodeText)}]
                    Tiff [{Clipboard.ContainsData(DataFormats.Tiff)}]
                    Text [{Clipboard.ContainsData(DataFormats.Text)}]
                    SymbolicLink [{Clipboard.ContainsData(DataFormats.SymbolicLink)}]
                    StringFormat [{Clipboard.ContainsData(DataFormats.StringFormat)}]
                    Serializable [{Clipboard.ContainsData(DataFormats.Serializable)}]
                    Rtf [{Clipboard.ContainsData(DataFormats.Rtf)}]
                    Riff [{Clipboard.ContainsData(DataFormats.Riff)}]
                    Palette [{Clipboard.ContainsData(DataFormats.Palette)}]
                    OemText [{Clipboard.ContainsData(DataFormats.OemText)}]
                    MetafilePicture [{Clipboard.ContainsData(DataFormats.MetafilePicture)}]
                    Locale [{Clipboard.ContainsData(DataFormats.Locale)}]
                    Html [{Clipboard.ContainsData(DataFormats.Html)}]
                    FileDrop [{Clipboard.ContainsData(DataFormats.FileDrop)}]
                    EnhancedMetafile [{Clipboard.ContainsData(DataFormats.EnhancedMetafile)}]
                    Dif [{Clipboard.ContainsData(DataFormats.Dif)}]
                    Dib [{Clipboard.ContainsData(DataFormats.Dib)}]
                    CommaSeparatedValue [{Clipboard.ContainsData(DataFormats.CommaSeparatedValue)}]
                    PenData [{Clipboard.ContainsData(DataFormats.PenData)}]
            """;
        }
    }
}