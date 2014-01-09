using System;
using System.Collections.Generic;
using System.Linq;
using Midwhay.Core.Interface;
using Midwhay.Core.Viewport;

namespace Midwhay.Testing
{
    class Model
    {
        public static IViewport Get()
        {
            //Define viewport
            var dimensions = new List<IDimension>();
            var viewport = new LogicalViewport("First viewport");
            var dimProduct = viewport.AddDimension("Product", DimensionClassification.What);
            dimensions.Add(dimProduct);
            dimensions.Add(viewport.AddDimension("Promotion", DimensionClassification.Why));
            var dimCustomer = viewport.AddDimension("Customer", DimensionClassification.Who);
            dimensions.Add(dimCustomer);
            var dimSalesTerritory = viewport.AddDimension("Sales Territory", DimensionClassification.Where);
            dimensions.Add(dimSalesTerritory);
            var dimCurrency = viewport.AddDimension("Currency", DimensionClassification.How);
            dimensions.Add(dimCurrency);
            var dimOrderDate = viewport.AddDimension("Order Date", DimensionClassification.When);
            dimensions.Add(dimOrderDate);
            var factInternetSales = viewport.AddFact("Internet Sales");
            foreach (var dim in dimensions)
                viewport.AddRelation(factInternetSales, dim);

            //Auto-addition of the dimensions
            viewport.AddRelation("Internet Sales", "Ship Date");
            viewport.AddRelation("Internet Sales", "Due Date");

            var dimSalesReason = viewport.AddDimension("Sales Reason", DimensionClassification.Why);
            var factInternetSalesReason = viewport.AddFactlessFact("Internet Sales Reason");
            viewport.AddBridgeRelation(factInternetSales, factInternetSalesReason, dimSalesReason);

            var dimProductSubCategory = viewport.AddDimension("Product SubCategory", DimensionClassification.What);
            var dimProductCategory = viewport.AddDimension("Product Category", DimensionClassification.What);
            viewport.AddSnowflakeRelation(dimProduct, dimProductSubCategory, dimProductCategory);

            var factCurrencyRate = viewport.AddFact("Currrency Rate");
            viewport.AddRelation(factCurrencyRate, dimCurrency);
            viewport.AddRelation(factCurrencyRate, dimOrderDate);

            var dimGeography = viewport.AddDimension("Geography", DimensionClassification.Where);
            viewport.AddOutriggerRelation(dimGeography, dimSalesTerritory);
            viewport.AddSnowflakeRelation(dimSalesTerritory, dimGeography);
            viewport.AddSnowflakeRelation(dimCustomer, dimGeography);

            var dimPriority = viewport.AddDimension("Priority", DimensionClassification.How);
            var dimVolume = viewport.AddDimension("Volume", DimensionClassification.How);
            var dimPackaging = viewport.AddDimension("Packaging", DimensionClassification.How);
            var dimDelivery = viewport.AddDimension("Delivery", DimensionClassification.How);
            viewport.AddJunkRelation(dimDelivery, new List<IDimension>() 
                {
                    dimPriority
                    , dimVolume
                    , dimPackaging
                });
            viewport.AddRelation(factInternetSales, dimDelivery);

            return viewport;
        }
    }
}
