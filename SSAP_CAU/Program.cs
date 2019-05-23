using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SSAP_CAU.Database;

namespace SSAP_CAU
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            while (!DatabaseWrapper.TestOpen())
            {
                System.Threading.Thread.Sleep(1000);Console.WriteLine("Waiting For DB...");
            }
            
            if (DatabaseWrapper.SendQuery("show tables like \"pin\"").Tables[0].Rows.Count == 0)
                DatabaseWrapper.SendNonQuery(DatabaseWrapper.strCreatePinTable);

            if (DatabaseWrapper.SendQuery("show tables like \"admin\"").Tables[0].Rows.Count == 0)
                DatabaseWrapper.SendNonQuery(DatabaseWrapper.strCreateAdminTable);

            if (DatabaseWrapper.SendQuery("show tables like \"reply\"").Tables[0].Rows.Count == 0)
                DatabaseWrapper.SendNonQuery(DatabaseWrapper.strCreateReplyTable);
            //*/
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
