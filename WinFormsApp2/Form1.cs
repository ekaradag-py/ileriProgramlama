namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mes = "";
            // TextBox'a bir sayý girilmemiþ ise;
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                string[] dizi = new string[] { "407", "372", "371", "370", "153", "587", "2023", "999", "987", "452" };

                dizi.Select(x =>
                {
                    bool chk = CheckNumber(x);
                    if (chk)
                        mes += $"{x} sayýsý amstrong bir sayýdýr.\n";
                    else
                        mes += $"{x} sayýsý amstrong bir sayý deðildir.\n";
                    return x;
                }).ToList();
            }
            else
            {
                bool chk = CheckNumber(textBox1.Text);
                if (chk)
                    mes += $"{textBox1.Text} sayýsý amstrong bir sayýdýr.\n";
                else
                    mes += $"{textBox1.Text} sayýsý amstrong bir sayý deðildir.\n";
            }
            MessageBox.Show(mes);
        }
        private bool CheckNumber(string sNumber)
        {
            int total = 0;
            bool response = false;
            try
            {
                sNumber.Select(x =>
                {
                    int number = int.Parse(x.ToString());
                    total += (int)Math.Pow(number, 3);
                    return x;
                }).ToList();
                response = Convert.ToInt32(sNumber) == total;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lütfen bir sayý giriniz!");
                throw new Exception("Lütfen bir sayý giriniz!");
            }

            return response;
        }
    }
}