// todo: remove after https://github.com/webpack-contrib/mini-css-extract-plugin/issues/34 resolved
if (process.env.NODE_ENV !== 'production') {
  import('../sass/main.scss');
}

// Load service worker in production build only.
if (process.env.NODE_ENV === 'production') {
  if ('serviceWorker' in navigator) {
    navigator.serviceWorker.register('/sitefiles/dist/sw.js', { scope: '/' }).catch((err) => {
      // eslint-disable-next-line no-console
      console.warn('Could not register service worker:', err);
    });
  }
}

import(/* webpackChunkName: "components" */ './components');
