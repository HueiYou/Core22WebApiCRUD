using Core22WebApiCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22WebApiCRUD.Helper
{
    /// <summary>
    /// DB Helper
    /// </summary>
    public class DBHelper
    {
        protected static IConfigurationBuilder builder;
        protected static IConfiguration configuration;
        private static string connectionString;

        public DBHelper()
        {
            builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
            connectionString = configuration.GetConnectionString("MyDB");
            //connectionString = configuration["ConnectionStrings:Dev"];
        }

        /// <summary>
        /// 取得連線字串
        /// </summary>
        /// <returns></returns>
        public static string GetDBConnection()
        {
            // return Helper.CryptographyEx.DecryptString(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ToString(), "KEY......");

            return configuration.GetConnectionString("MyDB").ToString();
        }

        /// <summary>
        /// 取得DbContext
        /// </summary>
        /// <returns></returns>
        public static NorthwindContext CreateDbContext()
        {
            builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
            connectionString = configuration.GetConnectionString("MyDB");

            //設定檔之連線字串應加密
            //var cnStr = configuration["ConnectionStrings:Dev"].ToString();
            //自動偵測，支援加密及未加密的連線字串，測時不加密，上線時再加密
            //在連線字串找到metadata字樣表示為加密字串
            // cnStr = Helper.CryptographyEx.DecryptString(cnStr, "XXXXXXX");

            var ent = new NorthwindContext(new DbContextOptionsBuilder<NorthwindContext>()
                                               .UseSqlServer(connectionString)
                                               .Options);

            return ent;
        }
    }
}
