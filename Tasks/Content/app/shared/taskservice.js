(function (app) {
    'use strict';

    app.factory(
        'TaskService',
        [
            '$http',
            function ($http) {
                var url = 'api/task';
                return {
                    create: function (task) {
                        return $http.post(
                            url,
                            {
                                task: task.task,
                                responsible: task.responsible,
                                done: task.done
                            });
                    },
                    delete: function (task) {
                        return $http.delete(
                            url,
                            {
                                params: {
                                    task: task.task,
                                    responsible: task.responsible,
                                }
                            });
                    },
                    changeDone: function (task) {
                        return $http.put(
                            url,
                            {
                                task: task.task,
                                responsible: task.responsible,
                                done: !task.done
                            });
                    }
                };
            }]);
})(window.App);