
namespace FisherYates.Algorithm
{
    using System.Text;

    public class ShufflerService : IShufflerService
    {
        private readonly ILogger<ShufflerService> _logger;

        public ShufflerService(ILogger<ShufflerService> logger){ 
            _logger = logger; 
        }


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
            Random rand = new Random();
            var array = input.Split("-");
            int n = array.Length;
            for (int i = n - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                array = Swap(array, i, j);
            }
            return array;
        }

        public string ConvertBackToString(string[] input) {
            //convert back to dash separated output
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                sb.Append(item + "-");
            }
            return sb.ToString().Substring(0,sb.Length-1);
        }
    
        private string[] Swap(string[] arr, int i, int j)
        {
            string temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            return arr;
        }
    }
}
