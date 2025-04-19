window.scrollElementIntoView = function (index) {
    var element = document.querySelectorAll('.search-result')[index];
    if (element) {
        element.scrollIntoView({
            behavior: 'smooth',
            block: 'nearest'
        });
    }
};

window.registerEscapeClose = function (dotNetHelper) {
    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape') {
            dotNetHelper.invokeMethodAsync('CloseModal');
        }
    });
};

window.focusElementById = function (id) {
    var element = document.getElementById(id);
    if (element) {
        element.focus();
    }
};

window.registerSearchShortcut = function (dotNetHelper) {
    document.addEventListener('keydown', function (e) {
        const isTyping = document.activeElement.tagName === 'INPUT' || document.activeElement.tagName === 'TEXTAREA';
        if (e.key === '/' && !isTyping) {
            e.preventDefault();
            dotNetHelper.invokeMethodAsync('ShowModal');
        }
    });
};
