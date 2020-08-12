Feature: Get Payment Details Endpoint
  Scenario: Get Existing Successful Payment
    Given An existing successful payment
    When The payment is requested
    Then StatusCode 200 should be returned
    And The expected details returned

  Scenario: Get Existing Failed Payment
    Given An existing failed payment
    When The payment is requested
    Then StatusCode 200 should be returned
    And The expected details returned

  Scenario: Non Existent Payment
    Given An non-existing payment
    When The payment is requested
    Then StatusCode 404 should be returned
