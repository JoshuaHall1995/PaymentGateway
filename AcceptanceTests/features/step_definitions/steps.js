var {Given, When, Then} = require('cucumber');
const assert = require('assert')
const fetch = require("node-fetch");
const { v4: uuidv4 } = require('uuid');

require('dotenv').config()

var response;

Given(/^The status endpoint is deployed$/, function () {

});

When(/^I call the status endpoint$/,  async function () {
    await fetch
    (process.env.BASEPATH + '/status' +
        '?code=' + process.env.HOSTKEY)
        .then(res => response = res.status);
});


Then(/^StatusCode (\d+) should be returned$/, function (expectedCode) {
    assert.deepStrictEqual(response, expectedCode)
});