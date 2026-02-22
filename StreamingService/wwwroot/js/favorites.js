document.addEventListener('click', async (e) => {
    const favoriteBtn = e.target.closest('.js-favorite-btn');

    if (favoriteBtn) {
        e.preventDefault();
        e.stopPropagation();

        const videoId = favoriteBtn.dataset.videoId;
        const isCurrentlyFavorite = favoriteBtn.dataset.isFavorite === 'true';

        // ТИМЧАСОВО ЗАКОМЕНТОВАНО ДЛЯ ТЕСТУВАННЯ ВІЗУАЛУ
        /*
        try {
            const response = await fetch('/api/favorites/toggle', { //// випадкове посилання
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ videoId })
            });

            if (response.ok) {
                const result = await response.json(); ////статус з бази
            }
        } catch (error) {
            console.error('Помилка при зміні статусу улюбленого:', error);
        }
        */

        const allButtons = document.querySelectorAll(`.js-favorite-btn[data-video-id="${videoId}"]`);
        allButtons.forEach((btn) => {
            btn.dataset.isFavorite = !isCurrentlyFavorite;
            btn.classList.toggle('text-[#FF0000]');
            btn.classList.toggle('text-white');
        });
    }
});