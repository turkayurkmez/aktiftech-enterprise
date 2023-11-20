namespace SingleResponsibility.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreateProduct_Click(object sender, EventArgs e)
        {

        }

        int CreateProduct(string name, decimal price)
        {
            return 1;
        }


        void SendMailToVendor(string vendorEmail)
        {
            MessageBox.Show("Eposta gönderildi");
        }
    }
}