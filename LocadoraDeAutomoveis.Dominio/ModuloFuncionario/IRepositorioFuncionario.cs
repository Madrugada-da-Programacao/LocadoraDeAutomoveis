using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {
        Funcionario? SelecionarPorNome(string nome);
    }
}
