using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace patyclub_server.Core.Service
{
    public class CoreService {
        public bool isDate(string date)
        {
            try
            {
                if (isNullOrEmpty(date))
                    return true;
                Convert.ToDateTime(date);
                return true;
            }
            catch
            {
                return false;
            }
            // return Regex.Match(date, "[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{2}:[0-9]{2}:[0-9]{2}").Success;
        }

        public bool isNullOrEmpty(object A){
            if (A == "" || A == null)
            {
                return true;
            }
            return false;
        }

        public PaginationAttr getPageAttr(int totalRownum, int rownumPerPage, int requestPageNum){
            return new PaginationAttr{
                skipRownum = rownumPerPage * requestPageNum, 
                rownumPerPage = rownumPerPage, 
                maxPageNum = totalRownum / rownumPerPage,
                currentPageNum = requestPageNum
                };
        }
    }
}