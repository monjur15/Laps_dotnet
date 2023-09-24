﻿using Azolution.Entities.HumanResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Azolution.HumanResource.DataService.DataService
{
    public class PersonalDetailsDataService
    {

        public string SavePersonDetails(PersonalDetails objPerson)
        {

            string rv = "";
            string sql = "";
            CommonConnection connection = new CommonConnection();
            try
            {
                if (objPerson.PersonalDetailsId == 0)
                {
                    sql = string.Format(
                   @"INSERT INTO PersonalDetails (FirstName,LastName,FatherName,MotherName,DateOfBirth,Gender,Maritalstatus,NationalIdNo,
Religion,Mobile,Address)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", objPerson.FirstName, objPerson.LastName,
                                                                                        objPerson.FatherName, objPerson.MotherName,
                                                                                        objPerson.DateOfBirth,
                                                                      objPerson.Gender, objPerson.Maritalstatus, objPerson.NationalIdNo,
                                                                      objPerson.Religion, objPerson.Mobile, objPerson.Address);
                }
                else 
                {
                    sql = string.Format(@"Update PersonalDetails Set FirstName='{0}',LastName='{1}',FatherName='{2}',
MotherName='{3}',DateOfBirth='{4}',Gender='{5}',Maritalstatus='{6}',NationalIdNo='{7}',Religion='{8}',Mobile='{9}',Address='{10}' Where PersonalDetailsId='{11}'", objPerson.FirstName, objPerson.LastName, objPerson.FatherName, objPerson.MotherName, objPerson.DateOfBirth, objPerson.Gender, objPerson.Maritalstatus, objPerson.NationalIdNo, objPerson.Religion, objPerson.Mobile, objPerson.Address, objPerson.PersonalDetailsId);


                }


                
                  


                connection.ExecuteNonQuery(sql);

                
                    

                rv = Operation.Success.ToString();
            }
            catch (Exception exception)
            {

                return exception.Message;
            }
            finally
            {
                connection.Close();
            }
            return rv;

        }


        public string DeletePersonalInfo(PersonalDetails objPerson)
        {
            string rv = "";
            string sql = "";
            CommonConnection connection = new CommonConnection();
            try
            {
                sql = string.Format(@"Delete from PersonalDetails Where PersonalDetailsId='{0}'",objPerson.PersonalDetailsId);

                connection.ExecuteNonQuery(sql);
                rv = Operation.Success.ToString();
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

            return rv;
        }




      
        public GridEntity<PersonalDetails> GetPersonalSummary(GridOptions options)
        {

            string query =
                string.Format(
                    @"Select PersonalDetailsId, PersonalDetails.FirstName,PersonalDetails.LastName, PersonalDetails.FatherName,PersonalDetails.MotherName,
PersonalDetails.DateOfBirth,PersonalDetails.Gender,PersonalDetails.Maritalstatus,PersonalDetails.NationalIdNo,PersonalDetails.Religion,PersonalDetails.Mobile,
PersonalDetails.Address,CASE
    WHEN PersonalDetails.Gender=1 THEN 'Male' WHEN PersonalDetails.Gender=2 THEN 'Female'ELSE 'Other' END As GenderName, CASE
    WHEN PersonalDetails.Religion=1 THEN 'Islam'
    WHEN PersonalDetails.Religion=2 THEN 'Hinduism'
	WHEN PersonalDetails.Religion=3 THEN 'Christianity'
    WHEN PersonalDetails.Religion=4 THEN 'Budhism'ELSE 'Others' END As ReligionName, CASE
    WHEN PersonalDetails.Maritalstatus= 1 THEN 'Married'ELSE 'Unmarried' End As MaritalStatusName
	From PersonalDetails ");
            return Kendo<PersonalDetails>.Grid.DataSource(options, query, "PersonalDetailsId");

        }

       
    }
};
        
               

    

