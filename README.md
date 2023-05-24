# SanabiApi-Mvc
 Bilgisayar Uygulamaları 1 Proje Ödevi
                                                                                                               
•	Api asp.net core 6 ile yazılmıştır.
•	Solid’i ezmeden katmanlı mimari kullanılarak yazılmıştır.
•	İhtiyac’a göre yazılan metodlar güncellenmektedir.
•	Toplam 9 adet model ve bu modelleri kullanan 17 adet DTO class’ı vardır.
•	Her modelin en az 1 adet DTO’su vardır. Bundaki amaç clientler api’yi kullanırken her bilgiye erişmek yerine sadece client’e sunulan Dto’ları kullanması amaçlanmıştır.
•	Api projemiz 5 katmanlı mimaridan oluşuyor. Bunlar;
1.	Controller’larımızın bulunduğu Api katmanı
2.	Model,Dto,Repository ve Service katmanımızın interfacelerini bulundurduğu Core katmanı
3.	Veri tabanı ile alakalı işlemler yaptığımız ve her modele ait konfigürasyon işlemlerini yaptığımız Repository katmanı
4.	Hatalar,Mapleme ve kurallarımızın bulunduğu Service katmanından oluşmaktadır
5.	Web kısmının bulunduğu Web katmanından oluşmaktadır.
•	Her Class'ın temel Crud işlemleri vardır.
•	Her Dto’nun base bir entity mirası vardır. Burada Id ve CreatedDate tutulur.
•	Kullanılan frameworkler; Autofac,EntityFrameworkDesign,Swashbuckle,EntityFramework,EntityFrameworkCoreSql, EntityFrameworkTools,AutoMapper,FluentValidation

