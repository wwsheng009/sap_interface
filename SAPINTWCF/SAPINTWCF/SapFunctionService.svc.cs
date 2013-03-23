using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SAPINT;
using SAPINT.Function.Json;
using SAP.Middleware.Connector;
using System.ServiceModel.Activation;

namespace SAPINTWCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“SapFunctionService1”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SapFunctionService : ISapFunctionService
    {
        public string ReadSAPTable(string systemName, string table)
        {
            SAPINT.Utils.ReadTable readTable = new SAPINT.Utils.ReadTable(systemName);
            readTable.TableName = table;
            readTable.RowCount = 100;
            readTable.SetCustomFunctionName("Z_XTRACT_IS_TABLE");
            readTable.Run();
          //RfcDestination destination =  RfcDestinationManager.GetDestination("RET");
        //  RfcDestinationManager manage =  RfcDestinationManager.g;
            //return "";
            return SAPFunctionJson2.convertDataTableToJson(readTable.Result);
        }
    }
}
