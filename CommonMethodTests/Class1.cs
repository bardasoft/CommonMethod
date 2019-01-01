using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMethodTests
{
    class Class1
    {
    }
    ///<summary>
    ///指纹信息表
    ///</summary>
    public partial class T_Fingerprint
    {
        public T_Fingerprint()
        {


        }
        /// <summary>
        /// Desc:Id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int fp_id { get; set; }

        /// <summary>
        /// Desc:用户id
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int user_id { get; set; }

        /// <summary>
        /// Desc:用户id 数据源	1.表示操作员表
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public int user_source { get; set; }

        /// <summary>
        /// Desc:指纹特征码（指纹仪上传）
        /// Default:
        /// Nullable:False
        /// </summary>           
        public byte[] fp_content { get; set; }

        /// <summary>
        /// Desc:指纹类别
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public int fp_type { get; set; }

        /// <summary>
        /// Desc:使能?
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public bool fp_enable { get; set; }

        /// <summary>
        /// Desc:添加时间
        /// Default:DateTime.Now
        /// Nullable:False
        /// </summary>           
        public DateTime fp_inserttime { get; set; }

        /// <summary>
        /// Desc:更新时间
        /// Default:DateTime.Now
        /// Nullable:False
        /// </summary>           
        public DateTime fp_updatetime { get; set; }

        /// <summary>
        /// Desc:备注信息
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string fp_remark { get; set; }

        /// <summary>
        /// Desc:备用1
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string fp_remark1 { get; set; }

        /// <summary>
        /// Desc:备用2
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string fp_remark2 { get; set; }

        /// <summary>
        /// Desc:备用3
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string fp_remark3 { get; set; }

    }
}
