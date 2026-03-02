function toggleFaq(button) {
    const item = button.parentElement;
    const answer = item.querySelector('.faq-answer');
    const icon = item.querySelector('.faq-icon');

    const isOpen = !answer.classList.contains('max-h-0');

    if (isOpen) {
        answer.style.maxHeight = null;
        answer.classList.add('max-h-0', 'opacity-0');
        icon.classList.remove('rotate-135');
        item.classList.remove('bg-[#3A3A61]/70');
    } else {
        answer.classList.remove('max-h-0', 'opacity-0');
        answer.style.maxHeight = answer.scrollHeight + "px";
        icon.classList.add('rotate-135');
        item.classList.add('bg-[#3A3A61]/70');
    }
}

document.addEventListener('DOMContentLoaded', () => {

    const slides = [
        '/images/landing/Landing_robot.png',
        '/images/landing/Landing_revenant.png',
        '/images/landing/Landing_dexter.png'
    ];

    let currentSlide = 0;
    const totalSlides = slides.length;
    const heroSection = document.getElementById('hero-section');

    if (heroSection) {
        function updateIndicators(activeIndex) {
            for (let i = 0; i < totalSlides; i++) {
                const slideEl = document.getElementById(`slide-${i}`);
                if (!slideEl) continue;

                const dot = slideEl.children[0];
                const line = slideEl.children[1];

                if (i === activeIndex) {
                    slideEl.classList.remove('opacity-50');
                    dot.classList.remove('bg-white', 'w-2.5', 'h-2.5');
                    dot.classList.add('bg-[#DCF260]', 'shadow-[0_0_10px_#DCF260]', 'w-4', 'h-4');
                    line.classList.remove('bg-white');
                    line.classList.add('bg-[#DCF260]');
                } else {
                    slideEl.classList.add('opacity-50');
                    dot.classList.remove('bg-[#DCF260]', 'shadow-[0_0_10px_#DCF260]', 'w-4', 'h-4');
                    dot.classList.add('bg-white', 'w-2.5', 'h-2.5');
                    line.classList.remove('bg-[#DCF260]');
                    line.classList.add('bg-white');
                }
            }
        }

        function setSlide(index) {
            if (index >= totalSlides) index = 0;
            if (index < 0) index = totalSlides - 1;

            currentSlide = index;
            heroSection.style.backgroundImage = `url('${slides[currentSlide]}')`;
            updateIndicators(currentSlide);
        }

        setInterval(() => {
            setSlide(currentSlide + 1);
        }, 3000);
    }

    setupScrollableCarousel('topMoviesCarousel', 'scrollLeftBtn', 'scrollRightBtn');

});