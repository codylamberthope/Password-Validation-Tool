var UIFunctions = {
    Forms: {
        ValidatePassword: function ($form, inVersion) {
            var formData = $form.serialize();
            var handlerUrl = inVersion == 1 ? "/Home/ValidatePasswordOne" : "ValidatePasswordTwo";

            $.post(handlerUrl, formData, function (data) {
                // processing
            }).done(function (data) {
                if (data) {
                    $('#validation-results').html(data);
                }
            });
        }
    }
}