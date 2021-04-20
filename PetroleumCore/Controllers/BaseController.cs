using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetroleumModel.Dtos;


namespace PetroleumCore.Controllers
{
   
    public class BaseController : Controller
    {
        public ResponseInfo responseInfo = new ResponseInfo();
        public BaseController()
        {
            int ts = 55;
            int ts1 = 55;
            int ts2 = 55;
            int ts3 = 55;
        }

        /// <summary>
        /// 重新 OnActionExecuted  全局过滤器   controller 要继承  Controller
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}