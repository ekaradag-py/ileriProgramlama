namespace richTextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string readText = richTextBox1.Text;
            if (String.IsNullOrEmpty(readText))
            {
                MessageBox.Show("L�tfen bir �eyler yaz�n.");
                return;
            }
            string[] spliteText = readText.Split("\n");
            string selectText = spliteText.Max();

            int totalNumbers = 0;
            int totalChars = 0;
            int totalTurkishChars = 0;

            string[] numbers = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] charArray = new string[] { ",", ".", ";", ":" };
            string[] turkishCharArray = new string[] { "�", "�", "�", "�", "�", "�", "�", "�", "�", "�", "�", "�" };
            selectText.Select(x =>
            {
                string search = x.ToString();
                if (numbers.Contains(search))
                    totalNumbers++;
                if (charArray.Contains(search))
                    totalChars++;
                if (turkishCharArray.Contains(search))
                    totalTurkishChars++;
                return x;
            }).ToList();
            string mes = $"En uzun sat�r: {selectText} \n ��erdi�i say�lar {totalNumbers} \n ��erdi�i Noktalama i�aretleri {totalChars} \n ��erdi�i T�rk�e karakterler {totalTurkishChars} \n kadard�r.";

            MessageBox.Show(mes);
        }
    }
}