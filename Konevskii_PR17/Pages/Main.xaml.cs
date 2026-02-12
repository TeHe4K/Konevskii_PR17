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
using Konevskii_PR17.Classes;

namespace Konevskii_PR17.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public List<Classes.Dish> dishes = new List<Classes.Dish>();

        public Main()
        {
            InitializeComponent();
            Dish newDish = new Dish();
            newDish.img = "img-1";
            newDish.name = "Сливочная";
            newDish.description = "Пицца - итальянское национальное блюдо в виде круглой дрожжевой лепёшки";

            Dish.Ingredient newIngredient = new Dish.Ingredient();
            newIngredient.name = "Соус <<Кунжутный>>";
            newDish.ingredients.Add(newIngredient);

            newIngredient = new Dish.Ingredient();
            newIngredient.name = "Сыр <<Моцарелла>>";
            newDish.ingredients.Add(newIngredient);

            newIngredient = new Dish.Ingredient();
            newIngredient.name = "Сыр <<Моцаррела>> мягкий";
            newDish.ingredients.Add(newIngredient);

            newIngredient = new Dish.Ingredient();
            newIngredient.name = "Помидоры";
            newDish.ingredients.Add(newIngredient);

            Dish.Sizes newSizes = new Dish.Sizes();
            newSizes.size = 23;
            newSizes.price = 380;
            newSizes.wes = 530;
            newDish.sizes.Add(newSizes);

            newSizes = new Dish.Sizes();
            newSizes.size = 30;
            newSizes.price = 760;
            newSizes.wes = 560;
            newDish.sizes.Add(newSizes);

            newSizes = new Dish.Sizes();
            newSizes.size = 40;
            newSizes.price = 1210;
            newSizes.wes = 730;
            newDish.sizes.Add(newSizes);

            dishes.Add(newDish);
            CreatePizza();
        }

        public void CreatePizza()
        {
            for (int i = 0; i < dishes.Count; i++)
            {
                var bc = new BrushConverter();
                Grid global = new Grid();

                global.Height = 100;
                global.Background = (Brush)bc.ConvertFrom("#FFECECEC");
                if (i > 0) global.Margin = new Thickness(0, 10, 0, 0);

                Image logo = new Image();
                if (File.Exists(MainWindow.localPath + @"/image/dish/" + dishes[i].img + ".png"))
                    logo.Source = new BitmapImage(new Uri(MainWindow.localPath + @"\image\dish\" + dishes[i].img + ".png"));
                else
                    logo.Source = new BitmapImage(new Uri(MainWindow.localPath + @"\image\icon.png"));

                logo.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                logo.Height = 50;
                logo.Margin = new Thickness(10, 10, 0, -10);
                logo.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                logo.Width = 50;
                global.Children.Add(logo);

                Label name = new Label();
                name.Content = dishes[i].name;
                name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                name.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                name.Margin = new Thickness(65, 0, 0, 0);
                name.FontWeight = FontWeights.Bold;
                global.Children.Add(name);

                Label description = new Label();
                description.Content = dishes[i].description;
                description.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                description.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                description.Margin = new Thickness(65, 20, 0, 0);
                global.Children.Add(description);

                if (dishes[i].ingredients.Count != 0)
                {
                    Label ingredient = new Label();
                    string str_ingredient = "";
                    for (int j = 0; j < dishes[i].ingredients.Count; j++)
                    {
                        str_ingredient += dishes[i].ingredients[j].name;
                        if (j != dishes[i].ingredients.Count - 1)
                            str_ingredient += ", ";
                    }

                    ingredient.Content = "Cocnfd: " + str_ingredient;
                    ingredient.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ingredient.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ingredient.Margin = new Thickness(65, 40, 0, 0);
                    global.Children.Add(ingredient);
                }

                Label price = new Label();
                price.Content = "Цена: " + dishes[i].sizes[0].price + " р.";
                price.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                price.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                price.Margin = new Thickness(65, 0, 0, 0);
                global.Children.Add(price);

                Label wes = new Label();
                wes.Content = "Вес: " + dishes[i].sizes[0].wes + " г.";
                wes.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                wes.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                wes.Margin = new Thickness(236, 0, 0, 0);
                global.Children.Add(wes);

                Button button1 = new Button();
                Button button2 = new Button();
                Button button3 = new Button();

                Button minus = new Button();
                TextBox count = new TextBox();
                Button plus = new Button();
                CheckBox order = new CheckBox();

                button1.Content = dishes[i].sizes[0].size + " см.";
                button1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button1.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button1.Margin = new Thickness(0, 10, 110, 0);
                button1.Width = 45;
                button1.Background = Brushes.White;
                button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");
                button1.Tag = i;
                button1.Click += delegate
                {
                    price.Content = "Цена: " + dishes[int.Parse(button1.Tag.ToString())].sizes[0].price + " .p";
                    wes.Content = "Цена: " + dishes[int.Parse(button1.Tag.ToString())].sizes[0].wes + " .г";

                    button1.Background = Brushes.White;
                    button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button2.Background = Brushes.White;
                    button2.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button3.Background = Brushes.White;
                    button3.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    dishes[int.Parse(button1.Tag.ToString())].activeSize = 0;
                    count.Text = dishes[int.Parse(button1.Tag.ToString())].sizes[0].countOrder.ToString();
                    order.IsChecked = dishes[int.Parse(button1.Tag.ToString())].sizes[0].orders;
                };
                global.Children.Add(button1);

                button2.Content = dishes[i].sizes[1].size + " см.";
                button2.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button2.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button2.Margin = new Thickness(0, 10, 60, 0);
                button2.Width = 45;
                button2.Background = Brushes.White;
                button2.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");
                button2.Tag = i;
                button2.Click += delegate
                {
                    price.Content = "Цена: " + dishes[int.Parse(button2.Tag.ToString())].sizes[1].price + " .p";
                    wes.Content = "Цена: " + dishes[int.Parse(button2.Tag.ToString())].sizes[1].wes + " .г";

                    button1.Background = Brushes.White;
                    button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button2.Background = Brushes.White;
                    button2.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button3.Background = Brushes.White;
                    button3.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    dishes[int.Parse(button1.Tag.ToString())].activeSize = 1;
                    count.Text = dishes[int.Parse(button1.Tag.ToString())].sizes[1].countOrder.ToString();
                    order.IsChecked = dishes[int.Parse(button1.Tag.ToString())].sizes[1].orders;
                };
                global.Children.Add(button2);

                button3.Content = dishes[i].sizes[2].size + " см.";
                button3.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button3.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button3.Margin = new Thickness(0, 10, 10, 0);
                button3.Width = 45;
                button3.Background = Brushes.White;
                button3.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");
                button3.Tag = i;
                button3.Click += delegate
                {
                    price.Content = "Цена: " + dishes[int.Parse(button3.Tag.ToString())].sizes[2].price + " .p";
                    wes.Content = "Цена: " + dishes[int.Parse(button3.Tag.ToString())].sizes[2].wes + " .г";

                    button1.Background = Brushes.White;
                    button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button2.Background = Brushes.White;
                    button2.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button3.Background = Brushes.White;
                    button3.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    dishes[int.Parse(button1.Tag.ToString())].activeSize = 2;
                    count.Text = dishes[int.Parse(button1.Tag.ToString())].sizes[2].countOrder.ToString();
                    order.IsChecked = dishes[int.Parse(button1.Tag.ToString())].sizes[2].orders;
                };
                global.Children.Add(button3);

                minus.Content = "-";
                minus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                minus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                minus.Margin = new Thickness(0, 0, 103.6f, 10);
                minus.Width = 19;
                minus.Tag = i;
                minus.Click += delegate
                {
                    if (count.Text != "")
                    {
                        if (int.Parse(count.Text) > 0)
                        {
                            count.Text = (int.Parse(count.Text) - 1).ToString();
                            int id = int.Parse(minus.Tag.ToString());
                            dishes[id].sizes[dishes[id].activeSize].countOrder = int.Parse(count.Text);
                        }
                    }
                };
                global.Children.Add(minus);

                count.Text = "0";
                count.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                count.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                count.Margin = new Thickness(0, 0, 33.6f, 10);
                count.TextWrapping = TextWrapping.Wrap;
                count.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                count.Width = 65;
                count.Height = 19;
                count.Tag = i;
                global.Children.Add(count);

                plus.Content = "+";
                plus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                plus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                plus.Margin = new Thickness(0, 0, 9.6f, 10);
                plus.Width = 19;
                plus.Tag = i;
                plus.Click += delegate
                {
                    if (count.Text != "")
                    {
                        if (int.Parse(count.Text) < 15)
                        {
                            count.Text = (int.Parse(count.Text) + 1).ToString();
                            int id = int.Parse(plus.Tag.ToString());
                            dishes[id].sizes[dishes[id].activeSize].countOrder = int.Parse(count.Text);
                        }
                    }
                };
                global.Children.Add(plus);

                order.Content = "Выбрать";
                order.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                order.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                order.Margin = new Thickness(0, 0, 128, 13);
                order.Tag = i;
                order.Click += delegate
                {
                    int id = int.Parse(order.Tag.ToString());
                    dishes[id].sizes[dishes[id].activeSize].orders = (bool)order.IsChecked;
                };
                global.Children.Add(order);

                parrent.Children.Add(global);
            }
        }
    }
}
