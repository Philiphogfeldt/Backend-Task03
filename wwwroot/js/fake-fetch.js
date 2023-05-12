export default function fakeFetch(urlString, options) {
    const url = new URL(urlString);

    if (url.hostname === 'pizzaexample.com' && url.pathname === '/api/') {
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