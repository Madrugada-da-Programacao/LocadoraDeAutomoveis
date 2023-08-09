namespace LocadoraDeAutomoveis.WinApp.Compartilhado.IoC
{
    //public class IoC_ComServiceLocator : IoC
    //{
    //    private Dictionary<string, ControladorBase> controladores;

    //    public IoC_ComServiceLocator()
    //    {
    //        controladores = new Dictionary<string, ControladorBase>();

    //        var configuracao = new ConfigurationBuilder()
    //           .SetBasePath(Directory.GetCurrentDirectory())
    //           .AddJsonFile("appsettings.json")
    //           .Build();

    //        var connectionString = configuracao.GetConnectionString("SqlServer");

    //        var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeAutomoveisDbContext>();

    //        optionsBuilder.UseSqlServer(connectionString);

    //        LocadoraDeAutomoveisDbContext dbContext = new LocadoraDeAutomoveisDbContext(optionsBuilder.Options);

    //        var migracoesPendentes = dbContext.Database.GetPendingMigrations();

    //        if (migracoesPendentes.Count() > 0)
    //        {
    //            dbContext.Database.Migrate();
    //        }

    //        IRepositorioCliente RepositorioCliente = new RepositorioClienteEmOrm(dbContext);
    //        ValidadorCliente ValidadorCliente = new ValidadorCliente();
    //        ServicoCliente ServicoCliente = new ServicoCliente(RepositorioCliente, ValidadorCliente, dbContext);
    //        controladores.Add("ControladorCliente", new ControladorCliente(RepositorioCliente, ServicoCliente));

    //        IRepositorioFuncionario RepositorioFuncionario = new RepositorioFuncionarioEmOrm(dbContext);
    //        ValidadorFuncionario ValidadorFuncionario = new ValidadorFuncionario();
    //        ServicoFuncionario ServicoFuncionario = new ServicoFuncionario(RepositorioFuncionario, ValidadorFuncionario, dbContext);
    //        controladores.Add("ControladorFuncionario", new ControladorFuncionario(RepositorioFuncionario, ServicoFuncionario));

    //        IRepositorioGrupoDeAutomoveis RepositorioGrupoDeAutomoveis = new RepositorioGrupoDeAutomoveisOrm(dbContext);
    //        ValidadorGrupoDeAutomoveis ValidadorGrupoDeAutomoveis = new ValidadorGrupoDeAutomoveis();
    //        ServicoGrupoDeAutomoveis ServicoGrupoDeAutomoveis = new ServicoGrupoDeAutomoveis(RepositorioGrupoDeAutomoveis, ValidadorGrupoDeAutomoveis, dbContext);
    //        controladores.Add("ControladorGrupoDeAutomoveis", new ControladorGrupoDeAutomoveis(RepositorioGrupoDeAutomoveis, ServicoGrupoDeAutomoveis));

    //        IRepositorioTaxaOuServico RepositorioTaxaOuServico = new RepositorioTaxaOuServicoEmOrm(dbContext);
    //        ValidadorTaxaOuServico ValidadorTaxaOuServico = new ValidadorTaxaOuServico();
    //        ServicoTaxaOuServico ServicoTaxaOuServico = new ServicoTaxaOuServico(RepositorioTaxaOuServico, ValidadorTaxaOuServico, dbContext);
    //        controladores.Add("ControladorTaxaOuServico", new ControladorTaxaOuServico(RepositorioTaxaOuServico, ServicoTaxaOuServico));

    //        IRepositorioPlanoDeCobranca RepositorioPlanoDeCobranca = new RepositorioPlanoDeCobrancaEmOrm(dbContext);
    //        ValidadorPlanoDeCobranca ValidadorPlanoDeCobranca = new ValidadorPlanoDeCobranca();
    //        ServicoPlanoDeCobranca ServicoPlanoDeCobranca = new ServicoPlanoDeCobranca(RepositorioPlanoDeCobranca, ValidadorPlanoDeCobranca, dbContext);
    //        controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(RepositorioPlanoDeCobranca, ServicoPlanoDeCobranca, RepositorioGrupoDeAutomoveis));

    //        IRepositorioParceiro RepositorioParceiro = new RepositorioParceiroEmOrm(dbContext);
    //        ValidadorParceiro ValidadorParceiro = new ValidadorParceiro();
    //        ServicoParceiro ServicoParceiro = new ServicoParceiro(RepositorioParceiro, ValidadorParceiro, dbContext);
    //        controladores.Add("ControladorParceiro", new ControladorParceiro(RepositorioParceiro, ServicoParceiro));
    //    }

    //    public ControladorBase Get<T>()
    //    {
    //        Type tipo = typeof(T);

    //        string nome = tipo.Name;

    //        return controladores[nome];
    //    }
    //}
}
