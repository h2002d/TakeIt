﻿using System;
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
        public static string connectionString = ConfigurationManager.ConnectionStrings["CarProjectConnectionString"].ConnectionString;

        public static List<Post> getPosts(int? id, int? CategoryId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetPosts", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                        {
                            command.Parameters.AddWithValue("@PostId", DBNull.Value);
                            command.Parameters.AddWithValue("@CategoryId", CategoryId);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@PostId", id);
                            command.Parameters.AddWithValue("@CategoryId", DBNull.Value);
                        }

                        SqlDataReader rdr = command.ExecuteReader();
                        List<Post> postList = new List<Post>();

                        while (rdr.Read())
                        {
                            Post post = new Post();
                            //post.Id = Convert.ToInt32(rdr["Id"]);
                            //post.GeneralImage = rdr["GeneralImage"].ToString();

                            //post.CreateDate = Convert.ToDateTime(rdr["DateAdded"]);
                            //post.SecondaryImageId = Convert.ToInt32(rdr["SecondaryImageId"]);
                            //post.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            //post.Quantity = Convert.ToInt32(rdr["Quantity"]);
                            //post.Price = Convert.ToDecimal(rdr["Price"]);

                            //post.Title = rdr["Title"].ToString();
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
                        command.Parameters.AddWithValue("@FromId", newPost.FromCountryId);
                        command.Parameters.AddWithValue("@ToId", newPost.ToCountryId);
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
    }
}
