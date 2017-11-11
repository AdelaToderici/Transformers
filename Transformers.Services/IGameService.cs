using System.Collections.Generic;

namespace Transformers.Services
{
    public interface IGameService
    {
        GameScore ComputeScore(List<Transformer> transformers);
    }
}