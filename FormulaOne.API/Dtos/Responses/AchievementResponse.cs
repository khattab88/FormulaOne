namespace FormulaOne.API.Dtos.Responses
{
    public class AchievementResponse
    {
        public int RaceWins { get; set; }
        public int PolePosition { get; set; }
        public int FastestLap { get; set; }
        public int WorldChampionship { get; set; }
        public Guid DriverId { get; set; }
    }
}
