var system = require('system');

if (system.args.length < 2) {
    console.log('Usage: ' + system.args[0] + ' number');
    phantom.exit(1);
}

var now = new Date();
var memento = function (memo, f) {
    var recur = function (n) {
        var result = memo[n];
        if (typeof result !== 'number') {
            result = f(recur, n);
            //memo[n] = result;
        }
        return result;
    };
    return recur;
};

var fib = memento([0, 1], function (recur, n) {
    return recur(n - 1) + recur(n - 2);
});

console.log(fib(system.args[1]));
console.log('Time: ' + (new Date() - now));

phantom.exit(0);
