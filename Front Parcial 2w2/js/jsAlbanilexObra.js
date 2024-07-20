function loadAlbaniles() {
    const obraId = localStorage.getItem('selectedObraId');

    fetch(`https://localhost:7220/api/Parcial/ObtenerAlbanilesNoParteObra/${obraId}`)
        .then(response => response.json())
        .then(data => {
            const albanilSelect = document.getElementById('albanilSelect');
            data.data.forEach(albanil => {
                const option = document.createElement('option');
                option.value = albanil.id;
                option.text = `${albanil.nombre} ${albanil.apellido}`;
                albanilSelect.appendChild(option);
            });
        })
        .catch(error => console.error(error));
}

function handleSubmit(event) {
    event.preventDefault();

    const albanilId = document.getElementById('albanilSelect').value;
    const tareaArealizar = document.getElementById('tareaInput').value;

    const id = crypto.randomUUID();;

    const payload = {
        id: id,
        idAlbanil: albanilId,
        idObra: localStorage.getItem('selectedObraId'),
        tareaArealizar: tareaArealizar
    };

    fetch('https://localhost:7220/api/Parcial/PostAlbanilXObra', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
    })
        .then(response => {
            if (response.ok) {
                alert('Se asignó correctamente');
                window.location.href = 'GetObras.html';
            } else {
                throw new Error('Failed to assign albañil to obra');
            }
        })
        .catch(error => console.error(error));
}


function goToGetObras() {
    window.location.href = 'GetObras.html';
}

document.addEventListener('DOMContentLoaded', function() {
    loadAlbaniles();
    document.getElementById('postAlbanilForm').addEventListener('submit', handleSubmit);
});