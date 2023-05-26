using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace HelloWorld
{
    public class Program
    {
        private static readonly string Address = "http://localhost:8080/";

        public static void Main(string[] args)
        {
            using (HttpListener listener = new())
            {
                listener.Prefixes.Add(Address);
                listener.Start();

                Console.WriteLine("Listening for requests at", Address);

                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    ThreadPool.QueueUserWorkItem(HandleRequest, context);
                }
            }
        }

        private static void HandleRequest(object? state) // Add nullability annotation '?'
        {
            HttpListenerContext context = (HttpListenerContext)state!; // Add null-forgiving operator '!'

            string responseString = "Hello, web!";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);

            context.Response.ContentType = "text/plain";
            context.Response.ContentLength64 = buffer.Length;

            using (Stream output = context.Response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }

            context.Response.Close();
        }
    }
}
