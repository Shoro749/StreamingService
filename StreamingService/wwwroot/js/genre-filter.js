// Масив обраних жанрів
let selectedGenres = [];
let originalContent = null;

// Обробка кліків на жанри
document.addEventListener('click', async (e) => {
    const genreBtn = e.target.closest('.genre-btn');
    if (genreBtn) {
        e.preventDefault();

        const genreCode = genreBtn.dataset.genreCode;

        // Toggle жанр
        if (selectedGenres.includes(genreCode)) {
            selectedGenres = selectedGenres.filter(g => g !== genreCode);
            genreBtn.classList.remove('bg-[#D0F260]', 'text-[#22223A]');
            genreBtn.classList.add('bg-white/10', 'text-white');
        } else {
            selectedGenres.push(genreCode);
            genreBtn.classList.remove('bg-white/10', 'text-white');
            genreBtn.classList.add('bg-[#D0F260]', 'text-[#22223A]');
        }

        // Фільтруємо відео
        if (selectedGenres.length > 0) {
            await filterVideosByGenres();
        } else {
            restoreOriginalContent();
        }
    }
});

// Визначення типу сторінки
function getPageType() {
    if (document.getElementById('video-collections')) {
        return 'movies'; // Сторінка Movies з каруселями
    } else if (window.location.pathname.includes('/favorites')) {
        return 'favorites'; // Сторінка Favorites
    } else if (document.querySelector('section.mb-16 .grid')) {
        return 'catalog'; // Сторінка Catalog
    }
    return null;
}

// Функція фільтрації (визначає тип сторінки автоматично)
async function filterVideosByGenres() {
    const pageType = getPageType();

    if (pageType === 'movies') {
        await filterCarousels('/Home/FilterByGenres');
    } else if (pageType === 'favorites') {
        await filterGrid('/Home/FilterFavoritesByGenres'); // ОКРЕМИЙ ENDPOINT
    } else if (pageType === 'catalog') {
        await filterGrid('/Home/FilterByGenres');
    }
}

// Фільтрація для каруселей (Movies)
async function filterCarousels(endpoint) {
    try {
        const response = await fetch(endpoint, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ genreCodes: selectedGenres })
        });

        if (response.ok) {
            const result = await response.json();

            if (result.success && result.videos) {
                updateCarousels(result.videos);
            }
        }
    } catch (error) {
        console.error('Помилка фільтрації:', error);
    }
}

// Фільтрація для сітки (Favorites/Catalog)
async function filterGrid(endpoint) {
    try {
        const response = await fetch(endpoint, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ genreCodes: selectedGenres })
        });

        if (response.ok) {
            const result = await response.json();

            if (result.success && result.videos) {
                updateGrid(result.videos);
            }
        }
    } catch (error) {
        console.error('Помилка фільтрації:', error);
    }
}

// Оновлення каруселей
function updateCarousels(filteredVideos) {
    const videoCollections = document.getElementById('video-collections');
    if (!videoCollections) return;

    // Зберігаємо оригінал
    if (!originalContent) {
        originalContent = videoCollections.innerHTML;
    }

    // Знаходимо всі секції
    const sections = videoCollections.querySelectorAll('.js-carousel-section');

    sections.forEach(section => {
        const carousel = section.querySelector('[id$="List"]');
        if (!carousel) return;

        carousel.innerHTML = '';

        if (filteredVideos.length > 0) {
            filteredVideos.forEach(video => {
                carousel.insertAdjacentHTML('beforeend', createVideoCard(video));
            });
        } else {
            carousel.innerHTML = `
                <div class="w-full flex justify-center items-center py-10">
                    <p class="text-white/50 text-lg">Немає відео з обраними жанрами</p>
                </div>
            `;
        }
    });
}

// Оновлення сітки
function updateGrid(filteredVideos) {
    const grid = document.querySelector('section.mb-16 .grid');
    if (!grid) return;

    // Зберігаємо оригінал
    if (!originalContent) {
        originalContent = grid.innerHTML;
    }

    grid.innerHTML = '';

    if (filteredVideos.length > 0) {
        filteredVideos.forEach(video => {
            grid.insertAdjacentHTML('beforeend', createVideoCard(video));
        });
    } else {
        const pageType = getPageType();
        const message = pageType === 'favorites'
            ? 'Немає улюблених відео з обраними жанрами'
            : 'Немає відео з обраними жанрами';

        grid.innerHTML = `
            <div class="col-span-full flex justify-center items-center py-20">
                <p class="text-white/50 text-xl font-montserrat">${message}</p>
            </div>
        `;
    }
}

// Відновлення оригінального контенту
function restoreOriginalContent() {
    if (!originalContent) return;

    const videoCollections = document.getElementById('video-collections');
    const grid = document.querySelector('section.mb-16 .grid');

    if (videoCollections) {
        videoCollections.innerHTML = originalContent;
    } else if (grid) {
        grid.innerHTML = originalContent;
    }

    originalContent = null;
}

// Створення картки відео (універсальна для каруселей і сітки)
function createVideoCard(video) {
    const heartColor = video.isFavorite ? 'text-[#FF0000]' : 'text-white';

    return `
        <div class="flex-shrink-0 w-64 xl:w-[calc((100%-96px)/5)] flex flex-col gap-3 group snap-start cursor-pointer transition-all duration-300">
            <div class="relative w-full aspect-[2/3] rounded-3xl overflow-hidden bg-gray-800">
                <img src="${video.posterUrl}" 
                     alt="${video.title}" 
                     class="w-full h-full object-cover transition-transform duration-500 group-hover:scale-110" />
                
                <button class="js-favorite-btn absolute top-3 right-4 z-10 transition-transform duration-300 hover:scale-110 ${heartColor} hover:text-[#FF0000]"
                        data-video-id="${video.id}"
                        data-is-favorite="${video.isFavorite}">
                    <svg class="w-8 h-8 drop-shadow-md" fill="currentColor" viewBox="0 0 24 24">
                        <path d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"></path>
                    </svg>
                </button>
                
                <div class="absolute inset-0 bg-black/20 opacity-0 group-hover:opacity-100 transition-opacity pointer-events-none"></div>
            </div>
            
            <div class="flex items-start justify-between pl-3 pr-2">
                <div class="min-w-0">
                    <h4 class="text-white font-montserrat font-semibold text-xl leading-none mb-2.5 truncate w-full" title="${video.title}">
                        ${video.title}
                    </h4>
                    <div class="flex items-center gap-4 font-montserrat font-semibold text-xl leading-none text-white/50">
                        <span>${video.year || ''}</span>
                        ${video.rating > 0 ? `
                            <span class="flex items-center gap-1 text-[#DCF260]">
                                <img src="/images/ui/symbols/star.svg" alt="Rating" class="w-5 h-5" />
                                ${video.rating.toFixed(1)}
                            </span>
                        ` : ''}
                    </div>
                </div>
            </div>
        </div>
    `;
}