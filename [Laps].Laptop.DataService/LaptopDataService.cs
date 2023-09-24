using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Azolution.Entities.Sale;
using Utilities;

namespace Laps.Laptop.DataService
{
    public class LaptopDataService
    {
        public List<LaptopColor> PopulateColorCombo()
        {
            CommonConnection conn = new CommonConnection();

            try
            {
                conn.BeginTransaction();
                string query = "SELECT * FROM ColorsLaptop";

                return Kendo<LaptopColor>.Combo.DataSource(query);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<LaptopBrand> PopulateBrandCombo()
        {
            CommonConnection conn = new CommonConnection();
            try
            {
                conn.BeginTransaction();
                string query = "SELECT * FROM  BrandsLaptop";
                return Kendo<LaptopBrand>.Combo.DataSource(query);
            }
            catch (Exception)
            {
                return null;
            }

            finally
            {
                conn.Close();
            }
        }

        public string SaveLaptopInfo(LaptopInfo laptop)
        {
            string resultMSG = "";
            CommonConnection conn = new CommonConnection();
            try
            {
                conn.BeginTransaction();

                if (laptop.LaptopId != 0)
                {
                    string updateQuery = string.Format(@"UPDATE [dbo].[LaptopInformation]
                                   SET [ModelName] = '{0}'
                                      ,[BrandId] = {1}
                                      ,[ColorId] = {2}
                                      ,[price] = {3}
                                      ,[IsW] = {4}
                                      ,[IsActive] = {5}
                                 WHERE LaptopId = {6}",
                             laptop.ModelName, laptop.BrandId, laptop.ColorId, laptop.Price, laptop.IsW, laptop.IsActive, laptop.LaptopId);
                    conn.ExecuteNonQuery(updateQuery);
                }
                else
                {
                    string saveQuery = string.Format(@"INSERT INTO [dbo].[LaptopInformation]
                                                   ([ModelName]
                                                   ,[BrandId]
                                                   ,[ColorId]
                                                   ,[Price]
                                                   ,[IsW]
                                                   ,[IsActive])
                                             VALUES
                                                   ('{0}'
                                                   ,{1}
                                                   ,{2}
                                                   ,{3}
                                                   ,{4}
                                                   ,{5})", laptop.ModelName, laptop.BrandId, laptop.ColorId, laptop.Price, laptop.IsW, laptop.IsActive);
                    conn.ExecuteNonQuery(saveQuery);
                }
              



                conn.CommitTransaction();
                resultMSG = "Success";
            }
            catch (Exception ex)
            {
                resultMSG = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return resultMSG;
        }

     


        public GridEntity<LaptopInfo> LaptopInfoGrid(GridOptions options)
        {
            CommonConnection conn = new CommonConnection();

            try
            {
                conn.BeginTransaction();
                string query = string.Format(@"SELECT * FROM LaptopInformation");

                return Kendo<LaptopInfo>.Grid.DataSource(options, query, "LaptopId");
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }




    }
}