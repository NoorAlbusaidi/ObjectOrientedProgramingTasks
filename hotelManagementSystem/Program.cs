using System.Globalization;
using System.Xml.Linq;
using static hotelManagementSystem.Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hotelManagementSystem
{
    internal class Program
    {
        public static void AddNewRoom(List<Room> rooms)
        {
            List<string> roomTypes = new List<string> { "single", "double", "suite" };
            int roomNumber;
            string roomType;
            double nightPrice;

            //room number
            Console.Write("Enter a room number: ");
            //validate the room number to enter only integers
            while (!int.TryParse(Console.ReadLine(), out roomNumber)|| roomNumber<0)
            {
                Console.WriteLine("Invalid input! Please enter a valid room number.");
                Console.Write("Enter the room number: ");
            }
            bool availableRoom = rooms.Any(r => r.RoomNumber == roomNumber);
            if (availableRoom)
            {
                Console.WriteLine("The room is already booked");
                return;
            }

            //Room type
            Console.Write("Enter a room type( (Single / Double / Suite)): ");
            roomType = Console.ReadLine();
            roomType = roomType.Trim().ToLower();
            while (!roomTypes.Contains(roomType))
            {
                Console.WriteLine("Invalid room type.");
                Console.Write("Please enter Single, Double, or Suite: ");
                roomType = Console.ReadLine().Trim().ToLower();
            }
            //price per night
            Console.Write("Enter the price: ");
            //validate the price
            while (!double.TryParse(Console.ReadLine(), out nightPrice)|| nightPrice<0)
            {
                Console.WriteLine("Invalid input! Please enter a valid price.");
                Console.Write("Enter the price: ");
            }
            rooms.Add(new Room(roomNumber, roomType, nightPrice));
            Console.WriteLine("Room added successfully");
        }
        public static void RegisterNewGuest(List<Guest> guests) {
            string guestName;
            string checkInDate;
            DateTime parsedDate;
            int nights;
            int nextNumber;
            string guestId;

            //validate guest name
            Console.Write("Enter the guest name: ");
            guestName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(guestName))
            {
                Console.WriteLine("Invalid name. Try again");
                Console.Write("Enter the guest name: ");
                guestName = Console.ReadLine();
            }

            // validate check-in date
            //DateTime.TryParseExact(input, format, culture, style, out result)
            //dd → day (01–31), MM → month (01–12), yyyy → full year
            //CultureInfo.InvariantCulture: Ignore computer settings — use a fixed, standard interpretation
            //DateTimeStyles.None, No special rules, Just strict parsing
            // If parsing succeeds: the date is stored in parsedDate

            Console.Write("Enter check-in date (dd-MM-yyyy): ");
            while (!DateTime.TryParseExact(
           Console.ReadLine(),
           "dd-MM-yyyy",
           CultureInfo.InvariantCulture,
           DateTimeStyles.None,
           out parsedDate))
            {
                Console.WriteLine("Invalid date format. Try again (dd-MM-yyyy)");
                Console.Write("Enter check-in date (dd-MM-yyyy): ");
            }

            checkInDate = parsedDate.ToString("dd-MM-yyyy");

            //validate nights#
            Console.Write("number of nights: ");
            while (!int.TryParse(Console.ReadLine(), out nights) || nights<0)
            {
                Console.WriteLine("Invalid nights number ");
                Console.Write("number of nights: ");
            }

            nextNumber = guests.Count + 1;
            guestId = "G" + nextNumber.ToString("D3");

            //(string id, string name, DateTime date, int nights)
            guests.Add(new Guest(guestId, guestName, checkInDate, nights));
            Console.WriteLine("Guest added successfully");
        }

        public class Room {
            //attributes
             public int RoomNumber;
            public string RoomType;
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
            public string guestId { get; }
            public string guestName;
            public int RoomNumber;
            public string checkInDate { get; }
            public int totalNights { get; }

            public Guest(string id, string name, string date, int nights) {
                guestId = id;
                guestName = name;
                checkInDate = date;
                totalNights = nights;
                RoomNumber = 0;


            }
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
                Console.WriteLine("Invalid input!");
                Console.Write("Enter your choice: ");
            }
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        AddNewRoom(rooms);
                        break;

                    case 2:
                        RegisterNewGuest(guests);
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
