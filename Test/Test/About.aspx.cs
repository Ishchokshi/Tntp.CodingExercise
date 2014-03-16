using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MongoDB.Driver;
using MongoDB.Bson;
using TestProject1;
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System.Globalization;
using System.Collections.Generic;


namespace Test
{
    
    public partial class About: System.Web.UI.Page 
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            this.NewData();
        }
        private void NewData()
        {
            UnitTest1 ut1 = new UnitTest1();
            var con = new MongoConnectionStringBuilder(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
            var server = MongoServer.Create(con);
            var db = server.GetDatabase(con.DatabaseName);
            var collection = db.GetCollection("bios1");
            BsonValue value ;
            string dt;
            int count = 0;
            foreach (var doc in collection.Find(Query.Exists("_id")))
            {
                
                var firstname = (doc.TryGetValue("name", out value)? doc["name"][0] :"");
                var lastname = (doc.TryGetValue("name", out value)?(doc["name"][1]) : "");
                var birthdate = (doc.TryGetValue("birth", out value)? doc["birth"].ToString():"");
                var death = (doc.TryGetValue("death", out value) ? doc["death"] : DateTime.MinValue.ToString());
                var contribs =   (doc.TryGetValue("contribs", out value) ? doc["contribs"]: "");

                dt = birthdate.ToString();
                /*Store data into Developer's table*/
                ut1.Developer(firstname.ToString().Trim(), lastname.ToString().Trim(), dt);
                /*Store Data into Contrib's table*/
                ut1.contrib(firstname.ToString().Trim(), lastname.ToString().Trim(), dt, contribs.ToString().Trim());
                if (doc.TryGetValue("awards", out value))
                {
                    for (int j = 0; j < doc["awards"].AsBsonArray.Count; j++)
                    {
                        var awards = (doc.TryGetValue("awards", out value) ? doc["awards"][j][0] : "");
                        /*To store data into awards table*/
                        ut1.Awards(firstname.ToString().Trim(), lastname.ToString().Trim(), dt, awards.ToString().Trim());
                    }
                }
                count++;
            }
            this.ID.Text = count.ToString();
            this.TextBox.Text = ut1.CountDevelopers().ToString();
            this.TextBox1.Text = ut1.CountContribs().ToString();
            this.TextBox2.Text = ut1.CountAwards().ToString();

        }

                protected void Button_OnClick(object sender, System.EventArgs e)
        {
          
        }
       
       
       
    }
}
