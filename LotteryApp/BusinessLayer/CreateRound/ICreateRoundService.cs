using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace BusinessLayer.CreateRound
{
    public interface ICreateRoundService
    {
        RoundViewModel ActivateRound();
    }
}
