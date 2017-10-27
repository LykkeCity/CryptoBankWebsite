var app = app || {};

(function FeedbackForm($, doc) {

    var FeedbackForm = {

        submit: function (theform) {
            var feedbackForm = $(theform).parents('form');

            $.ajax({
                type: "POST",
                url: feedbackForm.attr('action'),
                data: feedbackForm.serialize(),
                success: function (response) {
                    toastr["success"](response, "Info");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    toastr["error"]("Something went wrong :(<br>Please, try again later...", "Error");
                }
            });
        }
    };

    app.FeedbackForm = FeedbackForm;
})(jQuery, document);
