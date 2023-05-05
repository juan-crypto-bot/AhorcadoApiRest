using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest{
    public interface IWordService{
        Word SelectRandomWord();

    }
    public class WordService : IWordService{

        private readonly ILogger<PlayerService> _logger;

        private readonly HangedDbContext _db;
        public WordService(ILogger<PlayerService> logger, HangedDbContext db){
            _db = db;
            _logger = logger;
            //_db.Database.EnsureCreated();    
        }

        public Word SelectRandomWord(){
            return _db.Word.OrderBy(o => Guid.NewGuid()).FirstOrDefault(); 
        }
    }
}
