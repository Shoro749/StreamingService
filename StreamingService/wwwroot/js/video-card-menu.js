document.addEventListener('DOMContentLoaded', () => {
    // === ЗМІННІ ===
    const globalMenu = document.getElementById('global-context-menu');
    const modal = document.getElementById('video-info-modal');
    const infoBtn = document.getElementById('menu-action-info');
    const trailerBtn = document.getElementById('menu-action-trailer');
    const closeModalBtn = document.getElementById('modal-close-btn');
    const modalBackdrop = document.getElementById('modal-backdrop');

    const modalTags = document.getElementById('modal-meta-tags');
    const tabContentInfo = document.getElementById('tab-content-info');
    const tabContentTrailer = document.getElementById('tab-content-trailer');
    const tabBtnInfo = document.getElementById('tab-btn-info');
    const tabIndicatorInfo = document.getElementById('tab-indicator-info');
    const tabBtnTrailer = document.getElementById('tab-btn-trailer');
    const tabIndicatorTrailer = document.getElementById('tab-indicator-trailer');
    

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
        // Копіюємо дані в меню
        for (const key in button.dataset) {
            globalMenu.dataset[key] = button.dataset[key];
        }
        globalMenu.dataset.currentVideoId = videoId;

        // Позиціювання
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

        // 2. Картинка 
        const bgImage = document.getElementById('modal-bg-image');
        if (bgImage) {
            // Якщо є картинка в даних - ставимо її, якщо ні - ставимо пустий рядок (або заглушку)
            bgImage.src = globalMenu.dataset.image || '';
        }

        // 2.5 Актори
        const actorsContainer = document.getElementById('modal-actors-container');
        const videoId = globalMenu.dataset.currentVideoId;
        const sourceActors = document.getElementById(`actors-source-${videoId}`);

        if (actorsContainer) {
            actorsContainer.innerHTML = sourceActors ? sourceActors.innerHTML : '';

            if (typeof setupScrollableCarousel === 'function') {
                setupScrollableCarousel('modal-actors-container', 'modal-actors-left', 'modal-actors-right', 150, false);
            }
        }

        // 2.6 Сцени
        const scenesContainer = document.getElementById('modal-scenes-container');
        const sourceScenes = document.getElementById(`scenes-source-${videoId}`);

        if (scenesContainer) {
            if (sourceScenes) {
                scenesContainer.innerHTML = sourceScenes.innerHTML;
            } else {
                scenesContainer.innerHTML = '';
            }

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

        // 2.7 Кнопка "Улюблене"
        const modalFavBtn = modal.querySelector('.js-favorite-btn');
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

    // === 3. ЛОГІКА ЗАКРИТТЯ МОДАЛЬНОГО ВІКНА ===
    function closeModal() {
        modal.classList.add('opacity-0');
        setTimeout(() => {
            modal.classList.add('hidden');
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