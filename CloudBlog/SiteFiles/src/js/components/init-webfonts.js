import FontFaceObserver from 'fontfaceobserver';
import whenDomReady from 'when-dom-ready';

function initialise() {
  const font = new FontFaceObserver('Titillium Web');

  font.load().then(() => {
    sessionStorage.fontsLoaded = true;
    const html = document.documentElement;
    html.classList.add('fonts-loaded');
  }).catch(() => {
    sessionStorage.fontsLoaded = false;
  });
}

whenDomReady().then(() => {
  initialise();
});

export default initialise;
