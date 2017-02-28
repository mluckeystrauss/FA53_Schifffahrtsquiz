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
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace Schifffahrt
{
    /// <summary>
    /// Interaktionslogik für QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : NavigationWindow
    {
        public QuestionWindow()
        {
            InitializeComponent();
            string[] fragen = new string[5];
            for (int i = 0; i < fragen.Length; i++)
            {
                fragen[i] = "Meine Frage + {i}";
            }
        }
    }
}
