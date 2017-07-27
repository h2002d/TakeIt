using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeIt.Models;

namespace TakeIt.DAO
{
    class PostDAO
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["TakeItConnectionString"].ConnectionString;

        public static List<Post> getPosts(string fromCountryid, string fromStateId,string fromCityId ,
                                                    string toCountryid, string toStateId, string toCityId,string fromDate,string toDate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetPosts", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.Text;
                        StringBuilder str = new StringBuilder("Select * From Post Where isDeleted IS NULL AND ");
                        if(!String.IsNullOrEmpty(fromCountryid)){
                        str.Append(string.Format("FromCountryId={0}",fromCountryid.ToString()));
                        }
                        if (!String.IsNullOrEmpty(fromStateId))
                        {
                            str.Append(string.Format(" AND FromStateId={0}", fromStateId.ToString()));
                        }
                        if (!String.IsNullOrEmpty(fromCityId))
                        {
                            str.Append(string.Format(" AND fromcityId={0}", fromCityId.ToString()));
                        } 
                        if (!String.IsNullOrEmpty(toCountryid))
                        {
                            str.Append(string.Format(" AND ToCountryid={0}", toCountryid.ToString()));
                        }
                        if (!String.IsNullOrEmpty(toStateId))
                        {
                            str.Append(string.Format(" AND toStateId={0}", toStateId.ToString()));
                        }
                        if (!String.IsNullOrEmpty(toCityId))
                        {
                            str.Append(string.Format(" AND toCityId={0}", toCityId.ToString()));
                        }
                        command.CommandText =str.ToString() ;

                        SqlDataReader rdr = command.ExecuteReader();
                        List<Post> postList = new List<Post>();

                        while (rdr.Read())
                        {
                            Post post = new Post();
                            post.id = Convert.ToInt32(rdr["id"]);
                            post.PostContent = rdr["PostContent"].ToString();
                            post.PostTime = Convert.ToDateTime(rdr["PostTime"]);
                            post.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            post.FromCountryId = Convert.ToInt32(rdr["FromCountryId"]);
                            post.FromStateId = Convert.ToInt32(rdr["FromStateId"]);
                            post.FromCityId = Convert.ToInt32(rdr["FromCityId"]);
                            post.ToCountryId = Convert.ToInt32(rdr["ToCountryId"]);
                            post.ToStateId = Convert.ToInt32(rdr["ToStateId"]);
                            post.ToCityId = Convert.ToInt32(rdr["ToCityId"]);
                            post.UserId = Convert.ToInt32(rdr["UserId"]);
                            postList.Add(post);
                        }
                        return postList;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }

        public static Post savePost(Post newPost)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SavePost", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (newPost.id == 0)
                        {
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Id", newPost.id);
                        }
                        command.Parameters.AddWithValue("@PostContent", newPost.PostContent);
                        command.Parameters.AddWithValue("@UserId", newPost.UserId);

                        command.Parameters.AddWithValue("@FromCountryId", newPost.FromCountryId);
                        command.Parameters.AddWithValue("@FromStateId", newPost.FromStateId);
                        command.Parameters.AddWithValue("@FromCityId", newPost.FromCityId);
                        command.Parameters.AddWithValue("@ToCountryId", newPost.ToCountryId);
                        command.Parameters.AddWithValue("@ToStateId", newPost.ToStateId);
                        command.Parameters.AddWithValue("@ToCityId", newPost.ToCityId);
                        command.Parameters.AddWithValue("@PostTime", newPost.PostTime);
                        command.ExecuteNonQuery();
                       
                        return newPost;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }
        }


        public static bool deletePost(int postId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("DeletePost", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PostId", postId);
                        command.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                    }
                    return false;
                }
            }
        }

        public static Post getPostById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetPostById", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PostId", id);
                        SqlDataReader rdr = command.ExecuteReader();

                        while (rdr.Read())
                        {
                            Post post = new Post();
                            post.id = Convert.ToInt32(rdr["id"]);
                            post.PostContent = rdr["PostContent"].ToString();
                            post.PostTime = Convert.ToDateTime(rdr["PostTime"]);
                            post.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            post.FromCountryId = Convert.ToInt32(rdr["FromCountryId"]);
                            post.FromStateId = Convert.ToInt32(rdr["FromStateId"]);
                            post.FromCityId = Convert.ToInt32(rdr["FromCityId"]);
                            post.ToCountryId = Convert.ToInt32(rdr["ToCountryId"]);
                            post.ToStateId = Convert.ToInt32(rdr["ToStateId"]);
                            post.ToCityId = Convert.ToInt32(rdr["ToCityId"]);
                            post.UserId = Convert.ToInt32(rdr["UserId"]);
                            return post;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }
        }
    }
}
