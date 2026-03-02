document.addEventListener('DOMContentLoaded', function () {
    const countryBtn = document.getElementById('countryBtn');
    const countryMenu = document.getElementById('countryMenu');
    const countryArrow = document.getElementById('countryArrow');
    const countryText = document.getElementById('selectedCountryText');
    const options = document.querySelectorAll('.country-option');

    function toggleCountryMenu() {
        countryMenu.classList.toggle('hidden');
        countryArrow.classList.toggle('rotate-180');
    }

    countryBtn.addEventListener('click', function (e) {
        e.stopPropagation();
        toggleCountryMenu();
    });

    options.forEach(option => {
        option.addEventListener('click', function () {
            countryText.innerText = this.getAttribute('data-locative')
            toggleCountryMenu();
        });
    });

    window.addEventListener('click', function (e) {
        if (!countryMenu.classList.contains('hidden') && !countryBtn.contains(e.target) && !countryMenu.contains(e.target)) {
            countryMenu.classList.add('hidden');
            countryArrow.classList.remove('rotate-180');
        }
    });
});