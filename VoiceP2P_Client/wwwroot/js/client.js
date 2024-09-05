"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("https://192.168.31.75:7282/chatHub").build();

connection.on("ReceiveMessage", function (message) {
});

connection.start()
    .then(() => {
        console.log("Connection established");
        document.getElementById("sendButton").disabled = false;
    })
    .catch(err => console.error("Connection failed: ", err.toString()));

var ipAdress;
fetch('https://api.ipify.org?format=json')
    .then(response => response.json())
    .then(data => {
        console.log('Ваш IP-адрес:', data.ip);
        ipAdress = data.ip;
    })
    .catch(error => {
        console.error('Ошибка при получении IP-адреса:', error);
    });


document.getElementById("sendButton").addEventListener("click", function (event) {
    //var message = document.getElementById("messageInput").value;
    var message = ipAdress
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});