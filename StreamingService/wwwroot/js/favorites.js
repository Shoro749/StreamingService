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
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ videoId: parseInt(videoId) })
            });

            if (response.ok) {
                const result = await response.json();

                if (result.success) {
                    const allButtons = document.querySelectorAll(`.js-favorite-btn[data-video-id="${videoId}"]`);
                    allButtons.forEach((btn) => {
                        btn.dataset.isFavorite = result.isFavorite.toString();

                        if (result.isFavorite) {
                            btn.classList.remove('text-white');
                            btn.classList.add('text-[#FF0000]');
                        } else {
                            btn.classList.remove('text-[#FF0000]');
                            btn.classList.add('text-white');
                        }
                    });
                }
            }
        } catch (error) {
            console.error('Помилка при зміні статусу улюбленого:', error);
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

//        try {
//            const response = await fetch('/Favorites/Toggle', {
//                method: 'POST',
//                headers: {
//                    'Content-Type': 'application/json',
//                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]')?.value || ''
//                },
//                body: JSON.stringify({ videoId: parseInt(videoId) })
//            });

//            if (response.ok) {
//                const result = await response.json();

//                if (result.success) {
//                    const allButtons = document.querySelectorAll(`.js-favorite-btn[data-video-id="${videoId}"]`);
//                    allButtons.forEach((btn) => {
//                        btn.dataset.isFavorite = result.isFavorite;

//                        if (result.isFavorite) {
//                            btn.classList.add('text-[#FF0000]');
//                            btn.classList.remove('text-white');
//                        } else {
//                            btn.classList.remove('text-[#FF0000]');
//                            btn.classList.add('text-white');
//                        }
//                    });

//                    console.log(result.isFavorite ? 'Додано до улюблених' : 'Видалено з улюблених');
//                }
//            } else {
//                console.error('Помилка сервера:', response.status);
//            }
//        } catch (error) {
//            console.error('Помилка при зміні статусу улюбленого:', error);

//            const allButtons = document.querySelectorAll(`.js-favorite-btn[data-video-id="${videoId}"]`);
//            allButtons.forEach((btn) => {
//                btn.dataset.isFavorite = !isCurrentlyFavorite;
//                btn.classList.toggle('text-[#FF0000]');
//                btn.classList.toggle('text-white');
//            });
//        }
//    }
//});