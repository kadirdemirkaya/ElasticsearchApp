
# ElasticSearchAPI

Bu proje basit bir api ve form projelerinden oluşan bir elastic search temalı projedir.




## Özellikler ve İçerik

Bu projede de Api projesi BackEnd, Form projesi Client olarak kullanılmıştır.

Ürün üzerinde CRUD işlemleri \
Loglama \
Kategori ve Ülke filtreleme \
Harf ve desen ile otomatik tamamlama \
Repository ve Servisler 

- ElasticsearchAPI
    Food Controller:
    - `GET api/Food/ApplySeedData`: SeedData uygular.
    - `GET api/Food/AllProduct`: Tüm ürünleri getirir.
    - `POST api/Food/AddProduct`: Ürün ekler.
    - `DELETE api/Food/DeleteProduct`: Ürünleri siler.
    - `GET api/Food/GetProduct`: Id bazlı ürün getirir.
    - `PUT api/Food/UpdateProduct`: Ürün güncelleme yapar.
    - `GET api/Food/AutoCompleteWithSearch`: Bir metin içinde verilen kelimenin baş harfini veya baş harflerini içeren kelimeleri bulmayı amaçlar.
    - `GET api/Food/AutoComplete`: Belirli bir deseni içeren kelimeleri bulmayı sağlar.
    - `GET api/Food/CountryFilter`: Şehire göre filtreleme yapar.
    - `GET api/Food/CategoryFilter`: Kategoriye göre filtreleme yapar.

- ElasticsearchForm
    

## Yükleme 

İlk önce projeyi çekin 

```bash 
 git clone https://github.com/kadirdemirkaya/ElasticsearchApp.git
```

Uzantılı yerdeki bilgileri değiştirin 

```bash 
 appsettings.json
```

API Projesini ayağa kaldırın

```bash 
 dotnet run
```


## Form Resmi

![ElasticApp](https://github.com/kadirdemirkaya/ElasticsearchApp/assets/126807887/4b1d653e-484f-4f8a-a6cd-3fcd67fcc9d3)


