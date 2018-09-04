using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
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
using System.Xml;

namespace Examenvragen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var namen = new[] { "Micheal", "Danny", "Roel", "Kenneth", "Bram", "Marcel", "Xander" };

            var q = namen.Any(n => n.Length == 50);

            string[] namen2 = null;

            namen2 = (string[])(from n in namen
                                select n).ToArray();




        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string operationName = "Subtract";
            int num1 = 20;
            int num2 = 5;

            var c = new Calculator();

            var mParam = new object[] { num1, num2 };

            //Type typeinfo = typeof(Calculator);
            Type typeinfo = c.GetType();



            MethodInfo methodinfo = typeinfo.GetMethod(operationName);

            var answer = methodinfo.Invoke(c, mParam);

            MessageBox.Show(answer.ToString());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var c1 = new Class1();
            var c2 = new Class2();

            (c2 as INewInterface).Method1();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var ser = new DataContractSerializer(typeof(Person));

            var p = new Person { Firstname = "Xander", Lastname = "Wemmers" };

            var writer = XmlWriter.Create(@"c:\tmp\personSerializer.txt");

            
            ser.WriteObject(writer, p);

            writer.Close();
        }
    }
}
