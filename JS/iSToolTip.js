var iSie=iSie4=iSnn4=iSonn=iSnn=iSpsub=iSsnav=0;iSNavegador()
var Contador=0,Mover=0,fl=0,Bien=1,cierra,ini,ubi,Ventana=window,isPixel=(iSpsub)?"px":""

var NombreDiv = "divToolTip" 
var iSActivo = 1 
iSIniciar()


var DocEle=(iSie&&document.compatMode=="CSS1Compat")? "document.documentElement":"document.body"
var AnchoV=Ventana.innerWidth
var AltoV=Ventana.innerHeight
var vbs=iSonn? 15:0

function iSCursor(){
if(iSsnav){
Ventana.onresize=iSRecarga
document.onmousemove=iSMover
if(iSnn4) document.captureEvents(Event.MOUSEMOVE)
}}		

function iSNavegador(){
var ua=navigator.userAgent.toLowerCase()
iSpsub=navigator.productSub
iSopr=ua.indexOf("opera")>-1?parseInt(ua.substring(ua.indexOf("opera")+6,ua.length)):0
iSie=document.all&&!iSopr?parseFloat(ua.substring(ua.indexOf("msie")+5,ua.length)):0
iSie4=parseInt(iSie)==4
iSnn4=navigator.appName.toLowerCase()=="netscape"&&!document.getElementById
iSnn=iSnn4||document.getElementById&&!document.all
iSonn=iSnn4||iSpsub<20020823
iSsnav=iSnn||iSie||iSopr>=7
}

function iSModifica(){
if(iSie>=5.5&&iSActivo){fl=1
var modi=" progid:DXImageTransform.Microsoft."
iSEtiquetaCSS().filter="revealTrans()"+modi+"Fade(Overlap=1.00 enabled=0)"+modi+"Inset(enabled=0)"+modi+"Iris(irisstyle=PLUS,motion=in enabled=0)"+modi+"Iris(irisstyle=PLUS,motion=out enabled=0)"+modi+"Iris(irisstyle=DIAMOND,motion=in enabled=0)"+modi+"Iris(irisstyle=DIAMOND,motion=out enabled=0)"+modi+"Iris(irisstyle=CROSS,motion=in enabled=0)"+modi+"Iris(irisstyle=CROSS,motion=out enabled=0)"+modi+"Iris(irisstyle=STAR,motion=in enabled=0)"+modi+"Iris(irisstyle=STAR,motion=out enabled=0)"+modi+"RadialWipe(wipestyle=CLOCK enabled=0)"+modi+"RadialWipe(wipestyle=WEDGE enabled=0)"+modi+"RadialWipe(wipestyle=RADIAL enabled=0)"+modi+"Pixelate(MaxSquare=35,enabled=0)"+modi+"Slide(slidestyle=HIDE,Bands=25 enabled=0)"+modi+"Slide(slidestyle=PUSH,Bands=25 enabled=0)"+modi+"Slide(slidestyle=SWAP,Bands=25 enabled=0)"+modi+"Spiral(GridSizeX=16,GridSizeY=16 enabled=0)"+modi+"Stretch(stretchstyle=HIDE enabled=0)"+modi+"Stretch(stretchstyle=PUSH enabled=0)"+modi+"Stretch(stretchstyle=SPIN enabled=0)"+modi+"Wheel(spokes=16 enabled=0)"+modi+"GradientWipe(GradientSize=1.00,wipestyle=0,motion=forward enabled=0)"+modi+"GradientWipe(GradientSize=1.00,wipestyle=0,motion=reverse enabled=0)"+modi+"GradientWipe(GradientSize=1.00,wipestyle=1,motion=forward enabled=0)"+modi+"GradientWipe(GradientSize=1.00,wipestyle=1,motion=reverse enabled=0)"+modi+"Zigzag(GridSizeX=8,GridSizeY=8 enabled=0)"+modi+"Alpha(enabled=0)"+modi+"Dropshadow(OffX=3,OffY=3,Positive=true,enabled=0)"+modi+"Shadow(strength=3,direction=135,enabled=0)"
}}

