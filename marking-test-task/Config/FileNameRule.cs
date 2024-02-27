namespace marking_test_task.Config
{
    public class FileNameRule
    {
        public static string GetFileName(string gtin)
        {
            string dateAndTime = DateTime.Now.ToString("ddMMyy_HHmm");
            return $"{gtin}_result_file_{dateAndTime}.json";
        }
    }
}
