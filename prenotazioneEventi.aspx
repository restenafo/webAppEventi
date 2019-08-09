<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prenotazioneEventi.aspx.cs" Inherits="WebAppEventiCrociera.prenotazioneEventi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link href="css/styles.css" rel="stylesheet" />
    <title>BOOK YOUR FUN</title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
                        <!--  ************************  PRIMA RIGA   *************************  --> 
            <div class="row distanziaDallAlto">
                <div class="col-lg-4">
                    <div class="card" style="width: 100%;">
                        <img src="img/casino.jpg" class="card-img-top" alt="Gran Casinò" />
                        <div class="card-body">
                            <h5 class="card-title">Casinò</h5>
                            <p class="card-text">Sfida la sorte ai nostri tavoli o alla roulette o partecipa al gran torneo di Poker.</p>
                            <a href="elencoRepliche.aspx?cod1=CASN&cod2=POKE" class="btn btn-primary">Prenota</a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card" style="width: 100%;">
                        <img src="img/cinema.jpg" class="card-img-top" alt="Cinema MultiSala" />
                        <div class="card-body">
                            <h5 class="card-title">Cinema Multisala</h5>
                            <p class="card-text">Partecipa con la tua famiglia alle proiezioni degli ultimi film di Hollywood.</p>
                            <a href="elencoRepliche.aspx?cod1=FI01&cod2=FI02&cod3=FI03" class="btn btn-primary">Prenota</a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card" style="width: 100%;">
                        <img src="img/discoteca.jpg" class="card-img-top" alt="Discoteca con DJ" />
                        <div class="card-body">
                            <h5 class="card-title">Disco Night</h5>
                            <p class="card-text">Scaténati sulla pista da ballo al ritmo delle note di DJ DiskMan.</p>
                            <a href="elencoRepliche.aspx?cod1=DISC&cod2=MASK" class="btn btn-primary">Prenota</a>
                        </div>
                    </div>
                </div>
            </div>
            <!--  ************************  SECONDA RIGA   *************************  --> 
            <div class="row distanziaDallAlto">
                <div class="col-lg-4">
                    <div class="card" style="width: 100%;">
                        <img src="img/gran-gala.jpg" class="card-img-top" alt="Gran Gala" />
                        <div class="card-body">
                            <h5 class="card-title">Gran Galà di Capodanno</h5>
                            <p class="card-text">Vivete una serata da sogno sulle note dei più celebri valzer viennesi.</p>
                            <a href="elencoRepliche.aspx?cod1=GALA" class="btn btn-primary">Prenota</a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card" style="width: 100%;">
                        <img src="img/magia.jpg" class="card-img-top" alt="Il Prestidigitatore" />
                        <div class="card-body">
                            <h5 class="card-title">Spettacolo di Prestidigitazione</h5>
                            <p class="card-text">Vivete la spettacolare magia del celeberrimo Mago Silvano!</p>
                            <a href="elencoRepliche.aspx?cod1=MAGO" class="btn btn-primary">Prenota</a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card" style="width: 100%;">
                        <img src="img/titanic.jpg" class="card-img-top" alt="Emozione sul ponte" />
                        <div class="card-body">
                            <h5 class="card-title">Emozione sul Ponte di prua</h5>
                            <p class="card-text">Vivete l'emozione di sentirvi come Rose e Jack.</p>
                            <a href="elencoRepliche.aspx?cod1=TEXP" class="btn btn-primary">Prenota</a>
                        </div>
                    </div>
                </div>
            </div>
                        <!--  ************************  TERZA RIGA   *************************  -->
            <div class="row distanziaDallAlto">
                <div class="col-lg-4">
                    <div class="card" style="width: 100%;">
                        <img src="img/palestra.jpg" class="card-img-top" alt="Palestra" />
                        <div class="card-body">
                            <h5 class="card-title">Fitness Gym Studio</h5>
                            <p class="card-text">Mantenetevi in forma con i nostri Personal Trainer Elle & Williamson.</p>
                            <a href="elencoRepliche.aspx?cod1=FITG" class="btn btn-primary">Prenota</a>
                        </div>
                    </div>
                </div>
                 <div class="col-lg-4">
                    <div class="card" style="width: 100%;">
                        <img src="img/ristorante.jpg" class="card-img-top" alt="Cena stellata" />
                        <div class="card-body">
                            <h5 class="card-title">Cena stellata</h5>
                            <p class="card-text">Assaporate una cena regale nel nostro ristorante da 2 stelle Michelin.</p>
                            <a href="elencoRepliche.aspx" class="btn btn-primary">Prenota</a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card" style="width: 100%;">
                        <img src="img/piscina.jpg" class="card-img-top" alt="Piscina" />
                        <div class="card-body">
                            <h5 class="card-title">Piscina olimpionica</h5>
                            <p class="card-text">Godetevi il sole e fatevi il bagno nella nostra piscina olimpionica</p>
                            <a href="elencoRepliche.aspx?cod1=AQDA&cod2=AQGY" class="btn btn-primary">Prenota</a>
                        </div>
                    </div>
                </div>
               
            </div>
        </form>
    </div>
</body>
</html>
