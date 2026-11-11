const dialog = document.getElementById('successDialog');
if (dialog) {
    dialog.showModal();
    document.getElementById('closeDialog').addEventListener('click', () => dialog.close());
}
