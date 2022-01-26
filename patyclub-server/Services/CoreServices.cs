using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace patyclub_server.Service
{
    public class CoreService {
        public bool isDate(string date)
        {
            try
            {
                Convert.ToDateTime(date);
                return true;
            }
            catch
            {
                return false;
            }
            // return Regex.Match(date, "[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{2}:[0-9]{2}:[0-9]{2}").Success;
        }
    }
}