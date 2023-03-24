using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pc_Hardware_Shop
{
    public partial class Form1 : Form
    {

        List<Hardware> hardwares = new List<Hardware>();
        List<Hardware> User_hardwares = new List<Hardware>();

        public void SendConfirm(string UserAdress)
        {

            MailAddress fromAdress = new MailAddress("yolka.today.from@gmail.com", "Pc shop");
            MailAddress toAdress = new MailAddress(UserAdress);
            MailMessage message= new MailMessage(fromAdress,toAdress);

            message.Body += "Список комплектующих:"+"\n";

            for (int i = 0; i < User_hardwares.Count; i++)
            {
                message.Body += User_hardwares[i].Name + " - " + User_hardwares[i].Price.ToString()+"$" + "\n";
            }

            message.Body += "К оплате "+label3.Text+"$";

            message.Subject = "Order confirm";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("yolka.today.from@gmail.com", "hqoifkucbcvrmkfl");

            smtpClient.Send(message);
        }

        public void Read()
        {
           
            String line;
            try
            {
                StreamReader sr = new StreamReader("Hardware.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                do
                {
                    Hardware hardware = new Hardware();
                    hardware.Name = line;
                    hardware.Price = Convert.ToInt32(sr.ReadLine());
                    hardware.Characteristics = sr.ReadLine();

                    line = sr.ReadLine();

                    hardwares.Add(hardware);

                } while (line!=null);

                //close the file
                sr.Close();
                Console.ReadLine();


                for (int i = 0; i < hardwares.Count; i++)
                {

                    listBox1.Items.Add(hardwares[i].Name);
                    
                }

            }
            catch (Exception e)
            {
                
            }
            finally
            {
                
            }


        }

        public Form1()
        {
            InitializeComponent();
            Read();

            tabPage1.Text = "Товары";
            tabPage2.Text = "Корзина";
        }





        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = hardwares[listBox1.SelectedIndex].Price.ToString();
            label2.Text = hardwares[listBox1.SelectedIndex].Characteristics;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            listBox2.Items.Add(listBox1.SelectedItem);
            User_hardwares.Add(hardwares[listBox1.SelectedIndex]);

            int sum = 0;

            for (int i = 0; i < User_hardwares.Count; i++)
            {
                sum += User_hardwares[i].Price;
            }

            label3.Text = sum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_hardwares.RemoveAt(listBox2.SelectedIndex);
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);

            int sum = 0;

            for (int i = 0; i < User_hardwares.Count; i++)
            {
                sum+= User_hardwares[i].Price;
            }

            label3.Text= sum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendConfirm(textBox1.Text);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


    }
}
