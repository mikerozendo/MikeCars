using MikeCars.Domain.Entities;
using MikeCars.Domain.Interfaces.Services.Generic;

namespace MikeCars.Domain.Interfaces.Services;

public interface IPessoaService : IPessoaGenericService<PessoaFisica>, IPessoaGenericService<PessoaJuridica> { }
