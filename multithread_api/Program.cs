using System.IO;

namespace multithread_api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      var env = builder.Environment;

      //set global thread worker pool
      int worker_min_threads = 32;

      // Get the current value of minWorker & minIOC.
      int minWorker, minIOC; ThreadPool.GetMinThreads(out minWorker, out minIOC);

      // Change the minimum number of worker threads to new value, but keep the old setting for minimum asynchronous I/O completion threads.
      if (ThreadPool.SetMinThreads(worker_min_threads, minIOC))
      {
        // The minimum number of threads was set successfully.
        Console.WriteLine("SetMinThreads >> to " + worker_min_threads + " succeded");
      }
      else
      {
        // The minimum number of threads was not changed.
        Console.WriteLine("SetMinThreads >> fail safe to default " + minWorker);
      }

      // Add services to the container.

      builder.Services.AddControllers();

      var app = builder.Build();

      // Configure the HTTP request pipeline.

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}