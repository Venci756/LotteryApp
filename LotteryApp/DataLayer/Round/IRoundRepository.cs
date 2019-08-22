using DtoModels;

namespace DataLayer.Round
{
    public interface IRoundRepository
    {
        void CreateRound(RoundResults round);
    }
}