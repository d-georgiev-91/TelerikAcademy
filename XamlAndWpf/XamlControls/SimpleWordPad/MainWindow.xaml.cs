using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace SimpleWordPad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        public void OpenDocument(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".rtf"; // Default file extension
            dlg.Filter = "Rich Text Format (RTF)|*.rtf"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                
                OpenRichTextDocument(filename);
            }
        }
  
        private void OpenRichTextDocument(string filename)
        {
            TextRange range;
            FileStream fStream;
            range = new TextRange(this.textContainer.Document.ContentStart, this.textContainer.Document.ContentEnd);
            fStream = new FileStream(filename, FileMode.Open);
            range.Load(fStream, DataFormats.Rtf);
            fStream.Close();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.FontFamilyChanger.ItemsSource = Fonts.SystemFontFamilies;
        }

        private void BoldStyleButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.textContainer.FontWeight != FontWeights.Bold)
            {
                this.textContainer.FontWeight = FontWeights.Bold;
            }
            else
            {
                this.textContainer.FontWeight = FontWeights.Normal;
            }
        }

        private void ItalicStyleButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.textContainer.FontStyle != FontStyles.Italic)
            {
                this.textContainer.FontStyle = FontStyles.Italic;
            }
            else
            {
                this.textContainer.FontStyle = FontStyles.Normal;
            }
        }

        private void UnderlinedStyleButtonClick(object sender, RoutedEventArgs e)
        {
            //if (this.textContainer.TextDecorations != TextDecorations.Underline)
            //{
            //    this.textContainer.TextDecorations = TextDecorations.Underline;
            //}
            //else
            //{
            //    this.textContainer.TextDecorations.Clear();
            //}
        }

        private void ChangeFontSize(object sender, SelectionChangedEventArgs e)
        {
            var selectedFontSize = this.FontSizeChanger.SelectedItem as ComboBoxItem;
            this.textContainer.FontSize = double.Parse(selectedFontSize.Content.ToString());
        }

        private void ChasngeFontFamily(object sender, SelectionChangedEventArgs e)
        {
            var selectedFontFamily = this.FontFamilyChanger.SelectedItem as FontFamily;
            this.textContainer.FontFamily = selectedFontFamily;
        }

        private void SaveDocument(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".rtf"; // Default file extension
            dlg.Filter = "Rich Text Format (RTF)|*.rtf"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                SaveRichTextContent(filename);
            }
        }
  
        private void SaveRichTextContent(string filename)
        {
            TextRange range;
            FileStream fStream;
            range = new TextRange(this.textContainer.Document.ContentStart, this.textContainer.Document.ContentEnd);
            fStream = new FileStream(filename, FileMode.Create);
            range.Save(fStream, DataFormats.Rtf);
            fStream.Close();
        }
    }
}
