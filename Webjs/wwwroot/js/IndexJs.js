
function getXmlHttp() {
    var xmlhttp;
    try {
        xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
    } catch (e) {
        try {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        } catch (E) {
            xmlhttp = false;
        }
    }
    if (!xmlhttp && typeof XMLHttpRequest != 'undefined') {
        xmlhttp = new XMLHttpRequest();
    }
    return xmlhttp;
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

async function showMessag() {
    while (true) {
        // (1) создать объект для запроса к серверу
        var req = getXmlHttp()

        // (2)
        // span рядом с кнопкой
        // в нем будем отображать ход выполнения
        //var statusElem = document.getElementById('vote_status')

        req.onreadystatechange = function () {
            // onreadystatechange активируется при получении ответа сервера

            if (req.readyState == 4) {
                // если запрос закончил выполняться

                //       statusElem.innerHTML = req.statusText // показать статус (Not Found, ОК..)

                if (req.status == 200) {
                    // если статус 200 (ОК) - выдать ответ пользователю
                    //alert("Ответ сервера: " + req.responseText);
                    if (req.responseText == "Get last news") {
                        GetAnswer(req.responseText);
                    }
                }
                // тут можно добавить else с обработкой ошибок запроса
            }

        }

        // (3) задать адрес подключения
        req.open('GET', 'http://localhost:56062/Home/Update', true);

        // объект запроса подготовлен: указан адрес и создана функция onreadystatechange
        // для обработки ответа сервера

        // (4)
        req.send(null);  // отослать запрос
        await sleep(60000);
        // (5)
        // statusElem.innerHTML = 'Ожидаю ответа сервера...'
    }
}

function GetAnswer(messege) {
    var elem = document.getElementById("LabelForGetUpdate");
    document.getElementById("LabelForGetUpdate").innerHTML = messege;
    elem.style.display = 'inline-block';
}                                                                                             
function CLickUpdate() {
    location.reload(true);
    //var elem = document.getElementById("LabelForGetUpdate");
    document.getElementById("LabelForGetUpdate").innerHTML = "";
    //elem.style.display = 'none';

}
function ClicOfButton() {
    document.getElementById("SearchButton").style.display = 'none';
    document.getElementById("SearchPanel").style.display = 'inline-block';
}
function ClicOfButton1() {
    document.getElementById("SearchButton").style.display = 'inline-block';
    document.getElementById("SearchPanel").style.display = 'none';
}

showMessag();