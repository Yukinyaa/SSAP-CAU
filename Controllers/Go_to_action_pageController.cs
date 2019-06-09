using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SSAP_CAU.Controllers
{
    public class Go_to_action_pageController : Controller
    {
        public IActionResult Index(RegisterViewModel register)
        {
            
            DatabaseWrapper.SendNonQuery
            (
                "INSERT INTO `SSAPCAU`.`pin` (`coordlat`, `coording`, `reportcnt`, `title`, `type`, `addr`, `content`, `writer`, `password`)  VALUES (" +
                2525 + "," +//coordlat   FLOAT    NOT NULL,
                2525 + "," +//coording   FLOAT    NOT NULL,
                0 + "," +//reportcnt INT       NOT NULL,
                register.inputTitle + "," +//title   CHAR(30)    NOT NULL,
                1 + "," +//type    INT         NOT NULL,
                register.inputAddress + "," +//addr TEXT(65535),
                register.inputcontext + "," +//content TEXT(65535),
                register.inputName + "," +//writer CHAR(100),        
                register.inputPassword +//password CHAR(30)
                ");"
            );

            return new RedirectResult("/");
        }
    }
}