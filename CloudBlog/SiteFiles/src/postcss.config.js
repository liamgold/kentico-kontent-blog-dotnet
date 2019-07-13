const autoprefixer = require('autoprefixer');
const pseudoelements = require('postcss-pseudoelements');
const normalize = require('postcss-normalize');
const ie11 = require('postcss-ie11-supports');

module.exports = {
  plugins: [
    autoprefixer(),
    pseudoelements(),
    normalize({ forceImport: false }),
    ie11(),
  ],
};
