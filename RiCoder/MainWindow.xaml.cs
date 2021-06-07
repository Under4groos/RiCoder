using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RiCoder
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

        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text_ = (sender as RichTextBox).GetText();
            if (text_.Length < 0)
                return;

            string ecode = EnDecode(text_);
            richTextBox1.SetText(ecode);
            richTextBox2.SetText(EnDecode(ecode));
        }

       
        string EnDecode(string text)
        {
            string ret_Encode = "";

            foreach (char item in text)
            {
                if (item.IsUp())
                {
                    int a = UTF32.CharTointUtf32Up(item);
                    char ret_char = UTF32.Utf32_ABC[ (UTF32.Utf32_ABC.Length-1) - a];
                    ret_Encode += $"{ret_char}";
                    continue;
                }
                else if (item.IsDown())
                {
                    int a = UTF32.CharTointUtf32Down(item);
                    char ret_char = UTF32.Utf32_abc[(UTF32.Utf32_abc.Length - 1) - a];
                    ret_Encode += $"{ret_char}";
                    continue;
                }else if(item.IsSYMV())
                {
                    int a = UTF32.CharTointUtf32SYMV(item);
                    char ddd = UTF32.Utf32_SYMV[(UTF32.Utf32_SYMV.Length - 1) - a];

                    ret_Encode += $"{ddd}";

                    continue;
                }
                else if (item.IsNumber())
                {
                    int a = UTF32.CharTointUtf32S_isnumber(item);
                    char ddd = UTF32.Utf32_012[(UTF32.Utf32_012.Length - 1) - a];
                    ret_Encode += $"{ddd}";
                    continue;
                }
                ret_Encode += $"{item}";
            }
            return ret_Encode;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
      
            OpenFileDialog openFileDialog1 = new OpenFileDialog();          
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == true)
                (richTextBox as RichTextBox).SetText(File.ReadAllText(openFileDialog1.FileName));
        }
    }
}
