namespace StudyBuddy.Core.Configurations
{
   public class EmailConfiguration
   {
      public string ToAddress { get; set; } = null!;
      public string Subject { get; set; } = null!;
      public string Body { get; set; } = null!;

      public EmailConfiguration(string toAddress, string subject, string body)
      {
         ToAddress = toAddress;
         Subject = subject;
         Body = body;
      }
   }
}