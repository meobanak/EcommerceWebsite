using EcomerceWebsite.Models;
using Exam1.Data.Interface;
using Exam1.Extensions;
using Exam1.LiteDB.Data;
using Exam1.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Data.LiteDB.EcomerceFashionService
{
    public class ProductService : IProduct
    {
        private LiteDatabase DB;

        public ProductService(ILiteDBContext data)
        {
            DB = data.Database;
        }

        private void InitDB()
        {
            #region Init User data
            if (DB.GetCollectionDBModel<User>().FindAll().Any() == false)
            {
                User user = new User();
                user.ID = 1;
                user.Email = "tamntt274@gmail.com";
                user.Password = "admin321";
                user.FirstName = "Tam";
                user.LastName = "Nguyen";
                DB.GetCollectionDBModel<User>().Insert(user);

                User user1 = new User();
                user1.ID = 2;
                user1.Email = "user@gmail.com";
                user1.Password = "user";
                user1.FirstName = "user";
                user1.LastName = "user";
                DB.GetCollectionDBModel<User>().Insert(user1);
            }
            #endregion

            #region Init Color data
            if(DB.GetCollectionDBModel<FColor>().FindAll().Any() == false)
            {
                FColor color = new FColor();
                color.ID = 1;
                color.Code = "0xFFFFFF";
                color.Name = "White";
                DB.GetCollectionDBModel<FColor>().Insert(color);

                FColor color1 = new FColor();
                color1.ID = 2;
                color1.Code = "0xFFFFFF";
                color1.Name = "Black";
                DB.GetCollectionDBModel<FColor>().Insert(color);
            }
            #endregion

            #region Init Size data
            if(DB.GetCollectionDBModel<FSize>().FindAll().Any() == false)
            {
                FSize size = new FSize();
                size.ID = 1;
                size.Name = "S";
                size.OrderIndex = 1;
                DB.GetCollectionDBModel<FSize>().Insert(size);

                FSize size1 = new FSize();
                size1.ID = 2;
                size1.Name = "M";
                size1.OrderIndex = 2;
                DB.GetCollectionDBModel<FSize>().Insert(size1);

                FSize size2 = new FSize();
                size2.ID = 3;
                size2.Name = "L";
                size2.OrderIndex = 3;
                DB.GetCollectionDBModel<FSize>().Insert(size2);

                FSize size3 = new FSize();
                size3.ID = 4;
                size3.Name = "XL";
                size3.OrderIndex = 4;
                DB.GetCollectionDBModel<FSize>().Insert(size3);
            }
            #endregion

            #region Init Category data
            if(DB.GetCollectionDBModel<Category>().FindAll().Any() == false)
            {
                Category cate = new Category();
                cate.ID = 1;
                cate.Code = "S01";
                cate.Name = "Shirt";
                DB.GetCollectionDBModel<Category>().Insert(cate);

                Category cate1 = new Category();
                cate1.ID = 2;
                cate1.Code = "S02";
                cate1.Name = "T-Shirt";
                DB.GetCollectionDBModel<Category>().Insert(cate1);

                Category cate2 = new Category();
                cate2.ID = 3;
                cate2.Code = "J01";
                cate2.Name = "Jacket";
                DB.GetCollectionDBModel<Category>().Insert(cate2);

                Category cate3 = new Category();
                cate3.ID = 4;
                cate3.Code = "J02";
                cate3.Name = "Jeans";
                DB.GetCollectionDBModel<Category>().Insert(cate3);

                Category cate4 = new Category();
                cate4.ID = 5;
                cate4.Code = "P01";
                cate4.Name = "Pants";
                DB.GetCollectionDBModel<Category>().Insert(cate4);
            }
            
            #endregion

            #region Init Product data
            if(DB.GetCollectionDBModel<Product>().FindAll().Any() == false)
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
                product.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product);

                Product product1 = new Product();
                product1.ID = 2;
                product1.CategoryID = 1;
                product1.Code = "SA02";
                product1.Name = "Shirt A02";
                product1.Price = 300000;
                product1.Description = "".RandomString(100);
                product1.IsActive = true;
                product1.SizeID = 1;
                product1.ColorID = 1;
                product1.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product1);

                Product product2 = new Product();
                product2.ID = 3;
                product2.CategoryID = 1;
                product2.Code = "SA03";
                product2.Name = "Shirt A03";
                product2.Price = 350000;
                product2.Description = "".RandomString(100);
                product2.IsActive = true;
                product2.SizeID = 1;
                product2.ColorID = 1;
                product2.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product2);
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
                product3.SizeID = 1;
                product3.ColorID = 1;
                product3.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product3);

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
                product4.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product4);

                Product product5 = new Product();
                product5.ID = 6;
                product5.CategoryID = 2;
                product5.Code = "TSA03";
                product5.Name = "T-Shirt A03";
                product5.Price = 100000;
                product5.Description = "".RandomString(100);
                product5.IsActive = true;
                product5.SizeID = 1;
                product5.ColorID = 1;
                product5.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product5);
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
                product6.SizeID = 1;
                product6.ColorID = 1;
                product6.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product6);

                Product product7 = new Product();
                product7.ID = 8;
                product7.CategoryID = 3;
                product7.Code = "JA02";
                product7.Name = "Jacket A02";
                product7.Price = 600000;
                product7.Description = "".RandomString(100);
                product7.IsActive = true;
                product7.SizeID = 1;
                product7.ColorID = 1;
                product7.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product7);

                Product product8 = new Product();
                product8.ID = 9;
                product8.CategoryID = 3;
                product8.Code = "JA03";
                product8.Name = "Jacket A03";
                product8.Price = 700000;
                product8.Description = "".RandomString(100);
                product8.IsActive = true;
                product8.SizeID = 1;
                product8.ColorID = 1;
                product8.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product8);
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
                product9.SizeID = 1;
                product9.ColorID = 1;
                product9.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product9);

                Product product10 = new Product();
                product10.ID = 11;
                product10.CategoryID = 4;
                product10.Code = "JEA02";
                product10.Name = "Jean A02";
                product10.Price = 3500000;
                product10.Description = "".RandomString(100);
                product10.IsActive = true;
                product10.SizeID = 1;
                product10.ColorID = 1;
                product10.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product10);

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
                product11.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product11);
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
                product12.SizeID = 1;
                product12.ColorID = 1;
                product12.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product12);

                Product product13 = new Product();
                product13.ID = 14;
                product13.CategoryID = 5;
                product13.Code = "PA02";
                product13.Name = "Pant A02";
                product13.Price = 3700000;
                product13.Description = "".RandomString(100);
                product13.IsActive = true;
                product13.SizeID = 1;
                product13.ColorID = 1;
                product13.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product13);

                Product product14 = new Product();
                product14.ID = 15;
                product14.CategoryID = 5;
                product14.Code = "PA03";
                product14.Name = "Pant A03";
                product14.Price = 800000;
                product14.Description = "".RandomString(100);
                product14.IsActive = true;
                product14.SizeID = 1;
                product14.ColorID = 1;
                product14.imageSrc = "";
                DB.GetCollectionDBModel<Product>().Insert(product14);
                #endregion
            }
            #endregion
        }


        public Product Get(int ID)
        {
            return DB.GetCollectionDBModel<Product>().FindOne(a => a.ID == ID);
        }

        public List<Product> List()
        {
            InitDB();
            return DB.GetCollectionDBModel<Product>().FindAll().ToList();
        }

        public bool Insert(Product product)
        {
            return DB.GetCollectionDBModel<Product>().Insert(product);
        }

        public bool Update(Product product)
        {
            return DB.GetCollectionDBModel<Product>().Update(product);
        }

        public int Delete(int ID)
        {
            return DB.GetCollectionDBModel<Product>().DeleteMany(a => a.ID == ID);
        }
    }
}
