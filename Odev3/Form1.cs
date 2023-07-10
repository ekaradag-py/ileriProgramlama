namespace Odev3
{

    public partial class Form1 : Form
    {
        List<BanknotModel> banknotlar = new List<BanknotModel>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!banknotlar.Any())
            {
                banknotlar.Add(new BanknotModel()
                {
                    BanknotTuru = 10,
                    Adet = 30
                });
                banknotlar.Add(new BanknotModel()
                {
                    BanknotTuru = 20,
                    Adet = 30
                });
                banknotlar.Add(new BanknotModel()
                {
                    BanknotTuru = 50,
                    Adet = 30
                });
                banknotlar.Add(new BanknotModel()
                {
                    BanknotTuru = 100,
                    Adet = 30
                });
                banknotlar.Add(new BanknotModel()
                {
                    BanknotTuru = 200,
                    Adet = 30
                });
            }
            banknotlar = banknotlar.OrderByDescending(x => x.BanknotTuru).ToList();
            int toplamTutar = banknotlar.Sum(x => x.Tutar);
            int talepEdilenTutar = 0;
            try
            {
                talepEdilenTutar = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Lütfen Çekmek Ýstediðiniz Tutarý Girin!");
                return;
            }
            bool isValidate = Validate(talepEdilenTutar, toplamTutar);
            if (!isValidate)
                return;

            int verilecekTutar = 0;
            List<BanknotModel> verilenBanknotlar = new List<BanknotModel>();
            banknotlar.Select(x =>
            {
                int verilenAdet = 0;
                while (x.BanknotTuru <= talepEdilenTutar && verilecekTutar < talepEdilenTutar && (talepEdilenTutar - verilecekTutar >= x.BanknotTuru) && x.Adet > 0)
                {
                    verilecekTutar += x.BanknotTuru;
                    x.Adet--;
                    verilenAdet++;
                }
                if (verilenAdet != 0)
                {
                    var addModel = new BanknotModel();
                    addModel.BanknotTuru = x.BanknotTuru;
                    addModel.Adet = verilenAdet;
                    verilenBanknotlar.Add(addModel);
                }
                return x;
            }).ToList();
            string mess = "";
            verilenBanknotlar.Select(x =>
            {
                mess += $"{x.BanknotTuru}'den {x.Adet} tane, \n";
                return x;
            }).ToList();
            mess += $"Olmak Üzere Toplamda {verilenBanknotlar.Sum(x => x.Tutar)} TL verilmiþtir.";
            MessageBox.Show(mess);
            toplamTutar = banknotlar.Sum(x => x.Tutar);
            label2.Text = $"Çekilebilecek Maximum Tutar : {toplamTutar} TL";
        }
        private class BanknotModel
        {
            public int BanknotTuru { get; set; } = 0;
            public int Adet { get; set; } = 0;
            public int Tutar => BanknotTuru * Adet;
        }
        private bool Validate(int talepEdilenTutar, int toplamTutar)
        {
            if (toplamTutar <= 0)
            {
                MessageBox.Show($"Para Bitti!");
                return false;
            }
            if (talepEdilenTutar % 10 != 0)
            {
                MessageBox.Show($"Lütfen 10 ve katlarýnda para çekiniz!");
                return false;
            }
            if (toplamTutar < talepEdilenTutar)
            {
                MessageBox.Show($"Maximum {toplamTutar} kadar para çebilirsiniz!");
                return false;
            }
            return true;
        }
    }
}