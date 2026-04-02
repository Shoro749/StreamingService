document.addEventListener('click', async (e) => {
    const saveForLaterBtn = e.target.closest('.js-save-for-later-btn');

    if (!saveForLaterBtn) return;

    e.preventDefault();
    e.stopPropagation()

    //if (saveForLaterBtn.dataset.isFavorite === 'true') {
    //    alert('Не можна любити в два рази сильніше!');
    //    return;
    //}
    
    const videoId = saveForLaterBtn.dataset.videoId;
    const isCurrentlySaved = saveForLaterBtn.dataset.isSaved === 'true' || false;
    
    try {
        const response = await fetch('Favorites/toggle', { 
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                videoId: parseInt(videoId),
                listType: 2
            })
        });

        if (response.ok) {
            const result = await response.json();

            if (result.success) {
                const allButtons = document.querySelectorAll(`.js-save-for-later-btn[data-video-id="${videoId}"]`);

                allButtons.forEach((btn) => {
                    const newSavedState = result.isAdded;
                    btn.dataset.isSaved = newSavedState.toString();

                    if (newSavedState) {
                        btn.classList.remove('bg-white/10');
                        btn.classList.add('bg-white/20');
                    } else {
                        btn.classList.remove('bg-white/20');
                        btn.classList.add('bg-white/10');
                    }

                    const iconDiv = btn.querySelector('div[style*="mask-image"]');
                    if (iconDiv) {
                        if (newSavedState) {
                            iconDiv.classList.remove('bg-white', 'group-hover:bg-[#DCF260]');
                            iconDiv.classList.add('bg-[#DCF260]', 'group-hover:bg-white');
                        } else {
                            iconDiv.classList.remove('bg-[#DCF260]', 'group-hover:bg-white');
                            iconDiv.classList.add('bg-white', 'group-hover:bg-[#DCF260]');
                        }
                    }
                });

                if (!result.isAdded && window.location.pathname === '/favorites') {
                    location.reload();
                }
            }
        }
    } catch (error) {
        console.error('Помилка при зміні статусу "На потім":', error);
    }
});