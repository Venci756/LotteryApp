using DataLayer.Round;
using DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels;
using BusinessLayer.Helpers;

namespace BusinessLayer.CreateRound
{
    public class CreateRoundService : ICreateRoundService
    {
        private readonly IRoundRepository _roundRepository;
        private readonly GenerateNumbersHelper _helper;
        public CreateRoundService(IRoundRepository roundRepository, GenerateNumbersHelper helper)
        {
            _roundRepository = roundRepository;
            _helper = helper;
        }
        //private Random _rnd = new Random();
        //public string drawNumbers(int numLimit, int numAmount)
        //{
           
        //    return string.Join(",",
        //        Enumerable
        //            .Range(1, numLimit)
        //            .OrderBy(x => _rnd.Next())
        //            .Take(numAmount));
        //}
        public RoundViewModel ActivateRound()
        {
            var round = new RoundViewModel()
            {

                WinningCombination = _helper.GenerateNumbers(37, 7)
               
            };

            var createdRound = new RoundResults()
            {
                WinningCombination = round.WinningCombination
            };

        _roundRepository.CreateRound(createdRound);  

            return round;
        }
    }
}
        
