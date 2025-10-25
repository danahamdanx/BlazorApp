// wwwroot/js/meterQuery.js

// Auto-format meter number input
export function autoFormatMeterNumber(inputElement) {
    if (!inputElement || !inputElement.value) return;
    
    // Remove non-digits
    let value = inputElement.value.replace(/\D/g, '');
    
    // Limit to 13 digits max
    if (value.length > 13) {
        value = value.substring(0, 13);
    }
    
    inputElement.value = value;
    
    // Auto-validate length
    if (value.length === 11 || value.length === 13) {
        inputElement.classList.remove('is-invalid');
        inputElement.classList.add('is-valid');
    } else if (value.length > 0) {
        inputElement.classList.remove('is-valid');
        inputElement.classList.add('is-invalid');
    } else {
        inputElement.classList.remove('is-valid', 'is-invalid');
    }
}

// Save to local storage
export function saveToLocalStorage(key, data) {
    try {
        if (typeof window === 'undefined' || !window.localStorage) {
            console.warn('Local storage not available');
            return false;
        }
        
        const existing = getFromLocalStorage(key) || [];
        const newItem = {
            ...data,
            timestamp: new Date().toISOString()
        };
        
        // Keep only last 5 queries
        const updated = [newItem, ...existing].slice(0, 5);
        localStorage.setItem(key, JSON.stringify(updated));
        return true;
    } catch (e) {
        console.error('Local storage error:', e);
        return false;
    }
}

// Get from local storage
export function getFromLocalStorage(key) {
    try {
        if (typeof window === 'undefined' || !window.localStorage) {
            console.warn('Local storage not available');
            return [];
        }
        
        const item = localStorage.getItem(key);
        return item ? JSON.parse(item) : [];
    } catch (e) {
        console.error('Local storage error:', e);
        return [];
    }
}

// Print receipt
export function printReceipt() {
    try {
        window.print();
        return true;
    } catch (e) {
        console.error('Print error:', e);
        return false;
    }
}