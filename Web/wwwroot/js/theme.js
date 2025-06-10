window.isDarkMode = () => {
    return window.matchMedia('(prefers-color-scheme: dark)').matches;
}

window.addDarkModeListener = (dotNetHelper) => {
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', (e) => {
        dotNetHelper.invokeMethodAsync('OnThemeChanged', e.matches);
    });
}
