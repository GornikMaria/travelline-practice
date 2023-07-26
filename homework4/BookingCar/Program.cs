using Core.Models;
using DatabaseProvider;
using DatabaseProvider.Repositories.Abstractions;
using DatabaseProvider.Repositories.Implementations;

namespace BookingCar
{
    public class Program
    {
        private const string ConnectionString =
            "Data Source=LAPTOP-R69EMDDL\\SQLEXPRESS;Initial Catalog=BookingCar;Pooling=true;Integrated Security=SSPI";

        private static ApplicationContext _applicationContext;
        private static IClientRepository _clientRepository;
        private static IBookingDataRepository _bookingDataRepository;
        private static ICarRepository _carRepository;

        public static void Main(string[] args)
        {
            _applicationContext = new ApplicationContext(ConnectionString);
            _clientRepository = new ClientRepository(_applicationContext);
            _bookingDataRepository = new BookingDataRepository(_applicationContext);
            _carRepository = new CarRepository(_applicationContext);

            ProcessCommands();
        }

        public static void ProcessCommands()
        {
            bool exitRequested = false;

            while (!exitRequested)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Ввести команду");
                Console.WriteLine("2) Выйти из программы");

                Console.Write("Выберите опцию: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter command: ");
                        string[] commandLine = Console.ReadLine().Split(' ');
                        string command = commandLine[0];
                        List<string> parameters = commandLine.Skip(1).ToList();
                        switch (command)
                        {
                            case "exit":
                                exitRequested = true;
                                break;
                            case "add-client":
                                AddClient(parameters);
                                break;
                            case "add-booking":
                                AddBookingData(parameters);
                                break;
                            case "add-car":
                                AddCar(parameters);
                                break;
                            case "delete-client":
                                DeleteClient(parameters);
                                break;
                            case "delete-booking":
                                DeleteBookingData(parameters);
                                break;
                            case "delete-car":
                                DeleteCar(parameters);
                                break;
                            case "list-clients":
                                ListClients();
                                break;
                            case "list-bookings":
                                ListBookingData();
                                break;
                            case "list-cars":
                                ListCars();
                                break;
                            default:
                                Console.WriteLine("Некорректная команда.");
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("Программа завершена.");
                        exitRequested = true;
                        break;
                    default:
                        Console.WriteLine("Некорректная опция. Пожалуйста, выберите снова.");
                        break;
                }
            }
        }

        public static void AddClient(List<string> parameters)
        {
            Client client = new Client
            {
                Name = parameters[0],
                Birthday = DateTime.Parse(parameters[1]),
                Address = parameters[2]
            };
            _clientRepository.Add(client);
            _clientRepository.SaveChanges();
        }

        public static void AddBookingData(List<string> parameters)
        {
            DateTime startDate = DateTime.Parse(parameters[0]);
            DateTime endDate = DateTime.Parse(parameters[1]);
            decimal pay = decimal.Parse(parameters[2]);
            int clientId = int.Parse(parameters[3]);
            Client client = _clientRepository.GetById(clientId);
            BookingData bookingData = new BookingData
            {
                StartDate = startDate,
                EndDate = endDate,
                Pay = pay
            };
            _bookingDataRepository.Add(bookingData);
            _bookingDataRepository.SaveChanges();
        }

        public static void AddCar(List<string> parameters)
        {
            string name = parameters[0];
            DateTime creationDate = DateTime.Parse(parameters[1]);
            int price = int.Parse(parameters[2]);
            int rating = int.Parse(parameters[3]);
            int clientId = int.Parse(parameters[4]);
            Client client = _clientRepository.GetById(clientId);
            Car car = new Car
            {
                Name = name,
                CreationDate = creationDate,
                Price = price,
                Rating = rating,
                Client = client
            };
            _carRepository.Add(car);
            _carRepository.SaveChanges();
        }

        public static void DeleteClient(List<string> parameters)
        {
            int clientId = int.Parse(parameters[0]);
            Client client = _clientRepository.GetById(clientId);
            _clientRepository.Remove(client);
            _clientRepository.SaveChanges();
        }

        public static void DeleteBookingData(List<string> parameters)
        {
            int bookingDataId = int.Parse(parameters[0]);
            BookingData bookingData = _bookingDataRepository.GetById(bookingDataId);
            _bookingDataRepository.Remove(bookingData);
            _bookingDataRepository.SaveChanges();
        }

        public static void DeleteCar(List<string> parameters)
        {
            int carId = int.Parse(parameters[0]);
            Car car = _carRepository.GetById(carId);
            _carRepository.Remove(car);
            _carRepository.SaveChanges();
        }

        public static void PrintListOfClients()
        {
            foreach (var client in _clientRepository.GetAll())
            {
                Console.WriteLine(client);
            }
        }

        public static void PrintListOfBookingData()
        {
            foreach (var bookingData in _bookingDataRepository.GetAll())
            {
                Console.WriteLine(bookingData);
            }
        }

        public static void PrintListOfCars()
        {
            foreach (var car in _carRepository.GetAll())
            {
                Console.WriteLine(car);
            }
        }
    }
}

