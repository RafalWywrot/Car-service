namespace CarService.Repository.Entities
{
    public class CarModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool Active { get; set; }

        public virtual CarBrand Brand { get; set; }
    }
}