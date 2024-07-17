﻿using DojoKitaoApp.Libraries.Domain.Entities;
using DojoKitaoApp.Libraries.Domain.Interfaces.Repositories;
using DojoKitaoApp.Libraries.Infrastructure.Data.Context;
using DojoKitaoApp.Libraries.Infrastructure.Data.Repositories.Base;

namespace DojoKitaoApp.Libraries.Infrastructure.Data.Repositories;

public class EnderecoRepository(AppDbContext context) : BaseRepository<Endereco>(context), IEnderecoRepository
{
}
