using System.Data;
using MySql.Data.MySqlClient;
namespace dal;
public class Dbutil
{ 

   private static string connection=@"server=sql12.freemysqlhosting.net;uid=sql12618175;pwd=b4Qb7gGzql;database=sql12618175";
 
    public static MySqlConnection conn =null;
       
   public  static MySqlConnection connect(){
       if(conn==null){
        conn=new MySqlConnection(connection);
    
       }
     return conn;
       
    }  

    
   

}
