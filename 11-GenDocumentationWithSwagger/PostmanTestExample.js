pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
    console.log(pm.response);
});

pm.test("Author returned must match requested author", function () {
    var jsonData = pm.response.json();
    pm.expect(jsonData.id).to.equal("2902b665-1190-4c70-9915-b9c2d7680450")
});

// BEGIN - we can add in the pre-request script
var responseTimeTest = () => pm.test("response time bellow 300ms", function () {
    pm.expect(pm.response.responseTime).to.be.below(300)
});

// pm.environment
pm.globals.set("responseTimeTest", responseTimeTest.toString());
// END - we can add in the pre-request script 


// this test can be used in all other APIs
eval(pm.globals.get("responseTimeTest"))();

