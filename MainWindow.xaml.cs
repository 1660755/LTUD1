using Aspose.Cells;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DoAn
{
    public static class StringExtension
    {
        public static bool IsNotEmpty(this string data)
        {
            bool result = data.Length != 0;
            return result;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class PagingInfo
        {
            public int RowsPerPage { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
            public int TotalItems { get; set; }
            public List<string> Pages
            {
                get
                {
                    var result = new List<string>();

                    for (var i = 1; i <= TotalPages; i++)
                    {
                        result.Add($"Trang {i} / {TotalPages}");
                    }

                    return result;
                }
            }
        }

        class FilterEntity
        {
            public int Value { get; set; }
        }


        PagingInfo _pagingInfo;
        FilterEntity _filterInfo;

        int rowsPerPage = 3;
        int _selectedCategoryIndex = 0;


        void CalculatePagingInfo()
        {
            // Ket noi CSDL va lay dl tuong ung
            var db = new MyStoreEntities();
            var categories = db.Category.ToList();
            var _selectedCategoryIndex = categoriesComboBox.SelectedIndex;
            var products = categories[_selectedCategoryIndex].Product;

            var keyword = searchProductTextBox.Text;
            var query = from product in products
                        where product.Name.ToLower()
                                .Contains(keyword.ToLower())
                        select product;

            // Tinh toan thong tin phan trang
            var count = query.Count();
            _pagingInfo = new PagingInfo()
            {
                RowsPerPage = rowsPerPage,
                TotalItems = count,
                TotalPages = count / rowsPerPage +
                    (((count % rowsPerPage) == 0) ? 0 : 1),
                CurrentPage = 1
            };

            pagingComboBox.ItemsSource = _pagingInfo.Pages;
            pagingComboBox.SelectedIndex = 0;

            //statusTextBlock.Text = $"Tổng sản phẩm tìm thấy: {count} ";
        }

        void UpdateProductView()
        {
            var db = new MyStoreEntities();
            var categories = db.Category.ToList();
            var _selectedCategoryIndex = categoriesComboBox.SelectedIndex;
            var products = categories[_selectedCategoryIndex].Product;
            var keyword = searchProductTextBox.Text;
            var query = from product in products
                        where product.Name.ToLower().Contains(keyword.ToLower())
                        select product;

            // Gan du lieu cho list view de o cuoi cung
            // Dua theo trang hien tai
            var skip = (_pagingInfo.CurrentPage - 1) * _pagingInfo.RowsPerPage;
            var take = _pagingInfo.RowsPerPage;
            var transform = from item in query.Skip(skip).Take(take)
                            select new
                            {
                                item.Name,
                            };
            productDataGrid.ItemsSource = transform.ToList();
        }

        private void importFromExcel_click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                var excelFile = new Workbook(screen.FileName);
                var tabs = excelFile.Worksheets;

                var db = new MyStoreEntities();

                foreach (var tab in tabs)
                {
                    Debug.WriteLine(tab.Name);
                    var row = 3;
                    var category = new Category()
                    {
                        Name = tab.Name
                    };
                    db.Category.Add(category);
                    db.SaveChanges();

                    var cell = tab.Cells[$"C3"];

                    while (cell.Value != null || cell.StringValue.IsNotEmpty())
                    {
                        var sku = tab.Cells[$"C{row}"].StringValue;
                        var name = tab.Cells[$"D{row}"].StringValue;
                        var price = tab.Cells[$"E{row}"].IntValue;
                        var quantity = tab.Cells[$"F{row}"].IntValue;
                        var description = tab.Cells[$"G{row}"].StringValue;
                        var image = tab.Cells[$"H{row}"].StringValue;

                        var product = new Product()
                        {
                            SKU = sku,
                            Name = name,
                            CatId = category.Id
                        };

                        category.Product.Add(product);
                        db.SaveChanges();

                        Debug.WriteLine($"{sku}{name}{price}{quantity}{description}");

                        // Đi qua dòng kế
                        row++;
                        cell = tab.Cells[$"C{row}"];
                    }

                }
                MessageBox.Show("Import thành công");
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new MyStoreEntities();

            categoriesComboBox.ItemsSource = db.Category.ToList();
            categoriesComboBox.SelectedIndex = 0;
            //productDataGrid.ItemsSource = db.Product.ToList();
            CalculatePagingInfo();
            UpdateProductView();
        }

        private void categoriesCombobox_change(object sender, SelectionChangedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        private void searchProductTextBox_change(object sender, TextChangedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        private void pagingComboBox_change(object sender, SelectionChangedEventArgs e)
        {
            int nextPage = pagingComboBox.SelectedIndex + 1;
            _pagingInfo.CurrentPage = nextPage;

            UpdateProductView();
        }
    }
}
