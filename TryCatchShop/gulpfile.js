// include gulp
var gulp = require('gulp');

// include plug-ins

var changed = require('gulp-changed');
var concat = require('gulp-concat');
var stripDebug = require('gulp-strip-debug');
var uglify = require('gulp-uglify');
var minifyHTML = require('gulp-minify-html');
var autoprefix = require('gulp-autoprefixer');
var minifyCSS = require('gulp-minify-css');
var rename = require('gulp-rename');
var jshint = require('gulp-jshint');
var less = require('gulp-less');
var shell = require('gulp-shell');

// JS concat, strip debugging code and minify
gulp.task('bundle-scripts', function () {
    var jsPath = { jsSrc: ['./app/app.js', './app/**/*.js'], jsDest: './appbuild' };
    gulp.src(jsPath.jsSrc)
      .pipe(shell(['attrib C:/_mySviluppo/TryCatchShop/TryCatchShop/appbuild/*.* -r']))
      .pipe(concat('ngscripts.js'))
      .pipe(stripDebug())
      .pipe(uglify())
      .pipe(rename({ suffix: '.min' }))
      .pipe(gulp.dest(jsPath.jsDest));
});

// minify new or changed HTML pages
gulp.task('minify-html', function () {
    var opts = { empty: true, quotes: true };
    var htmlPath = { htmlSrc: './app/views/*.html', htmlDest: './appbuild/views' };

    return gulp.src(htmlPath.htmlSrc)
              .pipe(shell(['attrib C:/_mySviluppo/TryCatchShop/TryCatchShop/appbuild/views/*.* -r']))
              .pipe(changed(htmlPath.htmlDest))
              .pipe(minifyHTML(opts))
              .pipe(gulp.dest(htmlPath.htmlDest));
});

// LESS Task for App
gulp.task('less1', function () {
    var lessPath = {
        cssSrc: ['./content/style/*.less'], cssDest: './content/style/'
    };
    return gulp.src(lessPath.cssSrc)
        .pipe(shell(['attrib C:/_mySviluppo/TryCatchShop/TryCatchShop/content/style/*.* -r']))
        .pipe(less())
        .pipe(gulp.dest(lessPath.cssDest));
});

// CSS concat, auto-prefix, minify, then rename output file
gulp.task('minify-css', function () {
    var cssPath = { cssSrc: ['./content/style/*.css', '!*.min.css', '!/**/*.min.css'], cssDest: './contentbuild/style/' };

    return gulp.src(cssPath.cssSrc)
      .pipe(shell(['attrib C:/_mySviluppo/TryCatchShop/TryCatchShop/contentbuild/style/*.min.css -r']))
      .pipe(concat('styles.css'))
      .pipe(autoprefix('last 2 versions'))
      .pipe(minifyCSS())
      .pipe(rename({ suffix: '.min' }))
      .pipe(gulp.dest(cssPath.cssDest));
});

// Lint Task
gulp.task('lint', function () {
    var jsPath = { jsSrc: ['./app/app.js', './app/**/*.js', './appbuild'] };
    return gulp.src(jsPath.jsSrc)
        .pipe(jshint())
        .pipe(jshint.reporter('default'));
});



// default gulp task
gulp.task('default', ['minify-css', 'lint', 'less1'], function () {
    // watch for HTML changes
    //gulp.watch('./app/views/*.html', ['minify-html']);
    // watch for JS changes
    //gulp.watch('./app/**/*.js', ['bundle-scripts']);
    // watch for LESS changes
    gulp.watch('./content/css/*.less', ['less1']);
    // watch for CSS changes
    gulp.watch('./content/css/*.css', ['minify-css']);
    // watch for JS error
    gulp.watch('./app/**/*.js', ['lint']);
});