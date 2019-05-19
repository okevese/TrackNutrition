// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {
  // Wire up all daily entries to delete
  $('.todelete').on('click', function(e) {
    removed(e.target);
  });
});

function removed(checkbox) {
  checkbox.disabled = true;
  var row = checkbox.closest('tr');
  $(row).addClass('deleted');

  var form = checkbox.closest('form');
  form.submit();
}