using System.Text;

namespace JNGV.TALKDESK.API.Repository
{
    public class ApiRepository : IApiRepository
    {
        private readonly IConfiguration _configuration;
        public ApiRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public List<string> ReadFile()
        {
            string path = String.Concat(Environment.CurrentDirectory + _configuration.GetValue<string>("FileOfPrefixs"));
            List<string> result = new List<string>();

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }

            return result;
        }
    }
}
