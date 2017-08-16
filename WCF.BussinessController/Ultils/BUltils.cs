using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIC.CONTROLLERS.Ultils
{
    public class BUltils
    {
        /*
             * Create by: Doannv
             * Date: 11/11/2009
             * Description: Base executed Database
             * Modify Date:
             * Description: 
             */

            private SqlConnection m_objConnection;
            private SqlCommand m_objCommand;
            private SqlDataAdapter m_objAdapter;
            private SqlDataReader m_objReader;
            private SqlParameter m_objParam;
            private DataTable m_objTable;

            /// <summary>
            /// Contructors
            /// </summary>
            public BUltils(SqlConnection objConnection)
            {
                m_objConnection = objConnection;
            }

            public BUltils() { }

            public BUltils(string connectString)
            {
                SqlDataAdapter obj = new SqlDataAdapter();                
                m_objConnection = new SqlConnection();
                if (m_objConnection.State == ConnectionState.Closed)
                {
                    OpenConnection(connectString);
                }
            }

            #region "OpenConnections"

            //Pthuc Mở kết nối
            private bool OpenConnection(string connectString)
            {
                //1. Khởi tạo đối tượng kết nối
                m_objConnection = new SqlConnection(connectString);

                try
                {
                    //2. Mở kết nối
                    m_objConnection.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                return true;
            }

            #endregion

            #region "1. Get Datatable"
            /// <summary>
            /// Get Datatable
            /// </summary>
            /// <param name="strQuery">Chuoi truy van</param>
            /// <returns></returns>
            public DataTable GetDataTables(string strQuery)
            {
                m_objTable = new DataTable();
                try
                {
                    m_objCommand = new SqlCommand(strQuery, m_objConnection);
                    m_objAdapter = new SqlDataAdapter(m_objCommand);
                    m_objAdapter.Fill(m_objTable);
                    m_objAdapter.Dispose();  //Giai phong
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                return m_objTable;
            }
            #endregion

            #region "2. Create Parammeter"
            /// <summary>
            /// Create Parammeter
            /// </summary>
            /// <param name="strParammeter">Tên tham số</param>
            /// <param name="oSqlDbType">Kiểu giá trị của than số</param>
            /// <param name="oParameterValue">Giá trị của tham số</param>
            /// <returns></returns>
            public SqlParameter CreateParammeter(string strParammeter, SqlDbType oSqlDbType, object oParameterValue)
            {
                try
                {
                    m_objParam = new SqlParameter();
                    m_objParam.ParameterName = strParammeter;
                    m_objParam.SqlDbType = oSqlDbType;
                    m_objParam.SqlValue = oParameterValue;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                return m_objParam;
            }

            /// <summary>
            /// Create Parammeter
            /// </summary>
            /// <param name="strParammeter"></param>
            /// <param name="oParameterValue"></param>
            /// <returns></returns>
            public SqlParameter CreateParammeter(string strParammeter, object oParameterValue)
            {
                try
                {
                    m_objParam = new SqlParameter();
                    m_objParam.ParameterName = strParammeter;
                    m_objParam.SqlValue = oParameterValue;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                return m_objParam;
            }

            #endregion

            #region "3. ExecutedStoreProc return objDbSetEn"            
            /// <summary>
            /// Executed StoreProc return DataTable
            /// </summary>
            /// <param name="strStoreProcName">Tên thủ tục</param>
            /// <param name="oParam">Mảng tập hợp các tham số đầu vào của thủ tục hiện tại</param>
            /// <returns></returns>
            public DataTable ExecProcReturnTable(string strStoreProcName, SqlParameter[] oParam)
            {
                DataTable objTable = new DataTable();
                try
                {
                    m_objCommand = new SqlCommand(strStoreProcName, m_objConnection);
                    m_objCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < oParam.Length; i++)
                    {
                        m_objCommand.Parameters.Add(oParam[i]);
                    }
                    m_objAdapter = new SqlDataAdapter(m_objCommand);
                    m_objAdapter.Fill(objTable);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                return objTable;
            }

            /// <summary>
            /// ExecutedStoreProc return DataTable
            /// </summary>
            /// <param name="strQuery">Chuỗi truy vấn CSDL</param>
            /// <returns></returns>
            public DataTable ExecProcReturnTable(string strQuery)
            {
                m_objTable = new DataTable();
                try
                {
                    m_objCommand = new SqlCommand(strQuery, m_objConnection);
                    m_objAdapter = new SqlDataAdapter(m_objCommand);
                    m_objAdapter.Fill(m_objTable);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                return m_objTable;
            }
            #endregion

            #region "4. Executed StoreProc use Insert - Update - Delete"
            /// <summary>
            /// Executed StoreProc use Insert - Update - Delete
            /// </summary>
            /// <param name="strParameterName">Tên thủ tục</param>
            /// <param name="oParam">Mảng tập hợp tham số đầu vào</param>
            public void ExecProcNoReturn(string strParameterName, SqlParameter[] oParam)
            {
                try
                {
                    m_objCommand = new SqlCommand(strParameterName, m_objConnection);
                    m_objCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < oParam.Length; i++)
                    {
                        m_objCommand.Parameters.Add(oParam[i]);
                    }
                    m_objCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }

            /// <summary>
            /// Executed StoreProc use Insert - Update - Delete
            /// </summary>
            /// <param name="strQuery"></param>
            public void ExecProcNoReturn(string strQuery)
            {
                try
                {
                    m_objCommand = new SqlCommand(strQuery, m_objConnection);
                    m_objCommand.CommandType = CommandType.Text;  //Default               
                    m_objCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }
            #endregion

            #region "5. ExecuteScalar use return one value"
            /// <summary>
            /// ExecuteScalar use return one value object
            /// </summary>
            /// <param name="strStorePoc">Tên thủ tục</param>
            /// <returns></returns>
            public object ExecuteScalarObject(string strStorePoc)
            {
                object objValue = null;
                try
                {
                    m_objCommand = new SqlCommand(strStorePoc, m_objConnection);
                    m_objCommand.CommandType = CommandType.StoredProcedure;
                    objValue = m_objCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                return objValue;
            }

            /// <summary>
            /// ExecuteScalarInt use return one value integer
            /// </summary>
            /// <param name="strStorePoc"></param>
            /// <returns></returns>
            public int ExecuteScalarInt(string strStorePoc)
            {
                int objValue = 0;
                try
                {
                    m_objCommand = new SqlCommand(strStorePoc, m_objConnection);
                    m_objCommand.CommandType = CommandType.StoredProcedure;
                    objValue = (int)m_objCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                return objValue;
            }
            #endregion

            #region "6. Get DataRow"
            /// <summary>
            /// Get DataRow
            /// </summary>
            /// <param name="strStoreProc">Tên thủ tục</param>
            /// <param name="oParam">Mảng tập hợp tham sồ vaod</param>
            /// <returns></returns>
            public int GetRowsCount(string strStoreProc, SqlParameter[] oParam)
            {
                int iNumber = 0;
                try
                {
                    m_objCommand = new SqlCommand(strStoreProc, m_objConnection);
                    m_objCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < oParam.Length; i++)
                    {
                        m_objCommand.Parameters.Add(oParam[i]);
                    }
                    iNumber = (int)m_objCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                return iNumber;
            }
            #endregion

            #region "7.Check Exist DataRow"
            /// <summary>
            /// Check Exist DataRow
            /// </summary>
            /// <param name="strStoreProc"></param>
            /// <param name="oParam"></param>
            /// <returns></returns>
            public bool CheckExistRow(string strStoreProc, SqlParameter[] oParam)
            {
                try
                {
                    m_objCommand = new SqlCommand(strStoreProc, m_objConnection);
                    m_objCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < oParam.Length; i++)
                    {
                        m_objCommand.Parameters.Add(oParam[i]);
                    }
                    m_objReader = m_objCommand.ExecuteReader();
                    if (m_objReader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }
            #endregion

            #region "8. Get DataTable Into Dataset"

            /// <summary>
            /// Get DataTable Into Dataset
            /// </summary>
            /// <param name="strStoreProc">Tên thủ tục</param>
            /// <param name="oParam">Mảng tham số đầu vào</param>
            /// <param name="strTableName">Tên bảng trên Dataset</param>
            /// <returns></returns>
            public DataSet GetDataTableToDataset(string strStoreProc, SqlParameter[] oParam, string strTableName)
            {
                DataSet Entities = new DataSet();
                try
                {
                    m_objCommand = new SqlCommand(strStoreProc, m_objConnection);
                    m_objCommand.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < oParam.Length; i++)
                    {
                        m_objCommand.Parameters.Add(oParam[i]);
                    }
                    m_objAdapter = new SqlDataAdapter(m_objCommand);
                    m_objAdapter.Fill(Entities, strTableName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
                return Entities;
            }
            #endregion
    }
}
