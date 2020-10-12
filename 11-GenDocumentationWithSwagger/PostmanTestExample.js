pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
    console.log(pm.response);
});

pm.test("Author returned must match requested author", function () {
    var jsonData = pm.response.json();
    pm.expect(jsonData.id).to.equal("2902b665-1190-4c70-9915-b9c2d7680450")
});
