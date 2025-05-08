using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Extensions.SentimentExtensions.Objs
{
    public class SentimentData
    {
        [LoadColumn(0)] // Assuming the 'Text' field is the first column
        public string Text { get; set; }
        [LoadColumn(1)]
        public float Sentiment { get; set; }
    }
}
