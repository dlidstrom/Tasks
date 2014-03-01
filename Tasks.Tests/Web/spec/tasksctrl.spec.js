describe('TaskCtrl', function () {
    'use strict';

    var ctrl;
    var scope;
    var initialData;
    var taskService;
    var rootScope;
    var returnResolvedDeferred;
    var returnRejectedDeferred;

    beforeEach(function () {
        module('App');
    });

    beforeEach(inject(function ($controller, $q, $rootScope) {
        rootScope = $rootScope;
        scope = {};
        initialData = {
            people: [
                {
                    name: 'Daniel'
                }
            ],
            tasks: [
                {
                    responsible: 'Daniel',
                    done: false
                }
            ]
        };

        returnResolvedDeferred = function () {
            var deferred = $q.defer();
            deferred.resolve();
            return deferred.promise;
        };
        returnRejectedDeferred = function () {
            var deferred = $q.defer();
            deferred.reject();
            return deferred.promise;
        };
        taskService = {
            create: returnResolvedDeferred,
            delete: returnResolvedDeferred,
            changeDone: returnResolvedDeferred
        };
        ctrl = $controller('TasksCtrl', { $scope: scope, InitialData: initialData, TaskService: taskService });
    }));

    describe('initialize', function () {
        it('should set people', function () {
            expect(scope.people).toBeDefined();
        });

        it('should start with one task', function () {
            expect(scope.tasks.length).toBe(1);
        });

        describe('initial task', function () {
            var firstTask;
            beforeEach(function () {
                firstTask = scope.tasks[0];
            });

            it('should have responsible', function () {
                expect(firstTask.responsible).toEqual('Daniel');
            });

            it('should be unfinished', function () {
                expect(firstTask.done).toBe(false);
            });
        });
    });

    describe('addTask', function () {
        describe('success', function () {
            beforeEach(function () {
                scope.task = 'New task';
                scope.responsible = { name: 'Someone responsible' };
                scope.addTask();
            });
            describe('saving flag', function () {
                it('should set it', function () {
                    expect(scope.saving).toBe(true);
                });
            });
            describe('success callback', function () {
                beforeEach(function () {
                    // resolve all deferreds
                    rootScope.$apply();
                });

                it('should add task', function () {
                    expect(scope.tasks.length).toBe(2);
                });

                it('should set task description', function () {
                    expect(scope.tasks[1].task).toBe('New task');
                });

                it('should set responsible', function () {
                    expect(scope.tasks[1].responsible).toBe('Someone responsible');
                });

                it('should add unfinished task', function () {
                    expect(scope.tasks[1].done).toBe(false);
                });

                it('should reset saving flag', function () {
                    expect(scope.saving).toBe(false);
                });
            });
        });

        describe('failure', function () {
            beforeEach(function () {
                taskService.create = returnRejectedDeferred;

                scope.task = 'New task';
                scope.responsible = { name: 'Someone responsible' };
                scope.addTask();

                // resolve all deferreds
                rootScope.$apply();
            });

            it('should reset saving flag', function () {
                expect(scope.saving).toBe(false);
            })
        });
    });

    describe('cancel function', function () {
        beforeEach(function () {
            scope.addingTask = true;
            scope.task = 'Some task';
            scope.responsible = 'Someone';
            scope.cancel();
        });

        it('should reset addingTask flag', function () {
            expect(scope.addingTask).toBeFalsy();
        });

        it('should reset task', function () {
            expect(scope.task).toBe('');
        });

        it('should reset responsible', function () {
            expect(scope.responsible).toBe('');
        });
    });

    describe('click done function', function () {
        describe('successfully', function () {
            beforeEach(function () {
                scope.clickDone(0);

                // resolve all deferreds
                rootScope.$apply();
            });

            it('should change task to done', function () {
                expect(scope.tasks[0].done).toBe(true);
            });
        });

        describe('failed', function () {
            beforeEach(function () {
                taskService.changeDone = returnRejectedDeferred;
                scope.clickDone(0);

                // resolve all deferreds
                rootScope.$apply();
            });

            it('should not change task to done', function () {
                expect(scope.tasks[0].done).toBe(false);
            });
        });
    });

    describe('click remove function', function () {
        describe('successfully', function () {
            beforeEach(function () {
                scope.clickRemove(0);

                // resolve all deferreds
                rootScope.$apply();
            });

            it('should remove task', function () {
                expect(scope.tasks.length).toBe(0);
            });
        });

        describe('failed', function () {
            beforeEach(function () {
                taskService.delete = returnRejectedDeferred;
                scope.clickRemove(0);

                // resolve all deferreds
                rootScope.$apply();
            });

            it('should not remove task', function () {
                expect(scope.tasks.length).toBe(1);
            });
        });
    });
});