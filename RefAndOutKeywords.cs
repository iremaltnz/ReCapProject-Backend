using System;

namespace RefAndOutKeywords
{
    class Program
    {
        static void Main(string[] args)
        {
            // ref ve out anahtar kelimeleri değer tipleri referans tiplere dönüştürmek için kullanılır.
            // out anahtar kelimesi ref anahtar kelimesi gibi çalışır farkı out anahtar kelimesinde metot içinde parametreyi en az 1 kere set etmeliyiz
            // bu yüzden out anahtar kelimesinde metoda parametre olarak yollanacak değişkene değer atamak zorunda değiliz zaten metot içinde parametrenin değerini değiştirdiğimiz için değişkeni tanımlarken yapacağımız atamanın bir önemi yoktur. 

            int number1 = 10, number2 = 10, number3;

            func1(number1);
            func2(ref number2);
            func3(out number3);

            Console.WriteLine(number1); // çıktı->10
            Console.WriteLine(number2); //çıktı -> 40 ref anahtar kelimesi kullanıldı number2 nin değeri metot içinde değiştirildi
            Console.WriteLine(number3); // çıktı ->50  out anahtar kelimesi kullanıldı number3 ün değeri metot içinde değiştiridi
        }

        static void func1(int number1)
        {
            number1 = 30;
        }

        static void func2(ref int number2)
        {
            number2 = 40;
        }

        static void func3(out int number3)
        {
            number3 = 50;
        }

    }
}
