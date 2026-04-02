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
        }
    } catch (error) {
        console.error('Помилка при зміні статусу:', error);
    }


    const allButtons = document.querySelectorAll(`.js-save-for-later-btn[data-video-id="${videoId}"]`);
    allButtons.forEach((btn) => {
        btn.dataset.isSaved = !isCurrentlySaved;

        btn.classList.toggle('bg-white/10');
        btn.classList.toggle('bg-white/20');

        const iconDiv = btn.querySelector('div');

        if (iconDiv) {
            iconDiv.classList.toggle('bg-white');
            iconDiv.classList.toggle('group-hover/btn:bg-[#DCF260]');

            iconDiv.classList.toggle('bg-[#DCF260]');
            iconDiv.classList.toggle('group-hover/btn:bg-white');
        }
    });

});