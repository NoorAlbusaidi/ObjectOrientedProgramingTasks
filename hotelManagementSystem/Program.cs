namespace hotelManagementSystem
{
    internal class Program
    {
       public class Room {
            //attributes
            int RoomNumber { get; }
            string RoomType { get; }
            private double PricePerNight;
            private bool isAvailable;

            //constructor
            public Room(int room, string type, double nightPrice) {
                RoomNumber = room;
                RoomType = type;
                PricePerNight = nightPrice;
                isAvailable = true; // default
            }

            public void displayRoom() { 
            
            
            }

        }
        public class Guest
        {
            string guestId;
            string guestName;
            int roomNumber;
            DateTime checkInDate;
            int totalNights;

            public void displayGuest() { }
            public void calculateTotalCost() { }

        }
        static void Main(string[] args)
        {
            int choice;
            List<Room> rooms = new List<Room>()
            {
                new Room(101, "Single", 25.0),
                new Room(102, "Single", 30.0),
                new Room(201, "Double", 50.0),
                new Room(202, "Double", 55.0),
                new Room(301, "Suite", 100.0),
                new Room(302, "Suite", 120.0)
            };
            
            List<Guest> guests = new List<Guest>();

            Console.WriteLine("================================================\r\nGRAND VISTA HOTEL — MANAGEMENT SYSTEM\r\n================================================\r\n1. Add New Room\r\n2. Register New Guest\r\n3. Book a Room for a Guest\r\n4. Search & Filter Rooms\r\n5. Guest & Booking Statistics\r\n6. Check Out a Guest\r\n7. Remove Unavailable Rooms\r\n0. Exit\r\n================================================");
            Console.Write("Enter your choice: ");
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                Console.Write("Enter your choice: ");
            }
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }//switch (choice)
                Console.WriteLine("================================================\r\nGRAND VISTA HOTEL — MANAGEMENT SYSTEM\r\n================================================\r\n1. Add New Room\r\n2. Register New Guest\r\n3. Book a Room for a Guest\r\n4. Search & Filter Rooms\r\n5. Guest & Booking Statistics\r\n6. Check Out a Guest\r\n7. Remove Unavailable Rooms\r\n0. Exit\r\n================================================");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
            }//while (choice != 0)
        }
    }
}
