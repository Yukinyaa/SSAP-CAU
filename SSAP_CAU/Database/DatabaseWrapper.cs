using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SSAP_CAU.Database
{
    public class DatabaseWrapper
    {
        const string strConn = "Server=db;Port=3306;Database=;Uid=ssapcau;Pwd=2019caucse;";
        public const string strCreatePinTable =
@"create table pin (
    pinID   INT         AUTO_INCREMENT, 
    coord   CHAR(30)    NOT NULL,
    reportcnt INT       NOT NULL,
    title   CHAR(30)    NOT NULL,
    type    INT         NOT NULL,
    content TEXT(65535),
    writer CHAR(100),
    password CHAR(30),
    startdate DATETIME,
    enddate DATETIME,
    PRIMARY KEY (pinID)
)";

        public const string strCreateAdminTable =
@"create table admin (
    adminID CHAR(30),
    adminPW CHAR(30),

    PRIMARY KEY (adminID)
)";
        public const string strCreateReplyTable =
@"create table reply (
    commentID   INT     AUTO_INCREMENT,
    pinID   INT,
    writer CHAR(100),
    password CHAR(30),
    content TEXT(65535),

    PRIMARY KEY (commentID),
    FOREIGN KEY (pinID) REFERENCES pins(pinID)
)";
        static public int SendNonQuery(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                return cmd.ExecuteNonQuery();
            }
        }
        static public DataSet SendQuery(string sql)
        {
            DataSet ds = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                adpt.Fill(ds, "Tab1");
            }
            //ds.Tables[0].Rows[0]["Name"];
            return ds;
        }
        static public bool TestOpen()
        {
            MySqlConnection conn = new MySqlConnection(strConn);
            try
            {
                conn.Open();
                conn.Close();
            }
            catch (MySqlException e)
            {
                return false;
            }
            return true;
        }
    }
}