function Mostrar(Titulo, Contenido) {
    if (iSsnav && Bien) {
        if (document.onmousemove != iSMover || Ventana.onresize != iSRecarga) iSCursor()

        iSEtiquetaCSS().visibility = "hidden"
        var ab = ""; var ap = ""
        var ColorBorde = "BGCOLOR='silver'"
        var ColorFondoTitulo = "BGCOLOR='#165195'"
        var IamgeFondoTitulo = "BACKGROUND='../Images/imgToolTip.JPG'"
        var AnchoToolTip = 350
        var ColorFondoTabla = "BGCOLOR='#ffffff'"
        var Ec = 1
        cierra = 0//3 muestra cerrar

        if (iSpsub == 20001108) {
            if (Ec) ab = "STYLE='border:" + Ec + "px solid silver'";
            ap = "STYLE='padding:2px 2px 2px 2px'"
        }
        var lnkCerrar = cierra == 3 ? "<TD ALIGN='right'><FONT SIZE='1' FACE='Lucida Sans Unicode, Arial, Tahoma'><A HREF='javascript:void(0)' ONCLICK='iSOculta(0)' STYLE='text-decoration:none;color:white'><B>Cerrar</B></A></FONT></TD>" : ""
        var TablaTitulo = Titulo || cierra == 3 ? "<TABLE WIDTH='100%' BORDER='0' CELLPADDING='2' CELLSPACING='1' " + ColorFondoTitulo + " " + IamgeFondoTitulo + "><TR><TD ALIGN='left' VALIGN='middle'><FONT SIZE='1' FACE='Lucida Sans Unicode, Arial, Tahoma' COLOR='white'><B>" + Titulo + "</B></FONT></TD>" + lnkCerrar + "</TR></TABLE>" : "";
        var ToolT = "<TABLE " + ab + " WIDTH='" + AnchoToolTip + "' BORDER='0' CELLSPACING='0' CELLPADDING='1' " + ColorBorde + "><TR><TD>" + TablaTitulo + "<TABLE WIDTH='100%' BORDER='0' CELLPADDING='2' CELLSPACING='0' " + ColorFondoTabla + "><TR><TD ALIGN='left' " + ap + " VALIGN='top'><FONT SIZE='1' FACE='Lucida Sans Unicode, Arial, Tahoma' COLOR='#555'>" + Contenido + "</FONT></TD></TR></TABLE></TD></TR></TABLE>"//black

        iSEcsribe(ToolT)

        ubi = { trans: 51, dur: 1, opac: "", st: "", sc: "", pos: 10, xpos: 10, ypos: 10 }

        if (iSie4) iSEtiquetaCSS().width = Estilo[12]
        ini = iSPrepara()
        Contador = 0
        Mover = 1
    } 
}

