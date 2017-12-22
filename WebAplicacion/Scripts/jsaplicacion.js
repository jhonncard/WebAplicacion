function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function SoloLetras(evt) {
    tecla = (document.all) ? evt.keyCode : evt.which;
    if (tecla == 8) return true;
    patron = /[A-Z a-z á é í ó ú Á É Í Ó Ú ä ë ï ö ü Ä Ë Ï Ö Ü ñ Ñ]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function SoloLetrasYNumeros(evt) {
    tecla = (document.all) ? evt.keyCode : evt.which;
    if (tecla == 8) return true;
    patron = /[A-Z a-z á é í ó ú Á É Í Ó Ú ä ë ï ö ü Ä Ë Ï Ö Ü ñ Ñ 0-9]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function Descripciones(evt) {
    tecla = (document.all) ? evt.keyCode : evt.which;
    if (tecla == 8) return true;
    patron = /[A-Z a-z á é í ó ú Á É Í Ó Ú ä ë ï ö ü Ä Ë Ï Ö Ü ñ Ñ 0-9 . : ; () , -]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function BotonOver(id) {
    $("#" + id).css("background-color", "#3598D4");
}

function BotonOut(id) {
    $("#" + id).css("background-color", "#63A22D");
}

function countdown() {

    var seconds = parseInt($("#lblSeconds").text());
    var minutes = parseInt($("#lblMinutes").text());

    var strMinutes;
    var strSeconds;

    if (seconds - 1 == -1) {
        seconds = 59;
        if (minutes - 1 == -1) {
            minutes = 59;
            /*if (hours - 1 == -1) {
                clearInterval();
                return false;
            } else {
                hours -= 1;
            }*/
        } else {
            minutes -= 1;
        }
    } else {
        seconds -= 1;
    }

    $("#lblSeconds").text(seconds);
    $("#lblMinutes").text(minutes);

    if (seconds == 0 && minutes == 0) {
        var Backlen = history.length;
        if (Backlen > 0) {
            history.go(-Backlen);
        }
                
        window.location.href = baseUrl + '/Auth/LogOut';
    }
}

            //obtener url base en layout principal:
        var baseUrl = '@ViewBag.BaseUrl';

    
		
         
            //ESCONDE LOADING CUANDO TERMINA DE CARGAR PAGINA HTML
            $(window).load(function () {
                $('#cargando').fadeOut();
        });

            //MUESTRA LOADING CUANDO EJECUTA EVENTO AJAX
            $(document).ajaxStart(function () {
                $('#cargando').fadeIn();
        });

            //ESCONDE LOADING CUANDO TERMINA EVENTO AJAX
            $(document).ajaxSuccess(function () {
                $('#cargando').fadeOut();
        });

            //ESCONDE LOADING CUANDO OCURRE ERROR EN EVENTO AJAX
            $(document).ajaxError(function () {
                $('#cargando').fadeOut();
        });


        