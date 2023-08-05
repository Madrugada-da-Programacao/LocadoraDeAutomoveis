using SequentialGuid;

namespace LocadoraDeAutomoveis.Dominio
{
    public abstract class EntidadeBase<T>
    {
        public Guid Id { get; set; }

		public EntidadeBase()
		{
			Id = SequentialGuidGenerator.Instance.NewGuid();
		}

		public virtual void Atualizar(T registro)
		{

		}
    }
}