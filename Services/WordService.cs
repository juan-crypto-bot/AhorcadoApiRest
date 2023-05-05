using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest{
    public interface IWordService{
        //Player FindPlayerById(int id);

    }
    public class WordService : IWordService{

        private readonly ILogger<PlayerService> _logger;

        private readonly HangedDbContext _db;
        public WordService(ILogger<PlayerService> logger, HangedDbContext db){
            _db = db;
            _logger = logger;
            //_db.Database.EnsureCreated();    
        }

       /* public Word SelectWord(){
            SqlConnection connection = new SqlConnection("Server=DESKTOP-1I6R14U;Database=Hanged;Integrated Security=false;Trusted_Connection=True;MultipleActiveResultSets=true");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Word ORDER BY NEWID()", connection);
            SqlDataReader reader = command.ExecuteReader();
            Word word = new Word();
            if(reader.Read()){
                word
            }
            reader.Close();
            connection.Close();*/
            
        }
    }
