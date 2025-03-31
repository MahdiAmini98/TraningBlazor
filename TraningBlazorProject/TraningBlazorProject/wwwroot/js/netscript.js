
window.calculateSum = function (a, b) {
    /*var result = a + b;*/
    //DotNet.invokeMethodAsync
    //DotNet.invokeMethod


    DotNet.invokeMethodAsync("TraningBlazorProject.Client", "myAddNumber", a, b)
        .then(result => {
            alert(`The sum is: ${result}`)
        });

}