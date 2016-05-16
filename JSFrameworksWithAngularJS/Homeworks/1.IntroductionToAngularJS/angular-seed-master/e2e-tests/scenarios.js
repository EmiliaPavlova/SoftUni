'use strict';

/* https://github.com/angular/protractor/blob/master/docs/toc.md */

describe('my app', function() {


  it('should automatically redirect to /student when location hash/fragment is empty', function() {
    browser.get('index.html');
    expect(browser.getLocationAbsUrl()).toMatch("/student");
  });


  describe('view1', function() {

    beforeEach(function() {
      browser.get('index.html#/student');
    });


    it('should render student when user navigates to /student', function() {
      expect(element.all(by.css('[ng-view] p')).first().getText()).
        toMatch(/partial for view 1/);
    });

  });


  describe('myApp', function() {

    beforeEach(function() {
      browser.get('index.html#/image');
    });


    it('should render image when user navigates to /image', function() {
      expect(element.all(by.css('[ng-view] p')).first().getText()).
        toMatch(/partial for view 2/);
    });

  });
});
