using LocadoraDeAutomoveis.Dominio;

namespace LocadoraDeAutomoveis.WinApp.Compartilhado
{

    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade disciplina)
        where TEntidade : EntidadeBase<TEntidade>;    
    
}
