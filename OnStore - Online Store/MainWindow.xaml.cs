using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace OnStore___Online_Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        List<Product> ProductsList = new List<Product>();

        public List<Product> ComplateProductsList { get; set; }


           
        public MainWindow()
        {

            InitializeComponent();

            if (AddProductNameText.Text != string.Empty && AddProductPriceText.Text != string.Empty && AddProductProducerText.Text != string.Empty)
            {
                AddRemoveButton.IsEnabled = true;
            }

            ComplateProductsList = new List<Product>
            {
               new Product
               {

                ProductName = "A",
                ProductPrice ="50",
                ProductImagePath= "Sb.png",
                ProductProducer= "Azercay",

               },

               new Product
               {

                ProductName = "Azercay11",
                ProductPrice ="50",
                ProductImagePath= "Images/p6.JPG",
                ProductProducer= "Azercay",

               },

               new Product
               {

                ProductName = "Caldo de Galinha ",
                ProductPrice ="1",
                ProductImagePath= "Images/p1.png",
                ProductProducer= "Bunge",

               },

               new Product
               {

                ProductName = "Forel",
                ProductPrice ="50",
                ProductImagePath= "Images/p2.PNG",
                ProductProducer= "Santa Bremor",

               },

               new Product
               {

                ProductName = "Alyonka",
                ProductPrice ="50",
                ProductImagePath= "Images/p3.jpg",
                ProductProducer= "UNICONF",

               },

               new Product
               {

                ProductName = "Fiorella",
                ProductPrice ="50",
                ProductImagePath= "Images/p4.JPG",
                ProductProducer= "Elvan",

               },

               new Product
               {

                ProductName = "Pistachios",
                ProductPrice ="50",
                ProductImagePath= "Images/p5.JPG",
                ProductProducer= "Wonderful",

               },

               new Product
               {

                ProductName = "Azercay",
                ProductPrice ="50",
                ProductImagePath= "Images/p6.JPG",
                ProductProducer= "Azersun",

               },
            };


            this.DataContext = this;

      


            EditButton.Visibility = Visibility.Hidden;
        }

        Border borders = new Border();


        List<Product> v = new List<Product>();

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                listbox1.ItemsSource = null;

                if (SearchButton.IsChecked == true)
                {
                    listbox1.Items.Clear();
                    SearchButton.Content = "Search Off";


                    IEnumerable<Product> foundObjects = ComplateProductsList.Where((myObject) => myObject.ProductName.Equals(SearchTextbox.Text, StringComparison.OrdinalIgnoreCase));


                    //v = ComplateProductsList.FindAll(y => y.ProductName == SearchTextbox.Text);


                    //var result = ComplateProductsList.Where(x => x.ProductName == SearchTextbox.Text);
                    listbox1.ItemsSource = foundObjects;


                }


                else
                {
                    listbox1.ItemsSource = null;
                    SearchButton.Content = "Search On";

                    listbox1.ItemsSource = ComplateProductsList;

                    SearchTextbox.Clear();
                }
            }
            catch (Exception)
            {

                
            }
      


        }




        Binding bindings = new Binding();

        Binding bindings2 = new Binding();


        TextBox EditProductPrice = new TextBox();

        TextBox EditProductProducer = new TextBox();

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            EditButton.IsEnabled = false;

            EditButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 37, 191, 255));

            EditProductNameText.IsReadOnly = false;

            EditProductImage.AllowDrop = true;
       


            EditProductPrice.Margin = new Thickness(5, 5, 0, 0);
            EditProductPrice.Foreground = new SolidColorBrush(Color.FromArgb(255, 37, 191, 255));
            EditProductPrice.FontSize = 20;

            bindings.Path = new PropertyPath("SelectedItem.ProductPrice");
            bindings.ElementName = "listbox1";
            bindings.Mode = BindingMode.TwoWay;

            bindings.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            EditProductPrice.SetBinding(TextBox.TextProperty, bindings);




            EditProductProducer.Margin = new Thickness(5, 5, 0, 0);
            EditProductProducer.Foreground = new SolidColorBrush(Color.FromArgb(255, 37, 191, 255));
            EditProductProducer.FontSize = 20;

            bindings2.Path = new PropertyPath("SelectedItem.ProductProducer");
            bindings2.ElementName = "listbox1";
            bindings2.Mode = BindingMode.TwoWay;

            bindings2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            EditProductProducer.SetBinding(TextBox.TextProperty, bindings2);



    

            if (listbox1.SelectedIndex == -1)
            {
                EditProductPrice.Text = EditProductPrice.Text;
            }
            if (listbox1.SelectedIndex != -1)
            {
                EditStackpanel.Children.Add(EditProductPrice);
                EditStackpanel.Visibility = Visibility.Visible;

            }

            if (listbox1.SelectedIndex == -1)
            {
                EditProductProducer.Text = EditProductProducer.Text;
            }
            if (listbox1.SelectedIndex != -1)
            {
                EditStackpanel.Children.Add(EditProductProducer);
                EditStackpanel.Visibility = Visibility.Visible;
            }



        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditButton.Visibility = Visibility.Visible;
        }



        void AddProduct()
        {
            if (PathTextbox.Text != "Path")
            {

                ComplateProductsList.Add(new Product()
                {
                    ProductName = AddProductNameText.Text,
                    ProductPrice = AddProductPriceText.Text,
                    ProductProducer = AddProductProducerText.Text,
                    ProductImagePath = PathTextbox.Text,



                });
            }

            else
            {
                    ComplateProductsList.Add(new Product()
                {
                    ProductName = AddProductNameText.Text,
                    ProductPrice = AddProductPriceText.Text,
                    ProductProducer = AddProductProducerText.Text,
                    ProductImagePath = "Sb.png",



                });
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
   

            List<Product> Distinct_ComplateProductsList = ComplateProductsList.Distinct().ToList();

            if (AddRemoveButton.IsChecked == true)
            {
                try
                {

                    AddRemoveButton.Content = "Remove";

                    AddProduct();

                    listbox1.ItemsSource = null;

                    listbox1.Items.Clear();
                    foreach (var item in ComplateProductsList)
                    {

                        listbox1.Items.Add(item);

                    }
                }
                catch (Exception)
                {


                }
            }

            else
            {

                try
                {
                    AddRemoveButton.Content = "Add";

                    listbox1.Items.Clear();



                    listbox1.ItemsSource = null;
                    var r2 = ComplateProductsList.RemoveAll(r => r.ProductName == AddProductNameText.Text);

                    listbox1.ItemsSource = ComplateProductsList;
                }
                catch (Exception)
                {

                   
                }
     

            }





        }

        string m = "";
        private void ProductImage_Drop(object sender, DragEventArgs e)
        {
            if (!Directory.Exists("Add ProductImage"))
            {
                Directory.CreateDirectory("Add ProductImage");
            }



            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var file in files)
            {
                m = file;

                PathTextbox.Visibility = Visibility.Visible;

                PathTextbox.Text = m;
            }

            try
            {

                string dircopyfrom = m;

                string[] fileEnter1 = Directory.GetFiles(dircopyfrom);

                string dircopyto = $@"Add ProductImage";

                foreach (var f in fileEnter1)
                {
                    string filename = System.IO.Path.GetFileName(f);
                    File.Copy(f, dircopyto + "\\" + filename, true);
                    File.Delete(f);
                }

                if(PathTextbox.Text != "Path")
                {
                    AddRemoveButton.IsEnabled = true;
                }
            }

            catch (Exception)
            {


            }

            File.Copy(m, $@"Add ProductImage/image.png", true);
        }

        private void ProductImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effects = DragDropEffects.All;
            }
        }

 

        private void StackDragDrop_Drop(object sender, DragEventArgs e)
        {
            if (!Directory.Exists("Add ProductImage"))
            {
                Directory.CreateDirectory("Add ProductImage");
            }



            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var file in files)
            {
                m = file;

                PathTextbox.Visibility = Visibility.Visible;

                PathTextbox.Text = m;
            }

            try
            {

                string dircopyfrom = m;

                string[] fileEnter1 = Directory.GetFiles(dircopyfrom);

                string dircopyto = $@"Add ProductImage";

                foreach (var f in fileEnter1)
                {
                    string filename = System.IO.Path.GetFileName(f);
                    File.Copy(f, dircopyto + "\\" + filename, true);
                    File.Delete(f);
                }

            }

            catch (Exception)
            {


            }

            File.Copy(m, $@"Add ProductImage/image.png", true);
                ProductImage.Source = new BitmapImage(new Uri(m));
        }

        private void StackDragDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effects = DragDropEffects.All;
            }
        }

        string imageLocation = "";

        private void EditProductImage_Drop(object sender, DragEventArgs e)
        {
            if (!Directory.Exists("Add ProductImage"))
            {
                Directory.CreateDirectory("Add ProductImage");
            }



            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var file in files)
            {
                m = file;

                PathTextbox.Visibility = Visibility.Visible;

                PathTextbox.Text = m;
            }

            try
            {

                string dircopyfrom = m;

                string[] fileEnter1 = Directory.GetFiles(dircopyfrom);

                string dircopyto = $@"Add ProductImage";

                foreach (var f in fileEnter1)
                {
                    string filename = System.IO.Path.GetFileName(f);
                    File.Copy(f, dircopyto + "\\" + filename, true);
                    File.Delete(f);
                }

            }

            catch (Exception)
            {


            }

            File.Copy(m, $@"Add ProductImage/image.png", true);
            EditProductImage.Source = new BitmapImage(new Uri(m));
        }

        private void EditProductImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effects = DragDropEffects.All;
            }
        }

        private void AddProductNameText_MouseEnter(object sender, MouseEventArgs e)
        {
            if (AddProductNameText.Text == "ProductName")
            {
                AddProductNameText.Text = null;
                AddProductNameText.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 178, 170));
            }
        }

        private void AddProductNameText_MouseLeave(object sender, MouseEventArgs e)
        {
            if (AddProductNameText.Text == "")
            {
                AddProductNameText.Text = "ProductName";
                AddProductNameText.Foreground = new SolidColorBrush(Color.FromArgb(255, 131, 137, 150));
            }
        }

        private void AddProductPriceText_MouseEnter(object sender, MouseEventArgs e)
        {
            if (AddProductPriceText.Text == "ProductPrice")
            {
                AddProductPriceText.Text = null;
                AddProductPriceText.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 178, 170));
            }
        }

        private void AddProductPriceText_MouseLeave(object sender, MouseEventArgs e)
        {
            if (AddProductPriceText.Text == "")
            {
                AddProductPriceText.Text = "ProductPrice";
                AddProductPriceText.Foreground = new SolidColorBrush(Color.FromArgb(255, 131, 137, 150));
            }
        }

        private void AddProductProducerText_MouseEnter(object sender, MouseEventArgs e)
        {
            if (AddProductProducerText.Text == "ProductProducer")
            {
                AddProductProducerText.Text = null;
                AddProductProducerText.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 178, 170));
            }
        }

        private void AddProductProducerText_MouseLeave(object sender, MouseEventArgs e)
        {
            if (AddProductProducerText.Text == "")
            {
                AddProductProducerText.Text = "ProductProducer";
                AddProductProducerText.Foreground = new SolidColorBrush(Color.FromArgb(255, 131, 137, 150));
            }
        }
    }
}
