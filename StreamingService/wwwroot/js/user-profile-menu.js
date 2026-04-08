document.addEventListener('DOMContentLoaded', function () {
    const profileMenu = document.getElementById('user-profile-menu');
    const profileBtn = document.getElementById('user-profile-btn');
    const dropdownContent = document.getElementById('user-dropdown-content');
    const arrowActor = document.getElementById('user-profile-arrow');

    if (profileBtn && dropdownContent) {
        profileBtn.addEventListener('click', function (e) {
            e.stopPropagation();

            const isHidden = dropdownContent.classList.contains('hidden');

            if (isHidden) {
                dropdownContent.classList.remove('hidden');
                setTimeout(() => {
                    dropdownContent.classList.remove('opacity-0', 'invisible', 'scale-95');
                    dropdownContent.classList.add('opacity-100', 'visible', 'scale-100');
                }, 10);
                if (arrowActor) arrowActor.classList.add('rotate-180');
            } else {
                dropdownContent.classList.add('opacity-0', 'invisible', 'scale-95');
                dropdownContent.classList.remove('opacity-100', 'visible', 'scale-100');
                setTimeout(() => {
                    dropdownContent.classList.add('hidden');
                }, 300);
                if (arrowActor) arrowActor.classList.remove('rotate-180');
            }
        });

        document.addEventListener('click', function (e) {
            if (!profileMenu.contains(e.target)) {
                dropdownContent.classList.add('opacity-0', 'invisible', 'scale-95');
                dropdownContent.classList.remove('opacity-100', 'visible', 'scale-100');
                setTimeout(() => {
                    dropdownContent.classList.add('hidden');
                }, 300);
                if (arrowActor) arrowActor.classList.remove('rotate-180');
            }
        });
    }
});