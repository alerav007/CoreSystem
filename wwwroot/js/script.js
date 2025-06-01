document.getElementById('loginForm').addEventListener('submit', async function (e) {
    e.preventDefault();

    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    const errorMsg = document.getElementById('error-msg');

    try {
        const response = await fetch('/api/auth/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ username, password })
        });

        if (response.ok) {
            errorMsg.style.color = 'green';
            errorMsg.textContent = 'Inicio de sesión exitoso. Redirigiendo...';
            setTimeout(() => window.location.href = "/dashboard", 1500);
        } else {
            const data = await response.json();
            errorMsg.style.color = 'red';
            errorMsg.textContent = data.message || 'Error al iniciar sesión.';
        }
    } catch (err) {
        errorMsg.style.color = 'red';
        errorMsg.textContent = 'Error de conexión con el servidor.';
        console.error(err);
    }
});
