/*
 * JS Helper to execute java scripts via Interops
 */
(function () {

    window.R = (command) => {
        try {
            eval(command);
        } catch (exception) {
            console.log(exception);
        }
       
    };
})();
