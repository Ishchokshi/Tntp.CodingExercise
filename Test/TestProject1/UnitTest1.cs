using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson.Serialization.Attributes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TestProject1
{

    
    public class UnitTest1
    {
        //private string firstname;
        //private string lastname;
        //private string birth;
        //private string contribs;
        //private string awards;
        //#region get set prop.............

        //public string Firstname
        //{
        //    get
        //    {
        //        return firstname;
        //    }
        //    set
        //    {
        //        firstname = value;
        //    }
        //}
        //public string Lastname
        //{
        //    get
        //    {
        //        return lastname;
        //    }
        //    set
        //    {
        //        lastname = value;
        //    }
        //}
        //public string Birth
        //{
        //    get
        //    {
        //        return birth;
        //    }
        //    set
        //    {
        //        birth = value;
        //    }
        //}
        //public string Contribs
        //{
        //    get
        //    {
        //        return contribs;
        //    }
        //    set
        //    {
        //        contribs = value;
        //    }
        //}
        //public string Awards
        //{
        //    get
        //    {
        //        return awards;
        //    }
        //    set
        //    {
        //        awards = value;
        //    }
        //}
        //#endregion
        private string ConnString()
        {
            return ConfigurationManager.ConnectionStrings["code"].ConnectionString;
        }



        public void Developer(string firstname, string lastname, string dt)
        {
            SqlConnection sc = new SqlConnection(ConnString());
            String DeveloperQuery = "Insert into Developer(Firstname,Lastname,Birth) values(@firstname,@lastname,@Birth)";
            SqlCommand mycom = new SqlCommand(DeveloperQuery, sc);
            mycom.Parameters.AddWithValue("@firstname", firstname);
            mycom.Parameters.AddWithValue("@lastname", lastname);
            mycom.Parameters.AddWithValue("@Birth", dt);
            sc.Open();
            mycom.ExecuteNonQuery();
            sc.Close();
        }
        public void contrib(string firstname, string lastname, string dt, string Contrib)
        {
            SqlConnection sc = new SqlConnection(ConnString());
            String ContribQuery = "Insert into Contribs(Firstname,Lastname,Birth,Contribs) values(@abc,@Lastname,@Birth,@Contribs)";//,@Contribs
            //SqlCommand mycom1 = new SqlCommand(ContribQuery, sc);
            //mycom1.Parameters.Add(new SqlParameter("@abc", firstname));
            //mycom1.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = lastname;
            //mycom1.Parameters.AddWithValue("@Birth", SqlDbType.VarChar).Value = dt;
            //mycom1.Parameters.AddWithValue("@Contribs", SqlDbType.VarChar).Value = Contrib;
            //mycom1 = new SqlCommand(ContribQuery, sc);
            //sc.Open();
            //mycom1.ExecuteNonQuery();
            //sc.Close();
            //String DeveloperQuery = "Insert into Developer(Firstname,Lastname,Birth) values(@firstname,@lastname,@Birth)";
            SqlCommand mycom = new SqlCommand(ContribQuery, sc);
            mycom.Parameters.AddWithValue("@abc", firstname);
            mycom.Parameters.AddWithValue("@lastname", lastname);
            mycom.Parameters.AddWithValue("@Birth", dt);
            mycom.Parameters.AddWithValue("@Contribs", Contrib);
            sc.Open();
            mycom.ExecuteNonQuery();
            sc.Close();

        }
        public void Awards(string firstname, string lastname, string dt, string Award)
        {
            SqlConnection sc = new SqlConnection(ConnString());
            String AwardsQuery = "Insert into Awards(Firstname,Lastname,Birth,Award)values(@firstname,@lastname,@Birth,@Award)";
            SqlCommand mycom = new SqlCommand(AwardsQuery, sc);
            mycom.Parameters.AddWithValue("@firstname", firstname);
            mycom.Parameters.AddWithValue("@lastname", lastname);
            mycom.Parameters.AddWithValue("@Birth", dt);
            mycom.Parameters.AddWithValue("@Award", Award);
            sc.Open();
            mycom.ExecuteNonQuery();
            sc.Close();
        }
        public int CountDevelopers()
        {
            SqlConnection sc = new SqlConnection(ConnString());
            string Count = "select COUNT(*) from Developer";
            SqlCommand mycom = new SqlCommand(Count, sc);
            sc.Open();
            int number = (int)mycom.ExecuteScalar();
            sc.Close();
            return number;
        }
        public int CountContribs()
        {
            SqlConnection sc = new SqlConnection(ConnString());
            string Count = "select COUNT(*) from Contribs";
            SqlCommand mycom = new SqlCommand(Count, sc);
            sc.Open();
            int number = (int)mycom.ExecuteScalar();
            sc.Close();
            return number;
        }
        public int CountAwards()
        {
            SqlConnection sc = new SqlConnection(ConnString());
            string Count = "select COUNT(*) from Awards";
            SqlCommand mycom = new SqlCommand(Count, sc);
            sc.Open();
            int number = (int)mycom.ExecuteScalar();
            sc.Close();
            return number;
        }

    }
}
