document.addEventListener('DOMContentLoaded', () => {
    const player = new Plyr('#main-player');

    const backBtn = document.getElementById('back-link');

    player.on('pause', () => {
        backBtn.classList.add('!opacity-100')
    });

    player.on('play', () => {
        backBtn.classList.remove('!opacity-100')
    });
});