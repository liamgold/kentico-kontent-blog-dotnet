import whenDomReady from 'when-dom-ready';

function initialise() {
  // do something here
}

whenDomReady().then(() => {
  initialise();
});

export default initialise;
