namespace ConfigFileReader
{
    public class ConfigSetting
    {
        public ConfigSetting(string line)
        {
            GetSetting(line);
        }

        public string Key { get; set; }
        public string Value { get; set; }

        public void GetSetting(string line)
        {
            int equalSignIndex = line.IndexOf('=');
            Key = line.Substring(0, equalSignIndex);
            Value = line.Substring(equalSignIndex + 1);
        }
    }    
}
