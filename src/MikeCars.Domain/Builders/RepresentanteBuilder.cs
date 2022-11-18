using MikeCars.Domain.Entities;

namespace MikeCars.Domain.Builders;

public static class RepresentanteBuilder
{
    public static Representante WithCompany(this Representante representante, PessoaJuridica empresa)
    {
        representante.Empresa = empresa; return representante;
    }
}
