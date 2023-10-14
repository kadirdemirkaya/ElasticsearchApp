using ElasticsearchForm.Constants;
using ElasticsearchForm.Enums;
using ElasticsearchForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElasticsearchForm
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        public Form1()
        {
            InitializeComponent();

            textBox1.TextChanged += textBox1_TextChanged;
            textBox4.TextChanged += textBox4_TextChanged;
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchWord = textBox1.Text;
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text is null)
                {
                    var alldata = await SendRequestAsync(RequestUrls.AllProduct);
                    textBox2.Text = string.Join(Environment.NewLine, alldata.Select(n => n.Name));
                    lblResultCount.Text = alldata.Count().ToString();
                }
                var searchdata = await SendRequestAsync($"{RequestUrls.FoodCont}/AutoCompleteWithSearch?keyword={searchWord}");
                textBox2.Text = string.Join(Environment.NewLine, searchdata.Select(n=>n.Name));
                lblResultCount.Text = searchdata.Count().ToString();
            }
            catch (Exception ex)
            {
                textBox2.Text = ex.Message;
            }
        }

        private async Task<List<Product>> SendRequestAsync(string url)
        {
            try
            {
                var response = await httpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Product>>(content.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(Category.İtalyanMutfagi);
            comboBox1.Items.Add(Category.CinMutfagi);
            comboBox1.Items.Add(Category.HintMutfagi);
            comboBox1.Items.Add(Category.MeksikaMutfagi);
            comboBox1.Items.Add(Category.JaponMutfagi);
            comboBox1.Items.Add(Category.FransizMutfagi);
            comboBox1.Items.Add(Category.TurkMutfagi);
            comboBox1.Items.Add(Category.AmerikanMutfagi);
            comboBox1.Items.Add(Category.IspanyolMutfagi);

            TextBoxAddDatas().GetAwaiter();

            comboBox2.Items.Add("Amerika");
            comboBox2.Items.Add("Cin");
            comboBox2.Items.Add("Fransa");
            comboBox2.Items.Add("Hindistan");
            comboBox2.Items.Add("Ispanya");
            comboBox2.Items.Add("Japonya");
            comboBox2.Items.Add("Meksika");
            comboBox2.Items.Add("Türkiye");
        }

        private async Task TextBoxAddDatas()
        {
            var allData  = await SendRequestAsync(RequestUrls.AllProduct);
            lblCounttxtBox3.Text = allData.Count().ToString();
            textBox3.Text = string.Join(Environment.NewLine, allData.Select(p => $"{p.Name}, {Enum.GetName(typeof(Country), p.Country)},  {Enum.GetName(typeof(Category), p.Category)}"));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedCategory = comboBox1.SelectedItem.ToString();
                var countryFilter = await SendRequestAsync($"{RequestUrls.CategoryFilter}?keyword={selectedCategory}");
                textBox3.Text = string.Join(Environment.NewLine, countryFilter.Select(p => $"NAME:{p.Name}, COUNTRY:{Enum.GetName(typeof(Country), p.Country)}, CATEGORY:{Enum.GetName(typeof(Category), p.Category)}"));
            }
            catch (Exception ex)
            {
                textBox3.Text = ex.Message;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedCategory = comboBox2.SelectedItem.ToString();
                var countryFilter = await SendRequestAsync($"{RequestUrls.CountryFilter}?keyword={selectedCategory}");
                textBox3.Text = string.Join(Environment.NewLine, countryFilter.Select(p => $"NAME:{p.Name}, COUNTRY:{Enum.GetName(typeof(Country), p.Country)}, CATEGORY:{Enum.GetName(typeof(Category), p.Category)}"));
            }
            catch (Exception ex)
            {
                textBox3.Text = ex.Message;
            }
        }

        private async void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text.Count() > 1)
            {
                string searchWord = textBox4.Text;
                try
                {
                    var searchdata = await SendRequestAsync($"{RequestUrls.FoodCont}/AutoComplete?keyword={searchWord}");
                    label7.Text = string.Join(Environment.NewLine, searchdata.Select(n => n.Name));
                }
                catch (Exception ex)
                {
                    textBox4.Text = ex.Message;
                }
            }
        }
    }
}