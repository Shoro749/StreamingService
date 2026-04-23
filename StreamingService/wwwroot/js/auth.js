function togglePassword(inputId, eyeOpenId, eyeClosedId) {
    var input = document.getElementById(inputId);
    var eyeOpen = document.getElementById(eyeOpenId);
    var eyeClosed = document.getElementById(eyeClosedId);

    if (!input) return;

    if (input.type === "password") {
        input.type = "text";
        if (eyeOpen) {
            eyeOpen.classList.remove("hidden");
            eyeOpen.classList.add("block");
        }
        if (eyeClosed) {
            eyeClosed.classList.add("hidden");
            eyeClosed.classList.remove("block");
        }
    } else {
        input.type = "password";
        if (eyeOpen) {
            eyeOpen.classList.add("hidden");
            eyeOpen.classList.remove("block");
        }
        if (eyeClosed) {
            eyeClosed.classList.remove("hidden");
            eyeClosed.classList.add("block");
        }
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