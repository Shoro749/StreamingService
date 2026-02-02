document.addEventListener('DOMContentLoaded', () => {
    const globalMenu = document.getElementById('global-context-menu');
    let currentMovieId = null;

    document.addEventListener('click', (e) => {

        const toggleBtn = e.target.closest('.js-menu-toggle');

        if (toggleBtn) {
            e.preventDefault();
            e.stopPropagation();

            const movieId = toggleBtn.dataset.menuId;

            if (currentMovieId === movieId && !globalMenu.classList.contains('hidden')) {
                closeMenu();
                return;
            }

            openMenu(toggleBtn, movieId);
        }

        else if (!e.target.closest('#global-context-menu')) {
            closeMenu();
        }
    });

    function openMenu(button, movieId) {
        currentMovieId = movieId;

        globalMenu.dataset.currentMovieId = movieId;

        const rect = button.getBoundingClientRect();

        let top = rect.bottom + window.scrollY + 5;
        let left = rect.left + window.scrollX - 140; 

        globalMenu.classList.remove('hidden');

        globalMenu.style.top = `${top}px`;
        globalMenu.style.left = `${left}px`;
    }

    function closeMenu() {
        globalMenu.classList.add('hidden');
        currentMovieId = null;
    }

    window.addEventListener('scroll', closeMenu, { passive: true });
});