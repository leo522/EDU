using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;

namespace KMU.EduActivity.ApplicationLayer.Utility
{
    public class OracleConnectionUtils
    {
        private static OracleConnection _conn;

        public static OracleConnection Conn
        {
            get
            {
                if (_conn == null)
                {
                    
                    ApConnService.GetDBConnMethodClient service = new  ApConnService.GetDBConnMethodClient();

                    _conn = new OracleConnection(service.GetDBConnectionWithHospCode("KMUH", "ora92", "AppStart_dsIPD").ConnectionString);
                    _conn.Open();
                }

                return _conn;
            }
        }

        public static void ExecuteProcedure(string cmd, OracleParameterCollection parms)
        {
            try
            {
                OracleCommand ocm = new OracleCommand(cmd, Conn);
                ocm.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (OracleParameter parm in parms)
                {
                    OracleParameter p = new OracleParameter();
                    p.ParameterName = parm.ParameterName;
                    p.Value = parm.Value;
                    p.DbType = parm.DbType;
                    p.Direction = parm.Direction;
                    p.Size = parm.Size;
                    ocm.Parameters.Add(p);
                }

                ocm.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
        }


    }
}
