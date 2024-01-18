﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IPerguntaRepository
    {
        Task<IEnumerable<Pergunta>> GetAllAsync();
    }
}
