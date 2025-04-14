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