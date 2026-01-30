document.addEventListener('DOMContentLoaded', () => {

    setupScrollableCarousel('genresList', 'genresLeftBtn', 'genresRightBtn', 200, false);

    const sections = document.querySelectorAll('.js-carousel-section');

    sections.forEach(section => {
        const id = section.dataset.sectionId;
        if (id && typeof setupScrollableCarousel === 'function') {
            setupScrollableCarousel(`${id}List`, `${id}LeftBtn`, `${id}RightBtn`, 360, false);
        }
    });
});