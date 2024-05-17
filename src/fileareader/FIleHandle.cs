    class FileHandler : IDisposable
    {
        private readonly string _root;
        public FileHandler (string root) {
            _root = root;
        }
        public IList <string> ReadLines() {
             List<string> lines = new List<string>();

            
            if (File.Exists(_root))
            {
                using (StreamReader reader = new StreamReader(_root))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException($"El archivo {_root} no fue encontrado.");
            }

            return lines;
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose enter");
        }
    }