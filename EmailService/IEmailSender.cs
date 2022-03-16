namespace portfolio_backend.EmailService  {
    public interface IEmailSender{
        void SendEmail(Message message);
    }
}