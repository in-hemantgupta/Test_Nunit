namespace TestNinja.Mocking
{
    public interface IEmailer
    {
        void Email(string emailAddress, string subject, string emailBody, string filename);
    }
}