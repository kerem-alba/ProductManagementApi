> ⚙️ Bu proje, aşağıda belirtilen görev yönergesine uygun olarak geliştirilmiştir.

# Ürün Yönetim API’si – Görev 1

## 📌 Giriş

Bu görevde, .NET 8 Minimal API kullanarak basit bir **Ürün Yönetim API’si** geliştirilecektir. API, ürün bilgilerini `products.json` dosyasında JSON formatında saklar. Dosya işlemleri için `Stream`, veri yönetimi için JSON serialization ve deserialization işlemleri kullanılır.

---

## 🎯 Amaçlar

- Minimal API ile ürün yönetimi API’si geliştirmek  
- JSON dosyası ile veri saklama ve okuma işlemleri gerçekleştirmek  
- `Stream` kullanarak dosya işlemlerini uygulamak  
- JSON serialization/deserialization işlemlerini öğrenmek  

---

## 🛠️ Gereksinimler

- Visual Studio veya Visual Studio Code  
- .NET 8 SDK  

---

## 📦 Model Yapısı

### `Product` Modeli

```csharp
public class Product
{
    public int Id { get; set; }           // Ürün kimliği
    public string Name { get; set; }      // Ürün adı
    public decimal Price { get; set; }    // Ürün fiyatı
    public string Category { get; set; }  // Ürün kategorisi
}
```

---

## 🔧 Adımlar

### 1. API Yapısı ve CRUD İşlemleri

Minimal API yapısını kullanarak aşağıdaki endpoint'leri oluşturun:

- `GET /products` → Tüm ürünleri listele  
- `POST /products` → Yeni bir ürün ekle  
- `PUT /products/{id}` → Ürünü güncelle  
- `DELETE /products/{id}` → Ürünü sil  

Bu işlemler sırasında JSON verileri serialize/deserialize edilerek dosyada saklanacaktır.

---

### 2. JSON Dosyasında Veri Saklama

- Veritabanı yerine `products.json` kullanılacak  
- Ürün ekleme, silme, güncelleme işlemleri doğrudan bu dosya üzerinde yapılacaktır  

💡 **Gerçek Dünya Senaryosu:**  
Küçük işletmeler ürün bilgilerini basit bir şekilde saklamak için JSON dosyalarını tercih edebilir.

---

### 3. Stream ve JSON Serialization İşlemleri

- `FileStream`, `StreamWriter` kullanarak ürünleri dosyaya JSON formatında yaz  
- `StreamReader` ile dosyadan oku ve `JsonSerializer.Deserialize<T>()` ile nesneye dönüştür  

---
