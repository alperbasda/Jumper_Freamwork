# Jumper_Freamwork

<b> Jumper_Freamwork Nedir ? </b>
<br/>
Jumper_Freamwork bir low code architecture projesidir. Son kullanıcıya sunulan arayüz aracılığı ile Cqrs ve NLayer mimarilere uygun code base oluşturmak için kullanılır.
<br/>
Son kullanıcı isteklerine göre yeni mimariler eklenebilmesi için çok esnek bir yapıya sahiptir.

<b> Jumper_Freamwork Nasıl Çalıştırılır ? </b>

Jumper_Freamwork'ün MongoDb, Mssql ve Redis bağımlılığı vardır. appsetting.json dosyasında ilgili alanların bilgileri düzenlenmelidir.
<br/>

<b> Jumper_Freamwork Geliştirici Notları ? </b>
<br/>
1-) Creator_UI ayağa kaltığında Auth gereksinimi duyduğu için Identity serverda eş zamanlı ayağa kaldırılmalıdır.  
<br/>
2-) Yer yeni mimari için CodeGenerator klasörü altına Jumper.CodeGenerator.{MimariAdı}Builder isimlendirmesi ile yeni bir proje başlatılır.
<br/>
3-) Yeni başlatılan builder projesi içerisinde sadece tt templateler olmalıdır. tt templateler kod üzerinden Invoke edildiği için custom tool özellik değeri "TextTemplatingFilePreprocessor" olarak ayarlanmalıdır.
<br/>
4-) Herhangi bir proje CodeGeneratorHelpers projesini refere edecekse _Dependency klasöründeki dll üzerinden referans almalıdır. Dolayısı ile helpers projesinde bir değişiklik oldugunda diğer projelerin bu değişikliği görebilmesi için helper projesi build edilmedir.
<br/>
5-) Builderbase ilgili mimarilerin dlllerini UIdan gelen talep dogrultusunda _Dependencies/Architecture klasöründen okur. dolayısı ile Builder projelerinde bir değişiklik olduğunda onlarda build edilmelidir.
<br/>
6-) Tasarımlarınızı test ederken T4Test projesini kullanabilirsiniz.
<br/>
