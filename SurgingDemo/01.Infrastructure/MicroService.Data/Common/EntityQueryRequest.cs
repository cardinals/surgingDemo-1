using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Data.Common
{
    public class EntityQueryRequest
    {
        /// <summary>
        /// 实体Id
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        public IList<string> Ids { set; get; }

        /// <summary>
        /// 所属公司Id
        /// </summary>
        public Guid CompanyId
        {
            get;
            set;
        }

        /// <summary>
        /// 登录人Id
        /// </summary>
        public Guid UserId
        {
            get;
            set;
        }

        /// <summary>
        /// 登录人姓名
        /// </summary>
        public string UserName
        {
            get;
            set;
        }


    }
}
