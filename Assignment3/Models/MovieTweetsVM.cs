using System.ComponentModel;
using Tweetinvi;
using VaderSharp2;

namespace Assignment3.Models
{
    public class MovieTweetsVM
    {
        public Movie? Movie { get; set; }
        public List<MovieTweets>? MovieResults { get; set; }

        public double? Sentiment { get; set; }



        public double CompoundSentiment()
        {
            if (MovieResults == null)
            {
                return 0;
            }
            else
            {
                int count = 0;
                double total = 0.0;

                foreach (MovieTweets tweet in MovieResults)
                {
                    if (tweet.Sentiment != 0)
                    {
                        count++;
                        total += tweet.Sentiment;
                    }
                }
                double finalSentiment = Math.Round((total / MovieResults.Count), 2);

                return finalSentiment;
            }
                
        }
    }
}
