$(document).ready(function() {
    $('#albanilForm').validate();
    
    $('#albanilForm').submit(function(event) {
        event.preventDefault();
        
        if ($(this).valid()) {
            var albanilData = {
                id: crypto.randomUUID(),
                nombre: $('#nombre').val(),
                apellido: $('#apellido').val(),
                dni: $('#dni').val(),
                telefono: $('#telefono').val(),
                calle: $('#calle').val(),
                numero: $('#numero').val(),
                codPost: $('#codPost').val()
            };
            
            fetch('https://localhost:7220/api/Parcial/PostAlbanil', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(albanilData)
            })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                alert('Albañil agregado correctamente..');
                window.location.href = 'GetObras.html'
            })
            .catch(error => {
                console.error('Error:', error);
                alert('Error al agregar albañil..');
            });
        }
    });
});