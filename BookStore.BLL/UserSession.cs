using BookStore.Entities;

namespace BookStore.BLL
{
    public static class UserSession
    {
        public static User CurrentUser { get; set; }
    }
}