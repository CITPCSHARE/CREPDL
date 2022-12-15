using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using CREPDL;
using System.IO;
using System.Linq.Expressions;

namespace EPUBValidatorGUI
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        string crepdlCP932And0213Source =
        @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"" mode=""graphemeCluster"">
        <repertoire 
          registry=""10646"" number=""371""/> <!-- JIS2004 IDEOGRAPHICS EXTENSION -->
        <repertoire 
          registry=""10646"" number=""285""/> <!-- BASIC JAPANESE (or JIS X 0208) -->
        <repertoire 
          registry=""10646"" number=""286""/> <!-- JAPANESE NON IDEOGRAPHICS EXTENSION -->
        <repertoire 
          registry=""10646"" number=""287""/> <!--  COMMON JAPANESE -->
        <char>[\n|\r|\t]|(\r\n)</char>
        </union>";

        string crepdlCP932And0213AndIVSAdobeJapan1Source =
        @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"" mode=""graphemeCluster"">
        <repertoire 
          registry=""10646"" number=""371""/> <!-- JIS2004 IDEOGRAPHICS EXTENSION -->
        <repertoire 
          registry=""10646"" number=""285""/> <!-- BASIC JAPANESE (or JIS X 0208) -->
        <repertoire 
          registry=""10646"" number=""286""/> <!-- JAPANESE NON IDEOGRAPHICS EXTENSION -->
        <repertoire 
          registry=""10646"" number=""287""/> <!--  COMMON JAPANESE -->
        <repertoire 
          registry=""IVD"" name=""Adobe-Japan1"" />
        <char>[\n|\r|\t]|(\r\n)</char>
        </union>";

        string crepdlCP932And0213AndAndIVSHanyoDenshiSource =
        @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"" mode=""graphemeCluster"">
        <repertoire 
          registry=""10646"" number=""371""/> <!-- JIS2004 IDEOGRAPHICS EXTENSION -->
        <repertoire 
          registry=""10646"" number=""285""/> <!-- BASIC JAPANESE (or JIS X 0208) -->
        <repertoire 
          registry=""10646"" number=""286""/> <!-- JAPANESE NON IDEOGRAPHICS EXTENSION -->
        <repertoire 
          registry=""10646"" number=""287""/> <!--  COMMON JAPANESE -->
        <repertoire 
          registry=""IVD"" name=""Hanyo-Denshi"" />
        <char>[\n|\r|\t]|(\r\n)</char>
        </union>";
        CREPDLValidator validator = null;


        string epubName;
        public MainWindow()
        {
            InitializeComponent();
            initializeValidator(crepdlCP932And0213Source);
        }

        private void initializeValidator(string crepdlScriptString)
        {
            validator =
                new CREPDLValidator(new StringReader(crepdlScriptString));
            if (this.message != null)
            {
                this.message.Text = "";
            }

        }
        private void CP932And0213_Checked(object sender, RoutedEventArgs e)
        {
            initializeValidator(crepdlCP932And0213Source);
        }

        private void CP932And0213AndIVSAdobeJapan1_Checked(object sender, RoutedEventArgs e)
        {

            initializeValidator(crepdlCP932And0213AndIVSAdobeJapan1Source);
        }

        private void CP932And0213AndIVSHanyoDenshi_Checked(object sender, RoutedEventArgs e)
        {

            initializeValidator(crepdlCP932And0213AndAndIVSHanyoDenshiSource);
        }

        private void CrepdlSelectionButton_Checked(object sender, RoutedEventArgs e)
        {
            // ダイアログのインスタンスを生成
            var dialog = new OpenFileDialog();

            // ファイルの種類を設定
            dialog.Filter = "CREPDLスクリプト (*.crepdl)|*.crepdl|全てのファイル (*.*)|*.*";

            // ダイアログを表示する
            if (dialog.ShowDialog() == true)
            {
                this.selectedCREPDLscript.Text = dialog.FileName;
                try {
                    validator = new CREPDLValidator(new StreamReader(dialog.FileName));
                }
                catch (Exception excp)
                {
                    this.message.Text = excp.Message;
                }
            }
            else
            {
                CP932And0213.IsChecked = true;
                initializeValidator(crepdlCP932And0213Source);
            }

        }

        private void EPUBSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();

            // ファイルの種類を設定
            dialog.Filter = "EPUB出版物 (*.epub)|*.epub|全てのファイル (*.*)|*.*";

            // ダイアログを表示する
            if (dialog.ShowDialog() == true)
            {
                this.selectedEPUB.Text = dialog.FileName;
                epubName = dialog.FileName;

            }
            else
            {
                this.selectedEPUB.Text = null;
                epubName = null;

            }

            this.message.Text = "";
        }


        private void ValidationButton_Click(object sender, RoutedEventArgs e)
        {
            StringWriter sw = new StringWriter();
            if (epubName != null) { 
                 EPUBValidation.scanZip (sw, epubName, validator);
            }
            sw.Flush();
            this.message.Text = sw.ToString();
            sw.Close();
        }
    }
}
