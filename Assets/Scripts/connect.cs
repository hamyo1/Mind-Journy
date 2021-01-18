using System;
using System.Net.Sockets;
using UnityEngine;

public class connect : MonoBehaviour
{
    //public connect(){}
    public static String Connect(String server, String message)
    {
        try
        {
            // -----------------Create a TcpClient.---------------------
            // Note, for this client to work you need to have a TcpServer
            // connected to the same address as specified by the server, port combination.
            Int32 port = 4999;
            TcpClient client = new TcpClient(server, port);
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            // Get a client stream for reading and writing.
            NetworkStream stream = client.GetStream();
            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);
            Debug.Log("Sent: ");
            // -----------Receive the TcpServer.response.----------------
            // Buffer to store the response bytes.
            data = new Byte[256];
            // String to store the response ASCII representation.
            String responseData = String.Empty;
            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            //convert the bytes to string type
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Debug.Log("Received: " + responseData);//print to the console the recived message
            return responseData;
            // Close everything.
            stream.Close();
            client.Close();
        }
        catch (ArgumentNullException e)
        {
            Debug.Log("ArgumentNullException: ");
        }
        catch (SocketException e)
        {
            Debug.Log("SocketException: ");
        }
        Debug.Log("\n Press Enter to continue...");
        return null;
    }
}
