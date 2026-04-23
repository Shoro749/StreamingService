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

function createVideoCard(video) {
    const heartColor = video.isFavorite ? 'text-[#FF0000]' : 'text-white';
    const btnTitle = video.isFavorite ? 'Видалити з улюбленого' : 'Додати до улюбленого';
    const isUpcoming = video.isUpcoming ? 'true' : 'false';
    const isSaved = video.isSavedForLater ? 'true' : 'false';
    const isFav = video.isFavorite ? 'true' : 'false';
    
    const ratingStr = video.rating > 0 ? video.rating.toFixed(1) : "0.0";
    const trailerUrl = video.trailerUrl || "#";
    const trailerDuration = video.trailerDuration || "00:00";
    const ageRating = video.ageRating || "12+";
    const firstGenre = (video.genres && video.genres.length > 0) ? video.genres[0] : "";
    const singularName = video.videoType || "Movie";

    let actorsHtml = '';
    if (video.actors && video.actors.length > 0) {
        actorsHtml = video.actors.map(actor => `
            <div class="flex flex-col items-center text-center min-w-24 snap-start">
                <div class="w-20 h-20 rounded-full overflow-hidden mb-3 shadow-xl">
                    <img src="${actor.imageUrl || '/images/placeholder-actor.jpg'}" class="w-full h-full object-cover" alt="${actor.name}">
                </div>
                <span class="text-white font-montserrat text-xs font-bold">${actor.name}</span>
                <span class="text-white/70 font-montserrat text-xs font-bold mt-1">${actor.character || ''}</span>
            </div>
        `).join('');
    }

    let scenesHtml = '';
    if (video.scenes && video.scenes.length > 0) {
        scenesHtml = video.scenes.map(scene => `
            <div class="js-carousel-item relative w-40 shrink-0 h-24 rounded snap-start cursor-pointer overflow-hidden transition-all duration-300 brightness-75 hover:brightness-100">
                <img src="${scene.sceneImageUrl || ''}" class="w-full h-full object-cover" alt="${scene.sceneName || 'Сцена'}">
            </div>
        `).join('');
    }

    return `
        <div class="flex-shrink-0 w-64 xl:w-[calc((100%-96px)/5)] flex flex-col gap-3 group snap-start cursor-pointer transition-all duration-300"
             data-video-id="${video.id}"
             data-is-upcoming="${isUpcoming}">
             
            <div class="relative w-full aspect-[2/3] rounded-3xl overflow-hidden bg-gray-800">
                <a href="/Movies/Details/${video.id}">
                    <img src="${video.posterUrl}" 
                         alt="${video.title.replace(/"/g, '&quot;')}" 
                         class="w-full h-full object-cover transition-transform duration-500 group-hover:scale-110" />
                </a>
                
                ${!video.isSavedForLater ? `
                <button class="js-favorite-btn absolute top-3 right-4 z-10 transition-transform duration-300 hover:scale-110 ${heartColor} hover:text-[#FF0000]"
                        data-video-id="${video.id}"
                        data-is-favorite="${isFav}"
                        title="${btnTitle}">
                    <svg class="w-8 h-8 drop-shadow-md" fill="currentColor" viewBox="0 0 24 24">
                        <path d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"></path>
                    </svg>
                </button>
                ` : ''}
                
                <div class="absolute inset-0 bg-black/20 opacity-0 group-hover:opacity-100 transition-opacity pointer-events-none"></div>
            </div>
            
            <div class="flex items-start justify-between pl-3 pr-2">
                <div class="min-w-0 flex-1">
                    <a href="/Movies/Details/${video.id}" class="hover:text-[#DCF260] transition-colors block">
                        <h4 class="text-white font-montserrat font-semibold text-xl leading-none mb-2.5 truncate w-full" title="${video.title.replace(/"/g, '&quot;')}">
                            ${video.title}
                        </h4>
                    </a>
                    
                    <div class="flex items-center gap-4 font-montserrat font-semibold text-xl leading-none text-white/50">
                        <span>${video.year || ''}</span>
                        ${video.isUpcoming ? `
                            <span class="flex items-center gap-1 text-white/70 text-sm font-medium">NR</span>
                        ` : (video.rating > 0 ? `
                            <span class="flex items-center gap-1 text-[#DCF260]">
                                <img src="/images/ui/symbols/star.svg" alt="Rating" class="w-5 h-5" />
                                ${ratingStr}
                            </span>
                        ` : '')}
                    </div>
                </div>

                <!-- КНОПКА КОНТЕКСТНОГО МЕНЮ  -->
                <div class="flex-shrink-0">
                    <button id="ctxBtn-${video.id}"
                            class="relative group/btn p-1.5 rounded-full text-white/60 transition-all duration-300 hover:text-white hover:bg-white/10 active:scale-95 -mr-2 js-menu-toggle"
                            data-menu-id="${video.id}"
                            data-video-id="${video.id}"
                            data-title="${video.title.replace(/"/g, '&quot;')}"
                            data-year="${video.year || ''}"
                            data-rating="${ratingStr}"
                            data-duration="${video.duration || ''}"
                            data-description="${(video.description || '').replace(/"/g, '&quot;')}"
                            data-image="${video.posterUrl || ''}"
                            data-age="${ageRating}"
                            data-genres="${firstGenre}"
                            data-trailer="${trailerUrl}"
                            data-trailer-duration="${trailerDuration}"
                            data-video-type="${singularName}"
                            data-is-upcoming="${isUpcoming}"
                            data-is-saved="${isSaved}"
                            data-is-favorite="${isFav}">
                        <svg class="w-7 h-7 pointer-events-none" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                  d="M12 5v.01M12 12v.01M12 19v.01M12 6a1 1 0 110-2 1 1 0 010 2zm0 7a1 1 0 110-2 1 1 0 010 2zm0 7a1 1 0 110-2 1 1 0 010 2z">
                            </path>
                        </svg>
                    </button>
                </div>
            </div>
            
            <!-- СЕКЦІЇ ДЛЯ МОДАЛОК (що підвантажують акторів) -->
            <div id="actors-source-${video.id}" class="hidden">${actorsHtml}</div>
            <div id="scenes-source-${video.id}" class="hidden">${scenesHtml}</div>
        </div>
    `;
}