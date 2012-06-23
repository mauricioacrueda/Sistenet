    function AcceptNum(evt) {
        var key;
        if (window.event) // IE
        {
            key = evt.keyCode;
        }
        else if (evt.which) // Netscape/Firefox/Opera
        {
            key = evt.which;
        }
        return (key < 13 || (key >= 48 && key <= 57));
    }

    function NoEnter(evt) {
        var key;
        if (window.event) // IE
        {
            key = evt.keyCode;
        }
        else if (evt.which) // Netscape/Firefox/Opera
        {
            key = evt.which;
        }
        if (key == 13) { return false; }
    }

    function SetSelected(TextBuscar) {       
        var Busca = document.getElementById(TextBuscar);
        if (Busca != null && Busca.value != "") {
            Busca.select();
        }
    }

    function RetornarSeleccion(Valor, Grilla, Oculto) {
        var hfdPopUp = document.getElementById(Oculto);

        if (hfdPopUp != null) {
            hfdPopUp.value = Valor;
        }

        var gvControl = document.getElementById(Grilla);
        var filas = gvControl.getElementsByTagName("TR");

        for (ro = 0; ro < filas.length; ro++) {

            var celdas = filas[ro].getElementsByTagName("TD");
            var boton = filas[ro].getElementsByTagName("INPUT");

            if (celdas.length > 0) {
                var Id = parseInt(boton[1].value, 10);
                if (Id == Valor) {
                    if (window.event) {
                        boton[0].parentElement.parentElement.className = 'ColumnaSeleccionada';                                  
                    }
                    else {
                        boton[0].parentNode.parentNode.setAttribute("class", "ColumnaSeleccionada");
                    }                    
                    boton[0].src = "../Images/CheckBlue.png";
                    boton[0].onmouseover = function() { this.src = "../Images/CheckBlue.png"; };
                    boton[0].onmouseout = function() { this.src = "../Images/CheckBlue.png"; };                             
                }
                else {
                    boton[0].src = "../Images/CheckGrey.png"
                    if (ro % 2 == 0) {
                        if (window.event) {                        
                            boton[0].parentElement.parentElement.className = 'GridViewRowStyle';                            
                        }
                        else {                        
                            boton[0].parentNode.parentNode.setAttribute("class", "GridViewRowStyle");                          
                        }
                        boton[0].onmouseover = function() { this.src = "../Images/CheckBlue2.png"; };
                        boton[0].onmouseout = function() { this.src = "../Images/CheckGrey.png"; };                        
                    }
                    else {
                        if (window.event) {
                            boton[0].parentElement.parentElement.className = "GridViewAlternatingRowStyle";                           
                        }
                        else {
                            boton[0].parentNode.parentNode.setAttribute("class", "GridViewAlternatingRowStyle");
                        }
                        boton[0].onmouseover = function() { this.src = "../Images/CheckBlue2.png"; };
                        boton[0].onmouseout = function() { this.src = "../Images/CheckGrey.png"; };                   
                    }
                }
            }
        }
    }

    function ActivarBuscarTer(TextBuscar, Buscar) {
        var Busca = document.getElementById(TextBuscar);
        var Agrega = document.getElementById(Buscar);

        if (Busca != null) {
            var Buscar = Busca.value;
            if (Buscar.length > 1) {                
                    Agrega.disabled = false;
                    Agrega.src = "../Images/btnBuscar.png";
                    Agrega.onmouseover = function() { this.src = "../Images/btnBuscar2.png"; };
                    Agrega.onmouseout = function() { this.src = "../Images/btnBuscar.png"; };              
            }
            else {
                Agrega.disabled = true;
                Agrega.src = "../Images/btnBuscar3.png";
                Agrega.onmouseover = function() { this.src = "../Images/btnBuscar3.png"; };
                Agrega.onmouseout = function() { this.src = "../Images/btnBuscar3.png"; };
            }
        }
    }

    function IsNumericPUC(sText) {
        var ValidChars = "0123456789";
        var IsNumber = true;
        var Char;

        for (i = 0; i < sText.length && IsNumber == true; i++) {
            Char = sText.charAt(i);
            if (ValidChars.indexOf(Char) == -1) {
                IsNumber = false;
            }
        }
        return IsNumber;
    }

    function ActivarBuscarPUC(TextBuscar, Buscar) {
        var Busca = document.getElementById(TextBuscar);
        var Agrega = document.getElementById(Buscar);

        if (Busca != null) {
            var Buscar = Busca.value;
            if (Buscar.length > 0) {

                if (IsNumericPUC(Buscar)) {
                    Agrega.disabled = false;
                    Agrega.src = "../Images/btnBuscar.png";
                    Agrega.onmouseover = function() { this.src = "../Images/btnBuscar2.png"; };
                    Agrega.onmouseout = function() { this.src = "../Images/btnBuscar.png"; };
                }
                else {
                    if (Buscar.length > 1) {
                        Agrega.disabled = false;
                        Agrega.src = "../Images/btnBuscar.png";
                        Agrega.onmouseover = function() { this.src = "../Images/btnBuscar2.png"; };
                        Agrega.onmouseout = function() { this.src = "../Images/btnBuscar.png"; };
                    }
                    else {
                        Agrega.disabled = true;
                        Agrega.src = "../Images/btnBuscar3.png";
                        Agrega.onmouseover = function() { this.src = "../Images/btnBuscar3.png"; };
                        Agrega.onmouseout = function() { this.src = "../Images/btnBuscar3.png"; };
                    }
                }
            }
            else {
                Agrega.disabled = true;
                Agrega.src = "../Images/btnBuscar3.png";
                Agrega.onmouseover = function() { this.src = "../Images/btnBuscar3.png"; };
                Agrega.onmouseout = function() { this.src = "../Images/btnBuscar3.png"; };
            }
        }
    } 