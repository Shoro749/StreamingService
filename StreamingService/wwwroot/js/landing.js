// Функція FAQ має бути доступна глобально, тому залишаємо її ззовні
function toggleFaq(button) {
    // 1. Знаходимо батьківський блок (.faq-item)
    const item = button.parentElement;

    // 2. Знаходимо відповідь та іконку всередині
    const answer = item.querySelector('.faq-answer');
    const icon = item.querySelector('.faq-icon');

    // 3. Перевіряємо, чи блок вже відкритий
    const isOpen = !answer.classList.contains('max-h-0');

    if (isOpen) {
        // ЗАКРИВАЄМО
        answer.style.maxHeight = null;
        answer.classList.add('max-h-0', 'opacity-0');
        icon.classList.remove('rotate-135'); // Прибираємо поворот
        item.classList.remove('bg-[#3A3A61]/70'); // Повертаємо прозорість фону
    } else {
        // ВІДКРИВАЄМО (якщо ми закрили всі інші вище, тут просто відкриваємо поточний)
        answer.classList.remove('max-h-0', 'opacity-0');
        answer.style.maxHeight = answer.scrollHeight + "px";
        icon.classList.add('rotate-135'); // Додаємо поворот
        item.classList.add('bg-[#3A3A61]/70'); // Робимо фон активним
    }
}

// А ось слайдер ініціалізуємо тільки коли сторінка готова
document.addEventListener('DOMContentLoaded', () => {

    const slides = [
        '/images/landing/Landing_robot.png',
        '/images/landing/Landing_revenant.png',
        '/images/landing/Landing_dexter.png'
    ];

    let currentSlide = 0;
    const totalSlides = slides.length;

    // Тепер цей елемент точно знайдеться
    const heroSection = document.getElementById('hero-section');

    // Перевірка, чи існує heroSection (щоб не було помилок на інших сторінках)
    if (!heroSection) return;

    // Функція оновлення індикаторів
    function updateIndicators(activeIndex) {
        for (let i = 0; i < totalSlides; i++) {
            const slideEl = document.getElementById(`slide-${i}`);
            // Перевірка на випадок, якщо індикатори ще не створені
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

    // Головна функція зміни слайду
    function setSlide(index) {
        if (index >= totalSlides) index = 0;
        if (index < 0) index = totalSlides - 1;

        currentSlide = index;
        heroSection.style.backgroundImage = `url('${slides[currentSlide]}')`;
        updateIndicators(currentSlide);
    }

    // Запускаємо таймер
    setInterval(() => {
        setSlide(currentSlide + 1);
    }, 3000);
});