﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TvApi_Lab.DAL;

namespace TvApi_Lab
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TvApiContext,Migrations.Configuration>());
        }
    }
}
