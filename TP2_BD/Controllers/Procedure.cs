using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TP2_BD
{
    static class Procedure
    {
        #region ComboBox Procedure index 
        public static List<Stage> getAllStage(SqlConnection conn)
        {
            List<Stage> listStage = new List<Stage>();
            try
            {
                //Creation de la commande
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getAllStage";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listStage.Add(new Stage(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return listStage;
        }

        static public List<Entreprise> getAllEnt(SqlConnection conn)
        {
            List<Entreprise> listeEnt = new List<Entreprise>();
            try
            {
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getAllEntreprise";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listeEnt.Add(new Entreprise(reader.GetInt32(0), reader.GetString(1)));
                    }
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return listeEnt;

        }

        public static List<Moniteur> getAllMoniteur(SqlConnection conn)
        {
            List<Moniteur> listeMoniteur = new List<Moniteur>();
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getAllMoniteur";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listeMoniteur.Add(new Moniteur(reader.GetString(1),reader.GetString(0),reader.GetInt32(2)));
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return listeMoniteur;
        }

        public static List<Moniteur> getAllMoniteurByEnt(SqlConnection conn,int idEnt)
        {
            List<Moniteur> listeMoniteur = new List<Moniteur>();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getMoniteurByEnt";

                SqlParameter idEntParam = new SqlParameter("@idEnt", SqlDbType.Int);
                idEntParam.Direction = ParameterDirection.Input;
                idEntParam.Value = idEnt;

                cmd.Parameters.Add(idEntParam);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listeMoniteur.Add(new Moniteur(reader.GetString(1), reader.GetString(0), reader.GetInt32(2)));
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return listeMoniteur;
        }

        public static List<Stagiaire> getAllStagiaire(SqlConnection conn)
        {
            List<Stagiaire> listeStagiaire = new List<Stagiaire>();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getAllStagiaire";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listeStagiaire.Add(new Stagiaire(reader.GetString(1),reader.GetString(0),reader.GetInt32(2)));
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return listeStagiaire;
        }
        #endregion

        //AJOUTER UN STAGE PROCEDURE 1
        public static void addStage(SqlConnection conn,int id_entreprise,int id_moniteur,int id_stagiaire,String description,String TypeEstg,String Language,String Plateformes)
        {
            try
            {
                //Creation de la commande
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertionStage";

                //Creation de parametre
                SqlParameter param1 = new SqlParameter("@pid_entreprise", SqlDbType.Int);
                param1.Direction = ParameterDirection.Input;
                param1.Value = id_entreprise;

                SqlParameter param2 = new SqlParameter("@pid_moniteur", SqlDbType.Int);
                param1.Direction = ParameterDirection.Input;
                param2.Value = id_moniteur;

                SqlParameter param3 = new SqlParameter("@pid_stagiaire", SqlDbType.Int);
                param1.Direction = ParameterDirection.Input;
                param3.Value = id_stagiaire;

                SqlParameter param4 = new SqlParameter("@pDescription", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param4.Value = description;

                SqlParameter param5 = new SqlParameter("@pTypeESTG", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param5.Value = TypeEstg;

                SqlParameter param6 = new SqlParameter("@pLanguages", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param6.Value = Language;

                SqlParameter param7 = new SqlParameter("@pPlateformes", SqlDbType.VarChar);
                param1.Direction = ParameterDirection.Input;
                param7.Value = Plateformes;

                //Ajouter les parametres
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param6);
                cmd.Parameters.Add(param7);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Stage Ajouter!");
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message.ToString());
            }
        }


        //MODIFIER LA DESCRIPTION D'UN STAGE modifyDescription
        public static void modifyDescription(SqlConnection conn,int idStage,String description)
        {
            try
            {
                //Creation de la commande
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "modifyDescription";

                SqlParameter IDStage = new SqlParameter("@pIdStage", SqlDbType.Int);
                IDStage.Direction = ParameterDirection.Input;
                IDStage.Value = idStage;

                SqlParameter DescriptiionS = new SqlParameter("@pdescription", SqlDbType.VarChar);
                DescriptiionS.Direction = ParameterDirection.Input;
                DescriptiionS.Value = description;

                cmd.Parameters.Add(IDStage);
                cmd.Parameters.Add(DescriptiionS);

                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Description modidifier!");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public static void deleteStage(SqlConnection conn,int idStage)
        {
            try
            {
                //Creation de la commande
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "deleteStages";

                SqlParameter IDStage = new SqlParameter("@pIDStage", SqlDbType.Int);
                IDStage.Direction = ParameterDirection.Input;
                IDStage.Value = idStage;

                cmd.Parameters.Add(IDStage);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Stage Supprimer!");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }


        public static void listeStageByEntreprises(SqlConnection conn,String entrepriseName,DataGridView dgv)
        {
            //Creation de la commande
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "listStageByEntreprise";

                SqlParameter nameEnt = new SqlParameter("@pNomEntrePrise", SqlDbType.VarChar);
                nameEnt.Direction = ParameterDirection.Input;
                nameEnt.Value = entrepriseName;

                cmd.Parameters.Add(nameEnt);

                DataTable dt = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                BindingSource source = new BindingSource(dt, dt.TableName);
                dgv.DataSource = source;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        public static int getNbStagesByEntreprise(SqlConnection conn,int idEntreprise)
        {
            
            try
            {
                Object nbEntreprise;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select dbo.getNbStagesByEntreprise(@idEntreprise)";

                SqlParameter idEnt = new SqlParameter("@idEntreprise", SqlDbType.Int);
                idEnt.Direction = ParameterDirection.Input;
                idEnt.Value = idEntreprise;

                cmd.Parameters.Add(idEnt);              
                nbEntreprise = cmd.ExecuteScalar();

                return Int32.Parse(nbEntreprise.ToString());
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return 0;
            }
            
        }

        public static void getEtudiantWithStage(SqlConnection conn,DataGridView dgv)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.listEtudiants()";

                DataTable dt = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                BindingSource source = new BindingSource(dt, dt.TableName);
                dgv.DataSource = source;
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
    }

}
