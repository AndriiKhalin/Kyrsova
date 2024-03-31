﻿using Kyrsova.Features;
using Microsoft.ML;

namespace Kyrsova.Interfaces;

public interface IProcessorRepository
{
    Task<IEnumerable<Processor>> GetAll();

    Task<Processor> GetById(int id);

    Task<Processor> GetByName(string name);

    Task Add(Processor processor);

    Task Update(Processor processor);

    Task Delete(int id);

    float CalculatePerformance(Processor processor);

}