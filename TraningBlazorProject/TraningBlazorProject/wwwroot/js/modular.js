
export function showAlert(message) {
    alert(message);
}



//load Sweet Alert
export async function loadSweetAlert() {
    const script = document.createElement("script");
    script.src = "https://cdn.jsdelivr.net/npm/sweetalert2@11";
    script.onload = () => {
        console.log("SweetAlert loaded");
    };
    script.onerror = () => {
        console.error("Failed to load SweetAlert");
    }
    document.head.appendChild(script);
}


export async function showSweetAlert(message) {
    if (window.Swal) {
        const result = await Swal.fire({
            title: 'پیغام',
            text: message,
            icon: 'info',
            showCancelButton: true,
            confirmButtonText: 'تایید',
            cancelButtonText: 'لغو',
        });

        return result.isConfirmed ? "تایید شد" : "لغو شد";
    }
    else {
        console.error("SweetAlert لود نشده است!");
        return "Error";
    }
}