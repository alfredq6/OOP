using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Xceed.Wpf.Toolkit;
using System.IO;
using Microsoft.Win32;
using System.Xml;
using System.Xml.Serialization;

namespace _2lab4_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public static class SaveCommand
    {
        static SaveCommand()
        {
            _Save = new RoutedCommand("_Save", typeof(MainWindow));
        }
        public static RoutedCommand _Save { get; set; }
    }

    public partial class MainWindow : Window
    {
        static string _filePath = "";
        static List<string> files = new List<string>();
        static CursorConverter cursorConverter = new CursorConverter();
        public MainWindow()
        {
            InitializeComponent();
            _RichTextBox.AddHandler(System.Windows.Controls.RichTextBox.DragOverEvent, new DragEventHandler(_RichTextBox_DragOver), true);
            _RichTextBox.AddHandler(System.Windows.Controls.RichTextBox.DropEvent, new DragEventHandler(_RichTextBox_Drop), true);
            try
            {
                using (FileStream fs = new FileStream("lastFiles.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<string>));
                    files = (List<string>)formatter.Deserialize(fs);
                }
                foreach (string el in files)
                {
                    MenuItem item = new MenuItem();
                    TextBlock textBlock = new TextBlock();
                    item.Cursor = (Cursor)cursorConverter.ConvertFrom("default.cur");
                    textBlock.Text = el;
                    textBlock.Style = (Style)this.FindResource("ForegroundText");
                    item.Header = textBlock;
                    item.Template = (ControlTemplate)this.FindResource("MenuItemControlTemplate2");
                    item.Click += _OpenLastFile_Click;
                    LastDocs.Items.Add(item);
                }
            }
            catch (Exception) { }
        }

        #region FontStyle

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton button = (ToggleButton)sender;
            if (button.Name == "BoldBut")
            {
                if (_RichTextBox != null)
                {
                    TextPointer selectionStartPoint = _RichTextBox.Selection.Start;
                    TextPointer selectionEndPoint = _RichTextBox.Selection.End;
                    _RichTextBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
                    _RichTextBox.Selection.Select(selectionStartPoint, selectionEndPoint);
                }
            }
            else if (button.Name == "ItalicBut")
            {
                if (_RichTextBox != null)
                {
                    TextPointer selectionStartPoint = _RichTextBox.Selection.Start;
                    TextPointer selectionEndPoint = _RichTextBox.Selection.End;
                    _RichTextBox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
                    _RichTextBox.Selection.Select(selectionStartPoint, selectionEndPoint);
                }
            }
            else if (button.Name == "UnderlineBut")
            {
                if (_RichTextBox != null)
                {
                    TextPointer selectionStartPoint = _RichTextBox.Selection.Start;
                    TextPointer selectionEndPoint = _RichTextBox.Selection.End;
                    _RichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                    _RichTextBox.Selection.Select(selectionStartPoint, selectionEndPoint);
                }
            }
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ToggleButton button = (ToggleButton)sender;
            if (button.Name == "BoldBut")
            {
                if (_RichTextBox != null)
                {
                    TextPointer selectionStartPoint = _RichTextBox.Selection.Start;
                    TextPointer selectionEndPoint = _RichTextBox.Selection.End;
                    _RichTextBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Normal);
                    _RichTextBox.Selection.Select(selectionStartPoint, selectionEndPoint);
                }
            }
            else if (button.Name == "ItalicBut")
            {
                if (_RichTextBox != null)
                {
                    TextPointer selectionStartPoint = _RichTextBox.Selection.Start;
                    TextPointer selectionEndPoint = _RichTextBox.Selection.End;
                    _RichTextBox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Normal);
                    _RichTextBox.Selection.Select(selectionStartPoint, selectionEndPoint);
                }
            }
            else if (button.Name == "UnderlineBut")
            {
                if (_RichTextBox != null)
                {
                    TextPointer selectionStartPoint = _RichTextBox.Selection.Start;
                    TextPointer selectionEndPoint = _RichTextBox.Selection.End;
                    _RichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
                    _RichTextBox.Selection.Select(selectionStartPoint, selectionEndPoint);
                }
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _SizeTxtBlock.Text = _SizeSlider.Value.ToString();
            if (_RichTextBox != null)
            {
                TextPointer selectionStartPoint = _RichTextBox.Selection.Start;
                TextPointer selectionEndPoint = _RichTextBox.Selection.End;
                _RichTextBox.Selection.ApplyPropertyValue(FontSizeProperty, _SizeSlider.Value.ToString());
                _RichTextBox.Selection.Select(selectionStartPoint, selectionEndPoint);
            }
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            BrushConverter converter = new BrushConverter();
            colorPicker.Background = (Brush)converter.ConvertFrom(colorPicker.SelectedColor.ToString());
            if (_RichTextBox != null)
            {
                TextPointer selectionStartPoint = _RichTextBox.Selection.Start;
                TextPointer selectionEndPoint = _RichTextBox.Selection.End;
                _RichTextBox.Selection.ApplyPropertyValue(ForegroundProperty, colorPicker.SelectedColor.Value.ToString());
                _RichTextBox.Selection.Select(selectionStartPoint, selectionEndPoint);
            }
        }

        private void FontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)_FontFamily.SelectedItem;
            Label label = (Label)item.Content;
            if (_RichTextBox != null)
            {
                TextPointer selectionStartPoint = _RichTextBox.Selection.Start;
                TextPointer selectionEndPoint = _RichTextBox.Selection.End;
                _RichTextBox.Selection.ApplyPropertyValue(FontFamilyProperty, label.Content);
                _RichTextBox.Selection.Select(selectionStartPoint, selectionEndPoint);
            }
        }

        #endregion

        #region MenuAction

        private void _New_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf";
            if (saveFileDialog.ShowDialog() == true)
            {
                _filePath = saveFileDialog.FileName;
                TextRange doc = new TextRange(_RichTextBox.Document.ContentStart, _RichTextBox.Document.ContentEnd);
                using (FileStream fs = File.Create(saveFileDialog.FileName))
                {
                    if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
                using (FileStream fs = new FileStream("lastFiles.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<string>));
                    if (files.Contains(Path.GetFullPath(saveFileDialog.FileName)))
                    {
                        for (int i = files.IndexOf(Path.GetFullPath(saveFileDialog.FileName)); i < files.Count - 1; i++)
                        {
                            files[i] = files[i + 1];
                        }
                        files.RemoveAt(files.Count - 1);
                        files.Add(Path.GetFullPath(saveFileDialog.FileName));
                    }
                    else
                    {
                        if (files.Count == 6)
                        {
                            for (int i = 0; i < files.Count - 1; i++)
                            {
                                files[i] = files[i + 1];
                            }
                            files.RemoveAt(files.Count - 1);
                        }
                        files.Add(Path.GetFullPath(saveFileDialog.FileName));
                    }
                    formatter.Serialize(fs, files);
                    LastDocs.Items.Clear();
                    foreach (string el in files)
                    {
                        MenuItem item = new MenuItem();
                        TextBlock textBlock = new TextBlock();
                        textBlock.Text = el;
                        textBlock.Style = (Style)this.FindResource("ForegroundText");
                        item.Header = textBlock;
                        item.Cursor = (Cursor)cursorConverter.ConvertFrom("default.cur");
                        item.Template = (ControlTemplate)this.FindResource("MenuItemControlTemplate2");
                        item.Click += _OpenLastFile_Click;
                        LastDocs.Items.Add(item);
                    }
                }
            }
        }

        private void _Save_Click(object sender, RoutedEventArgs e)
        {
            if (_filePath == "")
                _New_Click(sender, e);
            else
            {
                TextRange doc = new TextRange(_RichTextBox.Document.ContentStart, _RichTextBox.Document.ContentEnd);
                using (FileStream fs = File.Create(_filePath))
                {
                    if (Path.GetExtension(_filePath).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(_filePath).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
                using (FileStream fs = new FileStream("lastFiles.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<string>));
                    if (files.Contains(Path.GetFullPath(_filePath)))
                    {
                        for (int i = files.IndexOf(Path.GetFullPath(_filePath)); i < files.Count - 1; i++)
                        {
                            files[i] = files[i + 1];
                        }
                        files.RemoveAt(files.Count - 1);
                        files.Add(Path.GetFullPath(_filePath));
                    }
                    else
                    {
                        if (files.Count == 6)
                        {
                            for (int i = 0; i < files.Count - 1; i++)
                            {
                                files[i] = files[i + 1];
                            }
                            files.RemoveAt(files.Count - 1);
                        }
                        files.Add(Path.GetFullPath(_filePath));
                    }
                    formatter.Serialize(fs, files);
                    LastDocs.Items.Clear();
                    foreach (string el in files)
                    {
                        MenuItem item = new MenuItem();
                        TextBlock textBlock = new TextBlock();
                        textBlock.Text = el;
                        textBlock.Style = (Style)this.FindResource("ForegroundText");
                        item.Header = textBlock;
                        item.Cursor = (Cursor)cursorConverter.ConvertFrom("default.cur");
                        item.Template = (ControlTemplate)this.FindResource("MenuItemControlTemplate2");
                        item.Click += _OpenLastFile_Click;
                        LastDocs.Items.Add(item);
                    }
                }
            }
        }

        private void _OpenLastFile_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuitem = (MenuItem)sender;
            TextRange doc = new TextRange(_RichTextBox.Document.ContentStart, _RichTextBox.Document.ContentEnd);
            TextBlock textBlock = (TextBlock)menuitem.Header;
            _filePath = textBlock.Text;
            using (FileStream fs = new FileStream(textBlock.Text, FileMode.Open))
            {
                if (Path.GetExtension(textBlock.Text).ToLower() == ".rtf")
                    doc.Load(fs, DataFormats.Rtf);
                else if (Path.GetExtension(textBlock.Text).ToLower() == ".txt")
                    doc.Load(fs, DataFormats.Text);
                else
                    doc.Load(fs, DataFormats.Xaml);
            }
        }

        private void _Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf";
            if (openFileDialog.ShowDialog() == true)
            {
                _filePath = openFileDialog.FileName;
                TextRange doc = new TextRange(_RichTextBox.Document.ContentStart, _RichTextBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(openFileDialog.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
                using (FileStream fs = new FileStream("lastFiles.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<string>));
                    if (files.Contains(Path.GetFullPath(openFileDialog.FileName)))
                    {
                        for (int i = files.IndexOf(Path.GetFullPath(openFileDialog.FileName)); i < files.Count - 1; i++)
                        {
                            files[i] = files[i + 1];
                        }
                        files.RemoveAt(files.Count - 1);
                        files.Add(Path.GetFullPath(openFileDialog.FileName));
                    }
                    else
                    {
                        if (files.Count == 6)
                        {
                            for (int i = 0; i < files.Count - 1; i++)
                            {
                                files[i] = files[i + 1];
                            }
                            files.RemoveAt(files.Count - 1);
                        }
                        files.Add(Path.GetFullPath(openFileDialog.FileName));
                    }
                    formatter.Serialize(fs, files);
                    LastDocs.Items.Clear();
                    foreach (string el in files)
                    {
                        MenuItem item = new MenuItem();
                        TextBlock textBlock = new TextBlock();
                        textBlock.Text = el;
                        textBlock.Style = (Style)this.FindResource("ForegroundText");
                        item.Header = textBlock;
                        item.Cursor = (Cursor)cursorConverter.ConvertFrom("default.cur");
                        item.Template = (ControlTemplate)this.FindResource("MenuItemControlTemplate2");
                        item.Click += _OpenLastFile_Click;
                        LastDocs.Items.Add(item);
                    }
                }
            }
        }

        private void BlueViolet_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("C:/Users/mikci/source/repos/2lab4-5/2lab4-5/Style1.xaml");
            this.Resources.MergedDictionaries.Add(dictionary);
            foreach (MenuItem item in LastDocs.Items)
            {
                TextBlock textBlock = (TextBlock)item.Header;
                textBlock.Style = (Style)this.FindResource("ForegroundText");
                item.Header = textBlock;
                item.Cursor = (Cursor)cursorConverter.ConvertFrom("default.cur");
                item.Template = (ControlTemplate)this.FindResource("MenuItemControlTemplate2");
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("C:/Users/mikci/source/repos/2lab4-5/2lab4-5/Style2.xaml");
            this.Resources.MergedDictionaries.Add(dictionary);
            foreach (MenuItem item in LastDocs.Items)
            {
                TextBlock textBlock = (TextBlock)item.Header;
                textBlock.Style = (Style)this.FindResource("ForegroundText");
                item.Header = textBlock;
                item.Cursor = (Cursor)cursorConverter.ConvertFrom("default.cur");
                item.Template = (ControlTemplate)this.FindResource("MenuItemControlTemplate2");
            }
        }

        private void Glamurious_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("C:/Users/mikci/source/repos/2lab4-5/2lab4-5/Style3.xaml");
            this.Resources.MergedDictionaries.Add(dictionary);
            foreach (MenuItem item in LastDocs.Items)
            {
                TextBlock textBlock = (TextBlock)item.Header;
                textBlock.Style = (Style)this.FindResource("ForegroundText");
                item.Header = textBlock;
                item.Cursor = (Cursor)cursorConverter.ConvertFrom("default.cur");
                item.Template = (ControlTemplate)this.FindResource("MenuItemControlTemplate2");
            }
        }

        private void _Copy_Click(object sender, RoutedEventArgs e)
        {
            _RichTextBox.SelectAll();
            _RichTextBox.Copy();
            _RichTextBox.Selection.Select(_RichTextBox.Selection.End, _RichTextBox.Selection.End);
        }

        private void _Paste_Click(object sender, RoutedEventArgs e)
        {
            _RichTextBox.SelectAll();
            _RichTextBox.Paste();
            _RichTextBox.Selection.Select(_RichTextBox.Selection.End, _RichTextBox.Selection.End);
        }

        private void _Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Drag-and-Drop
        private void _RichTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                for (int i = 0; i < objects.Length; i++)
                {
                    StreamReader sr = new StreamReader(Path.GetFullPath(objects[i]));
                    string line = "";
                    line = sr.ReadToEnd();
                    sr.Close();
                    _RichTextBox.AppendText(line + "\n");
                }
            }
        }

        private void _RichTextBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.All;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = false;
        }

        #endregion

        #region LanguageAndStatusStroke

        private void _RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _RichTextBox.SelectAll();
            ComboBoxItem item = (ComboBoxItem)LanguageComboBox.SelectedItem;
            TextBlock text = (TextBlock)StatusStroke.Content;
            if (item.Name == "EN")
                text.Text = "Number of symbols = " + (_RichTextBox.Selection.Text.Length);
            else if (item.Name == "RU")
                text.Text = "Количество символов = " + (_RichTextBox.Selection.Text.Length);
            _RichTextBox.Selection.Select(_RichTextBox.Selection.End, _RichTextBox.Selection.End);
        }

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)LanguageComboBox.SelectedItem;
            
            if (item.Name == "RU")
            {
                ResourceDictionary dictionary = new ResourceDictionary();
                dictionary.Source = new Uri("C:/Users/mikci/source/repos/2lab4-5/2lab4-5/Dictionary1.xaml");
                this.Resources.MergedDictionaries.Add(dictionary);
            }
            else if (item.Name == "EN")
            {
                ResourceDictionary dictionary = new ResourceDictionary();
                dictionary.Source = new Uri("C:/Users/mikci/source/repos/2lab4-5/2lab4-5/Dictionary2.xaml");
                this.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        #endregion

        private void Redo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _RichTextBox.Redo();
        }

        private void Undo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _RichTextBox.Undo();
        }
    }
}