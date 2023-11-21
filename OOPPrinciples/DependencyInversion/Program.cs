// See https://aka.ms/new-console-template for more information
using DependencyInversion;

Console.WriteLine("Hello, World!");

WhatsappSender whatsappSender = new WhatsappSender();
MailSender mailSender = new MailSender();
SMSSender SMSSender = new SMSSender();

ReportGenerator report1 = new ReportGenerator(whatsappSender);
report1.Send();

ReportGenerator report2 = new ReportGenerator(mailSender);
report2.Send();

ReportGenerator report3 = new ReportGenerator(SMSSender);

report3.Send();
