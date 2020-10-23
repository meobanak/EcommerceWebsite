using EcommerceWebsite.Extensions;
using Exam1.Extensions;
using Exam1.Models;
using Exam1.Service.Interface;
using Exam1.Service.LiteDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Database.MongoDB
{
    public class MongoDB_InitFashionShop : IDBInit
    {
        private IMongoDatabase DB;
        public MongoDB_InitFashionShop(IDataContext context)
        {
            DB = context.GetDatabase<IMongoDatabase>();
        }

        public void InitDB()
        {
            #region Init User data
            if (DB.GetCollection<User>().Find(new BsonDocument()).Any() == false)
            {
                User user = new User();
                user.ID = 1;
                user.Email = "tamntt274@gmail.com";
                user.Password = "admin321";
                user.FirstName = "Tam";
                user.LastName = "Nguyen";
                DB.GetCollection<User>().InsertOne(user);

                User user1 = new User();
                user1.ID = 2;
                user1.Email = "user@gmail.com";
                user1.Password = "user";
                user1.FirstName = "user";
                user1.LastName = "user";
                DB.GetCollection<User>().InsertOne(user1);
            }
            #endregion

            #region Init Color data
            if (DB.GetCollection<FColor>().Find(new BsonDocument()).Any() == false)
            {
                FColor color = new FColor();
                color.ID = 1;
                color.Code = "0xFFFFFF";
                color.Name = "White";
                DB.GetCollection<FColor>().InsertOne(color);

                FColor color1 = new FColor();
                color1.ID = 2;
                color1.Code = "0xFFFFFF";
                color1.Name = "Black";
                DB.GetCollection<FColor>().InsertOne(color1);
            }
            #endregion

            #region Init Size data
            if (DB.GetCollection<FSize>().Find(new BsonDocument()).Any() == false)
            {
                FSize size = new FSize();
                size.ID = 1;
                size.Name = "S";
                size.OrderIndex = 1;
                DB.GetCollection<FSize>().InsertOne(size);

                FSize size1 = new FSize();
                size1.ID = 2;
                size1.Name = "M";
                size1.OrderIndex = 2;
                DB.GetCollection<FSize>().InsertOne(size1);

                FSize size2 = new FSize();
                size2.ID = 3;
                size2.Name = "L";
                size2.OrderIndex = 3;
                DB.GetCollection<FSize>().InsertOne(size2);

                FSize size3 = new FSize();
                size3.ID = 4;
                size3.Name = "XL";
                size3.OrderIndex = 4;
                DB.GetCollection<FSize>().InsertOne(size3);
            }
            #endregion

            #region Init Category data
            if (DB.GetCollection<Category>().Find(new BsonDocument()).Any() == false)
            {
                Category cate = new Category();
                cate.ID = 1;
                cate.Code = "S01";
                cate.Name = "Shirt";
                DB.GetCollection<Category>().InsertOne(cate);

                Category cate1 = new Category();
                cate1.ID = 2;
                cate1.Code = "S02";
                cate1.Name = "T-Shirt";
                DB.GetCollection<Category>().InsertOne(cate1);

                Category cate2 = new Category();
                cate2.ID = 3;
                cate2.Code = "J01";
                cate2.Name = "Jacket";
                DB.GetCollection<Category>().InsertOne(cate2);

                Category cate3 = new Category();
                cate3.ID = 4;
                cate3.Code = "J02";
                cate3.Name = "Jeans";
                DB.GetCollection<Category>().InsertOne(cate3);

                Category cate4 = new Category();
                cate4.ID = 5;
                cate4.Code = "P01";
                cate4.Name = "Pants";
                DB.GetCollection<Category>().InsertOne(cate4);
            }

            #endregion

            #region Init Product data
            if (DB.GetCollection<Product>().Find(new BsonDocument()).Any() == false)
            {
                #region Shirt
                Product product = new Product();
                product.ID = 1;
                product.CategoryID = 1;
                product.Code = "SA01";
                product.Name = "Shirt A01";
                product.Price = 450000;
                product.Description = "".RandomString(100);
                product.IsActive = true;
                product.SizeID = 1;
                product.ColorID = 1;
                product.Gender = 1;
                product.imageSrc = "https://outdoor-and-country-res.cloudinary.com/image/upload/e_trim:2/bo_8px_solid_white/c_pad,b_white,w_1000,h_1200,f_auto,q_auto/v1540205233/product/186710.jpg";
                DB.GetCollection<Product>().InsertOne(product);

                Product product1 = new Product();
                product1.ID = 2;
                product1.CategoryID = 1;
                product1.Code = "SA02";
                product1.Name = "Shirt A02";
                product1.Price = 300000;
                product1.Description = "".RandomString(100);
                product1.IsActive = true;
                product1.SizeID = 2;
                product1.ColorID = 1;
                product1.Gender = 1;
                product1.imageSrc = "https://a3655836d5c58a086ac2-4e8d43a89f100386d472e9f1a1dc59ca.ssl.cf3.rackcdn.com/images/original/dbf68972-c4aa-447b-9726-c11fd209cc7d.jpg";
                DB.GetCollection<Product>().InsertOne(product1);

                Product product2 = new Product();
                product2.ID = 3;
                product2.CategoryID = 1;
                product2.Code = "SA03";
                product2.Name = "Shirt A03";
                product2.Price = 350000;
                product2.Description = "".RandomString(100);
                product2.IsActive = true;
                product2.SizeID = 3;
                product2.ColorID = 1;
                product2.Gender = 1;
                product2.imageSrc = "https://cdn.shopify.com/s/files/1/1832/4455/products/1153_S17_IconShirt_MendocinoBlue_FR.jpg?v=1572027022";
                DB.GetCollection<Product>().InsertOne(product2);
                #endregion

                #region T-shirt
                Product product3 = new Product();
                product3.ID = 4;
                product3.CategoryID = 2;
                product3.Code = "TSA01";
                product3.Name = "T-Shirt A01";
                product3.Price = 250000;
                product3.Description = "".RandomString(100);
                product3.IsActive = true;
                product3.SizeID = 4;
                product3.ColorID = 1;
                product3.Gender = 1;
                product3.imageSrc = "https://cdn11.bigcommerce.com/s-rxzabllq/images/stencil/1280x1280/products/910/18045/Kids-Plain-Poly-Fit-Quick_Dry-Tshirt-red__13799.1567089094.jpg?c=2";
                DB.GetCollection<Product>().InsertOne(product3);

                Product product4 = new Product();
                product4.ID = 5;
                product4.CategoryID = 2;
                product4.Code = "TSA02";
                product4.Name = "T-Shirt A02";
                product4.Price = 150000;
                product4.Description = "".RandomString(100);
                product4.IsActive = true;
                product4.SizeID = 1;
                product4.ColorID = 1;
                product4.Gender = 1;
                product4.imageSrc = "https://d2h2vnfmmg5sct.cloudfront.net/catalog/product/large_image/02_414443.jpg";
                DB.GetCollection<Product>().InsertOne(product4);

                Product product5 = new Product();
                product5.ID = 6;
                product5.CategoryID = 2;
                product5.Code = "TSA03";
                product5.Name = "T-Shirt A03";
                product5.Price = 100000;
                product5.Description = "".RandomString(100);
                product5.IsActive = true;
                product5.SizeID = 2;
                product5.ColorID = 1;
                product5.Gender = 1;
                product5.imageSrc = "https://images-na.ssl-images-amazon.com/images/I/61mSyjeYXWL._AC_UX679_.jpg";
                DB.GetCollection<Product>().InsertOne(product5);
                #endregion

                #region Jacket
                Product product6 = new Product();
                product6.ID = 7;
                product6.CategoryID = 3;
                product6.Code = "JA01";
                product6.Name = "Jacket A01";
                product6.Price = 500000;
                product6.Description = "".RandomString(100);
                product6.IsActive = true;
                product6.SizeID = 3;
                product6.ColorID = 1;
                product6.Gender = 1;
                product6.imageSrc = "https://product.hstatic.net/1000306633/product/5bc67f9a-f1db-4405-9583-9ebc476078b5_4335d664706d4ec0a53e337da90c06a3_master.jpg";
                DB.GetCollection<Product>().InsertOne(product6);

                Product product7 = new Product();
                product7.ID = 8;
                product7.CategoryID = 3;
                product7.Code = "JA02";
                product7.Name = "Jacket A02";
                product7.Price = 600000;
                product7.Description = "".RandomString(100);
                product7.IsActive = true;
                product7.SizeID = 4;
                product7.ColorID = 1;
                product7.Gender = 1;
                product7.imageSrc = "https://cdni.llbean.net/is/image/wim/507067_0_46?hei=1095&wid=950&resMode=sharp2&defaultImage=llbstage/A0211793_2";
                DB.GetCollection<Product>().InsertOne(product7);

                Product product8 = new Product();
                product8.ID = 9;
                product8.CategoryID = 3;
                product8.Code = "JA03";
                product8.Name = "Jacket A03";
                product8.Price = 700000;
                product8.Description = "".RandomString(100);
                product8.IsActive = true;
                product8.SizeID = 2;
                product8.ColorID = 1;
                product8.Gender = 1;
                product8.imageSrc = "https://cf.shopee.ph/file/70f66a937abf9230417e1700379ca3ee";
                DB.GetCollection<Product>().InsertOne(product8);
                #endregion

                #region Jeans
                Product product9 = new Product();
                product9.ID = 10;
                product9.CategoryID = 4;
                product9.Code = "JEA01";
                product9.Name = "Jean A01";
                product9.Price = 400000;
                product9.Description = "".RandomString(100);
                product9.IsActive = true;
                product9.SizeID = 3;
                product9.ColorID = 1;
                product9.Gender = 1;
                product9.imageSrc = "https://i1.wp.com/ae01.alicdn.com/kf/HTB1U7edb9WD3KVjSZSgq6ACxVXaN/2019-New-autumn-Men-s-cotton-Jeans-men-Business-Casual-Stretch-Jean-Classic-Trousers-Denim-Blue.jpg?fit=800%2C800&ssl=1";
                DB.GetCollection<Product>().InsertOne(product9);

                Product product10 = new Product();
                product10.ID = 11;
                product10.CategoryID = 4;
                product10.Code = "JEA02";
                product10.Name = "Jean A02";
                product10.Price = 3500000;
                product10.Description = "".RandomString(100);
                product10.IsActive = true;
                product10.SizeID = 4;
                product10.ColorID = 1;
                product10.Gender = 1;
                product10.imageSrc = "https://cdn.mudjeans.eu/wp-content/uploads/2018/04/Man-Ethical-Jeans-Regular-Dunn-Stone-Blue-halffront-1.jpg";
                DB.GetCollection<Product>().InsertOne(product10);

                Product product11 = new Product();
                product11.ID = 12;
                product11.CategoryID = 4;
                product11.Code = "JEA03";
                product11.Name = "Jean A03";
                product11.Price = 600000;
                product11.Description = "".RandomString(100);
                product11.IsActive = true;
                product11.SizeID = 1;
                product11.ColorID = 1;
                product11.Gender = 1;
                product11.imageSrc = "https://www1.assets-gap.com/webcontent/0015/058/596/cn15058596.jpg";
                DB.GetCollection<Product>().InsertOne(product11);
                #endregion

                #region Pant
                Product product12 = new Product();
                product12.ID = 13;
                product12.CategoryID = 5;
                product12.Code = "PA01";
                product12.Name = "Pant A01";
                product12.Price = 450000;
                product12.Description = "".RandomString(100);
                product12.IsActive = true;
                product12.SizeID = 2;
                product12.ColorID = 1;
                product12.Gender = 1;
                product12.imageSrc = "https://cdn.shopify.com/s/files/1/0071/5633/4681/products/Men_Original-Mountain-Pant_Relaxed-Fit_Terra_272_grande.jpg?v=1568320083";
                DB.GetCollection<Product>().InsertOne(product12);

                Product product13 = new Product();
                product13.ID = 14;
                product13.CategoryID = 5;
                product13.Code = "PA02";
                product13.Name = "Pant A02";
                product13.Price = 3700000;
                product13.Description = "".RandomString(100);
                product13.IsActive = true;
                product13.SizeID = 3;
                product13.ColorID = 1;
                product13.Gender = 1;
                product13.imageSrc = "https://cdn.shopify.com/s/files/1/0023/9901/0881/products/M-Coburn-Pant-Storm-Cloud_5f952c4f-d899-484f-b891-acf4f37f6269_1400x1400.jpg?v=1582657066";
                DB.GetCollection<Product>().InsertOne(product13);

                Product product14 = new Product();
                product14.ID = 15;
                product14.CategoryID = 5;
                product14.Code = "PA03";
                product14.Name = "Pant A03";
                product14.Price = 800000;
                product14.Description = "".RandomString(100);
                product14.IsActive = true;
                product14.SizeID = 4;
                product14.ColorID = 1;
                product14.Gender = 1;
                product14.imageSrc = "https://images.puma.net/images/596699/32/fnd/AUS/w/1000/h/1000/bg/255,255,255";
                DB.GetCollection<Product>().InsertOne(product14);
                #endregion
            }
            #endregion
        }
    }
}
