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

console.log(fib(35));
console.log('Time: ' + (new Date() - now));

if (typeof phantom != 'undefined') phantom.exit(0);
