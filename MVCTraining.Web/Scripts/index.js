$(function () {
  $('form').submit(function () {
    if ($(this).valid()) {
      $.ajax({
        url: this.action,
        type: this.method,
        data: $(this).serialize(),
        success: function (result) {
          $('#divResult').html(result);
        }
      });
    }
    return false;
  });
});