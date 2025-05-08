using api.Infrastructure.Extensions.SentimentExtensions.Objs;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Extensions.SentimentExtensions
{
    public class SentimentAnalyzer : ISentimentAnalyzer
    {
        private readonly ILogger<SentimentAnalyzer> _logger;
        private readonly PredictionEngine<SentimentData, SentimentPrediction> _predictionEngine;

        public SentimentAnalyzer(ILogger<SentimentAnalyzer> logger)
        {
            _logger = logger;
            try
            {
                // Initialize ML.NET
                var mlContext = new MLContext();

                // load the data
                //var data = mlContext.Data.LoadFromTextFile<SentimentData>("data/sentiment_data.csv", separatorChar: ',', hasHeader: true); // for csv files
                //var dir = System.IO.Directory.GetCurrentDirectory();
                var data = mlContext.Data.LoadFromTextFile<SentimentData>("yelp_labelled.txt", hasHeader: false);

                // prepare pipeline
                var pipeline = mlContext.Transforms.Expression("Label", "(x) => x == 1 ? true : false", "Sentiment")
                    .Append(mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text)))
                    .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression());

                // Train the model
                var model = pipeline.Fit(data);

                _predictionEngine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error initializing SentimentAnalyzer");
                throw;
            }
        }

        public float AnalyzeSentiment(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                _logger.LogWarning("Text is null or empty");
                return 0.5f;
            }

            try
            {
                var input = new SentimentData { Text = text };
                var prediction = _predictionEngine.Predict(input);
                return prediction.Probability;
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error analyzing sentiment");
                return 0.5f;
            }

            // simple logic - AI generated
            // Placeholder for sentiment analysis logic
            // In a real implementation, you would use a library or API to analyze the sentiment of the text
            // For example, you could use a machine learning model or a third-party sentiment analysis API
            // For demonstration purposes, let's assume a simple sentiment score calculation
            // Positive words increase the score, negative words decrease it
            //string[] positiveWords = { "good", "happy", "great", "excellent", "positive" };
            //string[] negativeWords = { "bad", "sad", "terrible", "awful", "negative" };
            //float score = 0;
            //foreach (var word in text.Split(' '))
            //{
            //    if (positiveWords.Contains(word.ToLower()))
            //    {
            //        score += 1;
            //    }
            //    else if (negativeWords.Contains(word.ToLower()))
            //    {
            //        score -= 1;
            //    }
            //}
            //return score;
        }
    }
}
