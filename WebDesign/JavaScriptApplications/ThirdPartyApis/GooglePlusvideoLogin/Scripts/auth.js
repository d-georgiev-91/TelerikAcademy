var helper = (function () {
    var BASE_API_PATH = 'plus/v1/';

    return {
        /**
        * Hides the sign in button and starts the post-authorization operations.
        *
        * @param {Object} authResult An Object which contains the access token and
        *   other authentication information.
        */
        onSignInCallback: function (authResult) {
            gapi.client.load('plus', 'v1', function () {
                $('#authResult').html('Auth Result:<br/>');
                for (var field in authResult) {
                    $('#authResult').append(' ' + field + ': ' +
                                            authResult[field] + '<br/>');
                }
                if (authResult['access_token']) {
                    $('#authOps').show('slow');
                    $('#gConnect').hide();
                    helper.profile();
                    //helper.people();
                    $("#video-player-container").show();
                }
                else if (authResult['error']) {
                    // There was an error, which means the user is not signed in.
                    // As an example, you can handle by writing to the console:
                    console.log('There was an error: ' + authResult['error']);
                    $('#authResult').append('Logged out');
                    $('#authOps').hide('slow');
                    $('#gConnect').show();
                    $("#video-player-container").hide();
                }
            });
        },

        /**
        * Calls the OAuth2 endpoint to disconnect the app for the user.
        */
        disconnect: function () {
            // Revoke the access token.
            $.ajax({
                type: 'GET',
                url: 'https://accounts.google.com/o/oauth2/revoke?token=' +
                     gapi.auth.getToken().access_token,
                async: false,
                contentType: 'application/json',
                dataType: 'jsonp',
                success: function (result) {
                    console.log('revoke response: ' + result);
                    $('#authOps').hide();
                    $('#profile').empty();
                    $('#visiblePeople').empty();
                    $('#authResult').empty();
                    $('#gConnect').show();
                    $("#video-player-container").hide();
                },
                error: function (e) {
                    console.log(e);
                }
            });
        },

        /**
        * Gets and renders the currently signed in user's profile data.
        */
        profile: function () {
            var request = gapi.client.plus.people.get({ 'userId': 'me' });
            request.execute(function (profile) {
                $('#profile').empty();
                if (profile.error) {
                    $('#profile').append(profile.error);
                    return;
                }
                $('#profile').append(
                    $('<h3>Profile photo</h3><p><img id="profile-photo" src=\"' + "https://plus.google.com/s2/photos/profile/me" + "?sz=450" + '\"></p>'));

                $('#profile').append(
                    $('<p>' + profile.displayName + '</p>'));
            });
        }
    };
})();

/**
* jQuery initialization
*/
$(document).ready(function () {
    $('#disconnect').click(helper.disconnect);
    $('#loaderror').hide();
    if ($('[data-clientid="YOUR_CLIENT_ID"]').length > 0) {
        alert('This sample requires your OAuth credentials (client ID) ' +
              'from the Google APIs console:\n' +
              '    https://code.google.com/apis/console/#:access\n\n' +
              'Find and replace YOUR_CLIENT_ID with your client ID.'
        );
    }
});

/**
* Calls the helper method that handles the authentication flow.
*
* @param {Object} authResult An Object which contains the access token and
*   other authentication information.
*/
function onSignInCallback(authResult) {
    helper.onSignInCallback(authResult);
}