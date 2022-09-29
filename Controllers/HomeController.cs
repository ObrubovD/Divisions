using Divisions.Dal.Interfaces;
using Divisions.Dal.Models;
using Divisions.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Divisions.ViewModels;
using Divisions.Dal.Dbo;
using Divisions.Dal;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Divisions.Controllers
{
    public class HomeController : Controller
    {
        private IDivisions _divisions;
        private readonly DivisionDbContext dbContext;


        public HomeController(IDivisions divisions)
        {
            _divisions = divisions;
        }
        public  ActionResult Index()
        {
            var divisions = _divisions.AllDivisions;
            return View(divisions);
        }
        public ViewResult Division()
        {
            var divisions = _divisions.AllDivisions;
            return View(divisions);
        }
        public void DataSynchronization()
        {

            Npgsql.NpgsqlConnectionStringBuilder csb = new Npgsql.NpgsqlConnectionStringBuilder();
            csb.Database = "divisions";
            csb.Host = "localhost";
            csb.Port = 5432;
            csb.IntegratedSecurity = true;
            csb.Username = "postgres";
            csb.Password = "12345678";


            using (System.Data.DataTable dt = new System.Data.DataTable())
            {

                dt.TableName = "Divisions";

                using (System.Data.DataSet ds = new System.Data.DataSet("Divisions"))
                {
                    ds.Tables.Add(dt);
                    

                    using (System.Data.Common.DbConnection con = Npgsql.NpgsqlFactory.Instance.CreateConnection())
                    {
                        con.ConnectionString = csb.ConnectionString;

                        using (System.Data.Common.DbCommand cmd = con.CreateCommand())
                        {
                            cmd.CommandText = "SELECT * FROM public.\"Divisions\"";

                            using (System.Data.Common.DbDataAdapter da = Npgsql.NpgsqlFactory.Instance.CreateDataAdapter())
                            {
                                da.SelectCommand = cmd;

                                if (con.State != System.Data.ConnectionState.Open)
                                    con.Open();

                                da.Fill(dt);

                              
                                
                                if (con.State != System.Data.ConnectionState.Open)
                                    con.Close();
                            } // End Using da 

                        } // End Using cmd 

                    } // End Using con 


                    //using (System.IO.Stream fs = System.IO.File.OpenWrite(@"D:\geoip_blocks_temp.xml"))
                    //{
                    //    using (System.IO.TextWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8))
                    //    {
                    //        // System.IO.StringWriter sw = new System.IO.StringWriter();
                    //        // dt.WriteXml(sw, System.Data.XmlWriteMode.IgnoreSchema);
                    //        dt.WriteXml(sw, System.Data.XmlWriteMode.IgnoreSchema);
                    //    } // End Using sw 

                    //} // End Using fs 


                    System.Xml.XmlWriterSettings xs = new System.Xml.XmlWriterSettings();
                    xs.Indent = true;
                    xs.IndentChars = "    ";
                    xs.NewLineChars = System.Environment.NewLine;
                    xs.OmitXmlDeclaration = false;
                    // xs.Encoding = System.Text.Encoding.UTF8; // doesn't work with pgsql 
                    xs.Encoding = new System.Text.UTF8Encoding(false);

                    // <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                    using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(@"C:\Новая папка (2)\Divisions.xml", xs))
                    {
                        dt.WriteXml(writer, System.Data.XmlWriteMode.IgnoreSchema);
                    }

                    System.Console.WriteLine(dt.Rows.Count);
                } // End Using ds 

            } // End Using dt 

            

        } // End Sub DataToXML 

        

    }
}
