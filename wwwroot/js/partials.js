const messageButton = document.getElementById('loadMessage');
messageButton.addEventListener('click', async () => {
    const result = document.getElementById('messageResult');
    messageButton.disabled = true;
    try {
        const response = await fetch(messageButton.dataset.url);
        if (!response.ok) throw new Error('Unable to load the message.');
        result.innerHTML = await response.text();
    } catch (error) {
        result.textContent = error.message;
    } finally {
        messageButton.disabled = false;
    }
});

const searchForm = document.getElementById('bookSearch');
const searchInput = document.getElementById('query');
const books = document.getElementById('books');
const status = document.getElementById('bookStatus');
let searchRequest;
let searchTimer;

async function searchBooks() {
    searchRequest?.abort();
    const request = new AbortController();
    searchRequest = request;
    status.textContent = 'Loading...';
    try {
        const query = new URLSearchParams(new FormData(searchForm));
        const response = await fetch(`${searchForm.action}?${query}`, { signal: request.signal });
        if (!response.ok) throw new Error('Unable to load books.');
        const html = await response.text();
        if (!request.signal.aborted) {
            books.innerHTML = html;
            status.textContent = '';
        }
    } catch (error) {
        if (error.name !== 'AbortError') status.textContent = error.message;
    }
}

searchForm.addEventListener('submit', event => {
    event.preventDefault();
    clearTimeout(searchTimer);
    searchBooks();
});
searchInput.addEventListener('input', () => {
    clearTimeout(searchTimer);
    searchRequest?.abort();
    searchTimer = setTimeout(searchBooks, 250);
});
searchBooks();

const studentForm = document.getElementById('studentForm');
studentForm.addEventListener('submit', async event => {
    event.preventDefault();
    const result = document.getElementById('studentResult');
    const button = studentForm.querySelector('button');
    button.disabled = true;
    result.textContent = 'Submitting...';
    try {
        const response = await fetch(studentForm.action, {
            method: 'POST',
            body: new FormData(studentForm)
        });
        if (!response.ok && response.status !== 422) throw new Error('Unable to submit the student.');
        result.innerHTML = await response.text();
        if (response.ok) studentForm.reset();
    } catch (error) {
        result.textContent = error.message;
    } finally {
        button.disabled = false;
    }
});
