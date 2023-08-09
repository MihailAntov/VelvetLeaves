"use strict";

console.log('blabla');
var connection = new signalR.HubConnectionBuilder().withUrl("/OrderUpdate").build();
connection.start();
connection.on("NewOrderPlaced", function () {
    const pendingOrdersButton = document.querySelector('.pending-orders-button');
    const pendingStatus = pendingOrdersButton.getAttribute('orderStatus');

    if (pendingOrdersButton.classList.contains('btn-lg')) {
        $.ajax({
            type: 'GET',
            url: 'FetchOrders/',
            data: { "status": pendingStatus }
            ,
            success: function (response) {
                const orderDiv = document.querySelector('.orders-list');
                orderDiv.innerHTML = response;
            },
            error: function (response) {
                console.log(response);
            }

        });
    }
});


