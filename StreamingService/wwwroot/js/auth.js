function togglePassword() {
    var input = document.getElementById("passwordInput");
    var eyeOpen = document.getElementById("eyeOpen");
    var eyeClosed = document.getElementById("eyeClosed");

    if (!input || !eyeOpen || !eyeClosed) return;

    if (input.type === "password") {
        input.type = "text";
        eyeOpen.classList.remove("hidden");
        eyeClosed.classList.add("hidden");
    } else {
        input.type = "password";
        eyeOpen.classList.add("hidden");
        eyeClosed.classList.remove("hidden");
    }
}
// функція для обробки відправки форми входу (тестова, без відправки самих даних)
$(document).ready(function () {
    $('#loginForm').on('submit', function (e) {
        // Перехоплюємо відправку
        e.preventDefault();

        // Перевіряємо валідацію jQuery Unobtrusive
        if ($(this).valid()) {
            // Отримуємо URL з атрибута data-redirect-url
            var url = $(this).data('redirect-url');

            // Переходимо за посиланням
            window.location.href = url;
        }
    });
});