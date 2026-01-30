document.addEventListener('DOMContentLoaded', function () {
    const menuBtn = document.getElementById('menuBtn');
    const menu = document.getElementById('dropdownMenu');
    const arrow = document.getElementById('menuArrow');

    if (!menuBtn || !menu || !arrow) return;

    function toggleMenu() {
        menu.classList.toggle('hidden');
        arrow.classList.toggle('rotate-180');
    }

    menuBtn.addEventListener('click', function (e) {
        e.stopPropagation(); 
        toggleMenu();
    });

    window.addEventListener('click', function (e) {
        if (!menu.classList.contains('hidden') && !menu.contains(e.target) && e.target !== menuBtn) {
            menu.classList.add('hidden');
            arrow.classList.remove('rotate-180');
        }
    });
});