function Mostrar2(Titulo, Contenido,MiControl) {
    if (iSsnav && Bien) {
        if (document.onmousemove != iSMover || Ventana.onresize != iSRecarga) iSCursor()

        var MiControl = document.getElementById(MiControl);
        MiControl.style.color = "#0099ff"; 

        iSEtiquetaCSS().visibility = "hidden"
        var ab = ""; var ap = ""
        var ColorBorde = "BGCOLOR='silver'"
        var ColorFondoTitulo = "BGCOLOR='#165195'"
        var IamgeFondoTitulo = "BACKGROUND='../Images/imgToolTip.JPG'"
        var AnchoToolTip = 350
        var ColorFondoTabla = "BGCOLOR='#ffffff'"
        var Ec = 1
        cierra = 0//3 muestra cerrar

        if (iSpsub == 20001108) {
            if (Ec) ab = "STYLE='border:" + Ec + "px solid silver'";
            ap = "STYLE='padding:2px 2px 2px 2px'"
        }
        var lnkCerrar = cierra == 3 ? "<TD ALIGN='right'><FONT SIZE='1' FACE='Lucida Sans Unicode, Arial, Tahoma'><A HREF='javascript:void(0)' ONCLICK='iSOculta(0)' STYLE='text-decoration:none;color:white'><B>Cerrar</B></A></FONT></TD>" : ""
        var TablaTitulo = Titulo || cierra == 3 ? "<TABLE WIDTH='100%' BORDER='0' CELLPADDING='2' CELLSPACING='1' " + ColorFondoTitulo + " " + IamgeFondoTitulo + "><TR><TD ALIGN='left' VALIGN='middle'><FONT SIZE='1' FACE='Lucida Sans Unicode, Arial, Tahoma' COLOR='white'><B>" + Titulo + "</B></FONT></TD>" + lnkCerrar + "</TR></TABLE>" : "";
        var ToolT = "<TABLE " + ab + " WIDTH='" + AnchoToolTip + "' BORDER='0' CELLSPACING='0' CELLPADDING='1' " + ColorBorde + "><TR><TD>" + TablaTitulo + "<TABLE WIDTH='100%' BORDER='0' CELLPADDING='2' CELLSPACING='0' " + ColorFondoTabla + "><TR><TD ALIGN='left' " + ap + " VALIGN='top'><FONT SIZE='1' FACE='Lucida Sans Unicode, Arial, Tahoma' COLOR='black'>" + Contenido + "</FONT></TD></TR></TABLE></TD></TR></TABLE>"

        iSEcsribe(ToolT)

        ubi = { trans: 51, dur: 1, opac: "", st: "", sc: "", pos: 10, xpos: 10, ypos: 10 }

        if (iSie4) iSEtiquetaCSS().width = Estilo[12]
        ini = iSPrepara()
        Contador = 0
        Mover = 1
    }
}

function Mostrar3(Titulo, Contenido, MiControl) {
    if (iSsnav && Bien) {
        if (document.onmousemove != iSMover || Ventana.onresize != iSRecarga) iSCursor()

        var MiControl = document.getElementById(MiControl);
        MiControl.style.color = "#0099ff";

        iSEtiquetaCSS().visibility = "hidden"
        var ab = ""; var ap = ""
        var ColorBorde = "BGCOLOR='silver'"
        var ColorFondoTitulo = "BGCOLOR='#D7E0E3'"
        var IamgeFondoTitulo = "BACKGROUND='../Images/imgToolTip2.PNG'"
        var AnchoToolTip = 350
        var ColorFondoTabla = "BGCOLOR='#ffffff'"
        var Ec = 1
        cierra = 0//3 muestra cerrar

        if (iSpsub == 20001108) {
            if (Ec) ab = "STYLE='border:" + Ec + "px solid silver'";
            ap = "STYLE='padding:2px 2px 2px 2px'"
        }
        var lnkCerrar = cierra == 3 ? "<TD ALIGN='right'><FONT SIZE='1' FACE='Lucida Sans Unicode, Arial, Tahoma'><A HREF='javascript:void(0)' ONCLICK='iSOculta(0)' STYLE='text-decoration:none;color:white'><B>Cerrar</B></A></FONT></TD>" : ""
        var TablaTitulo = Titulo || cierra == 3 ? "<TABLE WIDTH='100%' BORDER='0' CELLPADDING='2' CELLSPACING='1' " + ColorFondoTitulo + " " + IamgeFondoTitulo + "><TR><TD ALIGN='left' VALIGN='middle'><FONT SIZE='1' FACE='Lucida Sans Unicode, Arial, Tahoma' COLOR='#245E83'><B>" + Titulo + "</B></FONT></TD>" + lnkCerrar + "</TR></TABLE>" : "";
        var ToolT = "<TABLE " + ab + " WIDTH='" + AnchoToolTip + "' BORDER='0' CELLSPACING='0' CELLPADDING='1' " + ColorBorde + "><TR><TD>" + TablaTitulo + "<TABLE WIDTH='100%' BORDER='0' CELLPADDING='2' CELLSPACING='0' " + ColorFondoTabla + "><TR><TD ALIGN='left' " + ap + " VALIGN='top'><FONT SIZE='1' FACE='Lucida Sans Unicode, Arial, Tahoma' COLOR='black'>" + Contenido + "</FONT></TD></TR></TABLE></TD></TR></TABLE>"

        iSEcsribe(ToolT)

        ubi = { trans: 51, dur: 1, opac: "", st: "", sc: "", pos: 10, xpos: 10, ypos: 10 }

        if (iSie4) iSEtiquetaCSS().width = Estilo[12]
        ini = iSPrepara()
        Contador = 0
        Mover = 1
    }
}

