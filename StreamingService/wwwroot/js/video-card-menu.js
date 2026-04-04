document.addEventListener('DOMContentLoaded', () => {
    // === ЗМІННІ ===
    const globalMenu = document.getElementById('global-context-menu');
    const modal = document.getElementById('video-info-modal');
    const infoBtn = document.getElementById('menu-action-info');
    const trailerBtn = document.getElementById('menu-action-trailer');
    const watchBtn = document.getElementById('menu-action-watch');
    const closeModalBtn = document.getElementById('modal-close-btn');
    const modalBackdrop = document.getElementById('modal-backdrop');

    const modalTags = document.getElementById('modal-meta-tags');
    const tabContentInfo = document.getElementById('tab-content-info');
    const tabContentTrailer = document.getElementById('tab-content-trailer');
    const tabBtnInfo = document.getElementById('tab-btn-info');
    const tabIndicatorInfo = document.getElementById('tab-indicator-info');
    const tabBtnTrailer = document.getElementById('tab-btn-trailer');
    const tabIndicatorTrailer = document.getElementById('tab-indicator-trailer');

    const playTrailerBtn = document.getElementById('play-trailer-btn');
    const youtubeTrailerPlayer = document.getElementById('youtube-trailer-player');
    const modalTabsContainer = document.getElementById('modal-tabs-container');
    const modalFavBtn = modal ? modal.querySelector('.js-favorite-btn') : null;
    const modalSaveBtn = document.getElementById('modal-save-later-btn');

    let currentVideoId = null;

    // === 1. ЛОГІКА КОНТЕКСТНОГО МЕНЮ (3 КРАПКИ) ===
    document.addEventListener('click', (e) => {
        const toggleBtn = e.target.closest('.js-menu-toggle');

        if (toggleBtn) {
            e.preventDefault();
            e.stopPropagation();
            const videoId = toggleBtn.dataset.videoId;

            if (currentVideoId === videoId && !globalMenu.classList.contains('hidden')) {
                closeMenu();
                return;
            }
            openMenu(toggleBtn, videoId);
        } else if (!e.target.closest('#global-context-menu')) {
            closeMenu();
        }
    });

    function openMenu(button, videoId) {
        currentVideoId = videoId;
        
        for (const key in button.dataset) {
            globalMenu.dataset[key] = button.dataset[key];
        }
        globalMenu.dataset.currentVideoId = videoId;

        const rect = button.getBoundingClientRect();
        let top = rect.bottom + window.scrollY + 5;
        let left = rect.left + window.scrollX - 140;
        globalMenu.classList.remove('hidden');
        globalMenu.style.top = `${top}px`;
        globalMenu.style.left = `${left}px`;
    }

    function closeMenu() {
        globalMenu.classList.add('hidden');
        currentVideoId = null;
    }

    window.addEventListener('scroll', closeMenu, { passive: true });

    // === 2 ЛОГІКА ВІДКРИТТЯ ЧЕРЕЗ КЛІК НА КАРТКУ (API) ===
    document.addEventListener('click', async (e) => {
        const card = e.target.closest('.js-video-card');

        if (card && !e.target.closest('.js-save-for-later-btn')) {
            const videoId = card.dataset.videoId;
            globalMenu.dataset.currentVideoId = videoId;
            globalMenu.dataset.isUpcoming = card.dataset.isUpcoming || 'false';

            try {
                const response = await fetch(`/api/videos/${videoId}`);
                if (!response.ok) throw new Error('Відео не знайдено');

                const data = await response.json();
                fillGlobalMenuFromApi(data);
                renderActors(data.actors);
                renderScenes(data.scenes);
                openVideoModal('info');
            } catch (error) {
                console.error('Помилка завантаження даних:', error);
            }
        }
    });

    function fillGlobalMenuFromApi(data) {
        /*globalMenu.dataset.currentVideoId = data.id;*/
        globalMenu.dataset.title = data.title || '';
        globalMenu.dataset.description = data.description || '';
        globalMenu.dataset.year = data.year || '';
        globalMenu.dataset.duration = data.duration || '';
        globalMenu.dataset.genres = (data.genres && data.genres.length > 0) ? data.genres[0] : '';
        globalMenu.dataset.age = data.ageRating || '12+';
        globalMenu.dataset.videoType = data.videoType || '';
        globalMenu.dataset.image = data.backdropUrl || '';
        globalMenu.dataset.trailer = data.trailerUrl || '';
        globalMenu.dataset.rating = data.rating || '';
        globalMenu.dataset.trailerDuration = data.trailerDuration || '';

        // IMPORTANT: set isSaved flag so modal logic knows origin state
        const isSaved = (data.isSavedForLater !== undefined) ? String(data.isSavedForLater) : (data.isSaved || 'false');
        globalMenu.dataset.isSaved = (isSaved === 'true') ? 'true' : 'false';
    }

    function renderActors(actors) {
        const container = document.getElementById('modal-actors-container');
        if (!container) return;

        if (!actors || actors.length === 0) {
            container.innerHTML = '';
            return;
        }

        const actorsHtml = actors.map(actor => `
        <div class="flex flex-col items-center text-center min-w-24 snap-start">
            <div class="w-20 h-20 rounded-full overflow-hidden mb-3 shadow-xl">
                <img src="${actor.imageUrl || '/images/default-actor.jpg'}" class="w-full h-full object-cover" alt="${actor.name}">
            </div>
            <span class="text-white font-montserrat text-xs font-bold">${actor.name}</span>
            <span class="text-white/70 font-montserrat text-xs font-bold mt-1">${actor.character}</span>
        </div>
    `).join('');

        container.innerHTML = actorsHtml;

        if (typeof setupScrollableCarousel === 'function') {
            setupScrollableCarousel('modal-actors-container', 'modal-actors-left', 'modal-actors-right', 150, false);
        }
    }

    function renderScenes(scenes) {
        const container = document.getElementById('modal-scenes-container');
        const section = document.getElementById('modal-scenes-section');
        if (!container) return;

        if (!scenes || scenes.length === 0) {
            container.innerHTML = '';

            if (section) section.classList.add('hidden');

            return;
        }

        if (section) section.classList.remove('hidden');

        const scenesHtml = scenes.map(scene => `
        <div class="js-carousel-item relative w-40 shrink-0 h-24 rounded snap-start cursor-pointer overflow-hidden transition-all duration-300 brightness-75 hover:brightness-100">
            <img src="${scene.sceneImageUrl || ''}"
                 class="w-full h-full object-cover"
                 alt="${scene.sceneName || 'Сцена'}">
        </div>
    `).join('');

        container.innerHTML = scenesHtml;

        if (typeof SceneStepper !== 'undefined') {
            const sceneSlider = new SceneStepper('modal-scenes-container', {
                activeClasses: ['scale-105', 'origin-left', 'brightness-100', 'z-10'],
                inactiveClasses: ['scale-100', 'brightness-75', 'z-0']
            });

            const leftBtn = document.getElementById('modal-scenes-left');
            const rightBtn = document.getElementById('modal-scenes-right');

            if (leftBtn) {
                leftBtn.onclick = (e) => {
                    e.preventDefault();
                    sceneSlider.prev();
                };
            }
            if (rightBtn) {
                rightBtn.onclick = (e) => {
                    e.preventDefault();
                    sceneSlider.next();
                };
            }
        }
    }

    function openVideoModal(targetTab) {
        const setElementText = (id, text) => {
            const el = document.getElementById(id);

            if (!el) return;

            if (text && text.trim() !== '') {
                el.innerText = text;
                el.classList.remove('hidden');
            } else {
                el.classList.add('hidden');
            }
        };

        // 1. Заповнюємо текстові поля з даними про відео
        setElementText('modal-title', globalMenu.dataset.title);
        setElementText('modal-description', globalMenu.dataset.description);
        setElementText('modal-year', globalMenu.dataset.year);
        setElementText('modal-duration', globalMenu.dataset.duration);
        setElementText('modal-genres', globalMenu.dataset.genres);
        setElementText('modal-age', globalMenu.dataset.age);
        setElementText('modal-type', globalMenu.dataset.videoType);

        // 2. Заміна кнопки "Улюблене" в залежності від сторінки
        if (globalMenu.dataset.isUpcoming === 'true') {
            if (modalFavBtn) modalFavBtn.classList.add('hidden'); 
            if (modalSaveBtn) modalSaveBtn.classList.remove('hidden'); 
        } else {
            if (modalFavBtn) modalFavBtn.classList.remove('hidden'); 
            if (modalSaveBtn) modalSaveBtn.classList.add('hidden');
        }

        // 3. Картинка 
        const bgImage = document.getElementById('modal-bg-image');
        if (bgImage) {
            bgImage.src = globalMenu.dataset.image || '';
        }

        // Актори
        const actorsContainer = document.getElementById('modal-actors-container');
        const videoId = globalMenu.dataset.currentVideoId;
        const sourceActors = document.getElementById(`actors-source-${videoId}`);

        if (actorsContainer) {
           
            if (sourceActors) {
                actorsContainer.innerHTML = sourceActors.innerHTML;

                if (typeof setupScrollableCarousel === 'function') {
                    setupScrollableCarousel('modal-actors-container', 'modal-actors-left', 'modal-actors-right', 150, false);
                }
            }
        }

        // Сцени
        const scenesContainer = document.getElementById('modal-scenes-container');
        const sourceScenes = document.getElementById(`scenes-source-${videoId}`);
        const scenesSection = document.getElementById('modal-scenes-section');

        if (scenesContainer) {

            if (sourceScenes) {
                scenesContainer.innerHTML = sourceScenes.innerHTML;

                if (typeof SceneStepper !== 'undefined') {
                    const sceneSlider = new SceneStepper('modal-scenes-container', {
                        activeClasses: ['scale-105', 'origin-left', 'brightness-100', 'z-10'],
                        inactiveClasses: ['scale-100', 'brightness-75', 'z-0']
                    });

                    const leftBtn = document.getElementById('modal-scenes-left');
                    const rightBtn = document.getElementById('modal-scenes-right');

                    if (leftBtn) {
                        leftBtn.onclick = (e) => {
                            e.preventDefault();
                            sceneSlider.prev();
                        };
                    }
                    if (rightBtn) {
                        rightBtn.onclick = (e) => {
                            e.preventDefault();
                            sceneSlider.next();
                        };
                    }
                }
            }

            if (scenesContainer.innerHTML.trim() === '') {
                if (scenesSection) scenesSection.classList.add('hidden');
            } else {
                if (scenesSection) scenesSection.classList.remove('hidden');
            }
        }

        // 2.7 Кнопка "Улюблене"
        const originalFavBtn = document.querySelector(`.js-favorite-btn[data-video-id="${videoId}"]:not(#video-info-modal .js-favorite-btn)`);

        if (modalFavBtn) {
            modalFavBtn.dataset.videoId = videoId;

            if (originalFavBtn) {
                const isFav = originalFavBtn.dataset.isFavorite;
                modalFavBtn.dataset.isFavorite = isFav;

                if (isFav === 'true') {
                    modalFavBtn.classList.add('text-[#FF0000]');
                    modalFavBtn.classList.remove('text-white');
                } else {
                    modalFavBtn.classList.add('text-white');
                    modalFavBtn.classList.remove('text-[#FF0000]');
                }
            }
        }

        // 2.8 Синхронізація кнопки "Відкласти на потім"
        if (modalSaveBtn) {
            modalSaveBtn.dataset.videoId = videoId;

            const originalSaveBtn = document.querySelector(`.js-save-for-later-btn[data-video-id="${videoId}"]:not(#video-info-modal .js-save-for-later-btn)`);

            let isSaved = 'false';
            let isFav = 'false';

            if (originalSaveBtn) {
                isSaved = originalSaveBtn.dataset.isSaved || 'false';
                isFav = originalSaveBtn.dataset.isFavorite || 'false';
            } else {
                isSaved = globalMenu.dataset.isSaved || 'false';
                isFav = globalMenu.dataset.isFavorite || 'false';
            }

            modalSaveBtn.dataset.isSaved = isSaved;
            modalSaveBtn.dataset.isFavorite = isFav;
            modalSaveBtn.title = isSaved === 'true' ? 'Видалити з відкладеного' : 'Відкласти на потім';

            const iconDiv = modalSaveBtn.querySelector('div');

            if (isSaved === 'true') {
                modalSaveBtn.classList.add('bg-white/20');
                modalSaveBtn.classList.remove('bg-white/10');
                if (iconDiv) {
                    iconDiv.classList.add('bg-[#DCF260]', 'group-hover/btn:bg-white');
                    iconDiv.classList.remove('bg-white', 'group-hover/btn:bg-[#DCF260]');
                }
            } else {
                modalSaveBtn.classList.add('bg-white/10');
                modalSaveBtn.classList.remove('bg-white/20');
                if (iconDiv) {
                    iconDiv.classList.add('bg-white', 'group-hover/btn:bg-[#DCF260]');
                    iconDiv.classList.remove('bg-[#DCF260]', 'group-hover/btn:bg-white');
                }
            }

            globalMenu.dataset.originIsSaved = (isSaved === 'true') ? 'true' : 'false';
        }

        switchModalTab(targetTab);

        modal.classList.remove('hidden');
        setTimeout(() => { modal.classList.remove('opacity-0'); }, 10);

        closeMenu();
    }

    if (infoBtn) {
        infoBtn.addEventListener('click', (e) => {
            e.preventDefault();
            e.stopPropagation();
            openVideoModal('info');
        });
    }

    if (trailerBtn) {
        trailerBtn.addEventListener('click', (e) => {
            e.preventDefault();
            e.stopPropagation();
            openVideoModal('trailer');
        });
    }

    if (watchBtn) {
        watchBtn.addEventListener('click', (e) => {
            e.preventDefault();
            e.stopPropagation();
            window.location.href = `/Movies/Details/${globalMenu.dataset.currentVideoId}`;
        });
    }

    //=== ЛОГІКА ПРОГРАМУВАННЯ ТРЕЙЛЕРА В МОДАЛЬНОМУ ВІКНІ ===
    if (playTrailerBtn) {
        playTrailerBtn.addEventListener('click', () => {
            const trailerUrl = globalMenu.dataset.trailer;

            if (!trailerUrl) return;

            let videoId = null;
            if (trailerUrl.includes('youtube.com/watch?v=')) {
                videoId = trailerUrl.split('v=')[1].split('&')[0];
            } else if (trailerUrl.includes('youtu.be/')) {
                videoId = trailerUrl.split('youtu.be/')[1].split('?')[0];
            }

            if (videoId) {
                playTrailerBtn.classList.add('hidden');
                modalTabsContainer.classList.add('hidden');
                if (modalFavBtn) modalFavBtn.classList.add('hidden');
                const embedUrl = `https://www.youtube.com/embed/${videoId}?autoplay=1&rel=0&modestbranding=1`;

                youtubeTrailerPlayer.src = embedUrl;
                youtubeTrailerPlayer.classList.remove('hidden');
            } else {
                console.error("Не вдалося розпізнати посилання на YouTube:", trailerUrl);
            }
        });
    }

    // === ЛОГІКА ЗАКРИТТЯ МОДАЛЬНОГО ВІКНА ===
    function closeModal() {
        modal.classList.add('opacity-0');

        if (modalSaveBtn) {
            globalMenu.dataset.isSaved = modalSaveBtn.dataset.isSaved;

            if (modalSaveBtn.dataset.isSaved === 'false' && globalMenu.dataset.originIsSaved === 'true') {
                const videoId = globalMenu.dataset.currentVideoId;

                const contextBtn = document.querySelector(`.js-menu-toggle[data-video-id="${videoId}"]`);
                if (contextBtn) {
                    const cardContainer = contextBtn.closest('.group');

                    if (cardContainer && !cardContainer.querySelector('.js-save-for-later-btn')) {
                        cardContainer.style.transition = 'opacity 0.3s ease, transform 0.3s ease';
                        cardContainer.style.opacity = '0';
                        cardContainer.style.transform = 'scale(0.9)';
                        setTimeout(() => {
                            cardContainer.style.display = 'none';
                        }, 300);
                    }
                }
            }
        }

        setTimeout(() => {
            modal.classList.add('hidden');

            if (youtubeTrailerPlayer) {
                youtubeTrailerPlayer.src = '';
                youtubeTrailerPlayer.classList.add('hidden');
            }
            if (playTrailerBtn) {
                playTrailerBtn.classList.remove('hidden');
                modalTabsContainer.classList.remove('hidden');
                if (modalFavBtn) modalFavBtn.classList.remove('hidden');
            }
        }, 300);
    }

    // Закриття по хрестику
    if (closeModalBtn) {
        closeModalBtn.addEventListener('click', closeModal);
    }

    // Закриття по кліку на темний фон (backdrop)
    if (modalBackdrop) {
        modalBackdrop.addEventListener('click', closeModal);
    }

    // Закриття по клавіші ESC 
    document.addEventListener('keydown', (e) => {
        if (e.key === 'Escape' && !modal.classList.contains('hidden')) {
            closeModal();
        }
    });

    // === 4. ЛОГІКА ВКЛАДОК (ТАБІВ) МОДАЛЬНОГО ВІКНА ===

    function switchModalTab(tabName) {
        const trailerText = tabBtnTrailer.querySelector('span');
        const infoText = tabBtnInfo.querySelector('span');

        if (tabName === 'trailer') {
            tabContentInfo.classList.add('hidden');
            modalTags.classList.add('hidden');
            tabContentTrailer.classList.remove('hidden');

            trailerText.classList.remove('text-white/50');
            trailerText.classList.add('text-white');
            infoText.classList.remove('text-white');
            infoText.classList.add('text-white/50');

            tabIndicatorTrailer.classList.remove('opacity-0');
            tabIndicatorTrailer.classList.add('opacity-100');
            tabIndicatorInfo.classList.remove('opacity-100');
            tabIndicatorInfo.classList.add('opacity-0');

        } else if (tabName === 'info') {
            tabContentTrailer.classList.add('hidden');
            modalTags.classList.remove('hidden');
            tabContentInfo.classList.remove('hidden');

            infoText.classList.remove('text-white/50');
            infoText.classList.add('text-white');
            trailerText.classList.remove('text-white');
            trailerText.classList.add('text-white/50');

            tabIndicatorInfo.classList.remove('opacity-0');
            tabIndicatorInfo.classList.add('opacity-100');
            tabIndicatorTrailer.classList.remove('opacity-100');
            tabIndicatorTrailer.classList.add('opacity-0');
        }
    }

    // 2. Виклик функції при кліку на таби
    if (tabBtnTrailer) {
        tabBtnTrailer.addEventListener('click', () => switchModalTab('trailer'));
    }

    if (tabBtnInfo) {
        tabBtnInfo.addEventListener('click', () => switchModalTab('info'));
    }
});