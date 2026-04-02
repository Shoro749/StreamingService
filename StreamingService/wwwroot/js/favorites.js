document.addEventListener('click', async (e) => {
    const favoriteBtn = e.target.closest('.js-favorite-btn');
    if (favoriteBtn) {
        const videoId = favoriteBtn.dataset.videoId;
        const isCurrentlyFavorite = favoriteBtn.dataset.isFavorite === 'true';

        try {
            const response = await fetch('/Favorites/Toggle', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    videoId: parseInt(videoId),
                    listType: 1
                })
            });

            if (response.ok) {
                const result = await response.json();

                if (result.success) {
                    const allButtons = document.querySelectorAll(`.js-favorite-btn[data-video-id="${videoId}"]`);
                    allButtons.forEach((btn) => {
                        btn.dataset.isFavorite = result.isAdded.toString();

                        if (result.isAdded) {
                            btn.classList.remove('text-white');
                            btn.classList.add('text-[#FF0000]');
                        } else {
                            btn.classList.remove('text-[#FF0000]');
                            btn.classList.add('text-white');
                        }
                    });

                    if (!result.isAdded && window.location.pathname === '/favorites') {
                        location.reload();
                    }
                }
            }
        } catch (error) {
            console.error('Помилка при зміні статусу улюбленого:', error);
        }
    }
});