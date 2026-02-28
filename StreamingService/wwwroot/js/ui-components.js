function setupScrollableCarousel(containerId, leftBtnId, rightBtnId, scrollStep = 360, hideButtons = true) {
    const carousel = document.getElementById(containerId);
    const leftButton = document.getElementById(leftBtnId);
    const rightButton = document.getElementById(rightBtnId);

    if (!carousel || !leftButton || !rightButton) return;

    rightButton.addEventListener('click', () => {
        carousel.scrollBy({ left: scrollStep, behavior: 'smooth' });
    });

    leftButton.addEventListener('click', () => {
        carousel.scrollBy({ left: -scrollStep, behavior: 'smooth' });
    });

    const updateButtons = () => {
        
        if (hideButtons) {
            const isAtStart = carousel.scrollLeft <= 0;
            const isAtEnd = carousel.scrollWidth - carousel.clientWidth <= carousel.scrollLeft + 1;

            leftButton.classList.toggle('hidden', isAtStart);
            leftButton.classList.toggle('opacity-0', isAtStart);

            rightButton.classList.toggle('hidden', isAtEnd);
            rightButton.classList.toggle('opacity-0', isAtEnd);
        }
        
        else {
            leftButton.classList.remove('hidden', 'opacity-0');
            rightButton.classList.remove('hidden', 'opacity-0');
        }
    };

    carousel.addEventListener('scroll', updateButtons);
    window.addEventListener('resize', updateButtons);

    updateButtons();
}