using LingvoNET;
using StoGen.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace StoGen.Classes
{
    public static class SGDataBase
    {
        static string Connstring = ConfigurationManager.AppSettings["Connection"];

        #region Inclines

        //CREATE TABLE [dbo].[sg_Verb](
        //	[Id] [int] IDENTITY(1,1) NOT NULL,
        //	[Verb] [nvarchar](max) NOT NULL,
        //	[ParentId] [int] NOT NULL,
        //	[FormType] [int] NOT NULL,
        //	[VerbType] [int] NULL
        //) ON [PRIMARY]
        //GO
        public static bool GetInclines2(string connectionString, ref InclinesData name)
        {
            bool result = false;
            var noun = Nouns.FindSimilar(name.inc_N);
            if (noun != null)
            {
                name.inc_A = noun[LingvoNET.Case.Accusative, Number.Singular];
                name.inc_D = noun[LingvoNET.Case.Dative, Number.Singular];
                name.inc_G = noun[LingvoNET.Case.Genitive, Number.Singular];
                name.inc_I = noun[LingvoNET.Case.Instrumental, Number.Singular];
                name.inc_P = noun[LingvoNET.Case.Locative, Number.Singular];
                string sh = noun[LingvoNET.Case.Short, Number.Singular];
            }
            return result;
        }
        public static int GetVerbId(string connectionString, string verb)
        {
            int result = 0;
            string queryString =
             "SELECT Id FROM dbo.sg_Verb where Verb ='" + verb.ToLower() + "'";

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data. 
                if (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                // Call Close when done reading.
                reader.Close();
            }
            return result;
        }
        public static string GetModificatedVerb(string connectionString, int parentId, int modif)
        {
            string result = null;
            string queryString =
             "SELECT * FROM dbo.sg_Verb where ParentId = " + parentId + " AND FormType = " + modif.ToString();

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data. 
                if (reader.Read())
                {
                    result = reader.GetString(1);
                }
                // Call Close when done reading.
                reader.Close();
            }
            return result;
        }
        public static bool SetModificatedVerb(string connectionString, string verb, int parentId, int modif)
        {
            bool result = false;
            string queryString =
             "INSERT INTO dbo.sg_Verb (ParentId,Verb,FormType,VerbType) VALUES ("
             + parentId + ","
             + "'" + verb.ToLower() + "',"
             + "" + modif + ",0)";
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
            }
            return result;
        }
        #endregion

        #region Movie      
        public static bool SaveMovie(SgMovie m)
        {
            bool result = false;
            if (m.Id == 0)
            {
                InsertMovie(m);
            }
            else
            {
                UpdateMovie(m);
                CleanActorListOfMovie(m.Id);
            }
            if (m.ActorList == null)
                m.ActorList = new List<SgActor>();
            foreach (SgActor sgActor in m.ActorList)
            {
                InsertActorListToMovie(m.Id, sgActor);
            }

            return result;
        }
        public static bool LoadMovie(SgMovie m)
        {
            if (m.ActorList == null) m.ActorList = new List<SgActor>();
            m.ActorList.Clear();
            GetActorList(m.ActorList, m.Id);
            return true;

        }
        public static bool GetMovieList(List<SgMovie> list)
        {
            bool result = false;
            list.Clear();
            string sql =
                  $@"SELECT          	    			        
            [Id],
           	[Name],
            [Aliace],
        	[ProductionYear],
        	[Genre],
            [GenreType],
        	[Country],
        	[Studio],
        	[Director],
            [Score],
            [ProductionType],
            [SerieName],
            [SerieSeason],
            [SerieEpisode],
            [DescriptionShort],
            [DescriptionLong]            
            FROM [dbo].[sgMovie] ORDER BY Id DESC";

            using (SqlConnection connection =
                     new SqlConnection(Connstring))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SgMovie m = new SgMovie();
                    m.Id = (int)reader[nameof(m.Id)];
                    GetMovieFromReader(reader, m);
                    list.Add(m);
                }
                reader.Close();
                result = true;
            }
            return result;
        }
        private static void GetMovieFromReader(SqlDataReader reader, SgMovie m)
        {
            m.Name = (string)(KillDbNull(reader[nameof(m.Name)]) ?? string.Empty);
            m.Aliace = (string)(KillDbNull(reader[nameof(m.Aliace)]) ?? string.Empty);
            m.ProductionYear = (int)(KillDbNull(reader[nameof(m.ProductionYear)]) ?? 0);
            m.Genre = (GenreEnum)(KillDbNull(reader[nameof(m.Genre)]) ?? 0);
            m.GenreType = (GenreTypeEnum)(KillDbNull(reader[nameof(m.GenreType)]) ?? 0);
            m.Country = (CountryEnum)(KillDbNull(reader[nameof(m.Country)]) ?? 0);
            m.Score = (int)(KillDbNull(reader[nameof(m.Score)]) ?? 0);
            m.ProductionType = (ProductionTypeEnum)(KillDbNull(reader[nameof(m.ProductionType)]) ?? 0);
            m.SerieName = (string)(KillDbNull(reader[nameof(m.SerieName)]) ?? string.Empty);
            m.Studio = (string)(KillDbNull(reader[nameof(m.Studio)]) ?? string.Empty);
            m.Director = (string)(KillDbNull(reader[nameof(m.Director)]) ?? string.Empty);
            m.SerieSeason = (int)(KillDbNull(reader[nameof(m.SerieSeason)]) ?? 0);
            m.SerieEpisode = (int)(KillDbNull(reader[nameof(m.SerieEpisode)]) ?? 0);
            m.DescriptionShort = (string)(KillDbNull(reader[nameof(m.DescriptionShort)]) ?? string.Empty);
            m.DescriptionLong = (string)(KillDbNull(reader[nameof(m.DescriptionLong)]) ?? string.Empty);
        }
        private static object KillDbNull(object val)
        {
            if (val == DBNull.Value) return null;
            return val;
        }
        private static bool InsertMovie(SgMovie m)
        {
            bool result = false;
            string sql =
                  $@"INSERT           	    
			        into [dbo].[sgMovie] (
           	[Name],
            [Aliace],
        	[ProductionYear],
        	[Genre],
            [GenreType],
        	[Country],
        	[Studio],
        	[Director],
            [Score],
            [ProductionType],
            [SerieName],
            [SerieSeason],
            [SerieEpisode],
            [DescriptionShort],
            [DescriptionLong]
            )
            OUTPUT INSERTED.Id
            VALUES 
            (
            @Name,
            @Aliace,
            {m.ProductionYear},
            {(int)m.Genre},
            {(int)m.GenreType},
            '{(int)m.Country}',
            @Studio,
            @Director,
            {m.Score},
            {(int)m.ProductionType},
            @SerieName,
            {m.SerieSeason},
            {m.SerieEpisode},
            @DescriptionShort,
            @DescriptionLong
            )";


            using (SqlConnection connection =
                       new SqlConnection(Connstring))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
                SqlParameter param = new SqlParameter("@Name", m.Name);
                command.Parameters.Add(param);
                param = new SqlParameter("@Aliace", m.Aliace);
                command.Parameters.Add(param);
                param = new SqlParameter("@Studio", m.Studio);
                command.Parameters.Add(param);
                param = new SqlParameter("@Director", m.Director);
                command.Parameters.Add(param);
                param = new SqlParameter("@SerieName", m.SerieName);
                command.Parameters.Add(param);
                param = new SqlParameter("@DescriptionShort", m.DescriptionShort);
                command.Parameters.Add(param);
                param = new SqlParameter("@DescriptionLong", m.DescriptionShort);
                command.Parameters.Add(param);
                connection.Open();
                m.Id = (int)command.ExecuteScalar();
                result = m.Id > 0;
            }
            return result;
        }
        private static bool UpdateMovie(SgMovie m)
        {
            bool result = false;
            string sql =
                  $@"UPDATE           	    
			        [dbo].[sgMovie] SET
           	[Name]=@Name,
            [Aliace]=@Aliace,
        	[ProductionYear]={m.ProductionYear},
        	[Genre]={(int)m.Genre},
            [GenreType]={(int)m.GenreType},
        	[Country]={(int)m.Country},
        	[Studio]=@Studio,
        	[Director]=@Director,
            [Score]={m.Score},
            [ProductionType]={(int)m.ProductionType},
            [SerieName]=@SerieName,
            [SerieSeason]={m.SerieSeason},
            [SerieEpisode]={m.SerieEpisode},
            [DescriptionShort]=@DescriptionShort,
            [DescriptionLong]=@DescriptionLong
            WHERE Id={m.Id}";
            using (SqlConnection connection =
                       new SqlConnection(Connstring))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
                SqlParameter param = new SqlParameter("@Name", m.Name);
                command.Parameters.Add(param);
                param = new SqlParameter("@Aliace", m.Aliace);
                command.Parameters.Add(param);
                param = new SqlParameter("@Studio", m.Studio);
                command.Parameters.Add(param);
                param = new SqlParameter("@Director", m.Director);
                command.Parameters.Add(param);
                param = new SqlParameter("@SerieName", m.SerieName);
                command.Parameters.Add(param);
                param = new SqlParameter("@DescriptionShort", m.DescriptionShort);
                command.Parameters.Add(param);
                param = new SqlParameter("@DescriptionLong", m.DescriptionShort);
                command.Parameters.Add(param);
                connection.Open();
                command.ExecuteNonQuery();
                result = m.Id > 0;
            }
            return result;
        }
        private static bool InsertActorListToMovie(int movieId, SgActor a)
        {
            bool result = false;
            string sql =
                  $@"INSERT           	    
			        into [dbo].[SgLinkActorMovie] 
                ([ActorId],[MovieId]) VALUES ({a.Id},{movieId})";

            using (SqlConnection connection =
                       new SqlConnection(Connstring))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteScalar();

            }
            return result;
        }
        private static bool CleanActorListOfMovie(int movieId)
        {
            bool result = false;
            string sql =
                  $@"DELETE FROM [dbo].[SgLinkActorMovie] WHERE [MovieId]={movieId}";
            using (SqlConnection connection =
                       new SqlConnection(Connstring))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteScalar();

            }
            return result;
        }
        #endregion

        #region Actor    
        public static bool SaveActor(SgActor m)
        {
            using (SqlConnection connection =
                  new SqlConnection(Connstring))
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {


                    bool result = false;
                    if (m.Id == 0)
                    {
                        InsertActor(m, connection, tran);
                    }
                    else
                    {
                        UpdateActor(m, connection, tran);
                        CleanPictureList(m.Id, 0, 0, connection, tran);
                    }
                    if (m.PicList == null) { m.PicList = new List<SgPicture>(); };
                    foreach (SgPicture sgPicture in m.PicList)
                    {
                        InsertPictureList(m.Id, 0, 0, sgPicture, connection, tran);
                    }
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return false;

                }
            }
            return true;
        }
        public static bool GetActorList(List<SgActor> list, int MovieId)
        {
            bool result = false;
            list.Clear();
            string sql =
                  $@"SELECT          	    			        
[sgActor].[Id],
[Name],
[Aliace],
[Gender],
[BornCountry],
[BornYear],
[Race],
[FaceType],
[BodyType],
[ActivityType],
[DescriptionShort],
[DescriptionLong],
[Score],
        Bd_Height,
        Bd_Shoulders,
        Bd_Breasts,
        Bd_Waist,
        Bd_Hips     
            FROM [dbo].[sgActor]";
            if (MovieId > 0)
            {
                sql += $@"
                LEFT OUTER JOIN [SgLinkActorMovie] ON [sgActor].[Id] = [SgLinkActorMovie].[ActorId]
                WHERE [SgLinkActorMovie].[MovieId]={MovieId}
                ";
            }
            sql += $@" ORDER BY [sgActor].[Id] DESC";
            using (SqlConnection connection =
                     new SqlConnection(Connstring))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SgActor m = new SgActor();
                    m.Id = (int)reader[nameof(m.Id)];
                    GetActorFromReader(reader, m);

                    list.Add(m);
                }
                reader.Close();
                result = true;
            }
            return result;
        }
        private static void GetActorFromReader(SqlDataReader reader, SgActor m)
        {
            m.Name = (string)reader[nameof(m.Name)];
            m.Aliace = (string)reader[nameof(m.Aliace)];
            m.ActivityType = (ActivityTypeEnum)reader[nameof(m.ActivityType)];
            m.BodyType = (BodyTypeEnum)reader[nameof(m.BodyType)];
            m.BornCountry = (CountryEnum)reader[nameof(m.BornCountry)];
            m.BornYear = (int)reader[nameof(m.BornYear)];
            m.FaceType = (FaceTypeEnum)reader[nameof(m.FaceType)];
            m.Gender = (GenderEnum)reader[nameof(m.Gender)];
            m.Race = (RaceEnum)reader[nameof(m.Race)];
            m.Score = (int)reader[nameof(m.Score)];
            m.DescriptionShort = (string)reader[nameof(m.DescriptionShort)];
            m.DescriptionLong = (string)reader[nameof(m.DescriptionLong)];

            m.Bd_Breasts = (BodyBreastEnum)reader[nameof(m.Bd_Breasts)];
            m.Bd_Height = (BodyHeightEnum)reader[nameof(m.Bd_Height)];
            m.Bd_Hips = (BodyHipsEnum)reader[nameof(m.Bd_Hips)];
            m.Bd_Shoulders = (BodyShouldersEnum)reader[nameof(m.Bd_Shoulders)];
            m.Bd_Waist = (BodyWaistEnum)reader[nameof(m.Bd_Waist)];
        }
        private static bool InsertActor(SgActor m, SqlConnection connection, SqlTransaction tran)
        {
            bool result = false;
            string sql =
                  $@"INSERT           	    
			        into [dbo].[sgActor] (
[Name],
[Aliace],
[Gender],
[BornCountry],
[BornYear],
[Race],
[FaceType],
[BodyType],
[ActivityType],
[DescriptionShort],
[DescriptionLong],
[Score],
        Bd_Height,
        Bd_Shoulders,
        Bd_Breasts,
        Bd_Waist,
        Bd_Hips  
            )
            OUTPUT INSERTED.Id
            VALUES 
            (
            N'{m.Name}',
           N'{m.Aliace}',
            {(int)m.Gender},
            '{(int)m.BornCountry}',
            {m.BornYear},
            {(int)m.Race},
            {(int)m.FaceType},
            {(int)m.BodyType},
            {(int)m.ActivityType},
            '{m.DescriptionShort}',
            '{m.DescriptionLong}',
            {m.Score},
            {(int)m.Bd_Height},
            {(int)m.Bd_Shoulders},
            {(int)m.Bd_Breasts},
            {(int)m.Bd_Waist},
            {(int)m.Bd_Hips}
            )";



            SqlCommand command =
                new SqlCommand(sql, connection, tran);
            command.CommandType = CommandType.Text;
            m.Id = (int)command.ExecuteScalar();
            result = m.Id > 0;

            return result;
        }
        private static bool UpdateActor(SgActor m, SqlConnection connection, SqlTransaction tran)
        {
            bool result = false;
            string sql =
                  $@"UPDATE           	    
			        [dbo].[sgActor] SET
           	[Name]=N'{m.Name}',
[Aliace]=N'{m.Aliace}',
[Gender]={(int)m.Gender},
[BornCountry]={(int)m.BornCountry},
[BornYear]={m.BornYear},
[Race]={(int)m.Race},
[FaceType]={(int)m.FaceType},
[BodyType]={(int)m.BodyType},
[ActivityType]={(int)m.ActivityType},
[Score]={m.Score},   
            [DescriptionShort]='{m.DescriptionShort}',
            [DescriptionLong]='{m.DescriptionLong}',
        Bd_Height = {(int)m.Bd_Height},
        Bd_Shoulders ={(int)m.Bd_Shoulders},
        Bd_Breasts = {(int)m.Bd_Breasts},
        Bd_Waist ={(int)m.Bd_Waist},
        Bd_Hips = {(int)m.Bd_Hips}
            WHERE Id={m.Id}";

            SqlCommand command =
                new SqlCommand(sql, connection, tran);
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            result = m.Id > 0;

            return result;
        }

        public static bool LoadActor(SgActor m)
        {
            if (m.PicList == null) m.PicList = new List<SgPicture>();
            m.PicList.Clear();
            GetPictureList(m.PicList, m.Id, 0, 0);
            return true;

        }
        #endregion

        public static bool GetPictureList(List<SgPicture> list, int objectId, int objectType, int pictureType)
        {
            bool result = false;
            list.Clear();
            string sql =
                  $@"SELECT          	    			        
            [ImagePath],[Description]
            FROM [dbo].[SgImages]
            WHERE [ObjectType]={objectType} AND [ObjectId]={objectId}";

            using (SqlConnection connection =
                     new SqlConnection(Connstring))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    byte[] ff = (byte[])reader["ImagePath"];
                    using (var ms = new MemoryStream(ff))
                    {
                        SgPicture pic = new SgPicture();
                        pic.Picture = Image.FromStream(ms);
                        list.Add(pic);
                        pic.Description = (string)reader["Description"];
                    }


                }
                reader.Close();
                result = true;
            }
            return result;
        }
        private static bool CleanPictureList(int objectId, int objectType, int pictureType, SqlConnection connection, SqlTransaction tran)
        {
            bool result = false;
            string sql =
                  $@"DELETE FROM [dbo].[SgImages] WHERE [ObjectType]={objectType} AND [ObjectId]={objectId}";

            SqlCommand command =
                new SqlCommand(sql, connection, tran);
            command.CommandType = CommandType.Text;
            command.ExecuteScalar();

            return result;
        }
        private static bool InsertPictureList(int objectId, int objectType, int pictureType, SgPicture pic, SqlConnection connection, SqlTransaction tran)
        {
            bool result = false;
            if (objectId == 0) return false;
            string sql =
                  $@"INSERT           	    
			        into [dbo].[SgImages] 
                ([ObjectType],[ObjectId],[ImageId],[ImagePath],[Description])
                 VALUES({objectType},{objectId},{pictureType},@pic,N'{pic.Description}')";

            SqlParameter picparameter = new SqlParameter();
            picparameter.SqlDbType = SqlDbType.VarBinary;
            picparameter.ParameterName = $"@pic";

            Bitmap bm = new Bitmap(pic.Picture);
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(bm, typeof(byte[]));

            picparameter.Value = xByte;
            SqlCommand command =
                 new SqlCommand(sql, connection, tran);
            command.CommandType = CommandType.Text;
            command.Parameters.Add(picparameter);
            command.ExecuteScalar();

            return result;
        }



        #region Clip
        public static bool SaveClip(SgClip m)
        {
            using (SqlConnection connection =
                  new SqlConnection(Connstring))
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {


                    bool result = false;
                    if (m.Id == 0)
                    {
                        InsertClip(m, connection, tran);
                    }
                    else
                    {
                        UpdateClip(m, connection, tran);
                        CleanRoleListOfCip(m.Id, connection, tran);
                    }
                    if (m.ActorRoleList == null) { m.ActorRoleList = new List<SgActorRole>(); };
                    foreach (SgActorRole sgActorRole in m.ActorRoleList)
                    {
                        InsertRoleToClip(m.Id, sgActorRole, connection, tran);
                    }
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return false;

                }
            }
            return true;
        }
        private static bool InsertClip(SgClip m, SqlConnection connection, SqlTransaction tran)
        {
            bool result = false;
            string sql =
                  $@"INSERT           	    
			        into [dbo].[sgClip] (
                    [SetId],
                    [SetType],
                    [Path],
                    [OldFileName],
                    [Description]    
                     )
                     OUTPUT INSERTED.Id
                     VALUES 
            (
            {m.SetId},
            {(int)m.SetType},
            N'{m.Path}',
            N'{m.OldFileName}',
            N'{m.Description}'
            )";
            SqlCommand command =
                new SqlCommand(sql, connection, tran);
            command.CommandType = CommandType.Text;
            m.Id = (int)command.ExecuteScalar();
            result = m.Id > 0;

            return result;
        }
        private static bool UpdateClip(SgClip m, SqlConnection connection, SqlTransaction tran)
        {
            bool result = false;
            string sql =
                  $@"UPDATE           	    
			        [dbo].[sgClip] SET
            [SetId]={m.SetId},
            [SetType]={(int)m.SetType},
            [Path]='{m.Path}',
            [OldFileName]='{m.OldFileName}',
            [Description]='{m.Description}'
            WHERE Id={m.Id}";
            SqlCommand command =
                new SqlCommand(sql, connection, tran);
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            result = m.Id > 0;

            return result;
        }
        private static bool CleanRoleListOfCip(int clipId, SqlConnection connection, SqlTransaction tran)
        {
            bool result = false;
            string sql =
                  $@"DELETE FROM [dbo].[SgLinkClipRole] WHERE [ClipId]={clipId}";
            SqlCommand command =
                new SqlCommand(sql, connection, tran);
            command.CommandType = CommandType.Text;
            //connection.Open();
            command.ExecuteScalar();

            return result;
        }
        private static bool InsertRoleToClip(int clipId, SgActorRole a, SqlConnection connection, SqlTransaction tran)
        {
            bool result = false;
            string sql =
                  $@"INSERT           	    
			        into [dbo].[SgLinkClipRole] 
                ([ActorId],[ClipId],[RoleType]) VALUES ({a.ActorId},{clipId},{(int)a.RoleType})";

            SqlCommand command =
                new SqlCommand(sql, connection, tran);
            command.CommandType = CommandType.Text;
            // connection.Open();
            command.ExecuteScalar();

            return result;
        }

        public static bool GetClipList(List<SgClip> list, int setType, int setId, int id, string path, string fn)
        {
            bool result = false;
            list.Clear();
            string wheresql = string.Empty;
            List<string> wheresqllist = new List<string>();
            if (setType > 0) wheresqllist.Add($" [SetType] = {setType} ");
            if (setId > 0) wheresqllist.Add($" [SetId] = {setId} ");
            if (id > 0) wheresqllist.Add($" [Id] = {setId} ");
            //if (!string.IsNullOrEmpty(path)) wheresqllist.Add($" [Path] ='{path}' ");
            if (!string.IsNullOrEmpty(fn)) wheresqllist.Add($" [OldFileName] ='{fn}' ");
            if (wheresqllist.Count > 0) wheresql = $" WHERE {string.Join(" AND ", wheresqllist.ToArray())}";

            string sql =
                  $@"SELECT          	    			        
            [SgClip].[Id],
            [SetType],
            [SetId],
        	[Path],
        	[OldFileName],
            [Description],
             
 	        [SgMovie].[Name] as Name,
            [SgMovie].[Aliace],
        	[ProductionYear],
        	[Genre],
            [GenreType],
        	[Country],
        	[Studio],
        	[Director],
            [SgMovie].[Score],
            [ProductionType],
            [SerieName],
            [SerieSeason],
            [SerieEpisode],
            [SgMovie].[DescriptionShort],
            [SgMovie].[DescriptionLong],            
            
            [RoleType],

            [SgActor].[Name] as ActorName,
            [ActorId],

            [SgActor].[Aliace],
            [Gender],
            [BornCountry],
            [BornYear],
            [Race],
            [FaceType],
            [BodyType],
            [ActivityType],
            [SgActor].[DescriptionShort] AS ActorDS,
            [SgActor].[DescriptionLong] AS ActorDL,
            [SgActor].[Score] AS ActorScore,
            Bd_Height,
            Bd_Shoulders,
            Bd_Breasts,
            Bd_Waist,
            Bd_Hips     

            FROM [dbo].[SgClip]
            LEFT JOIN [dbo].[SgMovie] ON [SgClip].[SetId] = [SgMovie].[Id]
            LEFT JOIN [dbo].[SgLinkClipRole] ON [SgClip].[Id] = [SgLinkClipRole].[ClipId]
            LEFT JOIN [dbo].[SgActor] ON [SgLinkClipRole].[ActorId] = [SgActor].[Id]
            {wheresql}";

            using (SqlConnection connection =
                     new SqlConnection(Connstring))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SgClip s = new SgClip();
                    s.Id = (int)reader[nameof(s.Id)];
                    s.OldFileName = (string)reader[nameof(s.OldFileName)];
                    s.Path = (string)reader[nameof(s.Path)];
                    s.SetId = (int)reader[nameof(s.SetId)];
                    s.SetType = (ProductionTypeEnum)reader[nameof(s.SetType)];
                    s.Description = (string)reader[nameof(s.Description)];

                    s.Movie = new SgMovie();
                    GetMovieFromReader(reader, s.Movie);
                    s.Movie.Id = s.SetId;

                    if (reader[nameof(SgActorRole.RoleType)] != DBNull.Value)
                    {
                        s.ActorRoleList = new List<SgActorRole>();
                        s.ActorRoleList.Add(new SgActorRole());
                        s.MainRole.RoleType = (RoleRelationEnum)reader[nameof(SgActorRole.RoleType)];
                        s.MainRole.ActorId = (int)reader[nameof(SgActorRole.ActorId)];
                        if (s.MainRole.ActorId > 0)
                        {
                            s.MainRole.Actor = new SgActor();
                            GetActorFromReader(reader, s.MainRole.Actor);
                            s.MainRole.Actor.Name = (string)reader["ActorName"];
                            s.MainRole.Actor.Id = s.MainRole.ActorId;
                        }
                    }


                    list.Add(s);
                }
                reader.Close();
                result = true;
            }
            return result;
        }
        public static bool GetRoleList(List<SgActorRole> list, int clipId)
        {
            bool result = false;
            list.Clear();
            string wheresql = string.Empty;
            List<string> wheresqllist = new List<string>();
            if (clipId > 0) wheresqllist.Add($" [ClipId] = {clipId} ");
            if (wheresqllist.Count > 0) wheresql = $" WHERE {string.Join(" AND ", wheresqllist.ToArray())}";

            string sql =
                  $@"SELECT
            [SgLinkClipRole].[Id],          	    			        
            [ClipId],
            [RoleType],
            [ActorId],
            [Name],
            [Aliace],
            [Gender],
            [BornCountry],
            [BornYear],
            [Race],
            [FaceType],
            [BodyType],
            [ActivityType],
            [DescriptionShort],
            [DescriptionLong],
            [Score],
             Bd_Height,
             Bd_Shoulders,
             Bd_Breasts,
             Bd_Waist,
             Bd_Hips    
            FROM [dbo].[SgLinkClipRole]
            LEFT JOIN [dbo].[SgActor] ON [SgLinkClipRole].[ActorId] = [sgActor].[Id]
            {wheresql}";

            using (SqlConnection connection =
                     new SqlConnection(Connstring))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SgActorRole s = new SgActorRole();
                    s.Id = (int)reader[nameof(s.Id)];
                    s.ClipId = (int)reader[nameof(s.ClipId)];
                    s.RoleType = (RoleRelationEnum)reader[nameof(s.RoleType)];
                    s.ActorId = (int)reader[nameof(s.ActorId)];

                    SgActor m = new SgActor();
                    m.Id = s.ActorId;
                    m.RoleRelation = s.RoleType;
                    GetActorFromReader(reader, m);
                    s.Actor = m;
                    
                    list.Add(s);
                }
                reader.Close();
                result = true;
            }
            return result;
        }
        public static bool LoadClip(SgClip m)
        {
            if (m.ActorRoleList == null) m.ActorRoleList = new List<SgActorRole>();
            m.ActorRoleList.Clear();
            GetRoleList(m.ActorRoleList, m.Id);
            return true;

        }
        public static bool ConvertClipName(SgClip m)
        {
            if (m.Id == 0)
            {
                SaveClip(m);
            }
            if (m.Id == 0) return false;
            string newclipname = "ab@" + String.Format("{0:00000000}", m.Id) + Path.GetExtension(m.OldFileName);
            if (m.OldFileName != newclipname)
            {
                string oldpath = Path.GetDirectoryName(m.Path)+Path.DirectorySeparatorChar + m.OldFileName;
                string newpath = Path.GetDirectoryName(m.Path) + Path.DirectorySeparatorChar + newclipname;
                if (File.Exists(oldpath))
                {
                    File.Move(oldpath, newpath);
                    if (File.Exists(newpath))
                    {
                        m.OldFileName = newclipname;
                        m.Path = newpath;
                        return SaveClip(m);
                    }

                }
                
            }
            return false;
        }
        #endregion
    }

    public struct InclinesData
    {
        public string inc_N;
        public string inc_A;
        public string inc_D;
        public string inc_G;
        public string inc_I;
        public string inc_P;
    }




}
