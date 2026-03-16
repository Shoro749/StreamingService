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

    const cards = document.querySelectorAll('.recommended-card');
    let currentIndex = 0;

    function updateCards() {
        cards.forEach((card, index) => {
            if (index === currentIndex) {
                card.classList.add('w-[204px]', 'h-[230px]');
                card.classList.remove('w-[162px]', 'h-[187px]');
                card.scrollIntoView({ behavior: 'smooth', block: 'nearest', inline: 'nearest' });
            } else {
                card.classList.add('w-[162px]', 'h-[187px]');
                card.classList.remove('w-[204px]', 'h-[230px]');
            }
        });
    }

    updateCards();

    document.addEventListener('keydown', function (event) {
        if (isVisible && cards.length > 0) {
            if (event.key === 'ArrowRight') {
                if (currentIndex < cards.length - 1) {
                    currentIndex++;
                    event.preventDefault();
                    updateCards();
                }
            } else if (event.key === 'ArrowLeft') {
                if (currentIndex > 0) {
                    currentIndex--;
                    event.preventDefault();
                    updateCards();
                }
            }
        }
    });               
    
    cards.forEach((card, index) => {
        card.addEventListener('click', function () {
            currentIndex = index;
            updateCards();
        });
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