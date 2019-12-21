namespace CarService.Repository.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public CarModel Model { get; set; }
        public int Year { get; set; }
        public double EngineCapacity { get; set; }

    }
}