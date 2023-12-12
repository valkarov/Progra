// login.js
document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('loginForm').addEventListener('submit', function (e) {
        e.preventDefault(); // Prevenir el envío tradicional del formulario

        var username = document.getElementById('username').value;
        var password = document.getElementById('password').value;

        fetch('https://localhost:44356/api/Login/authenticate', { // Asegúrate de que la URL es la correcta
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                NombreUsuario: username,
                Contrasenna: password
            })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Inicio de sesión fallido');
                }
                return response.json();
            })
            .then(data => {
                // Aquí manejas una respuesta exitosa
                window.location.href = '~/Views/Home/Index.cshtml'; // Redirecciona al usuario
            })
            .catch(error => {
                console.error('Error:', error);
            });
    });
});