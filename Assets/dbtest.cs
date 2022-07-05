using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;
using System.Data.SQLite;
public class dbtest : MonoBehaviour
{
    public InputField loginA; 
    public InputField passwordA; 
    public GameObject Menu;
    public GameObject Game;

    public void OnButtonClick() // регистраци€
    {
        
      
        ReadDB();
        string NewLogin = loginA.text;
        string NewPassword = passwordA.text;

        if (NewPassword.Length > 3)
        {
            string conn = "URI=file:" + Application.dataPath + "/testdb.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "INSERT INTO testdb VALUES('" + NewLogin + "', '" + NewPassword + "')";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
            Game.SetActive(true);    
            Menu.SetActive(false);
            
        }
        else
        {
            Debug.Log("ѕароль должен быть длинее 3 символов!");
        }    
    }

    public void OnButtonClick2() // ¬ход
    {
        string conn = "URI=file:" + Application.dataPath + "/testdb.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT username,password " + "FROM testdb";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string Login = loginA.text;
            string Pass = passwordA.text;
            string username = reader.GetString(0);
            string password = reader.GetString(1);
            if (Login == username && Pass == password)
            {
                //мен€ю нужные мне окна
                Game.SetActive(true);
                Menu.SetActive(false);
            }
            else 
            {
                Debug.Log("Ћогин или пароль неверный!");
            }
        }
        
        
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        



    }
    
    public void ReadDB()
    {

        string conn = "URI=file:" + Application.dataPath + "/testdb.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT username,password " + "FROM testdb";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string username = reader.GetString(0);
            string password = reader.GetString(1);
            
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
    void Adduser() // бл€,вроде это нахуй не надо,но есть шанс,что без этого все слетит (делайте на свой страх и риск)
    {
        string conn = "URI=file:" + Application.dataPath + "/testdb.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO testdb VALUES('" + loginA.text + "', '"+ passwordA.text + "')";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
