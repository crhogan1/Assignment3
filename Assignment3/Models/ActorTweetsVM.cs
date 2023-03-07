using System.ComponentModel;
using Tweetinvi;
using VaderSharp2;

namespace Assignment3.Models
{
    public class ActorTweetsVM
    {
        public Actor? Actor { get; set; }
        public List<ActorTweets>? ActorResults { get; set; }

        public double? Sentiment { get; set; }



        public double CompoundSentiment()
        {
            if (ActorResults == null)
            {
                return 0;
            }
            else
            {
                int count = 0;
                double total = 0.0;

                foreach (ActorTweets tweet in ActorResults)
                {
                    if (tweet.Sentiment != 0)
                    {
                        count++;
                        total += tweet.Sentiment;
                    }
                }
                double finalSentiment = Math.Round((total / ActorResults.Count), 2);

                return finalSentiment;
            }

        }
    }
}