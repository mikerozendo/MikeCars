using MikeCars.Domain.Entities;

namespace MikeCars.Domain.Builders;

public static class PessoaJuridicaBuilder
{
    public static PessoaJuridica WithRepresentativePerson(this PessoaJuridica pessoaJuridica, Representante representate)
    {
        pessoaJuridica.Representante = representate; return pessoaJuridica;
    }
}
