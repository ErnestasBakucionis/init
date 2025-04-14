window.registerEscapeClose = function (dotNetHelper) {
    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape') {
            dotNetHelper.invokeMethodAsync('CloseModal');
        }
    });
};

window.focusElementById = function (id) {
    const el = document.getElementById(id);
    if (el) {
        el.focus();
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
