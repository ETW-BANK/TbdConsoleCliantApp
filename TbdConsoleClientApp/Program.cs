using System.Text.Json;
using System.Text;
using Newtonsoft.Json;

namespace TbdConsoleClientApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await GetUsersNew();
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
                    var option = new JsonSerializerOptions();
                    option.WriteIndented = true;
                    string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    try
                    {
                        var response = await client.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();
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

            public static async Task GetUsernew()
            {

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

            public static async Task GetArtistsNew()
        {

        }

            public static async Task GetSongsNew()
        {

        }

            public static async Task GetGenresNew()
           {

           }

            static async Task<string> GetRelated(int artistId)
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"https://deezerdevs-deezer.p.rapidapi.com/artist/{artistId}";



                    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "597c529c02msh24cd8fda8287734p115600jsn5390d57dc0a0");
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "deezerdevs-deezer.p.rapidapi.com");

                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return string.Empty;
                    }
                }
            }

            static async Task<string> GetArtist(string ArtistName)
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"https://deezerdevs-deezer.p.rapidapi.com/search?q={ArtistName}";



                    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "597c529c02msh24cd8fda8287734p115600jsn5390d57dc0a0");
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "deezerdevs-deezer.p.rapidapi.com");

                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return string.Empty;
                    }
                }

            }
        }
    }
