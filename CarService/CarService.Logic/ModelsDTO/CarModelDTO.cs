namespace CarService.Logic.ModelsDTO
{
    public class CarModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CarBrandDTO Brand { get; set; }
    }
}