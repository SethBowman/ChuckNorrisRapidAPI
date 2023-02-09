using RestSharp;
using Newtonsoft.Json;


for (int i = 1; i <= 5; i++)
{
    var joke = Root.GetJoke();
    Console.WriteLine($"Chuck Norris Joke #{i}: {joke.Value}");
    Console.WriteLine();
}