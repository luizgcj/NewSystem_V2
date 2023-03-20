namespace NewSystem.Business.Models
{
    public abstract class Entity //com o abstract, a classe não pode ser instanciada, apenas herdada
    {
        public Entity()
        {
            Id = Guid.NewGuid();     
        }
        public Guid Id { get; set; }
    }
}