function iSMover(e){
if(Mover){
var X=0,Y=0,s_d=iSScroll(),w_d=iSDimensiona()
var mx=iSnn?e.pageX:iSie4?event.x:event.x+s_d[0]
var my=iSnn?e.pageY:iSie4?event.y:event.y+s_d[1]
if(iSie4)ini=iSPrepara()
switch(ubi.pos){
case 1:X=mx-ini[0]-ubi.xpos+6;Y=my+ubi.ypos;break
case 2:X=mx-(ini[0]/2);Y=my+ubi.ypos;break
case 3:X=ubi.xpos+s_d[0];Y=ubi.ypos+s_d[1];break
case 4:X=ubi.xpos;Y=ubi.ypos;break		
default:X=mx+ubi.xpos;Y=my+ubi.ypos}
if(w_d[0]+s_d[0]<ini[0]+X+vbs)X=w_d[0]+s_d[0]-ini[0]-vbs
if(w_d[1]+s_d[1]<ini[1]+Y+vbs){if(ubi.pos>2)Y=w_d[1]+s_d[1]-ini[1]-vbs;else Y=my-ini[1]}
if(X<s_d[0])X=s_d[0]
with(iSEtiquetaCSS()){left=X+isPixel;top=Y+isPixel}
iSEfecto()
}}

function iSEfecto(){Contador++
if(Contador==1){
if(fl){	
ubi.trans=46/*Efecto Estatico*/
var at=ubi.trans>-1&&ubi.trans<24&&ubi.dur>0 
var af=ubi.trans>23&&ubi.trans<51&&ubi.dur>0
var t=iSEtiqueta().filters[af?ubi.trans-23:0]
for(var p=28;p<31;p++){iSEtiqueta().filters[p].enabled=0}
for(var s=0;s<28;s++){if(iSEtiqueta().filters[s].status)iSEtiqueta().filters[s].stop()}
for(var e=1;e<3;e++){if(ubi.sc&&ubi.st==e){with(iSEtiqueta().filters[28+e]){enabled=1;color=ubi.sc}}}
if(ubi.opac>0&&ubi.opac<100){with(iSEtiqueta().filters[28]){enabled=1;opacity=ubi.opac}}
if(at||af){if(at)iSEtiqueta().filters[0].transition=ubi.trans;t.duration=ubi.dur;t.apply()}}
iSEtiquetaCSS().visibility=iSnn4?"show":"visible"
if(fl&&(at||af))t.play()
if(cierra>0&&cierra<4)Mover=0
}}

function iSEtiquetaCSS(){return iSnn4?iSEtiqueta():iSEtiqueta().style}
function iSEtiqueta(){with(document)return iSnn4?layers[NombreDiv]:iSie4?all[NombreDiv]:getElementById(NombreDiv)}
function iSEcsribe(txt){if(iSnn4){with(iSEtiqueta().document){open();write(txt);close()}}else iSEtiqueta().innerHTML=txt}
function iSOculta(C){if(!iSnn4||iSnn4&&C)iSEcsribe("");with(iSEtiquetaCSS()){visibility=iSnn4?"hide":"hidden";left=0;top=-800}}
function iSScroll() { return [parseInt(iSie ? eval(DocEle).scrollLeft : Ventana.pageXOffset), parseInt(iSie ? eval(DocEle).scrollTop : Ventana.pageYOffset)] }

