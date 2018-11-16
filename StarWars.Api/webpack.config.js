var webpack = require('webpack');
var path = require('path');

var output = './wwwroot';

module.exports = {
    mode: 'development',
    entry: {
        'bundle': './GraphiQL/app.js'
    },

    output: {
        path: path.resolve(output),
        filename: '[name].js'
    },

    resolve: {        
        extensions: ['*','.webpack.js', '.web.js', '.mjs', '.js', '.json']
    },

    module: {
        rules: [
            { test: /\.js/, use: [{ loader: 'babel-loader' }], exclude: /node_modules/ },
            { test: /\.css?$/, use: ['style-loader', 'css-loader'] },
            { test: /\.flow/, use: [{ loader: 'ignore-loader' }] },
            { test: /\.mjs$/, include: /node_modules/, type: "javascript/auto" }
        ]
    }    
};