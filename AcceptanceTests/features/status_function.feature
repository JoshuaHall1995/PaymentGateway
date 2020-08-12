Feature: Status Endpoint
  Scenario: The status endpoint is up and running.
    Given The status endpoint is deployed
    When I call the status endpoint
    Then StatusCode 200 should be returned