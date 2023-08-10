using LocadoraDeAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraDeAutomoveis.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorEmOrm : RepositorioBaseEmOrm<Condutor>, IRepositorioCondutor
    {
        public RepositorioCondutorEmOrm(LocadoraDeAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public Condutor? SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

        public List<Condutor> SelecionarTodosComCliente()
        {
            return registros.Include(c => c.Cliente).ToList();
        }
    }
}
