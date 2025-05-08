using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Extensions.SentimentExtensions
{
    public interface ISentimentAnalyzer
    {
        float AnalyzeSentiment(string text);
    }
}
