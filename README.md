# Muzik Magazasi

**Muzik Magazasi**, müzik enstrümanları satışını yönetmek için geliştirilen bir konsol uygulamasıdır. Sistem, ürünlerin eklenmesi, listelenmesi, güncellenmesi ve silinmesi gibi temel mağaza işlevlerini desteklemektedir.

## Özellikler

- **Ürün Yönetimi**: Enstrüman ekleme, güncelleme, silme ve listeleme.
- **Kategori Yönetimi**: Ürünlerin kategori bazında ayrılması.
- **Fiyat Hesaplama**: Ürünlerin fiyatlarının otomatik hesaplanması.
- **Konsol Arayüzü**: Basit ve kullanıcı dostu komut satırı arayüzü.

## Teknolojiler

- **.NET 7.0**
- **C#**
- **OOP (Nesne Yönelimli Programlama)**

## Kurulum

### Gereksinimler

- .NET 7.0 SDK
- Visual Studio veya Visual Studio Code

### Adımlar

1. Depoyu klonlayın:

   ```bash
   git clone https://github.com/Minelka/MuzikMagazasi.git
   ```

2. Proje dizinine gidin:

   ```bash
   cd MuzikMagazasi
   ```

3. Bağımlılıkları yükleyin:

   ```bash
   dotnet restore
   ```

4. Uygulamayı çalıştırın:

   ```bash
   dotnet run
   ```

## API Endpoints

Bu proje bir konsol uygulaması olduğu için herhangi bir API Endpoint'i içermemektedir.

## Proje Yapısı

```
MuzikMagazasi
├─ Models      # Veri modelleri
├─ Services    # İş servisleri
├─ Data        # Örnek veriler
└─ Program.cs  # Uygulama başlatma noktası
```

### Açıklama

- **Models**: Ürün ve kategori modellerini içerir.
- **Services**: Ürünlerin işlenmesi için servis sınıflarını barındırır.
- **Data**: Mock veri sınıflarını içerir.
- **Program.cs**: Uygulamanın başlangıç noktasıdır.

## Lisans

Bu proje açık kaynak değildir ve yalnızca izinli kullanıcılar tarafından kullanılabilir.
