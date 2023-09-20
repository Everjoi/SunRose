
    $(document).ready(function () {

        $('#sendMessage').click(function () {
            const messageText = $('#messageTextbox').val();

            $.ajax({
                url: '/Home/SaveMessage',
                method: 'POST',
                data: {
                    message: messageText
                },
                success: function (response) {
                    loadUserMessages();
                    loadAllMessages();
                },
                error: function (error) {
                    console.error("Помилка відправлення повідомлення:", error);
                }
            });
        });


    function loadUserMessages() {
        $.ajax({
            url: '/Home/GetUserMessages',
            method: 'GET',
            success: function (response) {

                displayMessages(response);
            },
            error: function (error) {
                console.error("Помилка завантаження повідомлень користувача:", error);
            }
        });
                }

    function displayMessages(messages) {
                    const messageContainer = $('#userMessages');
    messageContainer.empty();  

                    messages.forEach(msg => {
                        const displayMessage = `Message: ${msg.message} Date: ${msg.date} User: ${msg.user}`;
    messageContainer.append('<div>' + displayMessage + '</div>');
                    });
                }

    function loadAllMessages() {
        $.ajax({
            url: '/Home/GetAllMessages',
            method: 'GET',
            success: function (response) {
                displayAllMessages(response);
            },
            error: function (error) {
                console.error("Помилка завантаження усіх повідомлень:", error);
            }
        });
                }

    function displayAllMessages(messages) {
                    const allMessagesContainer = $('#allMessages');
    allMessagesContainer.empty();  

                    messages.forEach(msg => {
                        const displayMessage = `Message: ${msg.message} Date: ${msg.date} User: ${msg.user}`;
    allMessagesContainer.append('<div>' + displayMessage + '</div>');
                    });
                }


    loadAllMessages();
    loadUserMessages();         
            });


