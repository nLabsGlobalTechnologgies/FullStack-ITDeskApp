# FullStack-ITDeskApp
FullStack IT Desk Application
# ITDeskServer.WebAPI

Bu proje, IT Help Desk uygulamasının web API katmanını içermektedir. Kullanıcıların kayıt olmalarını ve giriş yapmalarını sağlar. Ayrıca JWT (JSON Web Token) tabanlı kimlik doğrulaması, CORS (Cross-Origin Resource Sharing) politikası, Swagger belgeleme gibi özellikleri içermektedir.

## Başlangıç

Projenin çalışabilmesi için aşağıdaki adımları takip edebilirsiniz.

### Önkoşullar

- .NET 8 SDK yüklü olmalıdır. [Dotnet 8 SDK İndirme](https://dotnet.microsoft.com/download/dotnet/8.0)

### Kurulum

1. Bu depoyu klonlayın veya ZIP olarak indirin.
2. Projenin kök dizininde terminal veya komut istemcisini açın.
3. Aşağıdaki komutu çalıştırarak projeyi başlatın:

```bash
dotnet run


# Proje Bilgileri

## Swagger Belgelendirmesi

Tarayıcıda [Swagger Belgelendirmesi](https://localhost:5001/swagger) adresine giderek API hakkında detaylı bilgilere ulaşabilirsiniz.

## Frontend

Projenin frontend kısmı sadece HTML, CSS ve saf JavaScript kullanılarak oluşturulmuştur. Herhangi bir derleme işlemine veya paket yöneticisine ihtiyaç duymaz. Sadece `index.html` dosyasını bir tarayıcıda açarak kullanabilirsiniz.

## Yapılandırma

Proje yapılandırması için `appsettings.json` dosyasını ve `Constants/ContextConstant.cs` dosyasını inceleyebilirsiniz.

## Kullanılan Kütüphaneler

### Backend

- **Entity Framework Core**: Veritabanı işlemleri için kullanılır.
- **Newtonsoft.Json**: JSON işlemleri için kullanılır.
- **FluentValidation**: DTO (Data Transfer Object) doğrulama için kullanılır.
- **Microsoft.AspNetCore.Authentication.JwtBearer**: JWT tabanlı kimlik doğrulaması için kullanılır.
- **Swashbuckle.AspNetCore.SwaggerGen**: Swagger belgeleme için kullanılır.

### Frontend

- **HTML, CSS, JavaScript**

## Katkıda Bulunma

1. Bu projeyi fork edin.
2. Yeni bir branch oluşturun (`git checkout -b yeni-özellik`).
3. Değişikliklerinizi yapın ve değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`).
4. Bir pull request oluşturun.
