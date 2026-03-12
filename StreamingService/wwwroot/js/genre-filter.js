// Масив обраних жанрів
let selectedGenres = [];
let originalSections = null; // Зберігаємо оригінальні секції

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
            restoreOriginalSections();
        }
    }
});

// Функція фільтрації
async function filterVideosByGenres() {
    try {
        const response = await fetch('/Home/FilterByGenres', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ genreCodes: selectedGenres })
        });

        if (response.ok) {
            const result = await response.json();

            if (result.success && result.videos) {
                updateVideoSections(result.videos);
            }
        }
    } catch (error) {
        console.error('Помилка фільтрації:', error);
    }
}

// Оновлення секцій зі збереженням структури
function updateVideoSections(filteredVideos) {
    const videoCollections = document.getElementById('video-collections');
    if (!videoCollections) return;

    // Зберігаємо оригінал при першій фільтрації
    if (!originalSections) {
        originalSections = videoCollections.innerHTML;
    }

    // Знаходимо всі секції
    const sections = videoCollections.querySelectorAll('section');

    sections.forEach(section => {
        const carousel = section.querySelector('.flex.gap-5, .grid');
        if (!carousel) return;

        // Очищаємо контент секції
        carousel.innerHTML = '';

        // Заповнюємо відфільтрованими відео
        if (filteredVideos.length > 0) {
            filteredVideos.forEach(video => {
                const videoCard = createVideoCardForCarousel(video);
                carousel.appendChild(videoCard);
            });
        } else {
            carousel.innerHTML = `
                <div class="col-span-full flex justify-center items-center py-10">
                    <p class="text-white/50 text-lg">Немає відео з обраними жанрами</p>
                </div>
            `;
        }
    });
}

// Відновлення оригінальних секцій
function restoreOriginalSections() {
    const videoCollections = document.getElementById('video-collections');
    if (videoCollections && originalSections) {
        videoCollections.innerHTML = originalSections;
        originalSections = null;
    }
}

// Створення картки для каруселі (в стилі сайту)
function createVideoCardForCarousel(video) {
    const div = document.createElement('div');
    div.className = 'flex-shrink-0 w-[220px] group relative snap-start';

    div.innerHTML = `
        <div class="relative w-full h-[326px] rounded-2xl overflow-hidden shadow-glass">
            <img src="${video.posterUrl}" 
                 alt="${video.title}" 
                 class="w-full h-full object-cover transition-transform duration-300 group-hover:scale-110" />
            
            <!-- Градієнт знизу -->
            <div class="absolute inset-0 bg-gradient-to-t from-black/80 via-transparent to-transparent"></div>
            
            <!-- Кнопки зверху -->
            <div class="absolute top-3 right-3 flex gap-2 opacity-0 group-hover:opacity-100 transition-opacity">
                <button 
                    class="js-favorite-btn w-10 h-10 rounded-full bg-black/50 backdrop-blur flex items-center justify-center ${video.isFavorite ? 'text-[#FF0000]' : 'text-white'} hover:scale-110 transition-all"
                    data-video-id="${video.id}"
                    data-is-favorite="${video.isFavorite}">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5">
                        <path d="M11.645 20.91l-.007-.003-.022-.012a15.247 15.247 0 01-.383-.218 25.18 25.18 0 01-4.244-3.17C4.688 15.36 2.25 12.174 2.25 8.25 2.25 5.322 4.714 3 7.688 3A5.5 5.5 0 0112 5.052 5.5 5.5 0 0116.313 3c2.973 0 5.437 2.322 5.437 5.25 0 3.925-2.438 7.111-4.739 9.256a25.175 25.175 0 01-4.244 3.17 15.247 15.247 0 01-.383.219l-.022.012-.007.004-.003.001a.752.752 0 01-.704 0l-.003-.001z" />
                    </svg>
                </button>
            </div>
            
            <!-- Інформація знизу -->
            <div class="absolute bottom-0 left-0 right-0 p-4">
                <h3 class="text-white font-semibold text-base mb-1 line-clamp-2">${video.title}</h3>
                <div class="flex items-center gap-2 text-sm text-white/70">
                    ${video.year ? `<span>${video.year}</span>` : ''}
                    ${video.rating > 0 ? `<span>⭐ ${video.rating.toFixed(1)}</span>` : ''}
                </div>
            </div>
        </div>
    `;

    // Додаємо клік на картку для переходу
    div.addEventListener('click', (e) => {
        if (!e.target.closest('.js-favorite-btn')) {
            window.location.href = `/video/${video.id}`;
        }
    });

    return div;
}