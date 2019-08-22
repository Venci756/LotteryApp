using DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Round
{
    public class RoundRepository : IRoundRepository
    {
        private readonly LotteryAppContext _dbContext;
        public RoundRepository(LotteryAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateRound(RoundResults entity)
        {
            _dbContext.RoundResults.Add(entity);
            _dbContext.SaveChanges();
        }

    }
}
