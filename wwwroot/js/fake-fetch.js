export default function fakeFetch(urlString, options) {
    const url = new URL(urlString);


    if (url.hostname === 'pizzaexample.com' && url.pathname === '/api/') {

    //Jag har bara behållt det här så länge. Den kommer aldrig att köras eftersom q aldrig= animal
        if (url.searchParams.get('q') === 'animal') {
            return {
                total: 4,
                totalHits: 4,
                hits: [
                    {
                        webformatURL: '/fake-images/redpanda.jpg'
                    },
                    {
                        webformatURL: '/fake-images/koala.jpg'
                    },
                    {
                        webformatURL: '/fake-images/panda.jpg'
                    },
                    {
                        webformatURL: '/fake-images/raccoon.jpg'
                    }
                ]
            }
        }

        else if (url.searchParams.get('q') === 'Meat') {
            return {
                total: 1,
                totalHits: 1,
                hits: [
                    {
                        webformatURL: '/fake-images/Meat.jpg'
                    }
                ]
            }
        }

        else if (url.searchParams.get('q') === 'Chicken') {
            return {
                total: 1,
                totalHits: 1,
                hits: [
                    {
                        webformatURL: '/fake-images/Chicken.jpg'
                    }
                ]
            }
        }
        else if (url.searchParams.get('q') === 'Dessert') {
            return {
                total: 1,
                totalHits: 1,
                hits: [
                    {
                        webformatURL: '/fake-images/Dessert.jpg'
                    }
                ]
            }
        } else if (url.searchParams.get('q') === 'Fish') {
            return {
                total: 1,
                totalHits: 1,
                hits: [
                    {
                        webformatURL: '/fake-images/Fish.jpg'
                    }
                ]
            }
        } else if (url.searchParams.get('q') === 'Vegetarian') {
            return {
                total: 1,
                totalHits: 1,
                hits: [
                    {
                        webformatURL: '/fake-images/Vegetarian.jpg'
                    }
                ]
            }
        }
        else {
            return {
                total: 0,
                totalHits: 0,
                hits: []
            }
        }
    }
    else {
        throw new Error('This URL has not been implemented in the fake API: ' + urlString);
    }
}