function iSRecarga() {
    var w_d = iSDimensiona();
    if (iSnn4 && (w_d[0] - AnchoV || w_d[1] - AltoV)) {
        location.reload();
    }
    else if (cierra == 3 || cierra == 2) {
        iSOculta(1)
    }
    size();
 }

function iSDimensiona(){return [parseInt(iSonn?Ventana.innerWidth:eval(DocEle).clientWidth),parseInt(iSonn?Ventana.innerHeight:eval(DocEle).clientHeight)]}
function iSPrepara() { return [parseInt(iSnn4 ? iSEtiqueta().clip.width : iSEtiqueta().offsetWidth) + 3, parseInt(iSnn4 ? iSEtiqueta().clip.height : iSEtiqueta().offsetHeight) + 5] }

function Quitar() { if (iSsnav && Bien) { if (cierra != 4) { Mover = 0; if (cierra != 3 && cierra != 2) { iSOculta(1) } } } }

function Quitar2(MiControl) {
    if (iSsnav && Bien) {
    
        var MiControl = document.getElementById(MiControl);
        MiControl.style.color = "#555"; //"black";      
        
        if (cierra != 4) {
            Mover = 0;
            if (cierra != 3 && cierra != 2) {
                iSOculta(1)
            }
        }
    }
}


function iSIniciar(){
if(!iSEtiqueta()){Bien=0}
else { iSCursor(); iSModifica() }
}

//Redimensionar Página.. Masters
function size() {
    var browser = navigator.appName;
    var size = 1024;

    var BannerL = document.getElementById("BannerL");
    var BannerM = document.getElementById("BannerM");    
    
    if (browser == "Microsoft Internet Explorer") {
        size = document.body.offsetWidth;
        if (size > 1024) {
            var ancho = size;
            if (BannerL != null && BannerM != null) {
                var size = ancho - (680 + 315);
                document.getElementById("BannerL").style.width = 315;
                document.getElementById("BannerM").style.width = size;
                document.getElementById("BannerR").style.width = 680;
                document.getElementById("TableBanner").style.width = ancho;
                document.getElementById("TableContent").style.width = ancho;
            }
            else {
                document.getElementById("TableBanner").style.width = ancho;
                document.getElementById("TableContent").style.width = ancho;
            }        
        }
        else {

            if (BannerL != null && BannerM != null) {
                document.getElementById("TableBanner").style.width = 1024;
                document.getElementById("BannerL").style.width = 315;
                document.getElementById("BannerR").style.width = 680;
                document.getElementById("BannerM").style.width = 29;
                document.getElementById("TableContent").style.width = 1024;
            }
            else {
                document.getElementById("TableBanner").style.width = 1024;
                document.getElementById("TableContent").style.width = 1024;
            } 
        }
    }
    if (browser == "Netscape") {
        size = document.body.clientWidth;
        if (size > 1024) {
            var ancho = size;
            if (BannerL != null && BannerM != null) {
                var size = ancho - (680 + 315);
                document.getElementById("BannerL").width = 315;
                document.getElementById("BannerM").width = size;
                document.getElementById("TableBanner").width = ancho;
                document.getElementById("TableContent").width = ancho;
                document.getElementById("BannerR").width = 680;
            }
            else {
                document.getElementById("TableBanner").width = ancho;
                document.getElementById("TableContent").width = ancho;
            } 
        }
        else {
            if (BannerL != null && BannerM != null) {
                document.getElementById("TableBanner").width = 1024;
                document.getElementById("BannerL").width = 315;
                document.getElementById("BannerR").width = 680;
                document.getElementById("BannerM").width = 29;
                document.getElementById("TableContent").width = 1024;
            }
            else {
                document.getElementById("TableBanner").width = 1024;
                document.getElementById("TableContent").width = 1024;
            } 
        }
    }

}