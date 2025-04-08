using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Doga.UI.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>
            {
                new Category(){ Name ="Meyve Fidanları", Description="Ağaç türleri"},
                new Category(){ Name ="Süs Bitkileri", Description="Çeşitli süs bitkileri"},
                new Category(){ Name ="Çiçekler", Description="Mis kokulu dekorlar"},
                new Category(){ Name ="Tobrak ve Gübre", Description="Bahçe ürünleri"},
                
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {

                new Product {Name="Armut ",Description="ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında",Price=50,Stock=50,IsApproved=true,CategoryId=1,IsHome=true,Image="armut.jpg"},
                new Product {Name="Alev Ağacı ",Description="ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında",Price=80,Stock=50,IsApproved=true,CategoryId=2,IsHome=true,Image="alevagacı.jpg"},
                new Product {Name="Kırmızı Gül ",Description="ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında",Price=5200,Stock=50,IsApproved=true,CategoryId=3,IsHome=true,Image="kırmızıgül.jpg"},
                new Product {Name="Bitki Toprağı ",Description="ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında ürün hakkında",Price=5200,Stock=50,IsApproved=true,CategoryId=4,IsHome=false,Image="bitkitoprakları.jpg"},
                


            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();


            base.Seed(context);
        }

    }
}