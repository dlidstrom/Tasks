(function (app) {
    'use strict';

    app.controller(
        'TasksCtrl',
        [
            '$scope',
            '$log',
            'InitialData',
            'TaskService',
            function ($scope, $log, initialData, taskService) {
                $scope.people = initialData.people;

                $scope.tasks = initialData.tasks;

                $scope.allTasksDone = function () {
                    for (var i in $scope.tasks) {
                        if ($scope.tasks[i].done == false) return false;
                    }

                    return true;
                };

                $scope.addTask = function () {
                    var task = {
                        task: $scope.task,
                        responsible: $scope.responsible.name,
                        done: false
                    };
                    $scope.saving = true;
                    taskService.create(task)
                        .then(function () {
                            $scope.tasks.push(task);

                            // close editor
                            $scope.addingTask = false;
                            $scope.task = '';
                            $scope.responsible = '';

                            $scope.saving = false;
                        }, function () {
                            $scope.saving = false;
                        });
                };

                $scope.cancel = function () {
                    $scope.addingTask = false;
                    $scope.task = '';
                    $scope.responsible = '';
                };

                $scope.clickDone = function (index) {
                    var oldTask = $scope.tasks[index];
                    var oldDone = oldTask.done;
                    taskService.changeDone(oldTask)
                        .then(
                            function () {
                                // success
                                oldTask.done = !oldDone;
                            },
                            function () {
                                // error
                                oldTask.done = oldDone;
                            });
                };

                $scope.clickRemove = function (index) {
                    var task = $scope.tasks[index];
                    taskService.delete(task)
                        .then(function () {
                            $scope.tasks.splice(index, 1);
                        }, function () {
                            $log.error('Failed to remove task');
                        });
                };
            }]);
})(window.App);