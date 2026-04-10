document.addEventListener('DOMContentLoaded', async () => {
    const playerEl = document.getElementById('main-player');
    if (!playerEl) return;

    const episodeId = playerEl.dataset.episodeId;
    const startTime = parseFloat(playerEl.dataset.startTime) || 0;

    const player = new Plyr('#main-player');
    const backBtn = document.getElementById('back-link');

    player.once('canplay', () => {
        if (startTime > 0) {
            player.currentTime = startTime;
            console.log(`Відео відновлено з ${startTime} сек.`);
        }
    });

    const saveProgress = async () => {
        if (!episodeId) return;

        try {
            await fetch('/api/history/save', {
                method: 'POST',
                headers: { 
                     'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    EpisodeId: parseInt(episodeId),
                    CurrentTime: Math.floor(player.currentTime),
                    Duration: Math.floor(player.duration || 0)
                })
            });
            console.log(`Збережено час: ${player.currentTime} сек для серії ${episodeId}`);
        } catch (error) {
            console.error('Помилка збереження часу:', error);
        }
    };

    player.on('pause', async () => {
        if (backBtn) backBtn.classList.add('!opacity-100');
        await saveProgress();
    });

    player.on('play', () => {
        if (backBtn) backBtn.classList.remove('!opacity-100');
    });

    // Регулярне збереження (кожні 10 секунд)
    setInterval(() => {
        if (player.playing) {
            saveProgress();
        }
    }, 10000);
});
