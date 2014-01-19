describe('TaskService', function () {
    'use strict';

    var httpMock;
    var taskService;

    beforeEach(function () {
        module('App');
    });

    beforeEach(inject(function ($httpBackend) {
        httpMock = $httpBackend;
    }));

    beforeEach(inject(['TaskService', function (service) {
        taskService = service;
    }]));

    it('should inject task service', function () {
        expect(taskService).toBeDefined();
    });

    describe('api', function () {
        afterEach(function () {
            httpMock.flush();
            httpMock.verifyNoOutstandingExpectation();
            httpMock.verifyNoOutstandingRequest();
        });

        it('should create task', function () {
            httpMock.expectPOST('api/task', { responsible: 'Somebody', task: 'Some task' }).respond(201);
            taskService.create({ responsible: 'Somebody', task: 'Some task' });
        });

        it('should delete task', function () {
            httpMock.expectDELETE('api/task?responsible=Somebody&task=Some+task').respond(201);
            taskService.delete({ responsible: 'Somebody', task: 'Some task' });
        });

        describe('changeDone', function () {
            it('should put new task', function () {
                httpMock.expectPUT('api/task', { responsible: 'Somebody', task: 'Some task', done: true }).respond(201);
                taskService.changeDone({ responsible: 'Somebody', task: 'Some task', done: false });
            });
        });
    });
});