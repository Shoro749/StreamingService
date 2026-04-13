document.addEventListener('DOMContentLoaded', () => {
    const historyContainer = document.getElementById('js-history-container');
    const template = document.getElementById('history-item-template');

    if (!historyContainer || !template) return;

    const lastId = localStorage.getItem('last_video_id');

    if (lastId && !document.querySelector(`.js-history-item[data-video-id="${lastId}"]`)) {
        const clone = template.content.cloneNode(true);
        const itemWrapper = clone.querySelector('.js-history-item');
        const poster = clone.querySelector('.js-history-poster');
        const title = clone.querySelector('.js-history-title');
        const durationText = clone.querySelector('.js-history-duration');
        const progressText = clone.querySelector('.js-history-progress');
        const watchBtn = clone.querySelector('.js-watch-btn');
        const removeBtn = clone.querySelector('.js-remove-history-btn');

        const savedTime = localStorage.getItem(`video_progress_${lastId}`);
        const totalDuration = localStorage.getItem(`video_duration_${lastId}`);
        const savedTitle = localStorage.getItem(`video_title_${lastId}`);
        const savedPoster = localStorage.getItem(`video_poster_${lastId}`);

        itemWrapper.dataset.videoId = lastId;
        watchBtn.dataset.videoId = lastId;
        removeBtn.dataset.videoId = lastId;

        if (savedTitle) title.innerText = savedTitle;
        if (savedPoster) poster.src = savedPoster;

        if (savedTime && totalDuration) {
            const durationMinutes = Math.round(totalDuration / 60);
            durationText.innerText = `${durationMinutes} хв`;

            const percent = Math.round((savedTime / totalDuration) * 100);
            progressText.innerText = `${percent}%`;

            if (percent >= 100) {
                watchBtn.innerText = "Дивитись знову";
                watchBtn.className = "js-watch-btn shadow-glass px-5 py-2 bg-white/10 hover:bg-white/20 rounded-sm text-white transition-all text-sm font-medium";

                durationText.style.display = 'none';
                progressText.classList.add('w-full', 'rounded-full', 'shadow-[3px_0_5.5px_rgba(132,132,132,0.42)]');
                progressText.classList.remove('flex-1');
            }
        }

        historyContainer.appendChild(clone);
    }
});