# Tasks #

Sample AngularJS application using ASP.NET MVC 4, with Jasmine tests that can be run in Visual Studio.

## Project Layout ##
    Solution 'Tasks'
       Tasks
       Tasks.Tests

- **Tasks** - ASP.NET MVC 4 project. This contains a WebAPI backend that used `Cache` to manage a list of people and some tasks. Have a look in the `Content` directory for JavaScript implementation. The backend is a typical REST implementation. There's `POST`, `PUT`, and `DELETE` of task instances.
- **Tasks.Tests** - This project contains webapi integration tests and Jasmine specifications for the JavaScript implementation. It is setup to run [PhantomJS](http://phantomjs.org/), a headless WebKit. Using PhantomJS we can pretty simply execute the Jasmine specifications within Visual Studio. This is done using a post-build step. It is easily integrated with a continuous integration platform (i.e. TeamCity).
- **Tools** - Contains PhantomJS executable.

## Author ##
Daniel Lidström ([dlidstrom@gmail.com](mailto:dlidstrom@gmail.com))

Feel free to contact me with any questions regarding this project.

### License ###
MIT
