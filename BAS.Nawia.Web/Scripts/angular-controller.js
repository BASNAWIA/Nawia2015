
'use strict';

angular.module('Nawia', ['ng', 'ngResource', 'ngSanitize'])

  /**
   * Form controller for a new Nawia subscription.
   */
  .controller('NawiaSubscriptionCtrl', ['$log', '$resource', '$scope',
              function ($log, $resource, $scope) {
                  // Handle clicks on the form submission.
                  $scope.addSubscription = function (Nawia) {
                      var actions,
                          NawiaSubscription,
                          params = {},
                          url;

                      // Create a resource for interacting with the Nawia API
                      url = '//' + Nawia.username + '.' + Nawia.dc +
                            '.list-manage.com/subscribe/post-json';

                      var fields = Object.keys(Nawia);

                      for (var i = 0; i < fields.length; i++) {
                          params[fields[i]] = Nawia[fields[i]];
                      }

                      params.c = 'JSON_CALLBACK';

                      actions = {
                          'save': {
                              method: 'jsonp'
                          }
                      };
                      NawiaSubscription = $resource(url, params, actions);

                      // Send subscriber data to Nawia
                      NawiaSubscription.save(
                        // Successfully sent data to Nawia.
                        function (response) {
                            // Define message containers.
                            Nawia.errorMessage = '';
                            Nawia.successMessage = '';

                            // Store the result from Nawia
                            Nawia.result = response.result;

                            // Nawia returned an error.
                            if (response.result === 'error') {
                                if (response.msg) {
                                    // Remove error numbers, if any.
                                    var errorMessageParts = response.msg.split(' - ');
                                    if (errorMessageParts.length > 1)
                                        errorMessageParts.shift(); // Remove the error number
                                    Nawia.errorMessage = errorMessageParts.join(' ');
                                } else {
                                    Nawia.errorMessage = 'Sorry! An unknown error occured.';
                                }
                            }
                                // Nawia returns a success.
                            else if (response.result === 'success') {
                                Nawia.successMessage = response.msg;
                            }
                        },

                        // Error sending data to Nawia
                        function (error) {
                            $log.error('Nawia Error: %o', error);
                        }
                      );
                  };
              }]);