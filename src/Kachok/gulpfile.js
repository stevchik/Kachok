/// <binding AfterBuild='default, minify' />
var gulp = require('gulp');
//var uglify = require('gulp-uglify');
var del = require('del');
//var ngAnnotate = require("gulp-ng-annotate");

//TODO see if System.js is needed
var paths = {
    scripts:['Scripts/**/*.js', 
                'Scripts/**/*.ts', 
                'Scripts/**/*.map']
};

gulp.task('clean', function () {
    return del(['wwwroot/scripts/**/*']);
});

gulp.task('default', ['clean'], function () {
    gulp.src(paths.scripts).pipe(gulp.dest('wwwroot/scripts/compile'))
});

//TODO test if annotate is needed
//gulp.task('minify', function () {
//    return gulp.src(["wwwroot/js/*.js"])
//        .pipe(ngAnnotate())//may not need this
//        .pipe(uglify())
//        .pipe(gulp.dest("wwwroot/lib/_app"));
//});