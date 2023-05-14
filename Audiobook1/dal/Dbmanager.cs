using dal;
using System.Data;
using MySql.Data.MySqlClient;
using bol;
public class Dbmanager
{   
   
  
   MySqlConnection conn =Dbutil.connect();

   
   public int addbook(string filename, string link){
    conn.Open();
    try
    {
       MySqlCommand cmd=new MySqlCommand("insert into audbook(filename,link)values(?filename,?link)",conn);
    cmd.Parameters.Add("@filename",MySqlDbType.VarChar).Value=filename;
    cmd.Parameters.Add("@link",MySqlDbType.VarChar).Value=link;
    cmd.ExecuteNonQuery(); 
    return 1;   
    }
    catch (System.Exception err)
    {
        
       Console.WriteLine(err);
       return 0;
    }
    finally{

       conn.Close();
    }
   }





   public List<Mp3saver> getallaudio(){
      conn.Open();
      List<Mp3saver>lp=new List<Mp3saver>();

    try{

       
        MySqlCommand cmd=new MySqlCommand("select * from audbook",conn);
        cmd.ExecuteNonQuery();

      MySqlDataReader reader=  cmd.ExecuteReader();
     while(reader.Read()){
        Mp3saver mp3=new Mp3saver();
      mp3.id=int.Parse(reader["id"].ToString());;
      mp3.filename=reader["filename"].ToString();
      mp3.link=reader["link"].ToString();
      lp.Add(mp3);
     }
     
      

    } catch(Exception err){
        Console.WriteLine(err);
         conn.Close();
    }  
      conn.Close();
     return  lp;  
 
   }

    
}