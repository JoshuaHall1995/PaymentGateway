Feature: Process Payment Endpoint
  Scenario: Valid Payment Should Return Success
    Given A valid payment request
    When The payment is processed
    Then StatusCode 200 should be returned

  Scenario: InValid Payment Should Return Bad Request
    Given A invalid payment request
    When The payment is processed
    Then StatusCode 400 should be returned

  Scenario: Duplicate Payment Should Return Bad Request
    Given A duplicate payment request
    When The payment is processed
    Then StatusCode 400 should be returned

  Scenario: Valid Payment Unsuccessfully Processed
    Given A valid payment request
    When The payment is processed
    But The payment is unsuccessful
    Then StatusCode 400 should be returned

