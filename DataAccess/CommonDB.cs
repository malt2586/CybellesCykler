﻿using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CommonDB
    {
        // FIELDS
        protected readonly string connectionString;

        // CONSTRUCTORS
        public CommonDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // METHODS
        protected DataSet ExecuteQuery(string query, QueryType qT = QueryType.Query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        con.Open();
                        cmd.ExecuteNonQuery();
                        dataAdapter.Fill(ds);
                        return ds;
                    }
                }
            }
        }

        protected int ExecuteNonQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}