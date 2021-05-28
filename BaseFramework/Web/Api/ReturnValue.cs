using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Web.Api
{

    public class ReturnValue<T>
    {


        /// <summary>
        /// 错误详细消息
        /// </summary>
        public string ErrorDetailed { set; get; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorSimple { set; get; }

        public T Value { set; get; }
        public bool Status { set; get; }

        /// <summary>
        /// 正确
        /// </summary>
        /// <param name="_Value"></param>
        public void True(T value)
        {
            Status = true;
            Value = value;
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="_ErrorSimple">简单说明</param>
        /// <param name="_ErrorDetailed">详细说明（一般异常用）</param>
        public void False(string errorSimple = "", string errorDetailed = "")
        {
            Status = false;
            ErrorSimple = errorSimple;
            ErrorDetailed = errorDetailed;
            if (ErrorDetailed.Length == 0)
            {
                ErrorDetailed = ErrorSimple;
            }
        }

    }
}
