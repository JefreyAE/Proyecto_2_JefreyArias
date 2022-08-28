function confirmar(mensaje) {
    let isExecuted = confirm(mensaje);
    if (!isExecuted) {
        event.preventDefault();
    }
}