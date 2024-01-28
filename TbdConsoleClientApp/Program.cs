using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using System;

namespace TbdConsoleClientApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            do
            {
                Console.WriteLine("\n\n");

                Console.WriteLine($"\t\t ============================================================\n");

                Console.WriteLine($"\t\t Press {"1"} to View All Users in the System");
                Console.WriteLine($"\t\t Press {"2"} to View A Specific User ");
                Console.WriteLine($"\t\t Press {"3"} to view Artists Related To A Specific User");
                Console.WriteLine($"\t\t Press {"4"} to view Genres Related To A Specific User");
                Console.WriteLine($"\t\t Press {"5"} to view Songs Related To A Specific User");
               
                Console.WriteLine($"\t\t Press {"0"} to exit\n");

                Console.WriteLine($"\t\t ============================================================\n");

                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {

               

                    case 0:

                        Environment.Exit(0);

                        break;
                    case 1:
                       
                        GetUsersNew();
                        EscapeKeyCall();
                        Console.Clear();
                        break;
                    case 2:

                        Console.WriteLine("Enter user Id");
                        int id = Convert.ToInt32(Console.ReadLine());
                        GetUsernew(id);
                        EscapeKeyCall();
                        Console.Clear();
                        break;


                    case 3:
                        Console.WriteLine("Enter user Id");
                        id = Convert.ToInt32(Console.ReadLine());
                        GetArtistsNew(id);
                        EscapeKeyCall();
                        Console.Clear();

                        break;

                    case 4:
                        Console.WriteLine("Enter user Id");
                        id = Convert.ToInt32(Console.ReadLine());
                         GetGenresNew(id);
                        EscapeKeyCall();
                        Console.Clear();
                        break;

                    case 5:
                        Console.WriteLine("Enter user Id");
                        id = Convert.ToInt32(Console.ReadLine());
                        GetSongsNew(id);
                        Console.WriteLine("\n");
                        EscapeKeyCall();
                        Console.Clear();
                        break;


     

                    default:

                        Console.WriteLine("\n\t\t\t\u001b[31m Wrong Choice. Please try agin\t\t\t\u001b[0m");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }




            } while (true);




           

            //await GetUsersNew();
            //await GetUsernew(id);
            //await GetArtistsNew(id);
            //await GetGenresNew(id);
            //await GetSongsNew(id);

            await AddArtist();
            




        }

        public static async Task AddUser()
        {

        }
        public static async Task AddArtist()
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("Enter the userId:");
                if (!int.TryParse(Console.ReadLine(), out int userId))
                {
                    Console.WriteLine("Invalid userId.");
                    return;
                }

                Console.WriteLine("Enter the Artist Name:");
                string artistName = Console.ReadLine();
                Console.WriteLine("Enter the Artist Description:");
                string artistDescription = Console.ReadLine();

                Console.WriteLine("Calling WebAPI....");

                string apiUrl = $"https://localhost:7224/AddArtists/{userId}";


                var payload = new List<object>
            {
                new { ArtistName = artistName, ArtistDescription = artistDescription }
            };

                string jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(result);
                        Console.WriteLine($"Result from API:\n{result}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

        public static async Task AddGenre()
        {

        }

        public static async Task AddSongs()
        {

        }

        public static async Task GetUsernew(int userid)
        {

            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("Calling WebAPI....");


                string apiUrl = $"https://localhost:7224/GetUser/{userid}";

                try
                {
                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Result from API:\n");


                        Console.WriteLine(JsonConvert.DeserializeObject($"{result}"));
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                Console.ReadLine();
            }
        }

        public static async Task GetUsersNew()
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("Calling WebAPI....");

                string apiUrl = "https://localhost:7224/GetUsers";

                try
                {
                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Result from API:\n");


                        Console.WriteLine(JsonConvert.DeserializeObject($"{result}"));
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                Console.ReadLine();
            }
        }

        public static async Task GetArtistsNew(int userid)
        {
            
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("Calling WebAPI....");


                string apiUrl = $"https://localhost:7224/GetArtists/{userid}";

                try
                {
                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Result from API:\n");


                        Console.WriteLine(JsonConvert.DeserializeObject($"{result}"));
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                Console.ReadLine();
            }
        }

        public static async Task GetSongsNew(int userid)
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("Calling WebAPI....");


                string apiUrl = $"https://localhost:7224/GetSongs/{userid}";

                try
                {
                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Result from API:\n");


                        Console.WriteLine(JsonConvert.DeserializeObject($"{result}"));
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                Console.ReadLine();
            }

        }

        public static async Task GetGenresNew(int userid)
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("Calling WebAPI....");


                string apiUrl = $"https://localhost:7224/GetGenres/{userid}";

                try
                {
                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Result from API:\n");


                        Console.WriteLine(JsonConvert.DeserializeObject($"{result}"));
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                Console.ReadLine();
            }
        }

        public static void EscapeKeyCall()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t\t\u001b[0m Press \u001b[34m ESC \u001b[0m to exit");

            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;

                if (key != ConsoleKey.Escape)
                {
                    Console.WriteLine("\n\t\t\t\u001b[31m Wrong key pressed. Press \u001b[34m ESC\u001b[0m \u001b[31m to exit.\t\t\t\u001b[0m");
                }
            } while (key != ConsoleKey.Escape);
        }



    }
}
