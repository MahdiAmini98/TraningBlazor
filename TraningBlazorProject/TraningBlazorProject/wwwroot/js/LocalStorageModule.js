export const LocalStorageModule = {

    SvaeLocalStorage: (key, value) => {
        localStorage.setItem(key, JSON.stringify(value));
    },

    LoadLocalStorage: (key) => {
        const value = localStorage.getItem(key);
        return value ? JSON.parse(value) : null;
    },

    ClearLocalStorage: (key) => {
        localStorage.removeItem(key);
    }
}