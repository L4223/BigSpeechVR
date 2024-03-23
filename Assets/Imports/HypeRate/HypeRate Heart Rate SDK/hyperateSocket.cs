using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using NativeWebSocket;

public class hyperateSocket : MonoBehaviour
{
    // Put your websocket Token ID here
    public string websocketToken = "oNFg0RxSSljvgzhUwLjEfCLL1saCvZVdHeoKDunrtMcx3sn6xb85TSxc4DFI12do"; // You don't have one, get it here https://www.hyperate.io/api
    public string hyperateID;
    // Textbox to display your heart rate in
    Text textBox;
    // Websocket for connection with Hyperate
    WebSocket websocket;
    public int heartRate { get; set; }
    // List to store received heart rate data
    public List<int> heartRateData { get; private set; } = new List<int>();


    async void Start()
    {
        textBox = GetComponent<Text>();


        websocket = new WebSocket("wss://app.hyperate.io/socket/websocket?token=" + websocketToken);
        Debug.Log("Connect!");

        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
            SendWebSocketMessage();
        };

        websocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };

        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        websocket.OnMessage += (bytes) =>
        {
            // getting the message as a string
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            var msg = JObject.Parse(message);

            if (msg["event"].ToString() == "hr_update")
            {
                // Parse and store the received heart rate value
                heartRate = (int)msg["payload"]["hr"];
                heartRateData.Add(heartRate);
                print("Puls:  " + heartRate);

                // Change textbox text into the newly received Heart Rate
                textBox.text = heartRate.ToString() + " bmp";
            }
        };

        // Send heartbeat message every 25 seconds in order to not be suspended from the connection
        InvokeRepeating("SendHeartbeat", 1.0f, 25.0f);

        // waiting for messages
        await websocket.Connect();
    }

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
#endif
    }

    async void SendWebSocketMessage()
    {
        if (websocket.State == WebSocketState.Open)
        {
            // Log into the "internal-testing" channel
            await websocket.SendText("{\"topic\": \"hr:" + hyperateID + "\", \"event\": \"phx_join\", \"payload\": {}, \"ref\": 0}");
        }
    }

    async void SendHeartbeat()
    {
        if (websocket.State == WebSocketState.Open)
        {
            // Send heartbeat message in order to not be suspended from the connection
            await websocket.SendText("{\"topic\": \"phoenix\",\"event\": \"heartbeat\",\"payload\": {},\"ref\": 0}");
        }
    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }

    // You can create a separate function to generate a graph
    void CreateHeartRateGraph()
    {
        // Assuming you have a Graphing system in place, you can use the heartRateData list to generate the graph.
        // You can use libraries like Unity's LineRenderer or other graphing assets to visualize the data.
        // Here, we are just printing the data to the console.

        Debug.Log("Heart Rate Data:");
        for (int i = 0; i < heartRateData.Count; i++)
        {
            Debug.Log("Data Point " + i + ": " + heartRateData[i]);
        }
    }

    // You may want to call CreateHeartRateGraph() when you need to generate the graph.
    // For example, you can call it when a button is clicked.
    public void OnGenerateGraphButtonClicked()
    {
        CreateHeartRateGraph();
    }
}

public class HyperateResponse
{
    public string Event { get; set; }
    public string Payload { get; set; }
    public string Ref { get; set; }
    public string Topic { get; set; }
}
