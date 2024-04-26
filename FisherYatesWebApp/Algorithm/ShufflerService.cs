
namespace FisherYates.Algorithm
{
    public class ShufflerService : IShufflerService
    {
        private readonly ILogger _logger;

        public ShufflerService(ILogger logger) => _logger = logger;


        public bool Validate(string input)
        {
            // Test input is in the required format
            // reject if it contains numbers or special characters
            // do not reject if lower case only/mixed case
            bool retval = false;
            try
            {
                var array = input.Split("-");
                foreach (var item in array)
                {
                    var isNumeric = int.TryParse(item, out _);
                    if (isNumeric) return false;

                    retval = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                retval = false;
            }
            return retval;
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
