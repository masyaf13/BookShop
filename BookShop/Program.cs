using System;

namespace BookShop
{
    public class Program
    {

        /// <summary>
        /// Kitap Mağazası Uygulaması
        ///
        /// Kitap, Kasa
        ///
        /// 1 - kitap kayıt edebilmeyi
        ///     -- kayıt esnasında kitap adi, adedi, maliyet fiyati, vergisi, kazanç miktari vs.
        ///     -- ürün fiyati maliyet fiyati, vergi ve kazanç miktarina bağlı olarak hesaplanır
        /// 2 - kitap silebilme
        ///     -- kita silme fonksiyonu seçilirse girilen adet kadar kitap silinecektir
        /// 3 - kitap güncelleme
        /// 4 - kitap satış
        ///     -- satılan kitap fiyatı kasaya gelir olarak giriş yapılır
        ///     -- satılan kitap kitap listemden eksiltilir
        /// 5 - kitap listesi
        /// 6 - kitap listesinden arama kabiliyeti
        ///
        ///  Kitap -> id, adi, tür'ü (enum kullanacağız), maliyet fiyati, toplam vergi, stok adedi, kayit tarihi, güncelleme tarihi
        ///  Kasa işlemi -> id, tür (gelir , gider (enum kullanacağım)), tutar, kayit tarihi
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            int secim = 0;
            while (secim != 8)
            {
                Console.WriteLine("1 - Kitap Ekle");
                Console.WriteLine("2 - Kitap Silme");
                Console.WriteLine("3 - Kitap Güncelleme");
                Console.WriteLine("4 - Kitap Satış");
                Console.WriteLine("5 - Kitap Listeleme");
                Console.WriteLine("6 - Kitap ara");
                Console.WriteLine("7 - Kasa Hareketleri");
                Console.WriteLine("8 - Çıkış");

                secim = Convert.ToInt32(Console.ReadLine());



                switch (secim)
                {
                    case 1:
                        kitapEkleCase();            
                        break;
                    case 2:
                        kitaplariListele();
                        Console.Write("Silmek istediğiniz kitap id si: ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        Book.removeBook(bookId);
                        break;
                    case 4:
                        kitaplariListele();
                        Console.Write("Satılan kitap id'si : ");
                        int satilanKitapId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Satılan Kitap Adedi:");
                        int satilanKitapAdeti = Convert.ToInt32(Console.ReadLine());

                        Book.sellBook(satilanKitapId,satilanKitapAdeti);
                        kitaplariListele();
                        break;
                    case 5:
                        kitaplariListele();                      
                        break;
                    case 6:
                                               
                        break;
                    case 7:
                        CaseTransaction.kasaHareketleriniListele();

                        break;
                    default:
                        break;
                        
                        }

                }

            /*
            int sayac = 0;

            Random rastgele = new Random();

             while (sayac < 50)
            {
                // yeni bir kitap nesnesi oluşturuldu
                Book book = new Book("Kitap " + (sayac +1), rastgele.Next(35,51), (BookTypeEnums)rastgele.Next(0,5), rastgele.Next(1,21), rastgele.Next(10,31) , rastgele.Next(1,16) );
                //oluşturulan kitap listeye eklendi
                Book.addBook(book);
                sayac++;
            }


            */

            Console.WriteLine("KASA HAREKETLERİ");
            foreach (CaseTransaction caseTransaction in CaseTransaction.CaseTransactions)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine(caseTransaction.ToString());


            }
            
        }
        public static void kitapEkleCase()
        {
            Console.Write("Kitap Adı:");
            string bookName = Console.ReadLine();

            Console.Write("Maliyet:");
            double costPrice = Convert.ToDouble(Console.ReadLine());

          
            Console.Write("Türü(0-4):");
            BookTypeEnums bookType = (BookTypeEnums)Convert.ToInt32(Console.ReadLine());
            if ( bookType< 0 && 4< (int)bookType)
            {
                Console.WriteLine("lütfen 0-4 arasında değer girin");
            }
        
            Console.Write("Vergi Oranı:");
            int taxPercantage = Convert.ToInt32(Console.ReadLine());

            Console.Write("Kazanç Oranı:");
            int profitMargin = Convert.ToInt32(Console.ReadLine());

            Console.Write("Adet:");
            int qty = Convert.ToInt32(Console.ReadLine());

            Book newBook = new Book(bookName, costPrice, bookType, taxPercantage, profitMargin, qty);
            Book.addBook(newBook);
        }

        public static void kitaplariListele()
        {

            Console.WriteLine("KİTAP LİSTESİ");
            foreach (Book item in Book.Books)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine(item.ToString());


            }
        }
       
      
    }
}
