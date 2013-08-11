using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPINT.Utils
{
    public class CTRDIR
    {
        public String name { get; set; } // ABAP Program Name
        public String sqlx { get; set; } // Source code protection
        public String edtx { get; set; } // Editor lock flag
        public String varcl { get; set; } // Case-Sensitive
        public String dbapl { get; set; } // Application database
        public String dbna { get; set; } // Logical database
        public String clas { get; set; } // Program class
        public String type { get; set; } // Selection screen version
        public String occurs { get; set; } // Automatically generated program
        public String subc { get; set; } // Program type
        public String appl { get; set; } // Application
        public String secu { get; set; } // Authorization Group
        public String cnam { get; set; } // Author
        public String cdat { get; set; } // Created on
        public String unam { get; set; } // Last changed by
        public String udat { get; set; } // Changed On
        public String vern { get; set; } // Version number
        public String levl { get; set; } // Level
        public String rstat { get; set; } // Status
        public String rmand { get; set; } // Client
        public String rload { get; set; } // Master Language
        public String fixpt { get; set; } // Fixed point arithmetic
        public String sset { get; set; } // Start only via variant
        public String sdate { get; set; } // Standard selection screen generation: Date
        public String stime { get; set; } // Standard selection screen generation: Time
        public String idate { get; set; } // Selection screen generation: Date
        public String itime { get; set; } // Selection screen generation: Time
        public String ldbname { get; set; } // LDB name
        public String uccheck { get; set; } // Flag, if unicode check was performed
    }
    public class CD010SINF
    {
        public String prog { get; set; } // ABAP 程序名
        public String clas { get; set; } // 程序类别
        public String subc { get; set; } //   程序类型
        public String appl { get; set; } // 应用程序
        public String cdat { get; set; } // 创建日期
        public String vern { get; set; } // 版本号
        public String rmand { get; set; } // 集团
        public String rload { get; set; } // 主语言
        public String unam { get; set; } // 最后修改人
        public String udat { get; set; } // 更改日期
        public String utime { get; set; } // 字典: 最后修改时间
        public Int32 datalg { get; set; } // ABAP/4： 程序组件的长度
        public String varcl { get; set; } // 区分大小写
    }
}
