namespace CarService.Logic.ModelsDTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public CarModelDTO Model { get; set; }
        public int Year { get; set; }
        public double EngineCapacity { get; set; }
        public int TransmissionId { get; set; }
        public int Odometer { get; set; }
        public int FuelTypeId { get; set; }
        public int EnginePower { get; set; }

        public string CarOwnerFullName { get; set; }
    }
}