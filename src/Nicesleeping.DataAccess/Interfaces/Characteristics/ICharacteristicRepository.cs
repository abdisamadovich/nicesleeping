using Nicesleeping.DataAccess.Common.Interfaces;
using Nicesleeping.Domain.Entities.Characteristics;

namespace Nicesleeping.DataAccess.Interfaces.Characteristics;

public interface ICharacteristicRepository : IRepository<Characteristic, Characteristic>,
    IGetAll<Characteristic>,ISearchable<Characteristic>
{}
