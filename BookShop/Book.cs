using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class Book : BaseClass
    {
        public static List<Book> Books = new List<Book>();
        public string Name { get; set; } // kitabın adı
        public BookTypeEnums BookType { get; set; } // kitap türü
        public double CostPrice { get; set; } // maliyet fiyati
        public int TaxPercantage { get; set; } // toplam vergiyi belirtir
        public int ProfitMargin { get; set; } // kazanç yüzde ör. 15 => %18
        public double Price { get; set; } // ürün fiyatı
        public int QTY { get; set; } // quantity qty -> stokdaki adedi gösterir


        // constructor
        public Book(string _name, double _costPrice, BookTypeEnums _bookTypeEnums, int _taxPercantage = 1, int _profitMargin = 10, int _qty = 1)
        {
            Name = _name;
            CostPrice = _costPrice;
            BookType = _bookTypeEnums;
            TaxPercantage = _taxPercantage;
            ProfitMargin = _profitMargin;
            QTY = _qty;

            Price = calculatePrice(_costPrice, _taxPercantage, _profitMargin);
        }

        public double calculatePrice(double costPrice, int tax, int profitMargin)
        {

            //methodda verilen isimler olmalı

            double taxPrice = (costPrice * tax) / 100;
            double profitPrice = (costPrice * profitMargin) / 100;
            double price = costPrice + taxPrice + profitPrice;
            return price;
        }

        public static void addBook(Book book)
        {
            try
            {
                // kitap oluştruldu
                Books.Add(book);

                // ürün maliyeti hesaplanan metot sayesinde metot hesaplandı
                double amount = CaseTransaction.calculateAmount(book.CostPrice, book.QTY);

                //kasa hareketleri nesnesi oluşturuldu
                CaseTransaction caseTransaction = new CaseTransaction(amount, TransactionTypeEnums.EXPENSE);

                //kasa hareketini kaydetmek için CaseTransaction sınıfındaki save metodu  çağrıldı
                CaseTransaction.saveCaseTransaction(caseTransaction);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }

        }

        public static void removeBook(int Id)
        {

            foreach (Book book in Books)
            {
                if (book.Id == Id)
                {
                    Books.Remove(book);
                    Console.WriteLine("Kitabınız başarıyla silindi");
                    break;
                }
            }
        }

 


        //satılacak kitabın id sini ve kaç kitap olduğu bilgisini alın
        public static void sellBook(int bookId, int bookQty)
        {
            foreach (Book kitap in Books)
            {
                if (kitap.Id == bookId)
                {
                    // satılan kitap miktarı kitap listesindeki kitap bilgisinden çkarıldı
                    // satılan kitap miktarı toplam miktardan büyükse hata verir
                    kitap.QTY = kitap.QTY - bookQty;

                    //satış tutarı hesaplandı 
                    double satisTutar = CaseTransaction.calculateAmount(kitap.Price, bookQty);

                    // kasa hareketinden yeni bir object 
                    CaseTransaction kasaHaraketi = new CaseTransaction(satisTutar, TransactionTypeEnums.INCOMING);

                    //
                    CaseTransaction.saveCaseTransaction(kasaHaraketi);
                }
            }
        }

        public override string ToString()
        {
            return String.Format(" Id: {0} " + "Name : {1} " + "Type:{2} " + "Cost Price: {3} " + "Price {4} " + "Quantity:{5} ", Id, Name, BookType, CostPrice, Price,QTY);
        }

    }
}
