namespace CarService.Logic.Services.Abstract
{
    public interface IBookingService
    {
        /// <param name="id">Booking service id</param>
        void SetStatusAsVerified(int id);
        void SetStatusAsAccepted(int id);
        void SetStatusAsDeclined(int id);
        void SetStatusInProgress(int id);
        void SetStatusAsFinished(int id);
        void AssignUser(int serviceBookingId, string user);
    }
}