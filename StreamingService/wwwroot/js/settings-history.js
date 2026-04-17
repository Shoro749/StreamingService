document.addEventListener('DOMContentLoaded', () => {
    const historyContainer = document.getElementById('js-history-container');
    const template = document.getElementById('history-item-template');

    if (historyContainer && template) {
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
                    durationText.style.display = 'none';
                    progressText.classList.add('w-full', 'rounded-full', 'shadow-[3px_0_5.5px_rgba(132,132,132,0.42)]');
                    progressText.classList.remove('flex-1');
                }
            }

            historyContainer.appendChild(clone);
        }
    }

    document.addEventListener('click', async function (e) {
        
        if (e.target.closest('.js-watch-btn')) {
            const btn = e.target.closest('.js-watch-btn');
            const videoId = btn.dataset.videoId;
            if (videoId) {
                window.location.href = `/Movies/Play/${videoId}`;
            }
        }

        if (e.target.closest('.js-remove-history-btn')) {
            const btn = e.target.closest('.js-remove-history-btn');
            const videoId = btn.dataset.videoId;
            const historyItem = btn.closest('.js-history-item');

            if (!videoId || !historyItem) return;

            try {
                const response = await fetch(`/api/history/remove/${videoId}`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                });

                if (response.ok) {
                    historyItem.style.transition = "opacity 0.3s ease, transform 0.3s ease";
                    historyItem.style.opacity = "0";
                    historyItem.style.transform = "scale(0.95)";
                    
                    setTimeout(() => {
                        historyItem.remove();

                        if (document.querySelectorAll('.js-history-item:not(template .js-history-item)').length === 0) {
                            const container = document.querySelector('.flex.flex-col.gap-5');
                            if (container) {
                                container.innerHTML = '<div class="text-white/60 text-center py-10">Ваша історія порожня.</div>';
                            }
                        }
                    }, 300);

                    if (localStorage.getItem('last_video_id') === videoId) {
                        localStorage.removeItem('last_video_id');
                        localStorage.removeItem(`video_progress_${videoId}`);
                        localStorage.removeItem(`video_duration_${videoId}`);
                        localStorage.removeItem(`video_title_${videoId}`);
                        localStorage.removeItem(`video_poster_${videoId}`);
                    }
                } else {
                    console.error('Помилка видалення з історії на сервері');
                }
            } catch (error) {
                console.error('Помилка мережі при видаленні:', error);
            }
        }
    });
});