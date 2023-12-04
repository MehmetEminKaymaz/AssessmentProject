# AssessmentProject
# Açıklama
Discount sınıfı verilen niteliklere göre kendi içerisinde ilgili fatura için uygun olup olmadığını kontrol eder. Bunu sağlamak adına bir Discount sınıfı kendini miras alacak farklı discount tipleri için şablon olur hemde tüm discountları etkileyebilecek kuralların yazılması için uygun sınıf olacaktır.
Aşağıdaki sınıflar Discount'tan kalıtım alarak oluşturulmuştur :
- AffiliateDiscount
- BulkPurchaseDiscount
- EmployeeDiscount
- LongTimeDiscount:
  
  Bu sınıfların ortak kullandığı bazı temel methodlar ve işlevleri :
- IsApplicable:
  
  İlgili Discount'un verilen Invoice için uygulanabilir olup olmadığını saptar. Bunu hem özelleştirilmiş Discount bazında kurallara bakarak hemde varsa geneli etkilecek kurallar için Base Sınıfın kontrollerinide kullanır.
- CheckDiscount:
  
  Sadece ilgili/özelleştirilmiş Discount tipinin Invoice'a uygunluğunu kontrol eder.
- ApplyDiscount:
  
  Verilen fatura için Discount uygunluğunu içerisinde kontrol ederek, faturaya ilgili indirim değerinin uygulanmasını sağlar.
# UML Diagram
![image](https://github.com/MehmetEminKaymaz/AssessmentProject/assets/50118591/1e3c9d1f-e8c8-4d01-a1a0-898c5925a557)
# SonarQube Report
![image](https://github.com/MehmetEminKaymaz/AssessmentProject/assets/50118591/753e2214-c15e-4b86-bece-37678376bc27)
