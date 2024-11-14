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

namespace VVViceTrade
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        int CountProduct = TradeSKRRRRRRRRRRRRRRRREntities.GetContext().Product.Count();
        int CountProductMax = TradeSKRRRRRRRRRRRRRRRREntities.GetContext().Product.Count();

        public ProductPage()
        {
            InitializeComponent();
            var currentProduct = TradeSKRRRRRRRRRRRRRRRREntities.GetContext().Product.ToList();
            ProductListView.ItemsSource = currentProduct;
            productCount.Text = "Выведено записей " + CountProduct.ToString() + " из " + CountProductMax.ToString();

        }
        private void UpdateProduct()
        {
            var currentProduct = TradeSKRRRRRRRRRRRRRRRREntities.GetContext().Product.ToList();

            if (ComboType.SelectedIndex == 0)
            {
                currentProduct = currentProduct.Where(p => (p.ProductDiscountAmount >= 0 && p.ProductDiscountAmount <= 100)).ToList();
            }
            if (ComboType.SelectedIndex == 1)
            {
                currentProduct = currentProduct.Where(p => (p.ProductDiscountAmount > 0 && p.ProductDiscountAmount < 10)).ToList();
            }
            if (ComboType.SelectedIndex == 2)
            {
                currentProduct = currentProduct.Where(p => (p.ProductDiscountAmount > 10 && p.ProductDiscountAmount < 15)).ToList();
            }
            if (ComboType.SelectedIndex == 3)
            {
                currentProduct = currentProduct.Where(p => (p.ProductDiscountAmount > 15 && p.ProductDiscountAmount <= 100)).ToList();
            }

            if (Sort.SelectedIndex == 0)
                currentProduct = currentProduct;
            else if (Sort.SelectedIndex == 1)
                currentProduct = currentProduct.OrderBy(product => product.ProductCost).ToList();
            else if (Sort.SelectedIndex == 2)
                currentProduct = currentProduct.OrderByDescending(product => product.ProductCost).ToList();

            currentProduct = currentProduct.Where(p => p.ProductName.ToLower().Contains(TboxSearch.Text.ToLower())).ToList();

            ProductListView.ItemsSource = currentProduct;
            
            CountProduct = currentProduct.Count();
            productCount.Text = "Выведено записей " + CountProduct.ToString() + " из " + CountProductMax.ToString();

        }

        private void TboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }
    }
}
