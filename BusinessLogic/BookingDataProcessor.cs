using Book_My_Table.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_My_Table.DataAccess;

namespace Book_My_Table.BusinessLogic
{
    public class BookingDataProcessor
    {
        public static int CreateBooking(int bookingId, int customerId, int restaurantId,
            DateTime bookingDate, DateTime bookingTime, int mealId)
        {
            Booking data = new Booking
            {
                BookingId = bookingId,
                CustomerId = customerId,
                RestaurantId = restaurantId,
                BookingDate = bookingDate,
                BookingTime = bookingTime,
                MealId = mealId
            };

            string sql = @"insert into dbo.Booking(BookingId, RestaurantId, CustomerId, CustomerName, CustomerAddress,
                            BookingDate, BookingTime, NoOfPeople, ContactNo, MealId) values (@BookingId, @CustomerId,
                            @RestaurantId, null, null, @BookingDate, @BookingTime, null, null, @MealId)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<Restaurant> LoadRestaurants()
        {
            string sql = @"Select Name from dbo.Restaurant;";
            return SqlDataAccess.LoadData<Restaurant>(sql);
        }
    }
}
