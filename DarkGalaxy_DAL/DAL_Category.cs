using DarkGalaxy_Model;
using System.Data;
using System.Data.SqlClient;

namespace DarkGalaxy_DAL
{
    /// <summary>
    /// 表Category的DAL层
    /// </summary>
    public class DAL_Category : BaseDAL<int, Category>
    {
        /// <summary>
        /// 删除分类主键对应的全部子分类记录，返回删除是否成功
        /// </summary>
        /// <param name="ID">分类主键</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteChildIntoCategory(int ID)
        {
            //处理错误参数
            if (0 >= ID)
            {
                return false;
            }
            else { }

            bool result = false;

            //删除分类主键对应的全部子分类记录
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