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
            if (A.Equals("") || A == null)
            {
                return true;
            }
            return false;
        }

        public PaginationAttr getPageAttr(int totalRownum, int rownumPerPage, int requestPageNum){
            // total   = 16, 2
            // perPage = 4 , 10
            // maxPage = 4 , 1
            
            // reqPage = -1 1 2 3  4  5
            // skip    =  0 0 4 8 12 12
            // getRow  =  4 4 4 4  4  4
            int skipRownum;
            int maxPageNum = (rownumPerPage!=0?(totalRownum / rownumPerPage) + (totalRownum%rownumPerPage!=0 ? 1:0):1);
            int currentPageNum;

            if(requestPageNum > maxPageNum){
                skipRownum = rownumPerPage * (maxPageNum-1);
                currentPageNum = maxPageNum;
            }
            else if (requestPageNum < 0){
                skipRownum = 0;
                currentPageNum = 1;
            }
            else{
                skipRownum = rownumPerPage * (requestPageNum-1);
                currentPageNum = requestPageNum;
            }

            return new PaginationAttr{
                skipRownum = skipRownum, 
                rownumPerPage = rownumPerPage, 
                maxPageNum = maxPageNum,
                currentPageNum = currentPageNum,
                totalRownum = totalRownum
                };
        }
    }
}