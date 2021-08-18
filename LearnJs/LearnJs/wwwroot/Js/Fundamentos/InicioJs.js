var GLOBAL = {};
GLOBAL.DotNetReference = null;
GLOBAL.SetDotnetReference = function (pDotNetReference) {
    GLOBAL.DotNetReference = null;
    if (GLOBAL.DotNetReference === null) {
        GLOBAL.DotNetReference = pDotNetReference;
    }
};


window.CalculaIMCJS = (altura, peso) => {
    var imc = peso * altura;
   // alert(`imc: ${imc}`);
    CalculaIMC(altura, peso);
};

function CalculaIMC(altura, peso) {
    var imc = (altura * altura) / peso;
    alert(`chamada 2>>  imc: ${imc}`);
}

window.displayTickerAlert1 = (symbol, price) => {
    alert(`${symbol}: $${price}!`);
};

window.displayAlerta = () => {
    alert('bom dia basico');
};

window.ExibeData = function (data) {
    alert(`${data}`);
    //   document.getElementById('hoje').innerHTML = `hoje é dia de estudar`
}

function GetTotalTarefas() {
    DotNet.invokeMethodAsync("LearnJs", "ObterTotalTarefas")
        .then(resultado => {
            alert("Total tarefas: " + resultado);
        });
}

window.convertArray = (win1251Array) => {
    var win1251decoder = new TextDecoder('windows-1251');
    var bytes = new Uint8Array(win1251Array);
    var decodedArray = win1251decoder.decode(bytes);
    console.log(decodedArray);
    return decodedArray;
};
