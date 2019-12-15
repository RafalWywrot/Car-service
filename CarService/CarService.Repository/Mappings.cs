using CarService.Repository.Entities;
using FluentNHibernate.Mapping;

namespace CarService.Repository
{
    public class Mappings : ClassMap<FirstMappedClass>
    {
        public Mappings() 
        {
            Table("TestClass");

            Id(x => x.Id);
            Map(x => x.Name, "Name").Not.Nullable();
            Map(x => x.Surname, "Surname").Not.Nullable();
        }
    }
}