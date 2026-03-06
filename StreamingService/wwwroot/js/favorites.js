// Функція для toggle фаворитів
//async function toggleFavorite(videoId, buttonElement) {
//    try {
//        const response = await fetch('/Favorites/Toggle', {
//            method: 'POST',
//            headers: {
//                'Content-Type': 'application/json',
//                'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]')?.value
//            },
//            body: JSON.stringify({ videoId: videoId })
//        });

//        const result = await response.json();

//        if (result.success) {
//            // Оновлюємо іконку
//            const icon = buttonElement.querySelector('svg') || buttonElement;

//            if (result.isFavorite) {
//                // Додано до фаворитів - заповнене серце
//                icon.innerHTML = `
//                    <path fill="currentColor" d="M12 21.35l-1.45-1.32C5.4 15.36 2 12.28 2 8.5 2 5.42 4.42 3 7.5 3c1.74 0 3.41.81 4.5 2.09C13.09 3.81 14.76 3 16.5 3 19.58 3 22 5.42 22 8.5c0 3.78-3.4 6.86-8.55 11.54L12 21.35z"/>
//                `;
//                buttonElement.classList.add('text-red-500');
//            } else {
//                // Видалено з фаворитів - порожнє серце
//                icon.innerHTML = `
//                    <path stroke="currentColor" stroke-width="2" fill="none" d="M12 21.35l-1.45-1.32C5.4 15.36 2 12.28 2 8.5 2 5.42 4.42 3 7.5 3c1.74 0 3.41.81 4.5 2.09C13.09 3.81 14.76 3 16.5 3 19.58 3 22 5.42 22 8.5c0 3.78-3.4 6.86-8.55 11.54L12 21.35z"/>
//                `;
//                buttonElement.classList.remove('text-red-500');
//            }
//        }
//    } catch (error) {
//        console.error('Error toggling favorite:', error);
//    }
//}

document.addEventListener('click', async (e) => {
    const favoriteBtn = e.target.closest('.js-favorite-btn');
    if (favoriteBtn) {
        e.preventDefault();
        e.stopPropagation();

        const videoId = favoriteBtn.dataset.videoId;
        const isCurrentlyFavorite = favoriteBtn.dataset.isFavorite === 'true';

        try {
            const response = await fetch('/Favorites/Toggle', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]')?.value || ''
                },
                body: JSON.stringify({ videoId: parseInt(videoId) })
            });

            if (response.ok) {
                const result = await response.json();

                if (result.success) {
                    const allButtons = document.querySelectorAll(`.js-favorite-btn[data-video-id="${videoId}"]`);
                    allButtons.forEach((btn) => {
                        btn.dataset.isFavorite = result.isFavorite;

                        if (result.isFavorite) {
                            btn.classList.add('text-[#FF0000]');
                            btn.classList.remove('text-white');
                        } else {
                            btn.classList.remove('text-[#FF0000]');
                            btn.classList.add('text-white');
                        }
                    });

                    // Опціонально: Показати повідомлення
                    console.log(result.isFavorite ? 'Додано до улюблених' : 'Видалено з улюблених');
                }
            } else {
                console.error('Помилка сервера:', response.status);
            }
        } catch (error) {
            console.error('Помилка при зміні статусу улюбленого:', error);

            const allButtons = document.querySelectorAll(`.js-favorite-btn[data-video-id="${videoId}"]`);
            allButtons.forEach((btn) => {
                btn.dataset.isFavorite = !isCurrentlyFavorite;
                btn.classList.toggle('text-[#FF0000]');
                btn.classList.toggle('text-white');
            });
        }
    }
});

//document.addEventListener('click', async (e) => {
//    const favoriteBtn = e.target.closest('.js-favorite-btn');

//    if (favoriteBtn) {
//        e.preventDefault();
//        e.stopPropagation();

//        const videoId = favoriteBtn.dataset.videoId;
//        const isCurrentlyFavorite = favoriteBtn.dataset.isFavorite === 'true';

//        // ТИМЧАСОВО ЗАКОМЕНТОВАНО ДЛЯ ТЕСТУВАННЯ ВІЗУАЛУ
//        /*
//        try {
//            const response = await fetch('/api/favorites/toggle', { //// випадкове посилання
//                method: 'POST',
//                headers: { 'Content-Type': 'application/json' },
//                body: JSON.stringify({ videoId })
//            });

//            if (response.ok) {
//                const result = await response.json(); ////статус з бази
//            }
//        } catch (error) {
//            console.error('Помилка при зміні статусу улюбленого:', error);
//        }
//        */

//        const allButtons = document.querySelectorAll(`.js-favorite-btn[data-video-id="${videoId}"]`);
//        allButtons.forEach((btn) => {
//            btn.dataset.isFavorite = !isCurrentlyFavorite;
//            btn.classList.toggle('text-[#FF0000]');
//            btn.classList.toggle('text-white');
//        });
//    }
//});