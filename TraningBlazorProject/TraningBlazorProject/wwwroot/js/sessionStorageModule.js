
export const sessionStorageModule = {

    SvaeSessionStorage: (key, value) => {
        sessionStorage.setItem(key, JSON.stringify(value));
    },

    LoadSessionStorage: (key) => {
        const value = sessionStorage.getItem(key);
        return value ? JSON.parse(value) : null;
    },

    ClearSessionStorage: (key) => {
        sessionStorage.removeItem(key);
    }
}