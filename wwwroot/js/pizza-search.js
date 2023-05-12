import fakeFetch from './fake-fetch.js';

/*const apiKey = '9143904-58a05ad2013e7353b89d19cb0';*/
const useRealAPI = false;

async function fetchJSON(url, options) {
    if (useRealAPI) {
        const response = await fetch(url, options);
        const json = await response.json();
        return json;
    }
    else {
        // Sleep for one second to simulate a network delay.
        await new Promise(r => setTimeout(r, 1000));
        const json = fakeFetch(url, options);
        return json;
    }
}

//const form = document.querySelector('#image-search-form');
//const resultList = document.querySelector('#results');
//const message = document.querySelector('#message');

let pizzacategory = "Meat";
/*const pizzacategory = document.querySelector('#goesWithFood')*/
const message = document.querySelector('#message');

const pizzadiv = document.querySelector('#pizzaGridCell')
var pizzaname = document.querySelector('#pizzaName')
var ingredientlist = document.querySelector('#ingredientlist')
var resultList = document.querySelector('#recommendation')

//function start() {
//    runThis();
//}

//async function runThis(){

    const result = await fetchJSON(
        'https://pizzaexample.com/api/?' +
        new URLSearchParams({
            q: pizzacategory,
        }).toString()
    );

    pizzacategory = '';

    if (result.hits.length === 0) {
        message.hidden = false;
        resultList.hidden = true;
    }
    else {
        message.hidden = true;
        resultList.hidden = false;

        resultList.replaceChildren();

        for (const hit of result.hits) {
            const img = document.createElement('img');
            img.src = hit.webformatURL;
            img.style.width = '250px';

            const li = document.createElement('li');
            li.append(img);

            resultList.append(li);
        }
    }

/*}*/

//form.onsubmit = async event => {
//    event.preventDefault();

//    const result = await fetchJSON(
//        'https://pixabay.com/api/?' +
//        new URLSearchParams({
//            q: form.keyword.value,
//            key: apiKey,
//        }).toString()
//    );

//    form.keyword.value = '';

//    if (result.hits.length === 0) {
//        message.hidden = false;
//        resultList.hidden = true;
//    }
//    else {
//        message.hidden = true;
//        resultList.hidden = false;

//        resultList.replaceChildren();

//        for (const hit of result.hits) {
//            const img = document.createElement('img');
//            img.src = hit.webformatURL;
//            img.style.width = '250px';

//            const li = document.createElement('li');
//            li.append(img);

//            resultList.append(li);
//        }
//    }
//};