namespace FormulaOne.API.Dtos.Requests
{
    public class UpdateAchievementRequest
    {
        public Guid DriverId { get; set; }
        public int PolePosition { get; set; }
        public int FastestLap { get; set; }
        public int WorldChampionship { get; set; }
        public int Wins { get; set; }
    }
}
