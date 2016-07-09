/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
     Q = require('q'),
    del = require('del'),
    sass = require("gulp-sass");

var config = {
    bootstrapDir: 'bower_components/bootstrap-sass',
    wwwDir: './wwwroot/',
};

gulp.task('clean', function () {
    // place code for your default task here
    return del(['./wwwroot/lib/',
        './wwwroot/fonts/',
        './wwwroot/css/app.css']);
});

gulp.task('bootstrap-css', function () {
    return gulp.src('Scripts/scss/app.scss')
    .pipe(sass({
        includePaths: [config.bootstrapDir + '/assets/stylesheets'],
    }))
    .pipe(gulp.dest(config.wwwDir + '/css'));
});

gulp.task('bootstrap-fonts', function () {
    return gulp.src(config.bootstrapDir + '/assets/fonts/**/*')
    .pipe(gulp.dest(config.wwwDir + '/fonts'));
});

gulp.task('bootstrap-js', function () {
    return gulp.src(config.bootstrapDir + '/assets/javascripts/*.min.js')
    .pipe(gulp.dest(config.wwwDir + '/lib/bootstrap/'));
});

gulp.task('js', function () {
    return gulp.src('Scripts/js/*')
    .pipe(gulp.dest(config.wwwDir + '/scripts/js/'));
});

gulp.task('copy:all', ['clean', 'bootstrap-css', 'bootstrap-js', 'js'], function () {
    var libs = [
        "@angular",
        "systemjs",
        "core-js",
        "zone.js",
        "reflect-metadata",
        "rxjs",
        "jquery"
    ];

    var promises = [];

    libs.forEach(function (lib) {
        var defer = Q.defer();
        var pipeline = gulp
            .src('node_modules/' + lib + '/**/*')
            .pipe(gulp.dest('./wwwroot/lib/' + lib));

        pipeline.on('end', function () {
            defer.resolve();
        });
        promises.push(defer.promise);
    });

    return Q.all(promises);

});