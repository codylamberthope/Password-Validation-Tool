$(document).on('click', '[data-show-password]', function () {
    UIFunctions.Forms.ShowPassword($(this));
})

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
        },
        ShowPassword: function ($this) {
            var $input = $('[name="' + $this.data('show-password') + '"]');


            if ($input.attr('type') == "password") {
                $input.attr('type', 'text');
            } else {
                $input.attr('type', 'password');
            }


            $this.toggleClass('fa-eye');
            $this.toggleClass('fa-eye-slash');
        }
    }
}