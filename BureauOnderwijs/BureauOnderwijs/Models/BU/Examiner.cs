using BureauOnderwijs.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BureauOnderwijs.Models.CC;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Examiner : Teacher // inherit from Teacher.cs
    {
        public Examiner()
        {
            // Leeg: anders verschijnen er enge rode lijntjes.
        }

        public Examiner(int id, string username, string email, string firstname, string lastname) : base()
        {
            this.userId = id;
            this.username = username;
            this.emailAdress = email;
            this.firstname = firstname;
            this.lastname = lastname;
        }


    public DataTable ReadModules(string ingelogd)
        {
            //connectie gemaakt naar de database en een query SELECT om alle informatie van de kolommen uit Module op te halen
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery = "SELECT [ModuleId],[Name],[Code],[Period],[Year],[Faculty],[Profile],[Credits],[ExaminerId] ,[Description],[GeneralModule],[LectureHours],[PracticalHours] FROM[Module] WHERE Deleted = 0";

            try
            {
                //nieuwe connectie + een command
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlquery, con);

                con.Open();
                //lezen van data binnen eeen database
                DataTable datatable = new DataTable();
                SqlDataReader datareader = cmd.ExecuteReader();
                datatable.Load(datareader);
                con.Close();
                //wanneer dit gelukt is returnt hij de datatable
                return datatable;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable ReadModulesLinkedToExaminor(string ingelogd)
        {
            //connectie gemaakt naar de datanase en een query SELECT om de moduleID te selecteren uit Module en die te linken aan een Userid in ModuleUser
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery = "SELECT m.ModuleId, m.Name, m.Code, m.Period, m.Year, m.Faculty, m.Profile, m.Credits, m.ExaminerId, m.Description, m.GeneralModule, m.LectureHours, m.PracticalHours, u.userId FROM Module m, UserAccount u, ModuleUser mu WHERE m.ModuleId = mu.ModuleId AND u.UserId = mu.UserId ORDER BY m.ModuleId";

            try
            {
                //nieuwe connectie + een command
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlquery, con);

                con.Open();
                //lezen van data binnen eeen database
                DataTable datatable = new DataTable();
                SqlDataReader datareader = cmd.ExecuteReader();
                datatable.Load(datareader);
                con.Close();
                //wanneer dit gelukt is returnt hij de datatable
                return datatable;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AddNewModule(string Name, string Code,int Period, int Year, string Faculty, string Profile, int Credits, bool GeneralModule ,int ExaminerId, string Description, int LectureHours, int PracticalHours, int Docent, string ingelogd)
        {
            //lokale variabele ModuleId aangemaakt als 0 die hij later in gaat vullen met een getal vanuit query 2
            int ModuleId = 0;
            //Deze query voegt informatie vanuit de tekstboxen in een nieuwe row waar de ModuleId uniek is. 
            string sqlquery =   "INSERT INTO Module(Name, Code, Period, Year, Faculty, Profile, Credits, GeneralModule, ExaminerId, Description, LectureHours, PracticalHours, Deleted)" +
                                "VALUES('" + Name + "', '" + Code + "','" + Period + "','" + Year + "','" + Faculty + "','" + Profile + "','" + Credits + "','" + GeneralModule + "', '" + ExaminerId + "', '" + Description + "','" + LectureHours + "','" + PracticalHours + "', 0);";
            //Deze query gaat de moduleID ophalen vanuit de module waar we zelf een unieke combinatie maken, in dit geval is dat Naam + Code
            string sqlquery2 = "SELECT ModuleId FROM Module WHERE Name = '" + Name + "' AND Code = '" + Code + "'";

            try
            {
                //nieuwe connectie + een command
                string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                //uitvoer van de eerste command
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                cmd.ExecuteNonQuery();
                //uitvoer van het tweede command
                SqlCommand cmd2 = new SqlCommand(sqlquery2, con);
                //de return waarde van de SQLquery, hier wordt aan ModuleId een waarde gehangen
                ModuleId = Convert.ToInt32(cmd2.ExecuteScalar());
                //uitvoer van het derde command + de 3de query waar we ModuleId en Docent als UserId aan elkaar koppelen binnen ModuleUser
                string sqlquery3 = "INSERT INTO ModuleUser(ModuleId, UserId) VALUES( '" + ModuleId + "','" + Docent + "')";
                SqlCommand cmd3 = new SqlCommand(sqlquery3, con);
                cmd3.ExecuteNonQuery();
                con.Close();
                //wanneer dit gelukt is komt er een "0" terug en wordt dit doorgegeven aan de GUI waar een melding komt dat het gelukt is.
                return "0";
            }

            catch (Exception)
            {
                //wanneer dit NIET gelukt is komt er een "1" terug en wordt dit doorgegeven aan de GUI waar een melding komt dat het NIET gelukt is.
                return "1";
            }
        }

        public string UpdateModule(string Name, string Code, int Period, int Year, string Faculty, string Profile, int Credits, bool GeneralModule, int ExaminerId, string Description, int LectureHours, int PracticalHours, int ModuleId, string ingelogd)
        {
            //connectie gemaakt naar de database en een query Update om een module via tekstboxen en een moduleID te kunnen updaten binnen dezelfde row in de table Module

            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlqueryUpdate = "UPDATE Module SET [Name] = '" + Name + "', [Code] = '" + Code + "', [Period] = '" + Period + "', [Year] ='" + Year + "', [Faculty] ='" + Faculty + "', [Profile] = '" + Profile + "', [Credits] ='" + Credits + "', [GeneralModule] = '" + GeneralModule + "', [ExaminerId] ='" + ExaminerId + "', [Description]='" + Description + "', [LectureHours] ='" + LectureHours + "', [PracticalHours] = '" + PracticalHours + "', Deleted = 0  WHERE ModuleId = '" + ModuleId + "'";

            try
            {
                //nieuwe connectie + een command
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlqueryUpdate, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //wanneer dit gelukt is komt er een "0" terug en wordt dit doorgegeven aan de GUI waar een melding komt dat het gelukt is.
                return "0";
            }
            catch (Exception)
            {
                //wanneer dit NIET gelukt is komt er een "1" terug en wordt dit doorgegeven aan de GUI waar een melding komt dat het NIET gelukt is.
                return "1";
            }

        }

        public DataTable DeleteModule(int ModuleId, string ingelogd)
        {
            //connectie gemaakt naar de database en een query DELETE waar de gebruiker een ModuleID invoert in een tekstbox. hij verwijderd dan de rij waar de ModuleId gelijk is aan de invoerwaarde.
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery = "DELETE FROM Module WHERE ModuleId = ('"+ ModuleId +"')";

            try
            {
                //nieuwe connectie + een command

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlquery, con);

                con.Open();
                //lezen van data binnen eeen database
                //Nieuwe datatable aangemaakt
                DataTable datatable = new DataTable();
                SqlDataReader datareader = cmd.ExecuteReader();
                datatable.Load(datareader);
                con.Close();
                //na het uitvoeren van de query moet de gridview opnieuw worden gevuld met alle relevante informatie. de verwijderde rij wordt er dus uitgelaten.
                return datatable;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}