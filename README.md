"# VeriTabaniOdev" 
ASP.NET Core ile DB First ve Code First Yöntemleriyle Ürün ve Sipariş Yönetim
Sistemi Geliştirme: LINQ, Lambda, OOP ve Veritabanı Operasyonları
Ödev Detayları
1. Projenin Amacı
Öğrenciler, bu ödev ile ASP.NET Core, Entity Framework Core, LINQ ve nesne yönelimli
programlama prensiplerini kullanarak bir API geliştirme sürecini öğrenirler. Ayrıca, DB
First ve Code First yöntemlerinin nasıl kullanılacağını, CRUD işlemlerini nasıl
gerçekleştireceklerini ve katmanlı mimariyi nasıl oluşturacaklarını deneyimleyeceklerdir.
2. Veritabanı Yapısı
Ödevin iki temel veri modeli olacak:
Product (Ürün)
Id (int, primary key)
Name (string, 50 karakter, nullable olamaz)
Price (decimal, nullable olamaz)
Stock (int, nullable olamaz)
Order (Sipariş)
Id (int, primary key)
ProductId (int, foreign key)
Quantity (int, nullable olamaz)
OrderDate (datetime, nullable olamaz)
Ekstra Gereksinimler:
Code First Genişlemesi: Customer (Müşteri) tablosu:
Id (int, primary key)
Name (string, nullable olamaz)
Email (string, nullable olamaz)
Bu tablo Code First yöntemiyle eklenmeli ve veritabanında uygun migration işlemleri
yapılmalıdır.
3. Teknolojiler ve Gereksinimler
Back-End Teknolojileri:
ASP.NET Core Web API (v7.0 ve üzeri)
Entity Framework Core
SQL Server
Programlama Teknikleri:
LINQ ve Lambda İfadeleri
LINQ ile veri çekme ve analiz etme işlemleri yapılacak.
Örneğin:
Stokta en çok bulunan ürünü listeleme.
Siparişlerin toplam tutarını hesaplama (Quantity * Price).
Verilen bir müşterinin yaptığı tüm siparişlerin listesi.
Nesne Yönelimli Programlama (OOP)
Miras (Inheritance): Tüm tablolar BaseEntity adlı bir sınıftan türetilmeli. Örneğin:
public class BaseEntity
{
public int Id { get; set; }
public DateTime CreatedAt { get; set; }
public DateTime UpdatedAt { get; set; }
}
Polimorfizm: ILogger adında bir interface tanımlanmalı ve bu interface iki farklı sınıf
tarafından implemente edilmelidir:
FileLogger: Logları bir dosyaya yazar.
DatabaseLogger: Logları bir veritabanına yazar.
Polimorfizm örneği olarak, kullanıcı hangi logger sınıfını kullanmak istediğine karar
verebilmelidir.
Interface Kullanımı: Repository katmanı için bir interface kullanılmalıdır. Örneğin:
public interface IProductRepository
{
Task<List<Product>> GetAllAsync();
Task<Product> GetByIdAsync(int id);
Task AddAsync(Product product);
Task UpdateAsync(Product product);
Task DeleteAsync(int id);
}
Katmanlı Mimari
Controllers: API endpoint'lerini içerir.
Services: İş kurallarını ve business logic içerir.
Repositories: Veritabanı işlemlerini içerir.
Models: Veri modellerini içerir.
4. API Endpoint Gereksinimleri
Ürün İşlemleri
GET /api/products: Tüm ürünleri listeleme.
GET /api/products/{id}: Belirli bir ürünü getirme.
POST /api/products: Yeni bir ürün ekleme.
Validasyonlar:
Name alanı boş olamaz.
Price sıfırdan küçük olamaz.
PUT /api/products/{id}: Mevcut bir ürünü güncelleme.
DELETE /api/products/{id}: Bir ürünü silme.
Sipariş İşlemleri
GET /api/orders: Tüm siparişleri listeleme.
GET /api/orders/{id}: Belirli bir siparişi getirme.
POST /api/orders: Yeni bir sipariş ekleme.
Ekstra İşlev: Toplam sipariş miktarını hesaplayan bir endpoint:
GET /api/orders/total: Toplam sipariş tutarını döndürür.
Müşteri İşlemleri (Code First ile)
GET /api/customers: Tüm müşterileri listeleme.
POST /api/customers: Yeni müşteri ekleme
5. LINQ ve Lambda Sorguları Örnekleri
Ödevde aşağıdaki sorguların yapılması bekleniyor:
Fiyatı 500 TL üzerinde olan ürünleri listeleme.
Sipariş sayısına göre en çok sipariş edilen ürünü bulma.
Tüm ürünlerin toplam stok miktarını hesaplama.
Belirli bir tarihten sonra verilen siparişleri listeleme (parametre olarak tarih alınacak).
6. Teslim Edilecekler
Tamamlanmış Proje:
GitHub deposuna yüklenmiş olmalı.
Veritabanı bağlantısı için appsettings.json kullanımı.
Migration dosyaları.
Açıklamalı Kod:
Tüm sınıflar, metotlar ve önemli kod blokları, açıklamalar içermelidir.
README.md Dosyası:
Projenin amacı, kullanılan teknolojiler, kurulumu ve çalıştırılması.
7. Değerlendirme Kriterleri
Fonksiyonellik: CRUD işlemleri ve API endpoint'leri çalışıyor mu? (40 puan)
Kod Kalitesi ve Mimari: Kod yapısı temiz ve katmanlı mimari uygun mu? (20 puan)
LINQ ve Lambda Kullanımı: Örnek sorgular başarılı bir şekilde yapılmış mı? (20 puan)
OOP Prensipleri: Interface, polimorfizm ve miras kullanılmış mı? (10 puan)
Validasyon ve Hata Yönetimi: Validasyon ve exception handling doğru yapılmış mı? (10
puan)
