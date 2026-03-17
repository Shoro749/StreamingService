class SceneStepper {
    constructor(containerId, options = {}) {
        this.container = document.getElementById(containerId);
        if (!this.container) return;

        this.options = Object.assign({
            activeClasses: [],
            inactiveClasses: []
        }, options);

        this.items = this.container.querySelectorAll('.js-carousel-item');
        this.currentIndex = 0;

        this.init();
    }

    init() {
        if (this.items.length === 0) return;
        this.update(this.currentIndex);
    }

    update(index) {
        if (index < 0 || index >= this.items.length) return;
        this.currentIndex = index;

        this.items.forEach(item => {
            if (this.options.activeClasses.length) item.classList.remove(...this.options.activeClasses);
            if (this.options.inactiveClasses.length) item.classList.add(...this.options.inactiveClasses);
        });

        const targetItem = this.items[this.currentIndex];
        if (this.options.activeClasses.length) targetItem.classList.add(...this.options.activeClasses);
        if (this.options.inactiveClasses.length) targetItem.classList.remove(...this.options.inactiveClasses);

        targetItem.scrollIntoView({ behavior: 'smooth', block: 'nearest', inline: 'start' });
    }

    next() {
        if (this.currentIndex < this.items.length - 1) {
            this.update(this.currentIndex + 1);
        }
    }

    prev() {
        if (this.currentIndex > 0) {
            this.update(this.currentIndex - 1);
        }
    }
}

window.SceneStepper = SceneStepper;