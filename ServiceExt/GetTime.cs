using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceExt
{
    public class GetTime
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            string ss = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000).ToString();
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <returns></returns>
        public static string GetRandom()
        {
            string random = string.Empty;
            for (int i = 0; i < 2; i++)
            {
                Random rd = new Random();
                random += rd.Next(1, 99).ToString();
            }
            return random;
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static string GetTimeAll()
        {
            string time = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.DayOfYear.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            return time;
        }
    }
}
