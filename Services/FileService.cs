using ProductManagementApi.Models;
using System.Text.Json;


namespace ProductManagementApi.Services
{
    public class FileService
    {
        private readonly string filePath = "products.json";

        public List<Product> ReadProducts()
        {
            if (!File.Exists(filePath))
            {
                return [];
            }

            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            return JsonSerializer.Deserialize<List<Product>>(json) ?? [];
        }
        public void WriteProducts(List<Product> products)
        {
            var json = JsonSerializer.Serialize(products);
            using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var writer = new StreamWriter(stream);
            writer.Write(json);
        }
    }
}
