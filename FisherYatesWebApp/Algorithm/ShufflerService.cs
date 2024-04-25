
namespace FisherYates.Algorithm
{
    public class ShufflerService : IShufflerService
    {

        public bool Validate(string input)
        {
            // Test input is in the required format
            // reject if it contains numbers or special characters
            // do not reject if lower case only/mixed case
            throw new NotImplementedException();
        }

        public string[] Shuffle(string input)
        {
            // assuming input is in the required format
            // perform shuffle (see https://exceptionnotfound.net/understanding-the-fisher-yates-card-shuffling-algorithm/)
            throw new NotImplementedException();
        }

        public string ConvertBackToString(string[] input) { 
            //convert back to dash separated output
            throw new NotImplementedException();
        }
    }
}
