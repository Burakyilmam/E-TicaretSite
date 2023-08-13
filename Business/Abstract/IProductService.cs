﻿using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        void ProductAdd(Product product);
        void ProductDelete(Product product);
        void ProductUpdate(Product product);
        Product GetProduct(int id);
        List<Product> ListProduct(); 
        List<Product> ListNewProduct();
        List<Product> ListHighPriceProduct();
        List<Product> ListLowPriceProduct();
        List<Product> ListProductWith();
        List<Product> ListLowStockProduct();
        List<Product> ListHighStockProduct();
        List<Product> ListCategoryProduct(int id);
        List<Product> ListBrandProduct(int id);
        List<Product> ProductPage(int id);
        List<Product> ListElectronicProducts();

    }
}
