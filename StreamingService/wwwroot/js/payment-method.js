document.addEventListener("DOMContentLoaded", function () {
    const tabButtons = document.querySelectorAll('.tab-button');
    const hiddenInput = document.getElementById('selectedPaymentMethod');
    const submitButton = document.getElementById('submitButton');
    const defaultButtonText = "Підтвердити та почати перегляд";

    tabButtons.forEach(button => {
        button.addEventListener('click', () => {
            const targetId = button.getAttribute('data-target');

            if (hiddenInput) hiddenInput.value = targetId.replace('payment-', '');

            document.querySelectorAll('.payment-content').forEach(content => content.classList.add('hidden'));
            const targetContent = document.getElementById(targetId);
            if (targetContent) targetContent.classList.remove('hidden');

            if (submitButton) {
                if (targetId === 'payment-card') {
                    submitButton.innerText = defaultButtonText;
                } else if (targetId === 'payment-paypal') {
                    submitButton.innerText = defaultButtonText;
                } else {
                    submitButton.innerText = defaultButtonText;
                }
            }

            tabButtons.forEach(btn => makeInactive(btn));
            makeActive(button);
        });
    });

    function makeInactive(btn) {
        btn.classList.remove('text-[#D0F260]', 'border-[#D0F260]', 'border-b-4');
        btn.classList.add('text-white', 'border-transparent', 'border-b-2', 'opacity-50');

        const icon = btn.querySelector('.tab-icon');
        if (icon) icon.classList.add('brightness-0', 'invert');
    }

    function makeActive(btn) {
        btn.classList.remove('text-white', 'border-transparent', 'border-b-2', 'opacity-50');
        btn.classList.add('text-[#D0F260]', 'border-[#D0F260]', 'border-b-4');

        const icon = btn.querySelector('.tab-icon');
        if (icon) icon.classList.remove('brightness-0', 'invert');
    }
});