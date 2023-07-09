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
                MessageBox.Show("Lütfen bir þeyler yazýn.");
                return;
            }
            string[] spliteText = readText.Split("\n");
            string selectText = spliteText.Max();

            int totalNumbers = 0;
            int totalChars = 0;
            int totalTurkishChars = 0;

            string[] numbers = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] charArray = new string[] { ",", ".", ";", ":" };
            string[] turkishCharArray = new string[] { "ý", "ç", "þ", "ö", "ü", "ð", "Ý", "Ç", "Þ", "Ö", "Ü", "Ð" };
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
            string mes = $"En uzun satýr: {selectText} \n Ýçerdiði sayýlar {totalNumbers} \n Ýçerdiði Noktalama iþaretleri {totalChars} \n Ýçerdiði Türkçe karakterler {totalTurkishChars} \n kadardýr.";

            MessageBox.Show(mes);
        }
    }
}