/* eslint-disable func-names, no-useless-escape, object-shorthand */

// modules
const merge = require('webpack-merge');
const path = require('path');
const webpack = require('webpack');

// webpack plugins
const BrowserSyncPlugin = require('browser-sync-webpack-plugin');
const CleanWebpackPlugin = require('clean-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const StatsWriterPlugin = require('webpack-stats-plugin').StatsWriterPlugin;
const WebpackAssetsManifest = require('webpack-assets-manifest');

// load base configuration.
const baseConfig = require('./webpack.config');

// Get paths.
const paths = require('../core/paths');

module.exports = merge.smart(baseConfig, {
  entry: {
    critical: ['sass/critical.scss'],
    main: ['sass/main.scss', 'js/main'],
    offline: ['sass/offline.scss'],
    polyfill: [
      'babel-polyfill',
      'loadcss-core',
      'loadcss-polyfill',
      'picturefill/dist/picturefill',
    ],
  },
  mode: 'development',
  module: {
    rules: [
      {
        test: /\.(css|scss)$/,
        use: [
          MiniCssExtractPlugin.loader,
          {
            loader: 'css-loader',
            options: {
              autoprefixer: false,
              sourceMap: true,
            },
          },
          {
            loader: 'postcss-loader',
            options: {
              sourceMap: true,
            },
          },
          {
            loader: 'sass-loader',
            options: {
              sourceMap: true,
            },
          },
        ],
        exclude: [paths.fonts],
      },
      {
        test: /\.(eot|ttf|woff|woff2)(\?.+)?$/,
        use: ['file-loader'],
      },
      {
        test: /\.(jpeg|jpg|gif|png|svg)(\?.+)?$/,
        use: ['file-loader'],
      },
    ],
  },
  optimization: {
    noEmitOnErrors: true,
  },
  output: {
    chunkFilename: '[name].js',
    filename: '[name].js',
    path: paths.dist,
    publicPath: '/sitefiles/dist/',
  },
  plugins: [
    new CleanWebpackPlugin([paths.dist], {
      exclude: path.join(paths.dist, '.gitignore'),
      root: paths.sitefiles,
    }),
    new WebpackAssetsManifest({
      integrity: true,
      output: 'assets.json',
      publicPath: true,
      writeToDisk: true,
    }),
    new webpack.ContextReplacementPlugin(/moment[\/\\]locale$/, /en-gb/),
    new webpack.DefinePlugin({
      'process.env.NODE_ENV': JSON.stringify('development'),
    }),
    new MiniCssExtractPlugin({
      filename: '[name].css',
    }),
    new StatsWriterPlugin({
      transform(data, opts) {
        const stats = opts.compiler.getStats().toJson({ chunkModules: true });
        return JSON.stringify(stats, null, 2);
      },
    }),
    new webpack.HotModuleReplacementPlugin(),
    new BrowserSyncPlugin({
        host: 'localhost',
        port: 3000,
        proxy: 'http://localhost/'
    })
  ],
});
