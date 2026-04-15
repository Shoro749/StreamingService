document.addEventListener("DOMContentLoaded", function () {
    const toggles = document.querySelectorAll('.toggle-auto-save');
    
    toggles.forEach(toggle => {
        toggle.addEventListener('change', function () {
            const form = document.getElementById('privacyForm');
            if (form) {
                form.submit();
            }
        });
    });
});