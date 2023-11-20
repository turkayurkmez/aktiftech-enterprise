namespace SingleResponsibility.WinForm
{
    /*
     * Her nesnenin sadece bir sorumluluğu olmalı.
     * Örneğin Form1'in amacı kullanıcıdan veri almak
     * Kullanıcıya durum bilgisi vermek
     * Kullanıcı ile interaktif olmak
     * 
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreateProduct_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            decimal price = decimal.Parse(textBoxPrice.Text);
            ProductService productService = new ProductService();
            var result = productService.CreateProduct(name, price);
            var message = result > 0 ? "Başarılı" : "Başarısız";
            MessageBox.Show(message);

            MailService mailService = new MailService();
            mailService.SendMailToVendor("Siemens");

        }





    }
}