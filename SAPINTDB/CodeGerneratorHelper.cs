using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPINTDB
{
    public class CodeGerneratorHelper
    {
        private netlib7 db2 = null;

        public CodeGerneratorHelper()
        {
            String defaultConnection = ConfigFileTool.SAPGlobalSettings.GetSettingsFromDb();
            db2 = new netlib7(defaultConnection);

        }
        public CodeGerneratorHelper(String dbConnectionName)
        {
            db2 = new netlib7(dbConnectionName);
        }

        public DataTable GetAlvSettings()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db2.DataTableFill("Select * from alv_settings");
            }
            catch (Exception)
            {
                throw;
                // throw new Exception(exception.Message);
            }

            return dt;
        }

        public bool UpdateAlvSettings(DataTable dt)
        {

            try
            {
                return db2.DataTableUpdate(dt, "select * from alv_settings");

            }
            catch (Exception)
            {
                throw;
                // throw new Exception(exception.Message);
            }

        }

    }
}
