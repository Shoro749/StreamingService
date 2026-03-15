document.addEventListener('DOMContentLoaded', function () {
    const carousel = document.getElementById('recommended-videos-container');
    let isVisible = false;

    window.addEventListener('wheel', function (event) {
        if (event.deltaY > 0 && !isVisible) {
            carousel.classList.remove('opacity-0', 'translate-y-full');
            carousel.classList.add('opacity-100', 'translate-y-0');
            isVisible = true;
        }
        else if (event.deltaY < 0 && isVisible) {
            carousel.classList.remove('opacity-100', 'translate-y-0');
            carousel.classList.add('opacity-0', 'translate-y-full');
            isVisible = false;
        }
    });

    setupScrollableCarousel('video-actors-container', 'video-actors-left', 'video-actors-right', 150, false);

    const sceneSlider = new SceneStepper('video-scenes-container', {
        activeClasses: ['scale-105', 'origin-left', 'brightness-100', 'border', 'border-white', 'z-10'],
        inactiveClasses: ['scale-100', 'brightness-75', 'z-0']
    });

    const leftBtn = document.getElementById('video-scenes-left');
    const rightBtn = document.getElementById('video-scenes-right');

    if (leftBtn) {
        leftBtn.addEventListener('click', function (e) {
            e.preventDefault();
            sceneSlider.prev();
        });
    }

    if (rightBtn) {
        rightBtn.addEventListener('click', function (e) {
            e.preventDefault();
            sceneSlider.next();
        });
    }
});