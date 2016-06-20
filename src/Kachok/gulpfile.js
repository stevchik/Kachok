/// <binding AfterBuild='default, minify' />
var gulp = require('gulp');
var uglify = require('gulp-uglify');
var del = require('del');
var ngAnnotate = require("gulp-ng-annotate");

var paths = {
    scripts: ['scripts/dist/boot.js', 'scripts/dist/**/*.js'],
    libs: ['wwwroot/lib/angular/Angular.js',
           'wwwroot/lib/systemjs/src/System.js']
};

gulp.task('clean', function () {
    return del(['wwwroot/scripts/**/*']);
});


gulp.task('lib', function () {
    gulp.src(paths.libs).pipe(gulp.dest('wwwroot/scripts/lib'))
});

gulp.task('default', ['lib'], function () {
    gulp.src(paths.scripts).pipe(gulp.dest('wwwroot/scripts'))
});


gulp.task('minify', function () {
    return gulp.src(["wwwroot/js/*.js"])
        .pipe(ngAnnotate())
        .pipe(uglify())
        .pipe(gulp.dest("wwwroot/lib/_app"));
});