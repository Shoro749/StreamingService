document.addEventListener('DOMContentLoaded', () => {

    const card = document.querySelector('.js-continue-card');
    const poster = document.querySelector('.js-sidebar-poster');
    const title = document.querySelector('.js-sidebar-title');
    const progressText = document.querySelector('.js-sidebar-progress-text');
    const lastId = localStorage.getItem('last_video_id');

    if (lastId && poster && title && progressText && card) {
        const savedTime = localStorage.getItem(`video_progress_${lastId}`);
        const totalDuration = localStorage.getItem(`video_duration_${lastId}`);
        const savedTitle = localStorage.getItem(`video_title_${lastId}`);
        const savedPoster = localStorage.getItem(`video_poster_${lastId}`);

        card.dataset.videoId = lastId;

        if (savedTime && totalDuration) {
            const percent = Math.round((savedTime / totalDuration) * 100);
            progressText.innerText = `${percent}%`;
        }

        if (savedTitle) {
            title.innerText = savedTitle;
        }

        if (savedPoster) {
            poster.src = savedPoster;
        }
    }
});

document.addEventListener('click', (e) => {
    const continueCard = e.target.closest('.js-continue-card');

    if (continueCard) {
        const videoId = continueCard.dataset.videoId;
        window.location.href = `/Movies/Play/${videoId}`;
    }
});