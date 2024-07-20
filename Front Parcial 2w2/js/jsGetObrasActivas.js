fetch('https://localhost:7220/api/Parcial/ObtenerTodasLasObras')
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    const obras = data.data;
                    const tableBody = document.querySelector('tbody');

                    obras.forEach(obra => {
                        const row = document.createElement('tr');
                        row.innerHTML = `
                            <td>${obra.nombre}</td>
                            <td>${obra.datosVarios}</td>
                            <td>${obra.nombreObra}</td>
                            <td>${obra.cantidadAlbaniles}</td>
                            <td>
                                ${obra.nombreObra === 'Edificio' ? `<button class="btn btn-primary" onclick="assignAlbanil('${obra.id}')">Asignar albañil</button>` : ''}
                            </td>
                        `;
                        tableBody.appendChild(row);
                    });
                }
            });

        function assignAlbanil(obraId) {
            localStorage.setItem('selectedObraId', obraId);
            window.location.href = 'PostAlbanilexObra.html';
        }