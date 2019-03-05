'use strict';
const sass = require('gulp-sass');

function myTask(cb) {
    //test
    console.log('My first task.');
    //call back function
    cb();
}

exports.default = myTask;