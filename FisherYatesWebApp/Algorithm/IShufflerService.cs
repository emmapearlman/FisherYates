namespace FisherYates.Algorithm
{
    public interface IShufflerService
    {
        public bool Validate(string input);
        public string[] Shuffle(string input);
        public string ConvertBackToString(string[] input);
    }
}
