using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quản_lý_thư_viện
{
    public partial class Form1 : Form
    {
        List<Book> books = new List<Book>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender , EventArgs e)
        {
            books.Add(new Book { BookId = " B001", Title = " C# cơ bản ", Quantity = 5 });
            books.Add(new Book { BookId = " B002", Title = " python nâng cao", Quantity = 3 });
            books.Add(new Book { BookId = " B003", Title = "Java cho người mới", Quantity = 2 });
            ShowBooks();
        }
    // update for III.4
        private void label3_Click(object sender, EventArgs e)
        {

        }
        // Test pull request
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.BookId = txtBookid.Text;
            b.Title = txtTitle.Text;
            b.Quantity = int.Parse(txtQuantity.Text);
            books.Add(b);
            ShowBooks();
            MessageBox.Show(" Thêm sách thành công!");
        }
        // feature intro changes
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (listBooks.SelectedIndex < 0)
            {
                MessageBox.Show(" hãy chọn một cuốn sách!");
                return;
            }
            Book b = books[listBooks.SelectedIndex];
            if (b.Quantity > 0)
            {
                b.Quantity--;
                ShowBooks();
                MessageBox.Show("Mượn sách thanh công!");
            }
            else
            {
                MessageBox.Show(" Sách đã hết!");
            }
        }
        // Đây là thay đổi test cho Git
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (listBooks.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy chọn một cuốn sách để trả!");
                return;
            }
            Book b = books[listBooks.SelectedIndex];
            b.Quantity++;
            ShowBooks();
            MessageBox.Show("Trả sách thanh công!");
        }
        private void ShowBooks()
        {
            listBooks.Items.Clear();
            foreach (var book in books)
            {
                listBooks.Items.Add($"{book.BookId} - {book.Title} (Qty:{book.Quantity}");
            }
        }
        public class Book
        {
            public string BookId { get;set;}
            public string Title {  get;set;}
            public int Quantity { get;set;}
        }
    }
}
