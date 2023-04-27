namespace MikeCars.Infraestructure.Repository.Sql;

static internal class FuncionarioSql
{
	internal const string Create = @"
		DECLARE @PessoaFisicaId TABLE (id INT);
		DECLARE @FuncionarioId TABLE (id INT);
		DECLARE @AgenteId TABLE (id INT);
		DECLARE @DocumentoId TABLE (id INT);
		DECLARE @ContatoInfoId TABLE (id INT);
		DECLARE @EnderecoId TABLE (id INT);

		INSERT INTO [T_PESSOA_FISICA] ([Nome],[Sobrenome],[Nascimento])
		OUTPUT inserted.id INTO @PessoaFisicaId
		VALUES(@Nome,@Sobrenome,@Nascimento)


		INSERT INTO [T_FUNCIONARIO] ([Salario],[Admissao],[Ativo],[PessoaFisicaId], [InicioExpediente], [TerminoExpediente])
		OUTPUT inserted.id INTO @FuncionarioId
		VALUES(@Salario,@Admissao,1,(SELECT TOP 1 id FROM @PessoaFisicaId),@InicioExpediente,@TerminoExpediente)


		INSERT INTO [T_DOCUMENTO]([Numero])
		OUTPUT inserted.id INTO @DocumentoId
		VALUES(@NumeroDocumentoFormatado);


		INSERT INTO [T_CONTATO_INFO]([Email],[Telefone],[Celular])
		OUTPUT inserted.id INTO @ContatoInfoId
		VALUES(@Email,@TelefoneResidencial,@TelefoneCelular);


		INSERT INTO [T_ENDERECO]([Logradouro],[Cidade],[Numero],[Bairro],[PontoReferencia],[Cep],[Uf])
		OUTPUT inserted.id INTO @EnderecoId
		VALUES(@Logradouro,@Cidade,@Numero,@Bairro,@PontoReferencia,@Cep,@Uf);


		INSERT INTO [T_AGENTE]([DocumentoId],[EnderecoId],[ContatoInfoId],[PessoaFisicaId])
		OUTPUT inserted.id INTO @AgenteId
		VALUES
		(
			(SELECT TOP 1 id FROM @DocumentoId),
			(SELECT TOP 1 id FROM @EnderecoId),
			(SELECT TOP 1 id FROM @ContatoInfoId),
			(SELECT TOP 1 id FROM @PessoaFisicaId)
		);


		UPDATE [T_PESSOA_FISICA] 
		SET [AgenteId] = (SELECT TOP 1 id FROM @AgenteId)
		WHERE [Id] = (SELECT TOP 1 id FROM @PessoaFisicaId);


		UPDATE [T_FUNCIONARIO] 
		SET [PessoaFisicaId] = (SELECT TOP 1 id FROM @PessoaFisicaId)
		WHERE Id = (SELECT TOP 1 id FROM @FuncionarioId);


		UPDATE [T_DOCUMENTO] 
		SET [AgenteId] = (SELECT TOP 1 id FROM @AgenteId)
		WHERE Id = (SELECT TOP 1 id FROM @DocumentoId);


		UPDATE [T_CONTATO_INFO] 
		SET [AgenteId] = (SELECT TOP 1 id FROM @AgenteId)
		WHERE [Id] = (SELECT TOP 1 id FROM @ContatoInfoId);


		UPDATE [T_ENDERECO] 
		SET [AgenteId] = (SELECT TOP 1 id FROM @AgenteId)
		WHERE [Id] = (SELECT TOP 1 id FROM @EnderecoId);


		UPDATE T_ENDERECO 
		SET [AgenteId] = (SELECT TOP 1 id FROM @AgenteId)
		WHERE [Id] = (SELECT TOP 1 id FROM @EnderecoId);
    ";

	internal const string Get = @"
		SELECT 
			*
		FROM T_FUNCIONARIO funcionario
			inner join T_PESSOA_FISICA pf
				on pf.Id = funcionario.PessoaFisicaId
			inner join T_AGENTE agente
				on agente.PessoaFisicaId = pf.Id
			inner join T_CONTATO_INFO contato
				on contato.AgenteId = agente.Id
			inner join T_ENDERECO endereco
				on endereco.AgenteId = agente.Id
			inner join T_DOCUMENTO documento
				on documento.AgenteId = agente.Id		
	";
}
