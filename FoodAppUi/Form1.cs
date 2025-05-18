using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace FoodAppUi
{
    public partial class Form1 : Form
    {
        private async Task<string> GetFoodInfo(string code)
        {
            StringBuilder result = new StringBuilder();
            string url = $"https://world.openfoodfacts.org/api/v0/product/{code}.json";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(body);
            JsonElement root = doc.RootElement;
            if (root.GetProperty("status").GetInt32() == 0)
            {
                return "Product not found";
            }

            var product = root.GetProperty("product");
            string brand = product.GetProperty("brands").GetString();
            string name = product.GetProperty("product_name").GetString();

            result.AppendLine($"Brand: {brand}");
            result.AppendLine($"Name: {name}");
            result.AppendLine();

            if (product.TryGetProperty("additives_tags", out var additives) && additives.ValueKind == JsonValueKind.Array && additives.GetArrayLength() > 0)
            {
                result.AppendLine("Additives: ");
                foreach (var additive in additives.EnumerateArray())
                {
                    string eCode = additive.GetString().Replace("en:", "").ToUpper();
                    result.AppendLine(eCode);
                }
            }
            else
            {
                result.AppendLine("No data about addetives in this product yet");
            }

            return result.ToString();

        }
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string barcode = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(barcode))
            {
                MessageBox.Show("Please enter a barcode");
                return;
            }
            label2.Text = "Loading...";

            string info = await GetFoodInfo(barcode);
            richTextBox1.Text = info;
            label2.Text = "Done!";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
