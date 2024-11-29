using System.Text;
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

namespace TranslatorProject
{
    public partial class MainWindow : Window
    {
        private Triangulation triangulation = new Triangulation();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Load STL File (LoadSTLButton_Click)
        private void LoadSTLButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "STL Files (*.stl)|*.stl";

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;

                // Assuming STLReader is a class that handles reading the STL file
                STLReader reader = new STLReader();
                reader.read(fileName, triangulation);

                LoadStatusTextBlock.Text = "File loaded successfully from - " + fileName;
            }
        }

        // Translate OBJ File (TranslateOBJButton_Click)
        private void TranslateOBJButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "OBJ Files (*.obj)|*.obj";

            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;

                // Assuming ObjWriter is a class that handles writing the OBJ file
                OBJWriter writer = new OBJWriter();
                writer.Write(fileName, triangulation);

                TranslateStatusTextBlock.Text = "File saved successfully to - " + fileName;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}