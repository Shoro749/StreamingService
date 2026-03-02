document.addEventListener('DOMContentLoaded', () => {
    const slides = document.querySelectorAll('.js-hero-slide');
    const dots = document.querySelectorAll('.js-hero-dot');

    if (slides.length < 2) return;

    const positionClasses = [
        "left-0 top-8 w-[1109px] h-[533px] z-30 opacity-100",
        "left-80 top-13 w-[1020px] h-[491px] z-20 opacity-100",
        "right-0 top-20 w-[909px] h-[437px] z-10 opacity-100",
        "-right-48 top-30 w-[800px] h-[350px] z-0 opacity-0"
    ];

    const baseClasses = "absolute transition-all duration-1000 ease-in-out js-hero-slide";
    let activeIndex = 0;

    function updateSlides() {
        slides.forEach((slide, index) => {
            // 1. Визначаємо позицію
            let posIdx = (index - activeIndex + slides.length) % slides.length;
            if (posIdx > 3) posIdx = 3;

            // 2. Оновлюємо класи самого слайда (рух)
            slide.className = `${baseClasses} ${positionClasses[posIdx]}`;

            // 3. Керуємо видимістю тексту (js-hero-content)
            const content = slide.querySelector('.js-hero-content');
            if (content) {
                if (posIdx === 0) {
                    content.classList.remove('opacity-0');
                    content.classList.add('opacity-100');
                    slide.style.pointerEvents = "auto";
                } else {
                    content.classList.remove('opacity-100');
                    content.classList.add('opacity-0');
                    slide.style.pointerEvents = "none";
                }
            }
        });

        // 4. Оновлюємо крапочки
        dots.forEach((dot, index) => {
            if (index === activeIndex) {
                dot.className = "js-hero-dot transition-all duration-300 rounded-full w-3 h-3 bg-[#DCF260] shadow-[0_0_10px_#DCF260]";
            } else {
                dot.className = "js-hero-dot transition-all duration-300 rounded-full w-2 h-2 bg-white/50";
            }
        });
    }

    function nextSlide() {
        activeIndex = (activeIndex + 1) % slides.length;
        updateSlides();
    }

    setInterval(nextSlide, 7000);
    updateSlides();
});