document.addEventListener('DOMContentLoaded', async () => {
    const player = new Plyr('#main-player');
    const backBtn = document.getElementById('back-link');
    const videoId = window.location.pathname.split('/').pop();

    player.on('pause', async () => {
        backBtn.classList.add('!opacity-100')
        if (videoId) {
            const videoElement = document.getElementById('main-player');
            const title = videoElement.dataset.title;
            const poster = videoElement.dataset.poster;

            localStorage.setItem('last_video_id', videoId);
            localStorage.setItem(`video_progress_${videoId}`, player.currentTime);
            localStorage.setItem(`video_duration_${videoId}`, player.duration);
            if (title) localStorage.setItem(`video_title_${videoId}`, title);
            if (poster) localStorage.setItem(`video_poster_${videoId}`, poster);

            try {
                await fetch('/api/history/save', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },

                    body: JSON.stringify({
                        videoId: videoId,
                        time: player.currentTime
                    })
                });
                console.log(`Збережено час: ${player.currentTime} сек для відео ${videoId}`);
            } catch (error) {
                console.error('Помилка збереження часу:', error);
            }
        }
    });

    player.on('play', () => {
        backBtn.classList.remove('!opacity-100')
    });

    if (videoId) {
        let startTime = 0;

        try {

            const response = await fetch(`/api/history/${videoId}`);
            if (response.ok) {
                const data = await response.json();
                startTime = data.time;
            } else {

                startTime = localStorage.getItem(`video_progress_${videoId}`);
            }
        } catch (error) {

            startTime = localStorage.getItem(`video_progress_${videoId}`);
        }

        if (startTime > 0) {
            const timeToSet = parseFloat(startTime);

            if (player.media.readyState >= 1) {
                player.currentTime = timeToSet;
                console.log(`Відео миттєво відновлено з ${timeToSet} сек.`);
            } else {
                player.once('loadedmetadata', () => {
                    player.currentTime = timeToSet;
                    console.log(`Відео відновлено після завантаження з ${timeToSet} сек.`);
                });
            }
        }
    }
});

