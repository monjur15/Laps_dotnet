using Azolution.Entities.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Laps.Mobile.DataService
{
    public class ComputerDataService
    {
        public List<ComputerColor> PopulateColorCombo()
        {
            CommonConnection conn = new CommonConnection();

            try
            {
                conn.BeginTransaction();
                string query = "SELECT * FROM ComputerColors";
                
                return Kendo<ComputerColor>.Combo.DataSource(query);
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
        public List<ComputerBrand> PopulateBrandCombo()
        {
            CommonConnection conn = new CommonConnection();
            try
            {
                conn.BeginTransaction();
                string query = "SELECT * FROM  ComputerBrands";
                return Kendo<ComputerBrand>.Combo.DataSource(query);
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
        public string SaveComputerInfo(ComputerInfo computer)
        {
            string resultMSG = "";
            CommonConnection conn = new CommonConnection();
            try
            {
                conn.BeginTransaction();

                if (computer.ComputerId != 0)
                {
                    string updateQuery = string.Format(@"UPDATE [dbo].[ComputerInfo]
                                   SET [ModelName] = '{0}'
                                      ,[BrandId] = {1}
                                      ,[ColorId] = {2}
                                      ,[price] = {3}
                                      ,[Is5G] = {4}
                                 WHERE ComputerId = {5}",
                             computer.ModelName, computer.BrandId, computer.ColorId, computer.Price, computer.Is5G, computer.ComputerId);
                    conn.ExecuteNonQuery(updateQuery);
                }
                else
                {
                    string saveQuery = string.Format(@"INSERT INTO [dbo].[ComputerInfo]
                                                   ([ModelName]
                                                   ,[BrandId]
                                                   ,[ColorId]
                                                   ,[Price]
                                                   ,[Is5G])
                                             VALUES
                                                   ('{0}'
                                                   ,{1}
                                                   ,{2}
                                                   ,{3}
                                                   ,{4})", computer.ModelName, computer.BrandId, computer.ColorId, computer.Price, computer.Is5G);
                    conn.ExecuteNonQuery(saveQuery);
                }
                

                
                conn.CommitTransaction();
                resultMSG = "Success";
            }
            catch(Exception ex)
            {
                resultMSG = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return resultMSG;
        }

        public GridEntity<ComputerInfo> ComputerInfoGrid(GridOptions options)
        {
            CommonConnection conn = new CommonConnection();

            try
            {
                conn.BeginTransaction();
                //string query = string.Format(@"SELECT * FROM ComputerInfo");

                //return Kendo<ComputerInfo>.Grid.DataSource(options, query, "ComputerId");
                string query = string.Format(@"Select ComputerId, ModelName, ComputerBrands.BrandId, ComputerColors.ColorId, Price, Brand, Color,
                                                case when Is5G = 1 then 'Yes' else 'No' end as Is5G
                                                from ComputerInfo
                                                left join ComputerBrands on ComputerBrands.BrandId = ComputerInfo.BrandId
                                                left join ComputerColors on ComputerColors.ColorId = ComputerInfo.ColorId");

                return Kendo<ComputerInfo>.Grid.DataSource(options, query, "ComputerId");
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public string DeleteComputerInfo(int id)
        {
            CommonConnection conn = new CommonConnection();
            var ResultMsg = "";
            var DeleteQuery = "";
            try
            {
                DeleteQuery = string.Format(@"DELETE FROM ComputerInfo WHERE ComputerId = {0}", id);
                conn.ExecuteNonQuery(DeleteQuery);
                ResultMsg = Operation.Success.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return ResultMsg;
        }

        public List<ComputerBrandandColorMaping> ComputerBrandandColorMaping()
        {
            CommonConnection conn = new CommonConnection();
            try
            {
                conn.BeginTransaction();
                string query = "SELECT * FROM  ComputerBrandsandColors";
                return Kendo<ComputerBrandandColorMaping>.Combo.DataSource(query);
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
    }
}

