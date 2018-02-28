using DarkGalaxy_Model;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表Navigation的DAL层
    /// </summary>
    public class DAL_Navigation : BaseDAL<int, Navigation>
    {
        /// <summary>
        /// 删除导航主键对应的全部子导航记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">导航主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteChildIntoNavigation(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除导航主键对应的全部子导航记录
            string Where = "IDPath like @DAL_ID and Enabled = 1";
            SqlParameter[] Parameters =
            {
                new SqlParameter("DAL_ID","%/" + ID + "/%"){ DbType = DbType.String }
            };
            result = DeleteIntoTable(Where, Parameters);

            return result;
        }
    }
}
