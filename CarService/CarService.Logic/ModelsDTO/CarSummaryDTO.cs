namespace CarService.Logic.ModelsDTO
{
    public class CarSummaryDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double EngineCapacity { get; set; }
        public string Transmission { get; set; }
        public int Odometer { get; set; }
        public string Fuel { get; set; }
        public int EnginePower { get; set; }
        public string UserId { get; set; }
    }
}