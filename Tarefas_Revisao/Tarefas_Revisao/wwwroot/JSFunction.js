<<<<<<< Updated upstream
﻿window.MostraAlerta = function()  {
    alert("asdasd");
}

export function jsIsolation(value) {
    console.log(value);
}

window.methods = {
    print: function (message) {
        return "from js " + message
    }
=======
﻿window.MostraAlerta = (message) => {
    alert(message);
>>>>>>> Stashed changes
}