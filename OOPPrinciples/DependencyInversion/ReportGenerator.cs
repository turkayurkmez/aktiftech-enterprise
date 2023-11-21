namespace DependencyInversion
{
    public class ReportGenerator
    {
        private ISender sender;

        public ReportGenerator(ISender sender)
        {
            this.sender = sender;
        }
        public void Send()
        {
            //MailSender mailSender = new MailSender();
            sender.Send();
        }
    }

    public interface ISender
    {
        void Send();
    }
    public class MailSender : ISender
    {
        public void Send() => Console.WriteLine("Mail gönderildi");
    }

    public class WhatsappSender : ISender
    {
        public void Send()
        {
            Console.WriteLine("Whatsapp ile gönderildi");
        }
    }

    public class SMSSender : ISender
    {
        public void Send()
        {
            Console.WriteLine("SMS gönderildi");
        }
    }
}
